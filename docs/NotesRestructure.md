## Frontend Views:

### Employee

- Employee fills out Questionnaire (by GUID)
- Emplyoee submits incident form (without auth, but email field provided)

### HR Manager

- Sees all Questionnaires
- Sees detail page of Questionnaire
  - includes:
  - QuestionnaireRuns
  - Questions
  - Results
- Has option to modify Questionnaire
- Sees detail page of QuestionnaireRun
  - sees all Questions & their answers
  - Results
- Can download Results Reports of Questionnaire (excel)
