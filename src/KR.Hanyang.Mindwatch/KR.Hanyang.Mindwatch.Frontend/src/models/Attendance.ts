import { Employee } from "./Employee";

export interface Attendance {
  id?: number;
  employeeId: number;
  employee?: Employee;
  durationStart?: string; // ISO DateTime string
  durationEnd?: string; // ISO DateTime string
}
