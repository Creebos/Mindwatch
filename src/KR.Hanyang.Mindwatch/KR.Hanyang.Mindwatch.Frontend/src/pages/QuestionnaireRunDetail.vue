<template>
  <div class="container mt-4">
    <!-- Title Section -->
    <div class="text-center mb-4">
      <h2>{{ questionnaireRun?.questionnaire?.title || "Loading..." }}</h2>
      <small class="text-muted">Questionnaire Run ID: {{ id }}</small>
      <button class="btn btn-primary" @click="copyModifiedUrl">Copy Url</button>
    </div>

    <!-- Main Content -->
    <div class="row">
      <!-- Chart Space -->
      <div class="col-md-6">
        <div class="p-4 text-center" style="height: 300px">
          <p class="text-muted">Chart Placeholder</p>
        </div>
      </div>

      <!-- Questions and Answers -->
      <div class="col-md-6">
        <div class="p-4">
          <h5>Questions and Answers</h5>
          <div v-if="questionsWithAnswers.length === 0" class="text-muted">No questions or answers available.</div>
          <ul class="list-group" v-else>
            <li class="list-group-item" v-for="item in questionsWithAnswers" :key="item.question.id">
              <strong>{{ item.question.questionText }}</strong>
              <p class="mb-0">{{ item.answer?.answerText || "No Answer" }}</p>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import { Answer, Question, QuestionnaireRun } from "../models/models";

export default defineComponent({
  name: "QuestionnaireRunResults",
  props: {
    id: {
      type: Number,
      required: true,
    },
  },
  setup(props) {
    const route = useRoute();
    const questionnaireRun = ref<QuestionnaireRun | null>(null);
    const questionsWithAnswers = ref<{ question: Question; answer: Answer | undefined }[]>([]);

    const fetchQuestionnaireRun = async () => {
      try {
        questionnaireRun.value = await QuestionnaireAPI.getQuestionnaireRunById(props.id);

        if (questionnaireRun.value) {
          const questions = questionnaireRun.value.questionnaire?.questions || [];
          const answers = questionnaireRun.value.answers || [];

          // Map and join questions and answers
          questionsWithAnswers.value = questions
            .map((q) => ({
              question: q,
              answer: answers.find((a) => a.questionId === q.id),
            }))
            .sort((a, b) => a.question.sortOrder - b.question.sortOrder);
        }
      } catch (error) {
        console.error("Error fetching questionnaire run:", error);
      }
    };

    const copyModifiedUrl = () => {
      const baseUrl = window.location.origin;
      const modifiedUrl = `${baseUrl}/questionnaires/fill/${props.id}`;

      navigator.clipboard.writeText(modifiedUrl);
    };

    onMounted(fetchQuestionnaireRun);

    return {
      questionnaireRun,
      questionsWithAnswers,
      copyModifiedUrl,
    };
  },
});
</script>
