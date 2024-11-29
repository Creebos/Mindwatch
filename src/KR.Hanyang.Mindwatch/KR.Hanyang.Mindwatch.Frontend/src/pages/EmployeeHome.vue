<template>
  <div>
    <h1>Employees</h1>
    <ul>
      <li v-for="employee in employees" :key="employee.id">{{ employee.firstName }}</li>
    </ul>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted } from "vue";
import { useEmployeeStore } from "../store/EmployeeStore";

export default defineComponent({
  name: "EmployeeList",
  setup() {
    const employeeStore = useEmployeeStore();

    // Fetch employees when the component is mounted
    onMounted(() => {
      employeeStore.fetchAllEmployees();
    });

    // Make employees reactive using computed
    const employees = computed(() => employeeStore.employees);

    return {
      employees,
    };
  },
});
</script>
