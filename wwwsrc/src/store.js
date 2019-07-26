import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";
import AuthService from "./AuthService";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "//localhost:5000/"
  : "//168.192.2.190:5000";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    user: {},
    posts: [],
    vaults: [],
    vaultPosts: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {};
    },
    setPostLine(state, posts = []) {
      state.posts = posts;
    },
    setVaults(state, data) {
      state.vaults = data;
    },
    setVaultPosts(state, data) {
      state.vaultPosts = data;
    }
  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds);
        commit("setUser", user);
        router.push({ name: "home" });
      } catch (e) {
        console.warn(e.message);
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds);
        commit("setUser", user);
        router.push({ name: "home" });
      } catch (e) {
        console.warn(e.message);
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout();
        if (!success) {
        }
        commit("resetState");
        router.push({ name: "login" });
      } catch (e) {
        console.warn(e.message);
      }
    },
    getPosts({ commit, dispatch }) {
      api.get("keeps").then(res => {
        commit("setPostLine", res.data);
        console.log("GetPosts response", res);
      });
    },
    deletePost({ commit, dispatch }, id) {
      api
        .delete("keeps/" + id)
        .then(res => {
          console.log('deletePost',res);
          dispatch("getPosts");
        })
        .catch(err => {
          console.error(err);
        });
    },
    likeDislike({ commit, dispatch }, id, isLike) {
      api
        .put("keeps/" + id, isLike)
        .then(res => {
          console.log('likeDislike',res);
          dispatch("getPosts");
        })
        .catch(err => {
          console.error(err);
        });
    },
    postToApi({ commit, dispatch }, data) {
      api
        .post("keeps", data)
        .then(res => {
          console.log("postToApi output", res);
          dispatch("getPosts");
        })
        .catch(err => {
          console.error(err);
        });
    },
    getVaults({ commit, dispatch }) {
      api
        .get("users/vaults")
        .then(res => {
          commit("setVaults", res.data);
          console.log("get vaults output", res);
        })
        .catch(err => {
          console.error(err);
        });
    },
    openVault({ commit, dispatch }, id) {
      api
        .get("users/vaults/" + id)
        .then(res => {
          commit("setVaultPosts", res.data);
          console.log("open vault output", res, res.data);
        })
        .catch(err => {
          console.error(err);
        });
    },
    removeVaultKeep({ commit, dispatch }, data) {
      api
        .delete("users/vaults/vk/" + data.vkId, data.IntId)
        .then(res => {
          // commit("setVaultPosts", res.data);
          console.log("remove vault output", res, res.data);
          dispatch('openVault', data.vkId);
        })
        .catch(err => {
          console.log("users/vaults/vk/" + data.vkId, data);
          console.error(err);
        });
    }
  }
});
