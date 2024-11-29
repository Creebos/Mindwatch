import { Questionnaire } from "./Questionnaire";

export interface Question {
  id?: number;
  questionnaireId: number;
  questionnaire?: Questionnaire;
  questionText: string;
  sortOrder?: number;
}
