import { parse } from "flatted";
import { Employee } from "../models/Employee";
import apiClient from "./http";

export const EmployeeAPI = {
  async getAllEmployees(): Promise<Employee[]> {
    const response = await apiClient.get("/employees");
    return parse(response.data) as Employee[];
  },

  async getEmployeeById(id: number): Promise<Employee> {
    const response = await apiClient.get(`/employees/${id}`);
    return parse(response.data) as Employee;
  },

  async createEmployee(employee: Employee): Promise<Employee> {
    const response = await apiClient.post("/employees", employee);
    return parse(response.data) as Employee;
  },

  async getSupervisedTeamsByEmployeeId(id: number): Promise<any[]> {
    const response = await apiClient.get(`/employees/${id}/supervised-teams`);
    return parse(response.data);
  },
};
