<template>
  <div style="padding: 20px">
    <h1>API Debugging Page</h1>
    <div>
      <h2>Employee API</h2>
      <button @click="fetchAllEmployees">Get All Employees</button>
      <button @click="fetchEmployeeById">Get Employee By ID (1)</button>
      <button @click="createEmployee">Create Employee</button>
      <button @click="getSupervisedTeams">Get Supervised Teams By Employee ID (1)</button>
    </div>

    <div>
      <h2>Questionnaire API</h2>
      <button @click="fetchAllQuestionnaires">Get All Questionnaires</button>
      <button @click="fetchQuestionnaireById">Get Questionnaire By ID (1)</button>
      <button @click="createQuestionnaire">Create Questionnaire</button>
      <button @click="fetchQuestionnaireRunById">Get Questionnaire Run By ID (1)</button>
      <button @click="createQuestionnaireRun">Create Questionnaire Run</button>
      <button @click="submitAnswer">Submit Answer</button>
      <button @click="addQuestion">Add Question</button>
    </div>

    <pre v-if="apiResponse">{{ formatResponse(apiResponse) }}</pre>
  </div>
</template>

<script>
import { EmployeeAPI } from "@/services/EmployeeAPI"; // Adjust the path if needed
import { QuestionnaireAPI } from "@/services/QuestionnaireAPI"; // Adjust the path if needed

export default {
  data() {
    return {
      apiResponse: null,
    };
  },
  methods: {
    // Employee API
    async fetchAllEmployees() {
      try {
        const data = await EmployeeAPI.getAllEmployees();
        this.apiResponse = data;
      } catch (error) {
        console.error("Error fetching all employees:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async fetchEmployeeById() {
      try {
        const data = await EmployeeAPI.getEmployeeById(1); // Using ID 1 for testing
        this.apiResponse = data;
      } catch (error) {
        console.error("Error fetching employee by ID:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async createEmployee() {
      try {
        const dummyEmployee = {
          id: 999, // Replace with your Employee model fields
          name: "Test Employee",
          department: "Testing",
        };
        const data = await EmployeeAPI.createEmployee(dummyEmployee);
        this.apiResponse = data;
      } catch (error) {
        console.error("Error creating employee:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async getSupervisedTeams() {
      try {
        const data = await EmployeeAPI.getSupervisedTeamsByEmployeeId(1); // Using ID 1 for testing
        this.apiResponse = data;
      } catch (error) {
        console.error("Error fetching supervised teams:", error);
        this.apiResponse = { error: error.message };
      }
    },

    // Questionnaire API
    async fetchAllQuestionnaires() {
      try {
        const data = await QuestionnaireAPI.getAllQuestionnaires();
        this.apiResponse = data;
      } catch (error) {
        console.error("Error fetching all questionnaires:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async fetchQuestionnaireById() {
      try {
        const data = await QuestionnaireAPI.getQuestionnaireById(1); // Using ID 1 for testing
        this.apiResponse = data;
      } catch (error) {
        console.error("Error fetching questionnaire by ID:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async createQuestionnaire() {
      try {
        const dummyQuestionnaire = {
          id: 999, // Replace with your Questionnaire model fields
          description: "Test Questionnaire",
        };
        const data = await QuestionnaireAPI.createQuestionnaire(dummyQuestionnaire);
        this.apiResponse = data;
      } catch (error) {
        console.error("Error creating questionnaire:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async fetchQuestionnaireRunById() {
      try {
        const data = await QuestionnaireAPI.getQuestionnaireRunById(1); // Using ID 1 for testing
        this.apiResponse = data;
      } catch (error) {
        console.error("Error fetching questionnaire run by ID:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async createQuestionnaireRun() {
      try {
        const dummyRun = {
          id: 999, // Replace with your QuestionnaireRun model fields
          questionnaireId: 1,
          employeeId: 1,
        };
        const data = await QuestionnaireAPI.createQuestionnaireRun(dummyRun);
        this.apiResponse = data;
      } catch (error) {
        console.error("Error creating questionnaire run:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async submitAnswer() {
      try {
        const dummyAnswer = {
          id: 999, // Replace with your Answer model fields
          questionId: 1,
          questionnaireRunId: 1,
          answerText: "Test Answer",
        };
        const data = await QuestionnaireAPI.submitAnswer(dummyAnswer);
        this.apiResponse = data;
      } catch (error) {
        console.error("Error submitting answer:", error);
        this.apiResponse = { error: error.message };
      }
    },
    async addQuestion() {
      try {
        const dummyQuestion = {
          id: 999, // Replace with your Question model fields
          questionnaireId: 1,
          questionText: "Test Question",
          sortOrder: 1,
        };
        const data = await QuestionnaireAPI.addQuestion(dummyQuestion);
        this.apiResponse = data;
      } catch (error) {
        console.error("Error adding question:", error);
        this.apiResponse = { error: error.message };
      }
    },

    // Formatter for Display
    formatResponse(response) {
      // Generic formatter for display
      return JSON.stringify(response, null, 2);
    },
  },
};
</script>

<style scoped>
button {
  margin: 5px;
  padding: 10px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
button:hover {
  background-color: #0056b3;
}
pre {
  background-color: #f4f4f4;
  padding: 15px;
  border-radius: 5px;
  white-space: pre-wrap;
}
</style>
