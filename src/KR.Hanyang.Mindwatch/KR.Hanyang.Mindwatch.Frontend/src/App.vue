<template>
  <v-app>
    <!-- App Bar -->
    <v-app-bar app color="primary" dark>
      <v-toolbar-title>MindWatch</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn to="/" text>Home</v-btn>
      <v-btn to="/employee" text>Employee</v-btn>
      <v-btn to="/hr-manager" text>HR Manager</v-btn>
      <v-btn to="/manager" text>Manager</v-btn>
      <v-btn to="/surveyform" text>Survey Form</v-btn>
      <!-- Add Survey Form link -->
      <v-btn text @click="logout" v-if="user">Logout</v-btn>
    </v-app-bar>

    <!-- Main Content -->
    <v-main>
      <router-view />
    </v-main>

    <!-- Footer -->
    <v-footer app color="primary" dark>
      <v-col class="text-center white--text"> &copy; 2024 MindWatch, All Rights Reserved. </v-col>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      user: JSON.parse(localStorage.getItem("user")) || null,
    };
  },
  methods: {
    logout() {
      this.user = null;
      localStorage.removeItem("user");
      this.$router.push("/login");
    },
  },
};
</script>
