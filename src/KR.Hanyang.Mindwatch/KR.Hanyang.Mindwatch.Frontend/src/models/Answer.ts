import { Question } from "./Question";
import { QuestionnaireRun } from "./QuestionnaireRun";

export interface Answer {
  id?: number;
  questionId: number;
  question?: Question;
  questionnaireRunId: number;
  questionnaireRun?: QuestionnaireRun;
  answerText?: string;
}
