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

>Participants: Instead of choosing from set options (e.g., “Are you feeling stressed: Yes, No, Sometimes”), participants write detailed responses in their own words.
 
>AI Processing: The AI will apply NLP techniques such as Sentiment Analysis, Topic Modeling, and Named Entity Recognition (NER) to extract meaningful insights from the text. For instance, it will identify emotional tone, key topics (e.g., stress, workload), and potential signs of depression or burnout without requiring the participant to label these themselves.
 
>Scoring: Based on these analyses, the AI will assign a score or category that reflects the individual’s mental health condition, such as levels of anxiety, stress, or burnout, as detected in their written responses.

This method allows for a more natural and nuanced expression of how participants feel, and the AI handles the burden of categorization and analysis afterward, ensuring accuracy and minimizing bias.

By utilizing these well-researched tools, we aim to provide an efficient, accurate, and privacy-preserving approach to mental health detection in the workplace.

### References
1. Levis, B., Benedetti, A., & Thombs, B. D. (2023). Accuracy of the Patient Health Questionnaire-9 for screening to detect major depression: Updated systematic review and individual participant data meta-analysis. *The BMJ*. https://doi.org/10.1136/bmj.l1476
2. Spitzer, R. L., Kroenke, K., Williams, J. B. W., & Löwe, B. (2023). A brief measure for assessing generalized anxiety disorder: The GAD-7. *JAMA Psychiatry*. https://doi.org/10.1001/jamapsychiatry.2023.0209
3. Maslach, C., Jackson, S. E., & Leiter, M. P. (2023). The Maslach Burnout Inventory manual (4th ed.). *Mind Garden*. https://www.mindgarden.com/117-maslach-burnout-inventory
4. Fliege, H., Rose, M., Arck, P., Levenstein, S., & Klapp, B. F. (2024). The Perceived Stress Questionnaire (PSQ) reconsidered: Validation and psychometric properties. *Journal of Psychosomatic Research*. https://doi.org/10.1016/j.jpsychores.2024.01.007


## Week 08
