import "bootstrap";
import "bootstrap-icons/font/bootstrap-icons.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { createPinia } from "pinia";
import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
const app = createApp(App);

app.use(router);

const pinia = createPinia();
app.use(pinia);

app.mount("#app");
