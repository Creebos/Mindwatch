# Project Blog

## Week 07

**1. PHQ-9 (Patient Health Questionnaire)**

The PHQ-9 is a standard tool for diagnosing depression. It consists of nine items that measure how frequently a person has experienced symptoms such as lack of interest, fatigue, or feelings of worthlessness over the past two weeks. Responses are scored on a scale from 0 to 3:

    •	0: Not at all
    •	1: Several days
    •	2: More than half the days
    •	3: Nearly every day

A total score of 0–27 is calculated, with higher scores indicating more severe depression:

    •	0-4: Minimal depression
    •	5-9: Mild depression
    •	10-14: Moderate depression
    •	15-19: Moderately severe depression
    •	20-27: Severe depression

**2. GAD-7 (Generalized Anxiety Disorder Scale)**

The GAD-7 is used to screen for generalized anxiety disorder (GAD) through seven questions focusing on feelings of nervousness, worry, and irritability over the past two weeks. Responses are scored similarly to the PHQ-9, from 0 (not at all) to 3 (nearly every day), with a total score ranging from 0 to 21:

    •	0-4: Minimal anxiety
    •	5-9: Mild anxiety
    •	10-14: Moderate anxiety
    •	15-21: Severe anxiety

**3. Maslach Burnout Inventory (MBI)**

The MBI is specifically designed to measure burnout in professionals, assessing three key dimensions:

    •	Emotional Exhaustion: Feeling emotionally drained by work.
    •	Depersonalization: Developing a cynical attitude towards colleagues or clients.
    •	Personal Accomplishment: Feeling ineffective or unproductive at work.

Each dimension is scored using a Likert scale from 0 (never) to 6 (every day). High emotional exhaustion and depersonalization scores, combined with low personal accomplishment, indicate burnout.

**4. PSQ (Perceived Stress Questionnaire)**

The PSQ measures perceived stress levels based on how frequently a person experiences feelings of tension, overload, and lack of control in daily life. Responses are rated on a scale from 1 (almost never) to 4 (almost always). The average score reflects the individual’s overall stress level:

    •	0.0-0.3: Low stress
    •	0.4-0.7: Moderate stress
    •	0.7 and above: High stress

**Data Preprocessing and Analysis**

The qualitative and quantitative responses collected from these questionnaires will be preprocessed and converted into a machine-readable format. Techniques such as Natural Language Processing (NLP) for textual responses and scaling algorithms for numerical responses will be applied to extract meaningful features.

**Machine Learning Integration**

Using the data from the questionnaires, we plan to build a predictive model using supervised learning to classify participants into categories based on their mental health status (e.g., “depressed”, “stressed”, “burned out”). Unsupervised learning methods like clustering will help detect hidden patterns and anomalies in the data that may indicate underlying mental health issues.

**Future Development**

In this project, participants do not select predefined answers like multiple-choice options. Instead, they provide free-text responses to open-ended questions about their mental health, work environment, or stress levels. Afterward, the AI will automatically analyze these free-text answers to assess the participants’ mental health using advanced Natural Language Processing (NLP) techniques.

Here’s how it works:

> Participants: Instead of choosing from set options (e.g., “Are you feeling stressed: Yes, No, Sometimes”), participants write detailed responses in their own words.

> AI Processing: The AI will apply NLP techniques such as Sentiment Analysis, Topic Modeling, and Named Entity Recognition (NER) to extract meaningful insights from the text. For instance, it will identify emotional tone, key topics (e.g., stress, workload), and potential signs of depression or burnout without requiring the participant to label these themselves.

> Scoring: Based on these analyses, the AI will assign a score or category that reflects the individual’s mental health condition, such as levels of anxiety, stress, or burnout, as detected in their written responses.

This method allows for a more natural and nuanced expression of how participants feel, and the AI handles the burden of categorization and analysis afterward, ensuring accuracy and minimizing bias.

By utilizing these well-researched tools, we aim to provide an efficient, accurate, and privacy-preserving approach to mental health detection in the workplace.

### References

1. Thombs, B. D., Benedetti, A., Kloda, L. A., Levis, B., Nicolau, I., Cuijpers, P., Gilbody, S., Ioannidis, J. P. A., McMillan, D., Patten, S. B., Shrier, I., Steele, R. J., & Ziegelstein, R. C. (2014). The diagnostic accuracy of the Patient Health Questionnaire-2 (PHQ-2), Patient Health Questionnaire-8 (PHQ-8), and Patient Health Questionnaire-9 (PHQ-9) for detecting major depression: protocol for a systematic review and individual patient data meta-analyses. Systematic Reviews, 3(1), 124–124. https://doi.org/10.1186/2046-4053-3-124
2. WILLIAMS, N. (2014). The GAD-7 questionnaire. Occupational Medicine (Oxford), 64(3), 224–224. https://doi.org/10.1093/occmed/kqt161
3. De Beer, L. T., van der Vaart, L., Escaffi-Schwarz, M., De Witte, H., & Schaufeli, W. B. (2024). Maslach Burnout Inventory - General Survey: A Systematic Review and Meta-Analysis of Measurement Properties. European Journal of Psychological Assessment : Official Organ of the European Association of Psychological Assessment, 40(5), 360–375. https://doi.org/10.1027/1015-5759/a000797
4. Fliege, H., Rose, M., Arck, P., Walter, O. B., Kocalevent, R. D., Weber, C., et al. (2005). ThePerceived Stress Questionnaire (PSQ) reconsidered: validation and reference valuesfrom different clinical and healthy adult samples. Psychosom. Med. 67, 78–88. https://doi.org/10.1097/01.psy.0000151491.80178.78

## Week 08 / Week 09

**Introduction**

>In this post, we’ll explore how to create a simple yet powerful web application that uses sentiment analysis to evaluate mental health responses. This project utilizes HTML, CSS, JavaScript, and Python’s Flask framework. The web app not only analyzes responses but displays personalized feedback through an animated progress bar and shows a department-wide summary for cumulative results.
Here’s a breakdown of how we built this engaging web app, along with the steps we followed.


**1. Setting Up the Backend with Flask and Sentiment Analysis**

Our application is powered by a Python backend, using Flask to create an API that interacts with the frontend. For sentiment analysis, we used the Hugging Face Transformers library. Specifically, we deployed the distilbert-base-uncased-finetuned-sst-2-english model, which is designed to classify text as positive or negative. Here’s how this backend works:
	•	API Route: We created an endpoint /analyze that takes a text response, processes it through the model, and returns a sentiment (either “positive” or “negative”) along with a risk score.
	•	Flask and CORS: Flask serves as the web framework, and flask-cors enables cross-origin resource sharing, allowing the frontend to interact smoothly with the backend.

After setting up the backend, we had a working API that could analyze text and provide sentiment-based feedback.

**2. Designing the Frontend Layout with HTML and CSS**

To make our application intuitive and visually appealing, we organized the frontend into several sections:
	1.	Navbar: A fixed navigation bar lets users switch between the home, results, and contact pages.
	2.	Landing Page: This introductory page gives an overview of the app and allows users to select their department and begin the test.
	3.	Questionnaire: Each question is displayed one by one, with a prompt to analyze user responses and advance to the next question.
	4.	Assessment Result: After answering all questions, users see a result page with a color-changing progress bar that fills up to reflect the result.
	5.	Department Summary: The app provides a cumulative summary showing positive and negative responses for each department.

Each section of our layout was styled with CSS to provide a consistent, clean, and user-friendly interface. Here are some highlights of the CSS design:
	•	Navbar Styling: We applied dark background colors with white text, and the logo and navigation links use hover effects for a polished look.
	•	Containers and Buttons: Using shadows, rounded corners, and subtle color transitions, we created a modern feel for the main containers and buttons.
	•	Responsive Design: We included media queries to ensure the app looks great on smaller screens, adjusting padding and font sizes for readability.

**3. Creating an Animated Progress Bar**

To add some interactive visual feedback, we implemented a progress bar that fills up when the assessment result is displayed. This progress bar dynamically changes color based on the analysis result—green for positive feedback and red for negative.
	•	CSS Transition: The progress bar uses a CSS transition on the width property, which animates its filling effect over 2 seconds.
	•	JavaScript Logic: When the result is generated, JavaScript sets the progress bar’s width to 100% with a slight delay, triggering the filling animation. We also adjust the color based on whether the assessment is positive or negative, giving users instant visual feedback.

 **4. Displaying a Department Results Summary**

The app also includes a department-wide results summary that visually represents the total positive and negative responses per department. Here’s how it works:
	•	JavaScript Data Collection: For each test, the app logs the department and the result (positive or negative). This data is stored in an object where each department has a count of positive and negative responses.
	•	Result Bars: Each department’s result is displayed as a colored bar, with green indicating positive responses and red for negative. These bars are dynamically generated in JavaScript, adjusting their width based on the department’s overall positive-to-negative ratio.
	•	CSS Styling: The .positive and .negative classes style each result bar, and we apply the widths dynamically via JavaScript.

 **5. Enhancing User Experience with JavaScript**

JavaScript plays a crucial role in this project, as it enables smooth page transitions, animations, and interactivity. Some key functionalities implemented in JavaScript include:
	Page Transitions:
 We use JavaScript to hide and show different sections, ensuring a seamless user flow as they move from the landing page to the questionnaire, then to the results.
	Error Handling:
Alerts notify users if they try to proceed without selecting a department or providing an answer.
	Asynchronous API Calls:
JavaScript sends each response to the Flask API, receives the sentiment analysis, and updates the department results based on this feedback.

 **Final Thoughts**

By combining Flask, sentiment analysis, and frontend development techniques, we built a web app that offers personalized feedback and provides an aggregated view of department-wide results. This project demonstrates how we can create an engaging user experience by incorporating animated feedback, cumulative analytics, and interactive elements.

Whether you’re a developer interested in building sentiment analysis tools or just curious about combining Python and JavaScript, this app offers a practical guide for using these tools together. Feel free to expand this project further with additional features, like saving historical data or refining the sentiment analysis with custom-trained models.

## Week 10

**Building Our Own Custom Sentiment Analysis Model**

>In previous weeks, we explored pre-trained models like distilbert-base-uncased-finetuned-sst-2-english for sentiment analysis. While these models are powerful, they may not fully capture the unique nuances of mental health-related text responses. This week, we took a significant step forward by building a custom sentiment analysis model tailored specifically to our dataset.

By doing this, we aim to:

	•	Improve accuracy for specific mental health categories.
	•	Reduce the bias present in generalized pre-trained models.
	•	Gain better insights into how the model interprets mental health-related language.
 

**Why Create a Custom Model?**

Pre-trained models are excellent for generic tasks like determining sentiment polarity (positive/negative). However, mental health analysis often requires more **nuance**:

	Complex Categories: 		Responses may fall into categories like Anxiety, Depression, Stress, or Burnout.
	Domain-Specific Vocabulary: 	Phrases and expressions in mental health contexts can differ significantly from those in social media or movie reviews.

A custom model allows us to train specifically on our dataset, ensuring better alignment with our goals.

**Steps to Build the Model**

1. Data Preparation

We started with a cleaned and processed dataset, which included:

	Text Responses: User-provided answers to mental health questions.
	Labels: Categories like Anxiety, Depression, Normal, and more.

We split the data into:

	Training Set (80%): 	For training the model.
	Test Set (20%):		For evaluation.

 2. Feature Extraction with TF-IDF

To convert text into numerical data, we used TF-IDF (Term Frequency-Inverse Document Frequency). This technique highlights important words in each response relative to the entire dataset.

```python
from sklearn.feature_extraction.text import TfidfVectorizer

vectorizer = TfidfVectorizer(max_features=5000)
X_train_tfidf = vectorizer.fit_transform(X_train)
X_test_tfidf = vectorizer.transform(X_test)
```

**Challenges and Future Plans**

Challenges:

	1.	Class Imbalance: Some categories, like Stress and Personality Disorder, had fewer examples, leading to weaker performance.
	2.	Overlapping Categories: Responses often contained language relevant to multiple emotions, making classification harder.

Future Improvements:

	•	Handle Class Imbalance: Use techniques like oversampling (e.g., SMOTE) or collect more data for underrepresented classes.
	•	Use Word Embeddings: Replace TF-IDF with advanced techniques like Word2Vec or GloVe.
	•	Fine-Tune Transformers: Train pre-trained models like BERT on our dataset to improve contextual understanding.
	•	Hybrid Approach: Combine machine learning with rule-based NLP techniques for better interpretability.

**Conclusion**

Creating a custom sentiment analysis model was an exciting milestone in our project. While we achieved a **67% accuracy**, this is just the beginning. By addressing class imbalances, incorporating more sophisticated NLP techniques, and fine-tuning transformer models, we aim to significantly improve performance in the coming weeks.

Next, we’ll **deploy this custom model into our web application** and gather real-world feedback. Stay tuned as we continue advancing mental health analysis with AI!

 
