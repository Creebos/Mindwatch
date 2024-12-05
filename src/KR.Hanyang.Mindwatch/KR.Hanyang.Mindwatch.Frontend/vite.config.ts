import vue from "@vitejs/plugin-vue";
import { defineConfig } from "vite";
import vuetify from "vite-plugin-vuetify";

export default defineConfig({
  plugins: [vue(), vuetify({ styles: true })],
  build: {
    rollupOptions: {
      // Vuetify doesnt export its styles lib correctly, so import doesnt work. This handles the problem
      external: ["vuetify/lib/styles"],
    },
  },
  server: {
    host: true,
    port: 5173,
    watch: {
      usePolling: true,
    },
  },
});
