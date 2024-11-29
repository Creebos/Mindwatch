import { Answer } from "./Answer";
import { Employee } from "./Employee";
import { Questionnaire } from "./Questionnaire";
import { QuestionnaireRunStatus } from "./QuestionnaireRunStatus";

export interface QuestionnaireRun {
  id?: number;
  questionnaireId: number;
  questionnaire?: Questionnaire;
  employeeId: number;
  employee?: Employee;
  questionnaireRunStatus?: QuestionnaireRunStatus;
  createdAt?: string; // ISO DateTime string
  openDateTime?: string; // ISO DateTime string
  closeDateTime?: string; // ISO DateTime string
  answers?: Answer[];
}
