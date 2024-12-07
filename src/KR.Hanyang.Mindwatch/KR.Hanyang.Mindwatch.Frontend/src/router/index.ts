import { createRouter, createWebHistory } from "vue-router";
import FillQuestionnaire from "../pages/FillQuestionnaire.vue";
import QuestionnaireDetail from "../pages/QuestionnaireDetail.vue";
import Questionnaires from "../pages/Questionnaires.vue";

const routes = [
  { path: "/questionnaires", component: Questionnaires },
  {
    path: "/questionnaires/:id",
    component: QuestionnaireDetail,
    props: true,
  },
  {
    path: "/questionnaires/fill/:id",
    component: FillQuestionnaire,
    props: true,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
