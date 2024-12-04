<template>
  <div class="layout">
    <HeaderComponent />
    <main class="main-content">
      <slot />
    </main>
    <FooterComponent />
  </div>
</template>

<script>
import FooterComponent from "./FooterComponent.vue";
import HeaderComponent from "./HeaderComponent.vue";

export default {
  name: "LayoutComponent",
  components: {
    HeaderComponent,
    FooterComponent,
  },
};
</script>

<style scoped>
.layout {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}
.main-content {
  flex-grow: 1;
  padding: 2rem;
  background-color: #f5f5f5;
}
</style>
