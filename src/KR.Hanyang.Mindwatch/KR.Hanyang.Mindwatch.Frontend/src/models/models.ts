export interface Answer {
  id: number;
  questionId: number;
  question?: Question;
  questionnaireRunId: number;
  questionnaireRun?: QuestionnaireRun;
  answerText: string;
  prediction: string;
}

export interface Employee {
  id: number;
  name: string;
  firstName: string;
  shortName: string;
  email: string;
  phoneNumber: string;
  githubId: string;
}

export interface Incident {
  id: number;
  title: string;
  description: string;
  authorEmail: string;
}

export interface Question {
  id: number;
  questionnaireId: number;
  questionnaire?: Questionnaire;
  questionText: string;
  sortOrder: number;
}

export interface Questionnaire {
  id: number;
  title: string;
  description: string;
  notes: string;
  questions?: Question[];
  questionnaireRuns?: QuestionnaireRun[];
}

export interface QuestionnaireRun {
  id: number;
  questionnaireId: number;
  questionnaire?: Questionnaire;
  questionnaireRunStatus: QuestionnaireRunStatus;
  createdAt: Date;
  openDateTime: Date;
  closeDateTime: Date;
  answers?: Answer[];
}

export enum QuestionnaireRunStatus {
  Open = 1,
  InProgress = 2,
  Done = 3,
}
