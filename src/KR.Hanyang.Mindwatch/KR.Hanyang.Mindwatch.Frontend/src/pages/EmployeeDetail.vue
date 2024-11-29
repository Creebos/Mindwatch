<template>
  <div>
    <h1>Employee Details</h1>
    <div v-if="employee">
      <p>Name: {{ employee.name }}</p>
      <p>Email: {{ employee.email }}</p>
      <p>Phone: {{ employee.phoneNumber }}</p>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted } from "vue";
import { useRoute } from "vue-router";
import { useEmployeeStore } from "../store/EmployeeStore";

export default defineComponent({
  name: "EmployeeDetail",
  setup() {
    const route = useRoute();
    const employeeStore = useEmployeeStore();
    const employeeId = Number(route.params.id);

    onMounted(() => {
      employeeStore.fetchEmployeeById(employeeId);
    });

    return {
      employee: employeeStore.currentEmployee,
    };
  },
});
</script>
