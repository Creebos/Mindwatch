<template>
  <div>
    <h1>Employees</h1>
    <ul>
      <li v-for="employee in employees" :key="employee.id">{{ employee.name }}</li>
    </ul>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted } from "vue";
import { useEmployeeStore } from "../store/EmployeeStore";

export default defineComponent({
  name: "EmployeeList",
  setup() {
    const employeeStore = useEmployeeStore();

    onMounted(() => {
      employeeStore.fetchAllEmployees();
    });

    return {
      employees: employeeStore.employees,
    };
  },
});
</script>
