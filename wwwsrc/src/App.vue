<template>
  <div id="app">
  <nav class="navbar navbar-expand-lg navbar-dark bg-primary" role="navigation">
    <router-link class="navbar-brand" to="/">
      <img src="../src/assets/icons__portal_by_gothpanda.png" style="height: 30px; width: 30px;">Micaiah</router-link>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01"
      aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarColor01">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item active">
          <router-link class="nav-link" to="/about">GitHub <span class="sr-only">(current)</span></router-link>
        </li>
        <li class="nav-item">
          <router-link class="nav-link" to="/about">About</router-link>
        </li>
        <li class="nav-item">
          <router-link class="nav-link" to="/about">About</router-link>
        </li>
        <li class="nav-item">
          <router-link class="nav-link" to="/about">About</router-link>
        </li>
      </ul>
      <!-- <form class="form-inline my-2 my-lg-0">
        <input class="form-control mr-sm-2" type="text" placeholder="Search">
        <button class="btn btn-secondary my-2 my-sm-0" type="submit">Search</button>
      </form> -->
    <div class="login-inline" v-if="!user.id">
      <form v-if="loginForm" @submit.prevent="loginUser">
        <input type="email" v-model="creds.email" placeholder="email">
        <input type="password" v-model="creds.password" placeholder="password">
        <button type="submit">Login</button>
      </form>
      <form v-else @submit.prevent="register">
        <input type="text" v-model="newUser.username" placeholder="name">
        <input type="email" v-model="newUser.email" placeholder="email">
        <input type="password" v-model="newUser.password" placeholder="password">
        <button type="submit">Create Account</button>
      </form>
      <div @click="loginForm = !loginForm">
        <p v-if="loginForm">No account Click to Register</p>
        <p v-else>Already have an account click to Login</p>
      </div>
    </div>
      <button v-else @click="logout">logout</button>
    </div>
  </nav>
    <router-view />
  </div>
</template>

<script>
  export default {
    name: "app",
    data() {
          return {
            loginForm: true,
            creds: {
              email: "",
              password: ""
            },
            newUser: {
              email: "",
              password: "",
              username: ""
            }
          };
        },
        mounted() {
          if(!user) router.push({ name: "home" });
        },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
        register() {
        this.$store.dispatch("register", this.newUser);
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
      }
    }
  };
</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>

 
<style>
body {
    background: none;
  }
  html {
    background-image: url('https://www.pixelstalk.net/wp-content/uploads/2016/03/Desktop-Neon-Wallpaper-HD-1920x1080.jpg');
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    background-size: cover;
    background-attachment: fixed;
  }
</style>

