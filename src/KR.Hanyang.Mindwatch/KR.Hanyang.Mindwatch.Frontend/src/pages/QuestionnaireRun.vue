<template>
  <div class="questionnaire-container">
    <div class="question-list">
      <h3>Questions</h3>
      <ul>
        <li
          v-for="(question, index) in questions"
          :key="question.id"
          :class="{ selected: selectedQuestionIndex === index }"
          @click="selectQuestion(index)"
        >
          Question {{ index + 1 }}
        </li>
      </ul>
    </div>
    <div class="question-details" v-if="selectedQuestion">
      <h3>Question {{ selectedQuestionIndex + 1 }}</h3>
      <p>{{ selectedQuestion.questionText }}</p>
      <textarea v-model="currentAnswer" placeholder="Type your answer here..."></textarea>
      <button @click="saveAnswer">Save & Next</button>
    </div>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import { QuestionnaireAPI } from "../api/QuestionnaireApi";
import { Question } from "../models/Question";

export default defineComponent({
  name: "Questionnaire",
  setup() {
    const route = useRoute();
    const questionnaireId = parseInt(route.params.id as string, 10);

    const questions = ref<Question[]>([]);
    const selectedQuestionIndex = ref(0);
    const currentAnswer = ref<string>("");

    const fetchQuestions = async () => {
      try {
        const response = await QuestionnaireAPI.getQuestionnaireRunById(questionnaireId);
        questions.value = ((response.questionnaire.questions as any).$values || []) as Question[];
      } catch (error) {
        console.error("Failed to fetch questions:", error);
      }
    };

    const selectedQuestion = computed(() => questions.value[selectedQuestionIndex.value]);

    const selectQuestion = (index: number) => {
      selectedQuestionIndex.value = index;
      currentAnswer.value = ""; // Reset the text area when switching questions
    };

    const saveAnswer = async () => {
      if (selectedQuestion.value) {
        try {
          await QuestionnaireAPI.submitAnswer({
            id: 0,
            questionId: selectedQuestion.value.id,
            questionnaireRunId: questionnaireId,
            answerText: currentAnswer.value,
          });

          const nextIndex = selectedQuestionIndex.value + 1;
          if (nextIndex < questions.value.length) {
            selectQuestion(nextIndex);
          } else {
            alert("You've completed the questionnaire!");
          }
        } catch (error) {
          console.error("Failed to save answer:", error);
        }
      }
    };

    onMounted(fetchQuestions);

    return {
      questions,
      selectedQuestion,
      selectedQuestionIndex,
      currentAnswer,
      selectQuestion,
      saveAnswer,
    };
  },
});
</script>

<style scoped>
.questionnaire-container {
  display: flex;
  gap: 20px;
}

.question-list,
.question-details {
  border: 1px solid #ccc;
  padding: 10px;
  width: 45%;
  max-height: 500px;
  overflow-y: auto;
}

.question-list ul {
  list-style-type: none;
  padding: 0;
}

.question-list li {
  cursor: pointer;
  padding: 5px;
  border: 1px solid transparent;
  margin-bottom: 5px;
}

.question-list li.selected {
  background-color: #f0f0f0;
  border-color: #007bff;
}

textarea {
  width: 100%;
  height: 100px;
  margin-top: 10px;
  margin-bottom: 10px;
}

button {
  display: block;
  width: 100%;
  padding: 10px;
  background-color: #007bff;
  color: white;
  border: none;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}
</style>
