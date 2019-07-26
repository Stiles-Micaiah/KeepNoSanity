import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Login from "./views/Login.vue";
import VaultPost from "./views/VaultPost.vue";
import createVault from "./views/createVault.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/login",
      name: "login",
      component: Login
    },
    {
      path: "/createvault",
      name: "createvault",
      component: createVault
    },
    {
      path: "/vault/:id",
      name: "vault",
      props: true,
      component: VaultPost
    }
  ]
});
