import { Employee } from "./Employee";

export interface Team {
  id?: number;
  name: string;
  supervisorEmployeeId: number;
  supervisorEmployee?: Employee;
  employees?: Employee[];
}
