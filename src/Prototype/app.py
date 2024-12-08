from flask import Flask, render_template, request, jsonify
import joblib
import os
import nltk
from nltk.corpus import stopwords
from nltk.stem import WordNetLemmatizer

# Initialisierung von NLTK
nltk.download('stopwords')
nltk.download('wordnet')

app = Flask(__name__)

# Absoluten Pfad zu den Modellen definieren
model_path = os.path.join(os.path.dirname(__file__), 'models', 'optimized_text_classification_model.pkl')
vectorizer_path = os.path.join(os.path.dirname(__file__), 'models', 'tfidf_vectorizer.pkl')

# Modelle und Vektorisierer laden
model = joblib.load(model_path)
vectorizer = joblib.load(vectorizer_path)

# Textvorverarbeitung
stop_words = set(stopwords.words('english'))
lemmatizer = WordNetLemmatizer()

def preprocess_text(text):
    words = text.split()
    words = [lemmatizer.lemmatize(word.lower()) for word in words if word.lower() not in stop_words]
    return " ".join(words)

# Globale Variable zum Speichern von Umfrageergebnissen
survey_results = []

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/survey', methods=['GET', 'POST'])
def survey():
    if request.method == 'POST':
        data = request.get_json()
        department = data.get('department')
        answers = data.get('answers', [])

        # Emotionen aggregieren
        states = {
            'Normal': 0, 'Depression': 0, 'Suicidal': 0, 'Anxiety': 0,
            'Stress': 0, 'Bi-Polar': 0, 'Personality Disorder': 0
        }

        for answer in answers:
            processed_text = preprocess_text(answer)
            text_tfidf = vectorizer.transform([processed_text])
            prediction = model.predict(text_tfidf)
            if prediction[0] in states:
                states[prediction[0]] += 1

        # Speichern der Ergebnisse
        survey_results.append({'department': department, 'states': states})

        # Feedback generieren
        max_state = max(states, key=states.get)
        feedback = generate_feedback(max_state)

        return jsonify({'states': states, 'feedback': feedback})
    return render_template('survey.html')

@app.route('/results')
def results():
    grouped_results = {}
    for entry in survey_results:
        department = entry.get('department', 'Unknown')
        if department not in grouped_results:
            grouped_results[department] = {
                'Normal': 0, 'Depression': 0, 'Suicidal': 0, 'Anxiety': 0,
                'Stress': 0, 'Bi-Polar': 0, 'Personality Disorder': 0
            }
        for key in grouped_results[department]:
            grouped_results[department][key] += entry['states'].get(key, 0)
    return render_template('results.html', grouped_results=grouped_results)

def generate_feedback(max_state):
    feedback_messages = {
        'Normal': "Your mental health seems stable. Keep maintaining a balanced work-life routine!",
        'Depression': "It seems you're experiencing signs of depression. Please consider reaching out for support.",
        'Suicidal': "Your responses indicate serious distress. It's important to seek immediate help or talk to someone you trust.",
        'Anxiety': "Signs of anxiety were detected. Managing stress and seeking support could be beneficial.",
        'Stress': "You're experiencing high levels of stress. Taking breaks and prioritizing self-care is important.",
        'Bi-Polar': "Your responses indicate potential bipolar tendencies. Professional support can help manage these feelings.",
        'Personality Disorder': "There are signs of personality challenges. A mental health professional could provide guidance."
    }
    return feedback_messages.get(max_state, "Your mental health assessment is inconclusive. Please take care and reach out if needed.")

if __name__ == '__main__':
    app.run(debug=True)