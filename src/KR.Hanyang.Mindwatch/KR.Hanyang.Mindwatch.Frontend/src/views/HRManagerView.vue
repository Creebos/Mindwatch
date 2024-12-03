<template>
  <v-container>
    <!-- Metrics Card -->
    <v-row justify="center" class="mb-6">
      <v-col cols="12" sm="10" md="8">
        <v-card outlined class="pa-6">
          <v-card-title>Team Survey Overview</v-card-title>
          <v-divider></v-divider>
          <v-card-text>
            <v-row class="mt-4" align="center" justify="center">
              <v-col cols="12" md="10">
                <v-progress-linear value="80" color="primary" class="mb-6" height="20">
                  <template #default>
                    <strong>Survey Completion Rate: 80%</strong>
                  </template>
                </v-progress-linear>
              </v-col>
              <v-col cols="12" md="10">
                <v-progress-linear value="60" color="warning" class="mb-6" height="20">
                  <template #default>
                    <strong>Average Stress Level: Moderate</strong>
                  </template>
                </v-progress-linear>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

    <!-- Bar Chart -->
    <v-row justify="center" class="mb-6">
      <v-col cols="12" md="10">
        <BarChart :labels="chartLabels" :data="chartData" />
      </v-col>
    </v-row>

    <!-- Actions Card -->
    <v-row justify="center">
      <v-col cols="12" sm="8" md="6">
        <v-card outlined class="pa-4">
          <v-card-title>Actions</v-card-title>
          <v-divider></v-divider>
          <v-card-text>
            <p>Manage team surveys and generate reports.</p>
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" class="ma-2">Review Surveys</v-btn>
            <v-btn color="secondary" class="ma-2">Generate Report</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import BarChart from "../components/BarChart.vue";

export default {
  name: "HRManagerView",
  components: {
    BarChart,
  },
  data() {
    return {
      chartLabels: ["January", "February", "March"],
      chartData: [10, 15, 7], // Example data for stress levels
    };
  },
};
</script>

<style scoped>
.v-container {
  padding: 16px;
}
</style>
