import { createRouter, createWebHistory } from "vue-router";
import Home from "./views/Home.vue";
import Americas from "./views/Americas.vue";
import EMEA from "./views/EMEA.vue";
import China from "./views/China.vue";
import Pacific from "./views/Pacific.vue";

const routes = [
  { path: "/", name: "Home", component: Home },
  { path: "/americas", name: "Americas", component: Americas },
  { path: "/emea", name: "EMEA", component: EMEA },
  { path: "/china", name: "China", component: China },
  { path: "/pacific", name: "Pacific", component: Pacific },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
