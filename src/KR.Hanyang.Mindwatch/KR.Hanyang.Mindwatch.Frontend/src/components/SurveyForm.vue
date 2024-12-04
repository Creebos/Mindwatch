<template>
  <div class="survey-form">
    <h2 v-if="isHR">Create a New Survey</h2>
    <h2 v-else>Health Assessment Survey</h2>

    <form @submit.prevent="submitForm">
      <!-- Employee View: Fill out survey -->
      <div v-if="!isHR" v-for="(question, index) in questions" :key="index">
        <label :for="'question-' + index">{{ question.text }}</label>
        <textarea
          :id="'question-' + index"
          v-model="answers[index]"
          required
        ></textarea>
      </div>

      <!-- HR Manager View: Create new survey -->
      <div v-else>
        <div v-for="(question, index) in newQuestions" :key="index">
          <label :for="'new-question-' + index">Question {{ index + 1 }}</label>
          <input
            type="text"
            :id="'new-question-' + index"
            v-model="newQuestions[index].text"
            placeholder="Enter question text"
            required
          />
        </div>
        <button type="button" @click="addNewQuestion">Add Question</button>
      </div>

      <button type="submit">{{ isHR ? "Create Survey" : "Submit Survey" }}</button>
    </form>
  </div>
</template>

<script>
import { QuestionnaireApi } from "../api/QuestionnaireApi";

export default {
  data() {
    return {
      isHR: false, // Replace with actual role check (e.g., via authService)
      questions: [], // For employees
      answers: [], // For employees
      newQuestions: [], // For HR managers
    };
  },
  methods: {
    async fetchQuestions() {
      if (!this.isHR) {
        // Fetch survey questions for employees
        try {
          const response = await QuestionnaireApi.getSurveyQuestions();
          this.questions = response.questions;
          this.answers = Array(response.questions.length).fill("");
        } catch (error) {
          console.error("Error fetching questions:", error);
        }
      }
    },
    addNewQuestion() {
      this.newQuestions.push({ text: "" });
    },
    async submitForm() {
      try {
        if (this.isHR) {
          // Create a new survey
          await QuestionnaireApi.createSurvey(this.newQuestions);
          alert("Survey created successfully!");
        } else {
          // Submit survey responses
          const payload = {
            answers: this.answers,
          };
          await QuestionnaireApi.submitSurvey(payload);
          alert("Survey submitted successfully!");
        }
      } catch (error) {
        console.error("Error submitting form:", error);
      }
    },
  },
  mounted() {
    this.fetchQuestions(); // Fetch questions if not HR
  },
};
</script>

<style>
.survey-form {
  max-width: 600px;
  margin: 2rem auto;
  padding: 1rem;
  border: 1px solid #ccc;
  border-radius: 8px;
}
.survey-form div {
  margin-bottom: 1rem;
}
.survey-form label {
  display: block;
  margin-bottom: 0.5rem;
}
</style>
