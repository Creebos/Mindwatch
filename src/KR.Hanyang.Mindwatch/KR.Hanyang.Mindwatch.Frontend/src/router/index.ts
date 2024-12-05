import { createRouter, createWebHistory } from "vue-router";
import EmployeeView from "../views/EmployeeView.vue";
import HomeView from "../views/HomeView.vue";
import HRManagerView from "../views/HRManagerView.vue";
import ManagerView from "../views/ManagerView.vue";
import SurveyForm from "../views/SurveyForm.vue"; // Import the SurveyForm view
import TestView from "../views/TestView.vue";

const routes = [
  { path: "/", name: "Home", component: HomeView },
  { path: "/employee", name: "Employee", component: EmployeeView },
  { path: "/hr-manager", name: "HRManager", component: HRManagerView },
  { path: "/manager", name: "Manager", component: ManagerView },
  { path: "/surveyform/:id", name: "SurveyForm", component: SurveyForm }, // Corrected route
  { path: "/testview", name: "TestView", component: TestView },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL || "/"),
  routes,
});

export default router;
