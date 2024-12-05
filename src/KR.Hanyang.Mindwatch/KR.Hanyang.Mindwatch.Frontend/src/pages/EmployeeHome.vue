<template>
  <div class="employee-questionnaire">
    <div class="employee-list">
      <h3>Employees ({{ employees.length }})</h3>
      <ul>
        <li
          v-for="employee in employees"
          :key="employee.id"
          @click="selectEmployee(employee)"
          :class="{ selected: selectedEmployee?.id === employee.id }"
        >
          {{ employee.firstName }} {{ employee.name }}
        </li>
      </ul>
    </div>
    <div class="questionnaire-list" v-if="selectedEmployee">
      <h3>
        Questionnaire Runs for {{ selectedEmployee.firstName }}
        {{ selectedEmployee.name }}
      </h3>
      <ul>
        <li
          v-for="questionnaireRun in questionnaireRuns"
          :key="questionnaireRun.id"
          @click="navigateToQuestionnaireRun(questionnaireRun.id)"
        >
          <div>
            <strong>Description:</strong>
            {{ questionnaireRun.questionnaire?.description || "Loading..." }}
          </div>
          <div>
            <strong>Status:</strong>
            {{ questionnaireRunStatusText(questionnaireRun.questionnaireRunStatus) }}
          </div>
          <div>
            <strong>Created At:</strong>
            {{ formatDate(questionnaireRun.createdAt) }}
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { EmployeeAPI } from "../api/EmployeeApi";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import { Employee } from "../models/Employee";
import { Questionnaire } from "../models/Questionnaire";
import { QuestionnaireRun } from "../models/QuestionnaireRun";

export default defineComponent({
  name: "EmployeeQuestionnaire",
  data() {
    return {
      employees: [] as Employee[],
      selectedEmployee: null as Employee | null,
      questionnaireRuns: [] as QuestionnaireRun[],
    };
  },
  methods: {
    navigateToQuestionnaireRun(id: number): void {
      this.$router.push({ path: `/questionnaire-run/${id}` });
    },
    async fetchEmployees() {
      try {
        this.employees = await EmployeeAPI.getAllEmployees();
      } catch (error) {
        console.error("Failed to fetch employees:", error);
      }
    },
    async selectEmployee(employee: Employee) {
      this.selectedEmployee = employee;

      try {
        const employeeData = await EmployeeAPI.getEmployeeById(employee.id);
        this.questionnaireRuns = (employeeData.questionnaireRuns as any).$values || [];

        // Fetch detailed questionnaire data for each QuestionnaireRun
        for (const run of this.questionnaireRuns) {
          if (!run.questionnaire) {
            run.questionnaire = await this.getQuestionnaireById(run.questionnaireId);
          }
        }
      } catch (error) {
        console.error("Failed to fetch employee data:", error);
        throw error;
      }
    },

    async getQuestionnaireById(id: number): Promise<Questionnaire> {
      try {
        return await QuestionnaireAPI.getQuestionnaireById(id);
      } catch (error) {
        console.error(`Failed to fetch questionnaire with ID ${id}:`, error);
        throw error;
      }
    },

    questionnaireRunStatusText(status?: number): string {
      switch (status) {
        case 1:
          return "Open";
        case 2:
          return "In Progress";
        case 3:
          return "Closed";
        default:
          return "Unknown";
      }
    },
    formatDate(date?: string): string {
      return date ? new Date(date).toLocaleString() : "N/A";
    },
  },
  async mounted() {
    await this.fetchEmployees();
  },
});
</script>

<style scoped>
.employee-questionnaire {
  display: flex;
  gap: 20px;
}

.employee-list,
.questionnaire-list {
  border: 1px solid #ccc;
  padding: 10px;
  width: 45%;
  max-height: 500px;
  overflow-y: auto;
}

.employee-list ul,
.questionnaire-list ul {
  list-style-type: none;
  padding: 0;
}

.employee-list li {
  cursor: pointer;
  padding: 5px;
  border: 1px solid transparent;
  margin-bottom: 5px;
}

.employee-list li.selected {
  background-color: #f0f0f0;
  border-color: #007bff;
}

.questionnaire-list li {
  border-bottom: 1px solid #ccc;
  padding: 10px 0;
}

h3 {
  margin-bottom: 10px;
}
</style>
