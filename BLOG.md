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

### Software Engineering

This week, the base setup for the application was established, consisting of three Docker containers: one for the backend, one for the frontend, and one for the SQL Server. Docker Compose was used to coordinate these containers, ensuring proper network connectivity and seamless interaction between them.

For the frontend, implementing a fast reload feature presented a small challenge aimed at refining the setup. This feature allows changes in the source code to be instantly reflected in the running instance during development mode, but achieving it required more than just a straightforward configuration. It was somewhat challenging because Docker typically copies files into the container and compiles them, which can be limiting since it operates in a virtualized environment. The solution involved utilizing Docker's support for mounted volumes. By mounting the source code from the developer's machine directly into the Docker container, Vite was able to build, watch, and run the application effectively in real time.

## Week 08 / Week 09

**Introduction (Building a Prototype)**

> In this post, we’ll explore how to create a simple yet powerful web application that uses sentiment analysis to evaluate mental health responses. This project utilizes HTML, CSS, JavaScript, and Python’s Flask framework. The web app not only analyzes responses but displays personalized feedback through an animated progress bar and shows a department-wide summary for cumulative results.
> Here’s a breakdown of how we built this engaging web app, along with the steps we followed.

**1. Setting Up the Backend with Flask and Sentiment Analysis**

Our application is powered by a Python backend, using Flask to create an API that interacts with the frontend. For sentiment analysis, we used the Hugging Face Transformers library. Specifically, we deployed the distilbert-base-uncased-finetuned-sst-2-english model, which is designed to classify text as positive or negative. Here’s how this backend works:
• API Route: We created an endpoint /analyze that takes a text response, processes it through the model, and returns a sentiment (either “positive” or “negative”) along with a risk score.
• Flask and CORS: Flask serves as the web framework, and flask-cors enables cross-origin resource sharing, allowing the frontend to interact smoothly with the backend.

After setting up the backend, we had a working API that could analyze text and provide sentiment-based feedback.

**2. Designing the Frontend Layout with HTML and CSS**

To make our application intuitive and visually appealing, we organized the frontend into several sections: 1. Navbar: A fixed navigation bar lets users switch between the home, results, and contact pages. 2. Landing Page: This introductory page gives an overview of the app and allows users to select their department and begin the test. 3. Questionnaire: Each question is displayed one by one, with a prompt to analyze user responses and advance to the next question. 4. Assessment Result: After answering all questions, users see a result page with a color-changing progress bar that fills up to reflect the result. 5. Department Summary: The app provides a cumulative summary showing positive and negative responses for each department.

Each section of our layout was styled with CSS to provide a consistent, clean, and user-friendly interface. Here are some highlights of the CSS design:
• Navbar Styling: We applied dark background colors with white text, and the logo and navigation links use hover effects for a polished look.
• Containers and Buttons: Using shadows, rounded corners, and subtle color transitions, we created a modern feel for the main containers and buttons.
• Responsive Design: We included media queries to ensure the app looks great on smaller screens, adjusting padding and font sizes for readability.

**3. Creating an Animated Progress Bar**

To add some interactive visual feedback, we implemented a progress bar that fills up when the assessment result is displayed. This progress bar dynamically changes color based on the analysis result—green for positive feedback and red for negative.
• CSS Transition: The progress bar uses a CSS transition on the width property, which animates its filling effect over 2 seconds.
• JavaScript Logic: When the result is generated, JavaScript sets the progress bar’s width to 100% with a slight delay, triggering the filling animation. We also adjust the color based on whether the assessment is positive or negative, giving users instant visual feedback.

**4. Displaying a Department Results Summary**

The app also includes a department-wide results summary that visually represents the total positive and negative responses per department. Here’s how it works:
• JavaScript Data Collection: For each test, the app logs the department and the result (positive or negative). This data is stored in an object where each department has a count of positive and negative responses.
• Result Bars: Each department’s result is displayed as a colored bar, with green indicating positive responses and red for negative. These bars are dynamically generated in JavaScript, adjusting their width based on the department’s overall positive-to-negative ratio.
• CSS Styling: The .positive and .negative classes style each result bar, and we apply the widths dynamically via JavaScript.

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

> In previous weeks, we explored pre-trained models like distilbert-base-uncased-finetuned-sst-2-english for sentiment analysis. While these models are powerful, they may not fully capture the unique nuances of mental health-related text responses. This week, we took a significant step forward by building a custom sentiment analysis model tailored specifically to our dataset.

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

2.  Feature Extraction with TF-IDF

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

### Software Engineering

In this week our Application was designed and structure of our Data created. The design is of course a first version and might need some adjustments further in the development process.

## UPDATE: Week 10

**What We Improved:**

**Efficient Training**
• Before: The model was trained in a for loop across 1000 iterations, restarting the training process every time.
• After: The loop was removed, and we now train the model once with a clear stopping condition using max_iter=1000 in the solver configuration. The built-in verbose=1 parameter provides progress updates directly.
Why it matters: This change reduced computational overhead significantly, making training faster and cleaner.

**Optimized Scaling for Sparse Data**

    Before: We used StandardScaler, which expects dense matrices and isn’t suitable for the sparse data produced by TF-IDF vectorization.
    After: We replaced it with MaxAbsScaler, a scaler designed specifically for sparse data. It ensures feature scaling without unnecessary memory overhead.

Why it matters: This adjustment made the pipeline more efficient and better aligned with the data structure.

**Streamlined Preprocessing**

    Before: 	The preprocessing function worked but didn’t handle leading/trailing spaces consistently after cleaning.
    After: 		We introduced a simple .strip() to remove unnecessary spaces at the beginning and end of strings after transformations.

Why it matters: Cleaner input ensures more consistent results and avoids subtle issues that could arise from irregular spacing.

**Simplified Progress Tracking**

    Before: A custom progress tracking solution using tqdm was implemented in an unnecessary loop around the training process.
    After: Progress updates are now handled by the verbose=1 option in the Logistic Regression solver (saga), eliminating the need for additional custom logic.

Why it matters: This change reduces code complexity and leverages built-in library features, making the code easier to maintain and extend.

```python
#Logistic Regression Model
import pandas as pd
import re
from sklearn.model_selection import train_test_split
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.linear_model import LogisticRegression
from sklearn.preprocessing import MaxAbsScaler
from sklearn.metrics import classification_report
from tqdm import tqdm

# 1. Load the data
file_path = '/Users/dennisriccardo/Downloads/processed_combined_data.csv'  # Adjust the file path as needed
data = pd.read_csv(file_path)

# 2. Text preprocessing
def preprocess_text(text):
   text = text.lower()  # Convert to lowercase
   text = re.sub(r'\W', ' ', text)  # Remove special characters
   text = re.sub(r'\s+', ' ', text)  # Remove extra spaces
   return text.strip()  # Remove leading/trailing spaces

data['processed_statement'] = data['processed_statement'].dropna().apply(preprocess_text)

# 3. Remove invalid or empty texts
data = data.dropna(subset=['processed_statement'])  # Drop rows where 'processed_statement' is NaN
data = data[data['processed_statement'].str.strip().astype(bool)]  # Keep rows with non-empty text

# 4. Extract text and label data
X = data['processed_statement']  # Input text data
y = data['status']  # Corresponding labels/classes

# 5. Split into training and testing data
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# 6. TF-IDF vectorization
vectorizer = TfidfVectorizer(max_features=5000)  # Limit to 5000 most important features
X_train_tfidf = vectorizer.fit_transform(X_train)  # Fit and transform training data
X_test_tfidf = vectorizer.transform(X_test)  # Transform test data

# 7. Scale the data (using MaxAbsScaler optimized for sparse data)
scaler = MaxAbsScaler()
X_train_tfidf_scaled = scaler.fit_transform(X_train_tfidf)
X_test_tfidf_scaled = scaler.transform(X_test_tfidf)

# 8. Train the model
print("Training Logistic Regression model...")

model = LogisticRegression(max_iter=1000, solver='saga', verbose=1)  # `verbose=1` shows solver progress
model.fit(X_train_tfidf_scaled, y_train)  # Train the model once

# 9. Evaluate the model
predictions = model.predict(X_test_tfidf_scaled)  # Predict on test data
print("\nClassification Report:")
print(classification_report(y_test, predictions))  # Display performance metrics

# 10. Optional: Save the model and vectorizer
import joblib
joblib.dump(model, 'emotion_model.pkl')  # Save the trained model
joblib.dump(vectorizer, 'tfidf_vectorizer.pkl')  # Save the TF-IDF vectorizer
```

## Week 11

**Introduction**
The Emotion Analysis Tool is a Python-based application that uses a pre-trained Logistic Regression model and a TF-IDF vectorizer to predict emotions from text inputs. This project is part of our effort to explore sentiment analysis and text classification using machine learning. Here’s how we built and implemented the tool.

**Steps to Build the Tool**

1. Training the Model

To train the Logistic Regression model, we prepared a dataset with labeled text and followed these steps:

    1.	Preprocessing:
    •	Convert text to lowercase.
    •	Remove special characters and extra spaces to clean the data.

    2.	Feature Extraction:
    •	Use TF-IDF vectorization to transform text into numerical features.
    •	Limit the feature space to the top 5000 most important words.

    3.	Model Training:
    •	Train a Logistic Regression model using the TF-IDF features.
    •	Use the saga solver, which is efficient for sparse data.

    4.	Saving the Model and Vectorizer:
    •	Serialize the trained model and vectorizer using joblib to reuse them later.

Here’s the complete training script:

```python
# Logistic Regression Model for Emotion Classification
import pandas as pd
import re
from sklearn.model_selection import train_test_split
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.linear_model import LogisticRegression
from sklearn.preprocessing import MaxAbsScaler
from sklearn.metrics import classification_report
import joblib

# 1. Load the data
file_path = '/path/to/processed_combined_data.csv'  # Adjust the file path as needed
data = pd.read_csv(file_path)

# 2. Text preprocessing
def preprocess_text(text):
   text = text.lower()  # Convert to lowercase
   text = re.sub(r'\W', ' ', text)  # Remove special characters
   text = re.sub(r'\s+', ' ', text)  # Remove extra spaces
   return text.strip()  # Remove leading/trailing spaces

data['processed_statement'] = data['processed_statement'].dropna().apply(preprocess_text)

# 3. Remove invalid or empty texts
data = data.dropna(subset=['processed_statement'])  # Drop rows where 'processed_statement' is NaN
data = data[data['processed_statement'].str.strip().astype(bool)]  # Keep rows with non-empty text

# 4. Extract text and label data
X = data['processed_statement']  # Input text data
y = data['status']  # Corresponding labels/classes

# 5. Split into training and testing data
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# 6. TF-IDF vectorization
vectorizer = TfidfVectorizer(max_features=5000)  # Limit to 5000 most important features
X_train_tfidf = vectorizer.fit_transform(X_train)  # Fit and transform training data
X_test_tfidf = vectorizer.transform(X_test)  # Transform test data

# 7. Scale the data (using MaxAbsScaler optimized for sparse data)
scaler = MaxAbsScaler()
X_train_tfidf_scaled = scaler.fit_transform(X_train_tfidf)
X_test_tfidf_scaled = scaler.transform(X_test_tfidf)

# 8. Train the model
print("Training Logistic Regression model...")
model = LogisticRegression(max_iter=1000, solver='saga', verbose=1)  # `verbose=1` shows solver progress
model.fit(X_train_tfidf_scaled, y_train)  # Train the model once

# 9. Evaluate the model
predictions = model.predict(X_test_tfidf_scaled)  # Predict on test data
print("\nClassification Report:")
print(classification_report(y_test, predictions))  # Display performance metrics

# 10. Save the model and vectorizer
joblib.dump(model, 'emotion_model.pkl')  # Save the trained model
joblib.dump(vectorizer, 'tfidf_vectorizer.pkl')  # Save the TF-IDF vectorizer
print("Model and vectorizer saved successfully!")
```

2. Analyzing New Text

After training, the saved model (emotion_model.pkl) and vectorizer (tfidf_vectorizer.pkl) are used to analyze new text inputs. The analysis process includes:

    1.	Loading the trained model and vectorizer.

    2.	Preprocessing the input text to match the format used during training.

    3.	Transforming the text with the TF-IDF vectorizer.

    4.	Using the model to predict the emotion associated with the text.

Here’s the emotion analysis script:

```python
# Emotion Analysis Script
# This script loads a pre-trained Logistic Regression model and TF-IDF vectorizer to analyze emotions from text inputs.

import joblib
import re

# Load the trained model and vectorizer
# Ensure that 'emotion_model.pkl' and 'tfidf_vectorizer.pkl' are in the same directory as this script
model = joblib.load('emotion_model.pkl')  # Load the trained Logistic Regression model
vectorizer = joblib.load('tfidf_vectorizer.pkl')  # Load the saved TF-IDF vectorizer

# Preprocessing function
# This function preprocesses input text to match the format used during training
def preprocess_text(text):
    text = text.lower()  # Convert text to lowercase
    text = re.sub(r'\W', ' ', text)  # Remove non-word characters (punctuation, symbols)
    text = re.sub(r'\s+', ' ', text)  # Replace multiple spaces with a single space
    return text.strip()  # Remove leading and trailing spaces

# Function to predict emotion
# This function preprocesses the input, transforms it using the TF-IDF vectorizer, and predicts the emotion
def predict_emotion(input_text):
    # Preprocess the input text
    processed_text = preprocess_text(input_text)

    # Transform the input text using the TF-IDF vectorizer
    transformed_text = vectorizer.transform([processed_text])

    # Use the trained model to predict the emotion
    prediction = model.predict(transformed_text)[0]

    # Return the predicted emotion
    return prediction

# Main script to accept user input
# This loop allows users to input text repeatedly until they type 'exit'
if __name__ == "__main__":
    print("Emotion Analysis Tool")
    print("=====================")
    while True:
        # Prompt the user to enter a text
        user_input = input("\nEnter a text to analyze emotions (or type 'exit' to quit): ")

        # Exit the loop if the user types 'exit'
        if user_input.lower() == 'exit':
            print("Goodbye!")
            break

        # Get the predicted emotion for the input text
        emotion = predict_emotion(user_input)

        # Display the predicted emotion
        print(f"The predicted emotion is: {emotion}")
```

**Conclusion**

With this tool, you can analyze the emotions of text inputs based on a trained Logistic Regression model. The two scripts (train_model.py and analyze_emotion.py) ensure a clear separation of concerns:
• Training Script: Prepares and trains the model on a labeled dataset.
• Analysis Script: Loads the trained model and analyzes new text inputs.

This project demonstrates the practical application of Logistic Regression for text classification, leveraging techniques like TF-IDF vectorization and preprocessing for accurate predictions.

Feel free to enhance the project by adding features like:
• Mapping numeric labels to descriptive emotions (e.g., 0 → “happy”).
• Deploying the tool as a web application using Flask or FastAPI.
• Experimenting with other classifiers like SVM or deep learning models.

### Software Engineering

This week, progress was made on implementing the backend and populating the database for the project.

As an additional challenge, an attempt was made to set up GitHub Identity as the identity platform for the application. Unfortunately, it didn’t work as expected on the first or second try. After spending around two hours troubleshooting, the focus shifted to the core features of the application since the API was still quite basic at this stage. Prioritizing functionality over identity platform integration seemed essential for the success of the project. However, if time permits later, there will be another attempt at implementing authentication and authorization, as they are critical components for any API.

The setup of Entity Framework (EF) Core with a code-first approach followed. This involved creating entities, setting up a DbContext, and generating migrations. Initially, there were some issues with the connection string and applying migrations via the Visual Studio Command Line (PMC). Since the API was running inside Docker, the connection string used "database" as the hostname, which worked within the container environment. However, PMC runs outside Docker, causing the connection string to fail. To resolve this, the connection string was manually adjusted for migrations in PMC. Eventually, migrations were configured to apply automatically at application startup, a practical solution for this project, though not advisable for larger, production-grade applications.

Some challenges also arose with .NET versions. The application is built on .NET Core 8, so all packages were intentionally limited to version 8. At one point, Visual Studio automatically installed a version 9 package when resolving a missing class, which caused startup issues. Identifying and fixing this compatibility problem took some time, but with the assistance of ChatGPT, the issue was resolved, and the project moved forward.

Seeding data for the database was another task completed during the week. Instead of using modelBuilder and generating seed data through migrations, a different approach was adopted to avoid affecting all environments, including production. On application startup, if the environment is detected as development, an early instance of the DbContext is created, and example data is inserted or updated. This ensures no duplicate data while allowing manually added data to remain untouched. The seed data, generated using AI, saved significant time and aligned well with the app's context, given the entities and their relationships.

Work also progressed on the API and controllers, beginning with the employee and questionnaire modules. Without a fully designed frontend, the data requirements were anticipated, and corresponding API endpoints and service calls were created. Onion architecture principles guided the structure, with occasional consultations with ChatGPT to refine implementation. Many service functions were generated with AI assistance, which saved time, though adjustments were often necessary to align with project needs. Basic validations were implemented to ensure clean updates, limited only to the relevant entity. Swagger was used for initial testing, allowing retrieval, modification, and re-verification of data.

The backend is now capable of handling employee and questionnaire management, as well as providing responses for the frontend. However, several tasks remain:

Developing an interface for the AI model to analyze and predict survey responses
Implementing authentication using GitHub accounts
Setting up role-based authorization for internal systems
Creating interfaces for data from external sources, including commits, attendance, and employee records
