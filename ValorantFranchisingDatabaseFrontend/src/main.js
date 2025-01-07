import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import router from "./router";
import VueLazyload from "vue-lazyload";

const app = createApp(App);
app.use(VueLazyload, {
  preLoad: 1.3,
  loading: "/src/assets/loading-placeholder.png", // Placeholder image
  attempt: 1,
});
app.use(router);
app.mount("#app");
