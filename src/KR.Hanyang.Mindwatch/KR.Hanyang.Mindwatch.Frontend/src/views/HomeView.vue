<template>
  <v-container class="fill-height d-flex flex-column justify-center align-center">
    <!-- Welcome Section -->
    <v-card outlined class="mb-6 pa-6" max-width="800" style="width: 90%; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1)">
      <v-card-title class="text-h4 text-center">Welcome to MindWatch</v-card-title>
      <v-card-text class="text-center">
        Empowering mental health management through surveys and analysis. Please log in to access your personalized
        dashboard.
      </v-card-text>
    </v-card>

    <!-- Login Form Section -->
    <v-card outlined class="pa-6" max-width="800" style="width: 90%; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1)">
      <v-card-title class="text-h5 text-center">Login</v-card-title>
      <v-divider></v-divider>
      <v-card-text>
        <v-form>
          <!-- Username Field -->
          <v-text-field
            v-model="username"
            label="Username"
            outlined
            dense
            class="mt-4"
            style="font-size: 18px; height: 60px"
          ></v-text-field>

          <!-- Password Field -->
          <v-text-field
            v-model="password"
            label="Password"
            type="password"
            outlined
            dense
            class="mt-4"
            style="font-size: 18px; height: 60px"
          ></v-text-field>
        </v-form>
      </v-card-text>
      <v-card-actions class="justify-center mt-4">
        <v-btn color="primary" class="pa-4" style="font-size: 18px; width: 50%" @click="login"> Login </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
import { authService } from "../services/auth";

export default {
  name: "HomeView",
  data() {
    return {
      username: "",
      password: "",
    };
  },
  methods: {
    login() {
      try {
        const user = authService.login(this.username, this.password);
        localStorage.setItem("user", JSON.stringify(user)); // Save session

        // Redirect based on user role
        if (user.role === "Employee") {
          this.$router.push("/employee");
        } else if (user.role === "HRManager") {
          this.$router.push("/hr-manager");
        } else if (user.role === "Manager") {
          this.$router.push("/manager");
        }
      } catch (error) {
        alert(error.message); // Handle errors gracefully
      }
    },
  },
};
</script>

<style scoped>
.v-container {
  padding: 20px;
}

.v-card {
  border-radius: 12px;
}
</style>
