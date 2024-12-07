## Frontend Views:

### Employee

- Employee fills out Questionnaire (by GUID)
- Employee sees Results of Questionnaire
- Emplyoee submits incident form (without auth, but email field provided)

### HR Manager

- Login page
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
- Sees all Incidents
- Sees detail of incident

## Required API Endpoints

- GET QuestionnaireRun (by QuestionnaireRunId)

  - Includes Questionnaire
    - Includes Questions
  - Includes Answers
  - Includes Result

- GET QuestionnaireRunResult (by QuestionnaireRunId)

(HR Manager Base View Stuff)

- GET All Questionnaires
- GET Questionnaire (by Id)
  - Includes Questions
  - Includes QuestionnaireRun

(HR Manager Questionnaire Edit stuff)

- POST Questionnaire (by Id)
- POST Question (by Id)
- POST QuestionnaireRun (by Id)

(HR Manager Incident Overview)

- GET All Incidents
- GET Incident (by Id)

(Employee Incident creation stuff shit)

- POST Incident (by Id)
