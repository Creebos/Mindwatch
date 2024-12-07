<template>
  <nav class="navbar navbar-expand-lg" style="background-color: #f8f9fa; border-bottom: 2px solid #e9ecef">
    <div class="container">
      <!-- Brand -->
      <a class="navbar-brand fw-bold text-primary" href="#"> <i class="bi bi-eyeglasses"></i> Mindwatch </a>

      <!-- Toggle Button for Mobile -->
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarNav"
        aria-controls="navbarNav"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>

      <!-- Navigation Links -->
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav me-auto">
          <li class="nav-item">
            <a class="nav-link text-secondary" href="/questionnaires">Questionnaires</a>
          </li>
          <li class="nav-item">
            <a class="nav-link text-secondary" href="/incidents">Incidents</a>
          </li>
        </ul>

        <!-- Login/User Area -->
        <div class="d-flex align-items-center">
          <template v-if="!loggedIn">
            <button class="btn btn-outline-primary me-2" @click="login"><i class="bi bi-person"></i> Login</button>
          </template>
          <template v-else>
            <span class="navbar-text fw-bold text-secondary me-2">
              <i class="bi bi-person-circle"></i> {{ username }}
            </span>
          </template>
        </div>
      </div>
    </div>
  </nav>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";

export default defineComponent({
  name: "Header",
  setup() {
    const loggedIn = ref(false); // Track login state
    const username = ref("Bingus bänger"); // Replace with dynamic user data after login

    const login = () => {
      // Simulate login
      loggedIn.value = true;
    };

    return {
      loggedIn,
      username,
      login,
    };
  },
});
</script>

<style scoped>
.navbar {
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}
.nav-link:hover {
  color: #007bff !important;
  text-decoration: underline;
}
</style>
