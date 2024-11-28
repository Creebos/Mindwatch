import { Employee } from "../models/Employee";
import apiClient from "./http";

export const EmployeeAPI = {
  async getAllEmployees(): Promise<Employee[]> {
    const response = await apiClient.get<Employee[]>("/employees");
    return response.data;
  },

  async getEmployeeById(id: number): Promise<Employee> {
    const response = await apiClient.get<Employee>(`/employees/${id}`);
    return response.data;
  },

  async createEmployee(employee: Employee): Promise<Employee> {
    const response = await apiClient.post<Employee>("/employees", employee);
    return response.data;
  },

  async getSupervisedTeamsByEmployeeId(id: number): Promise<any[]> {
    const response = await apiClient.get<any[]>(`/employees/${id}/supervised-teams`);
    return response.data;
  },
};
