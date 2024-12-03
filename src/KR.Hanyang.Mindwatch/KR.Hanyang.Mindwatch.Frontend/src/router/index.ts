import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import EmployeeView from "../views/EmployeeView.vue";
import HRManagerView from "../views/HRManagerView.vue";
import ManagerView from "../views/ManagerView.vue";
import SurveyForm from "../views/SurveyForm.vue"; // Import the SurveyForm view

const routes = [
  { path: "/", name: "Home", component: HomeView },
  { path: "/employee", name: "Employee", component: EmployeeView },
  { path: "/hr-manager", name: "HRManager", component: HRManagerView },
  { path: "/manager", name: "Manager", component: ManagerView },
  { path: "/surveyform", name: "SurveyForm", component: SurveyForm }, // Add the SurveyForm route
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
