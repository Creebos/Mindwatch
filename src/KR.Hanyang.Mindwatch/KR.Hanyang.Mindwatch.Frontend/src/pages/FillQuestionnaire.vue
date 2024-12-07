<template>
  <div class="d-flex justify-content-center align-items-center vh-100 bg-light">
    <div class="card shadow p-4" style="max-width: 600px; width: 100%">
      <!-- Display the Questionnaire Infos -->
      <div v-if="starting">
        <h1 class="text-center text-primary">{{ questionnaire?.questionnaire?.title }}</h1>
        <div v-if="questionnaire?.questionnaireRunStatus == 3" class="text-center mt-3">
          <p class="text-danger">This Questionnaire has already been completed!</p>
        </div>
        <div v-else class="text-center mt-3">
          <p>{{ questionnaire?.questionnaire?.description }}</p>
          <button class="btn btn-primary mt-3" @click="startQuestionnaire">Start</button>
        </div>
      </div>

      <!-- Display the Question and TextArea -->
      <div v-if="doing">
        <h2 class="text-center text-primary">Question {{ currentQuestionIndex + 1 }}</h2>
        <p class="text-center mt-3">{{ currentQuestion?.questionText }}</p>
        <textarea
          v-model="answerText"
          class="form-control my-3"
          rows="4"
          placeholder="Type your answer here..."
        ></textarea>
        <div class="d-flex justify-content-end">
          <button class="btn btn-success" @click="nextQuestion">Next</button>
        </div>
      </div>

      <!-- Display Completion Message -->
      <div v-if="completed" class="text-center">
        <h2 class="text-success">Thank you for completing the questionnaire!</h2>
        <p>You may now close this page.</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import { QuestionnaireRunStatus, type Answer, type Question, type QuestionnaireRun } from "../models/models";

export default defineComponent({
  name: "Questionnaire",
  setup() {
    const route = useRoute();
    const questionnaireRunId = Number(route.params.id);

    // State variables
    const questionnaire = ref<QuestionnaireRun | null>(null);
    const currentQuestionIndex = ref(0);
    const answerText = ref("");
    const starting = ref(true);
    const doing = ref(false);
    const completed = ref(false);

    const currentQuestion = ref<Question | null>(null);

    // Fetch the QuestionnaireRun by ID
    const fetchQuestionnaire = async () => {
      questionnaire.value = await QuestionnaireAPI.getQuestionnaireRunById(questionnaireRunId);
      setCurrentQuestion();
    };

    // Set the current question based on the index
    const setCurrentQuestion = () => {
      if (questionnaire.value && questionnaire.value.questionnaire?.questions) {
        currentQuestion.value = questionnaire.value.questionnaire.questions[currentQuestionIndex.value];
      }
    };

    // Start the questionnaire
    const startQuestionnaire = () => {
      starting.value = false;
      doing.value = true;
    };

    // Proceed to the next question
    const nextQuestion = async () => {
      if (questionnaire.value && currentQuestion.value) {
        const answer: Answer = {
          id: 0, // Let the backend generate the ID
          questionId: currentQuestion.value.id,
          questionnaireRunId: questionnaireRunId,
          answerText: answerText.value,
        };

        // Submit the answer
        await QuestionnaireAPI.submitAnswer(answer);

        // Clear the text area
        answerText.value = "";

        // Move to the next question
        if (
          questionnaire.value.questionnaire?.questions &&
          currentQuestionIndex.value < questionnaire.value.questionnaire.questions.length - 1
        ) {
          currentQuestionIndex.value++;
          setCurrentQuestion();
        } else {
          questionnaire.value.questionnaireRunStatus = QuestionnaireRunStatus.Done;
          QuestionnaireAPI.createOrUpdateQuestionnaireRun(questionnaire.value);
          // Mark as completed if there are no more questions
          doing.value = false;
          completed.value = true;
        }
      }
    };

    onMounted(() => {
      fetchQuestionnaire();
    });

    return {
      questionnaire,
      currentQuestion,
      currentQuestionIndex,
      answerText,
      starting,
      doing,
      completed,
      startQuestionnaire,
      nextQuestion,
    };
  },
});
</script>

<style scoped>
.card {
  border-radius: 10px;
}
textarea {
  resize: none;
}
</style>
