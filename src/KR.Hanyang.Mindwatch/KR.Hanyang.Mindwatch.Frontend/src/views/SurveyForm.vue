<template>
  <v-container>
    <v-card outlined class="pa-6">
      <v-card-title class="text-h4">{{ survey?.title || 'Loading...' }}</v-card-title>
      <v-divider></v-divider>
      <v-card-text>
        <div v-if="!survey">No survey data available</div>
        <div v-for="(question, index) in survey?.questions || []" :key="question.id">
          <p>{{ question.text }}</p>
          <input type="text" v-model="answers[index]" placeholder="Your answer" />
        </div>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" @click="submitSurvey">Submit</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { QuestionnaireAPI } from '../api/QuestionnaireApi';

const route = useRoute();
const surveyId = ref(route.params.id);
const survey = ref(null);
const answers = ref([]);

const fetchSurvey = async () => {
    try {
        const data = await QuestionnaireAPI.getQuestionnaireById(surveyId.value);
        console.log('Loaded survey:', data); // Debugging-Ausgabe
        survey.value = data;
        answers.value = survey.value.questions.map(() => '');
    } catch (error) {
        console.error('Error loading survey:', error);
    }
};

const submitSurvey = async () => {
    try {
        await QuestionnaireAPI.submitAnswer({ surveyId: surveyId.value, answers: answers.value });
        alert('Survey submitted successfully!');
    } catch (error) {
        console.error('Error submitting survey:', error);
    }
};

onMounted(fetchSurvey);
</script>

<style scoped>
.v-container {
  padding: 16px;
}
</style>
