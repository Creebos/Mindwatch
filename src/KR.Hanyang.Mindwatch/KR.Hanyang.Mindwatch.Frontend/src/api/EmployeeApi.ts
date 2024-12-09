import { Employee } from "../models/models";
import apiClient from "./http";

export const EmployeeAPI = {
  async getAllEmployees(): Promise<Employee[]> {
    const response = await apiClient.get("/employees");
    return response.data as Employee[];
  },

  async getEmployeeById(id: number): Promise<Employee> {
    const response = await apiClient.get(`/employees/${id}`);
    return response.data as Employee;
  },

  async createEmployee(employee: Employee): Promise<Employee> {
    const response = await apiClient.post("/employees", employee);
    return response.data as Employee;
  },
};
