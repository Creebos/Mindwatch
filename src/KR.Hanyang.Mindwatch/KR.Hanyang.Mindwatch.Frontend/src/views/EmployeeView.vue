<script setup>
import { onMounted, ref } from 'vue';
import { QuestionnaireAPI } from '../api/QuestionnaireApi';

const questionnaires = ref([]);

onMounted(async () => {
    try {
        const data = await QuestionnaireAPI.getAllQuestionnaires();
        console.log('Loaded questionnaires:', data); // Debugging-Ausgabe
        questionnaires.value = data;
    } catch (error) {
        console.error('Error loading questionnaires:', error);
    }
});
</script>

<template>
  <div>
    <h1>Employee Dashboard</h1>
    <h2>Your Surveys</h2>
    <ul>
      <li v-for="questionnaire in questionnaires" :key="questionnaire.id">
        {{ questionnaire.title }}
        <router-link :to="'/survey/' + questionnaire.id">Fill out survey</router-link>
      </li>
    </ul>
    <div v-if="questionnaires.length === 0">No surveys available</div>
  </div>
</template>
