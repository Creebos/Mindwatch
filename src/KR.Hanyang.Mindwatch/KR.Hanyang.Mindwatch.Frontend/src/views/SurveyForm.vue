<template>
  <v-container>
    <v-card outlined class="pa-6">
      <v-card-title class="text-h4">Survey Form</v-card-title>
      <v-divider></v-divider>
      <v-card-text>
        <p>Here you can fill out your mental health survey.</p>
        <!-- Add survey fields here -->
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary">Submit</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
export default {
  name: "SurveyForm",
};
</script>

<style scoped>
.v-container {
  padding: 16px;
}
</style>
