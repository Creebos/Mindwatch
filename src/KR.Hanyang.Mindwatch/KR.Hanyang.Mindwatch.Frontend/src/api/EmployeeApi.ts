import { Employee } from "../models/Employee";
import { Team } from "../models/Team";
import apiClient from "./http";

export const EmployeeAPI = {
  async getAllEmployees(): Promise<Employee[]> {
    const response = await apiClient.get("/employees");
    return response.data.$values as Employee[];
  },

  async getEmployeeById(id: number): Promise<Employee> {
    const response = await apiClient.get(`/employees/${id}`);
    return response.data as Employee;
  },

  async createEmployee(employee: Employee): Promise<Employee> {
    const response = await apiClient.post("/employees", employee);
    return response.data as Employee;
  },

  async getSupervisedTeamsByEmployeeId(id: number): Promise<Team[]> {
    const response = await apiClient.get(`/employees/${id}/supervised-teams`);
    return response.data as Team[];
  },
};
