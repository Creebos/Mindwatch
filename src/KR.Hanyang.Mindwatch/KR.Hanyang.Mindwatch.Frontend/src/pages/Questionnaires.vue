<template>
  <div class="container py-4">
    <div class="d-flex justify-content-between align-items-center mb-3">
      <!-- Page Title -->
      <h1 class="text-primary">Questionnaires</h1>
      <!-- New Questionnaire Button -->
      <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#questionnaireModal">
        <i class="bi bi-plus-circle"></i> New Questionnaire
      </button>
    </div>

    <!-- Questionnaires Table -->
    <div class="table-responsive">
      <table class="table table-striped table-hover">
        <thead class="table-light">
          <tr>
            <th style="width: 30%">Title</th>
            <th style="width: 40%">Notes</th>
            <th style="width: 15%">Amount of Questions</th>
            <th style="width: 15%">Amount of Runs</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="questionnaire in questionnaires"
            :key="questionnaire.id"
            @click="routeQuestionnaire(questionnaire.id)"
          >
            <td>{{ questionnaire.title }}</td>
            <td>{{ questionnaire.notes }}</td>
            <td>{{ questionnaire.questions?.length || 0 }}</td>
            <td>{{ questionnaire.questionnaireRuns?.length || 0 }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <QuestionnaireCreateEdit :questionnaireId="0" ref="questionnaireDialog" />
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import { useRouter } from "vue-router";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import QuestionnaireCreateEdit from "../components/QuestionnaireCreateEdit.vue";
import { Questionnaire } from "../models/models";

export default defineComponent({
  name: "Questionnaires",
  components: {
    QuestionnaireCreateEdit,
  },
  setup() {
    const questionnaires = ref<Questionnaire[]>([]);
    const router = useRouter();

    // Fetch all questionnaires
    const fetchQuestionnaires = async () => {
      questionnaires.value = await QuestionnaireAPI.getAllQuestionnaires();
    };

    const routeQuestionnaire = (id: number) => {
      router.push("/questionnaires/" + id);
    };

    onMounted(() => {
      fetchQuestionnaires();
    });

    return {
      questionnaires,
      routeQuestionnaire,
    };
  },
});
</script>

<style scoped>
.container {
  max-width: 1200px;
}
.table {
  margin-top: 1rem;
}
</style>
