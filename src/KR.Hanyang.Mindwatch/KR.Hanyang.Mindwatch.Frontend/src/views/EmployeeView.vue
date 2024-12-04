<template>
  <v-container>
    <!-- Survey Card -->
    <v-row justify="center" class="mb-6">
      <v-col cols="12" sm="8" md="6">
        <v-card outlined class="pa-4">
          <v-card-title>Take a Survey</v-card-title>
          <v-card-text>Complete your daily mental health survey.</v-card-text>
          <v-card-actions>
            <v-btn color="primary" @click="startSurvey">Start</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>

    <!-- Metrics Card -->
    <v-row justify="center" class="mb-6">
      <v-col cols="12" sm="10" md="8">
        <v-card outlined class="pa-6">
          <v-card-title>Your Mental Health Overview</v-card-title>
          <v-divider></v-divider>
          <v-card-text>
            <v-row class="mt-4" align="center" justify="center">
              <v-col cols="12" md="10">
                <v-progress-linear :value="surveyCompletion" color="success" class="mb-6" height="20">
                  <template #default>
                    <strong>Survey Completion: {{ surveyCompletion }}%</strong>
                  </template>
                </v-progress-linear>
              </v-col>
              <v-col cols="12" md="10">
                <v-progress-linear :value="stressLevel" color="info" class="mb-6" height="20">
                  <template #default>
                    <strong>Stress Level: {{ stressLevelDescription }}</strong>
                  </template>
                </v-progress-linear>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

    <!-- Bar Chart -->
    <v-row justify="center">
      <v-col cols="12" md="10">
        <BarChart :labels="chartLabels" :data="chartData" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import BarChart from "../components/BarChart.vue";
import { QuestionnaireApi } from "../api/QuestionnaireApi"; // Import the API

export default {
  name: "EmployeeView",
  components: {
    BarChart,
  },
  data() {
    return {
      chartLabels: [],
      chartData: [],
      surveyCompletion: 0,
      stressLevel: 0,
      stressLevelDescription: "Unknown",
    };
  },
  methods: {
    async fetchMetrics() {
      try {
        const metrics = await QuestionnaireApi.getMetrics(); // Replace with actual API method
        this.surveyCompletion = metrics.completion || 0;
        this.stressLevel = metrics.stressLevel || 0;
        this.stressLevelDescription =
          metrics.stressLevel < 40
            ? "Low"
            : metrics.stressLevel < 70
            ? "Moderate"
            : "High";
      } catch (error) {
        console.error("Error fetching metrics:", error);
      }
    },
    async fetchChartData() {
      try {
        const chartData = await QuestionnaireApi.getChartData(); // Replace with actual API method
        this.chartLabels = chartData.labels || [];
        this.chartData = chartData.values || [];
      } catch (error) {
        console.error("Error fetching chart data:", error);
      }
    },
    async startSurvey() {
      try {
        await QuestionnaireApi.startSurvey(); // Optional: Record the start
        this.$router.push("/surveyform");
      } catch (error) {
        console.error("Error starting survey:", error);
      }
    },
  },
  mounted() {
    this.fetchMetrics();
    this.fetchChartData();
  },
};
</script>

<style scoped>
.v-container {
  padding: 16px;
}
.v-card {
  border-radius: 8px;
}
.v-progress-linear {
  font-size: 16px;
  font-weight: bold;
}
</style>
