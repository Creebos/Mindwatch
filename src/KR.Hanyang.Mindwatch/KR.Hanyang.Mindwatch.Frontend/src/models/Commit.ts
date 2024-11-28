import { Employee } from "./Employee";

export interface Commit {
  id?: number;
  employeeId: number;
  employee?: Employee;
  commitDateTime?: string; // ISO DateTime string
  commitSize?: number;
  commitType?: string;
}
