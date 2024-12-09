from flask import Flask, request, jsonify
import joblib
import os
from nltk.corpus import stopwords
from nltk.stem import WordNetLemmatizer
from sklearn.feature_extraction.text import TfidfVectorizer  # Import sklearn
from sklearn.base import BaseEstimator  # Import sklearn

# Initialization
app = Flask(__name__)

# Load models
model_path = os.path.join(os.path.dirname(__file__), 'models', 'optimized_text_classification_model.pkl')
vectorizer_path = os.path.join(os.path.dirname(__file__), 'models', 'tfidf_vectorizer.pkl')
model = joblib.load(model_path)
vectorizer = joblib.load(vectorizer_path)

# Preprocess text
stop_words = set(stopwords.words('english'))
lemmatizer = WordNetLemmatizer()

def preprocess_text(text):
    words = text.split()
    words = [lemmatizer.lemmatize(word.lower()) for word in words if word.lower() not in stop_words]
    return " ".join(words)

@app.route('/predict', methods=['POST'])
def predict():
    data = request.get_json()
    if not data or 'text' not in data:
        return jsonify({"error": "Invalid input. 'text' is required."}), 400
    
    text = data['text']
    processed_text = preprocess_text(text)
    text_tfidf = vectorizer.transform([processed_text])
    prediction = model.predict(text_tfidf)
    
    return jsonify({"prediction": prediction[0]})

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5174)
