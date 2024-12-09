<template>
  <footer class="footer mt-auto py-3" style="background-color: #f8f9fa; border-top: 2px solid #e9ecef">
    <div class="container d-flex justify-content-between align-items-center">
      <!-- Left: Brand and Year -->
      <span class="text-muted"> ® Mindwatch, 2024 </span>

      <!-- Right: Project Members -->
      <span class="text-muted"> Daniel, Yunjie, Leandro, Dennis, Yves </span>
    </div>
  </footer>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Footer",
});
</script>

<style scoped>
.footer {
  box-shadow: 0 -4px 6px rgba(0, 0, 0, 0.1);
}
</style>
