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
                <v-progress-linear
                  value="70"
                  color="success"
                  class="mb-6"
                  height="20"
                >
                  <template #default>
                    <strong>Survey Completion: 70%</strong>
                  </template>
                </v-progress-linear>
              </v-col>
              <v-col cols="12" md="10">
                <v-progress-linear
                  value="50"
                  color="info"
                  class="mb-6"
                  height="20"
                >
                  <template #default>
                    <strong>Stress Level: Moderate</strong>
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
import BarChart from "@/components/BarChart.vue";

export default {
  name: "EmployeeView",
  components: {
    BarChart,
  },
  data() {
    return {
      chartLabels: ["January", "February", "March"],
      chartData: [12, 19, 3],
    };
  },
  methods: {
    startSurvey() {
      this.$router.push("/surveyform");
    },
  },
};
</script>

<style scoped>
/* Add padding and spacing to the container */
.v-container {
  padding: 16px;
}

/* Ensure cards have enough spacing */
.v-card {
  border-radius: 8px;
}

.v-progress-linear {
  font-size: 16px;
  font-weight: bold;
}
</style>
