from flask import Flask, request, jsonify
from flask_cors import CORS  # Importiere CORS, um Cross-Origin Resource Sharing zu ermöglichen
from transformers import AutoTokenizer, AutoModelForSequenceClassification
import torch
import torch.nn.functional as F

app = Flask(__name__)
CORS(app)  # CORS für die gesamte App aktivieren

# Laden des vortrainierten Modells und Tokenizers für Sentiment-Analyse
model_name = "distilbert-base-uncased-finetuned-sst-2-english"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForSequenceClassification.from_pretrained(model_name)

# Funktion zur Zuordnung der Sentiment-Intensität zu einer Risikoskala von 1 bis 10
def sentiment_to_risk_scale(probability, is_positive):
    if is_positive:
        return max(1, int((1 - probability) * 10))
    else:
        if probability < 0.4:
            return 3  # Geringes Risiko
        elif probability < 0.7:
            return 6  # Moderates Risiko
        else:
            return 9  # Hohes Risiko

@app.route("/analyze", methods=["POST"])
def analyze_sentiment():
    data = request.json
    text = data.get("text", "")
    
    # Tokenisiere den Eingabetext
    inputs = tokenizer(text, return_tensors="pt", truncation=True, padding=True)

    # Inferenz durchführen, um die Logits zu erhalten
    with torch.no_grad():
        outputs = model(**inputs)

    # Extrahiere Logits und wende Softmax an, um Wahrscheinlichkeiten zu erhalten
    logits = outputs.logits
    probs = F.softmax(logits, dim=1)
    predicted_class = torch.argmax(probs, dim=1).item()
    predicted_prob = probs[0][predicted_class].item()

    # Bestimme das Sentiment und berechne das Risikoniveau
    if predicted_class == 1:
        sentiment = "Positive"
        risk_score = sentiment_to_risk_scale(predicted_prob, is_positive=True)
    else:
        sentiment = "Negative"
        risk_score = sentiment_to_risk_scale(predicted_prob, is_positive=False)

    # Ergebnisse als JSON zurückgeben
    return jsonify({"sentiment": sentiment, "risk_score": risk_score})

if __name__ == "__main__":
    app.run(debug=True)