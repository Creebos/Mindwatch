import { defineStore } from "pinia";
import { EmployeeAPI } from "../api/EmployeeApi";
import { Employee } from "../models/Employee";

export const useEmployeeStore = defineStore("employee", {
  state: () => ({
    employees: [] as Employee[],
    currentEmployee: null as Employee | null,
  }),

  actions: {
    async fetchAllEmployees() {
      try {
        const employees = await EmployeeAPI.getAllEmployees();
        this.employees = employees;
        console.log(this.employees);
      } catch (error) {
        console.error("Error fetching employees:", error);
        throw error;
      }
    },

    async fetchEmployeeById(id: number) {
      try {
        const employee = await EmployeeAPI.getEmployeeById(id);
        this.currentEmployee = employee;
      } catch (error) {
        console.error("Error fetching employee by ID:", error);
        throw error;
      }
    },

    async createEmployee(employee: Employee) {
      try {
        const newEmployee = await EmployeeAPI.createEmployee(employee);
        this.employees.push(newEmployee);
        return newEmployee;
      } catch (error) {
        console.error("Error creating employee:", error);
        throw error;
      }
    },

    async fetchSupervisedTeams(id: number) {
      try {
        return await EmployeeAPI.getSupervisedTeamsByEmployeeId(id);
      } catch (error) {
        console.error("Error fetching supervised teams:", error);
        throw error;
      }
    },
  },
});
