import { createRouter, createWebHistory } from "vue-router";
import Home from "./views/Home.vue";
import RegionPage from "./views/RegionPage.vue";
import TeamPage from "./views/TeamPage.vue";
import PlayerPage from "./views/PlayerPage.vue";

const routes = [
  { path: "/", name: "Home", component: Home },
  {
    path: "/region/:region",
    name: "RegionPage",
    component: RegionPage,
    props: true,
  },
  { path: "/team/:id", name: "TeamPage", component: TeamPage, props: true },
  {
    path: "/player/:id/team/teamId",
    name: "player",
    component: PlayerPage,
    props: true,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
