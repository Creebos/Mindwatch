import { createRouter, createWebHistory } from "vue-router";
import EmployeeDetail from "../pages/EmployeeDetail.vue";
import EmployeeHome from "../pages/EmployeeHome.vue";

const routes = [
  { path: "/home", name: "Employee Home", component: EmployeeHome },
  { path: "/employees", name: "Employee Overview", component: EmployeeDetail },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
