import { Attendance } from "./Attendance";
import { Commit } from "./Commit";
import { EmployeeRole } from "./EmployeeRole";
import { QuestionnaireRun } from "./QuestionnaireRun";
import { Team } from "./Team";

export interface Employee {
  id?: number;
  name: string;
  firstName: string;
  shortName: string;
  email: string;
  phoneNumber: string;
  role?: EmployeeRole;
  teamId?: number;
  team?: Team;
  questionnaireRuns?: QuestionnaireRun[];
  supervisedTeams?: Team[];
  attendances?: Attendance[];
  commits?: Commit[];
}
