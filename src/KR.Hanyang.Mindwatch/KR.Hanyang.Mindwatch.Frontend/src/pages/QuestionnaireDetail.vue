<template>
  <div class="container-fluid py-4">
    <!-- Title -->
    <h1 class="text-primary mb-4">{{ questionnaire?.title }}</h1>

    <!-- Notes and Description Section -->
    <div class="row mb-4">
      <!-- Notes -->
      <div class="col-md-6">
        <h5 class="text-secondary">Notes</h5>
        <p>{{ questionnaire?.notes }}</p>
      </div>

      <!-- Description -->
      <div class="col-md-6">
        <h5 class="text-secondary">Description</h5>
        <p>{{ questionnaire?.description }}</p>
      </div>
    </div>

    <div class="row">
      <!-- Left Side: Questions -->
      <div class="col-md-8">
        <h4 class="mb-3">Questions</h4>
        <ul class="list-group mb-3">
          <li
            v-for="(question, index) in sortedQuestions"
            :key="question.id"
            class="list-group-item list-group-item-action"
            @click="openQuestionDialog(question.id)"
          >
            <strong>Question {{ index + 1 }}:</strong> {{ question.questionText }}
          </li>
        </ul>
        <button class="btn btn-success" @click="openQuestionDialog(0)">
          <i class="bi bi-plus-circle"></i> Add Question
        </button>
      </div>

      <!-- Right Side: QuestionnaireRuns -->
      <div class="col-md-4">
        <h4 class="mb-3">Questionnaire Runs</h4>
        <ul class="list-group mb-3">
          <li
            v-for="run in questionnaire?.questionnaireRuns || []"
            :key="run.id"
            class="list-group-item list-group-item-action d-flex justify-content-between align-items-center"
            @click="navigateToRun(run.id)"
          >
            <span>{{ run.id }}</span>
            <span :class="run.questionnaireRunStatus == 1 ? 'bg-primary' : 'bg-secondary'" class="badge text-light">{{
              QuestionnaireRunStatus[run.questionnaireRunStatus]
            }}</span>
          </li>
        </ul>
        <button class="btn btn-success" @click="openRunDialog"><i class="bi bi-plus-circle"></i> Add Run</button>
      </div>
    </div>

    <QuestionCreateEdit :questionnaire-id="questionnaire?.id" :question="selectedQuestion" ref="questionDialog" />
    <QuestionnaireRunCreate ref="runDialog" />
  </div>
</template>

<script lang="ts">
import * as bootstrap from "bootstrap";
import { computed, defineComponent, onMounted, ref } from "vue";
import { useRoute, useRouter } from "vue-router";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import QuestionCreateEdit from "../components/QuestionCreateEdit.vue";
import QuestionnaireRunCreate from "../components/QuestionnaireRunCreate.vue";
import { Question, Questionnaire, QuestionnaireRunStatus } from "../models/models";

export default defineComponent({
  name: "QuestionnaireDetail",
  components: {
    QuestionCreateEdit,
    QuestionnaireRunCreate,
  },
  setup() {
    const route = useRoute();
    const router = useRouter();
    const questionnaireId = Number(route.params.id);

    const questionnaire = ref<Questionnaire | null>(null);
    const selectedQuestion = ref<Question | undefined>(undefined);

    const fetchQuestionnaire = async () => {
      questionnaire.value = await QuestionnaireAPI.getQuestionnaireById(questionnaireId);
    };

    const sortedQuestions = computed(
      () => questionnaire.value?.questions?.slice().sort((a, b) => a.sortOrder - b.sortOrder) || []
    );

    const navigateToRun = (runId: number) => {
      router.push(`/questionnaires/${questionnaireId}/run/${runId}`);
    };

    const openRunDialog = () => {
      const modal = new bootstrap.Modal(document.getElementById("runDialog") as HTMLElement);
      modal.show();
    };

    const openQuestionDialog = (questionId: number) => {
      selectedQuestion.value = questionnaire.value.questions.find((f) => f.id === questionId);
      const modal = new bootstrap.Modal(document.getElementById("questionDialog") as HTMLElement);
      modal.show();
    };

    onMounted(() => {
      fetchQuestionnaire();

      // Add event listeners for modal close
      const questionDialog = document.getElementById("questionDialog");
      const runDialog = document.getElementById("runDialog");

      if (questionDialog) {
        questionDialog.addEventListener("hidden.bs.modal", () => {
          location.reload(); // Reload the page
        });
      }

      if (runDialog) {
        runDialog.addEventListener("hidden.bs.modal", () => {
          location.reload(); // Reload the page
        });
      }
    });

    return {
      questionnaire,
      sortedQuestions,
      selectedQuestion,
      navigateToRun,
      openRunDialog,
      openQuestionDialog,
      QuestionnaireRunStatus,
    };
  },
});
</script>

<style scoped>
.container-fluid {
  max-width: 1200px;
}
.list-group-item {
  cursor: pointer;
}
.list-group-item:hover {
  background-color: #f8f9fa;
}
</style>
