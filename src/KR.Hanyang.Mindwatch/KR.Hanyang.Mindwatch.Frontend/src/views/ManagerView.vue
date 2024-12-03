<template>
  <v-container>
    <!-- Metrics Card -->
    <v-row justify="center" class="mb-6">
      <v-col cols="12" sm="10" md="8">
        <v-card outlined class="pa-6">
          <v-card-title>Team Performance Metrics</v-card-title>
          <v-divider></v-divider>
          <v-card-text>
            <v-row class="mt-4" align="center" justify="center">
              <v-col cols="12" md="10">
                <v-progress-linear value="90" color="success" class="mb-6" height="20">
                  <template #default>
                    <strong>Performance: 90%</strong>
                  </template>
                </v-progress-linear>
              </v-col>
              <v-col cols="12" md="10">
                <v-progress-linear value="40" color="error" class="mb-6" height="20">
                  <template #default>
                    <strong>Burnout Risk: High</strong>
                  </template>
                </v-progress-linear>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>

    <!-- Line Chart -->
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
            <p>Schedule team meetings and assign tasks.</p>
          </v-card-text>
          <v-card-actions>
            <v-btn color="primary" class="ma-2">Schedule Meeting</v-btn>
            <v-btn color="secondary" class="ma-2">Assign Tasks</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import BarChart from "../components/BarChart.vue";

export default {
  name: "ManagerView",
  components: {
    BarChart,
  },
  data() {
    return {
      chartLabels: ["January", "February", "March"],
      chartData: [8, 12, 18], // Example data for team trends
    };
  },
};
</script>

<style scoped>
.v-container {
  padding: 16px;
}
</style>
