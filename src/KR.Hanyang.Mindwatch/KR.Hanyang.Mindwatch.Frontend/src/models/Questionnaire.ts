import { Question } from "./Question";
import { QuestionnaireRun } from "./QuestionnaireRun";

export interface Questionnaire {
  id?: number;
  description: string;
  questions?: Question[];
  questionnaireRuns?: QuestionnaireRun[];
}
