<script setup lang="ts"></script>

<template>
  <div class="app d-flex flex-column min-vh-100">
    <Header />

    <!-- Main Content -->
    <main class="flex-grow-1">
      <router-view />
    </main>

    <Footer />
  </div>
</template>

<script>
import Footer from "./components/Footer.vue";
import Header from "./components/Header.vue";

export default {
  components: {
    Header,
    Footer,
  },
};
</script>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
