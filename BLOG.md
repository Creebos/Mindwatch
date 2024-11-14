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

## Week 08

## Week 09
