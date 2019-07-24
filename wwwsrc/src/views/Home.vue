<template>
  <div class="home">
    <h1>Welcome Home {{ user.username }}</h1>
    <!-- <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link> -->
    <div style="height: auto; margin: 25px;" class="card card-803 " v-for="post in posts" :key="post.id">
      <h3 class="title-color card-header">{{post.name}}</h3>
      <h6 class="mix-a-lot">Post By:{{post.userId}}</h6>
      <div class="card-body card-body-with-image">
        <p class=" body-color card-text">{{post.description}}</p>
      <img class="card-body-img" :src="post.img" alt="Card image">
      </div>

      <div class="card-body">
        <div v-if="user.id != post.userId">
        <button class="btn btn-info rounded-pill ">Like</button>
        <button class="btn btn-info rounded-pill ">Dislike</button>
        </div>
        <button v-else @click="deletePost(post.id)" class="btn btn-danger rounded-pill ">Delete</button>
      </div>
      <div style="-webkit-text-fill-color: blueviolet;" class="card-footer text-muted">
        {{post.user}} but in Purple
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "home",
    mounted() {
this.$store.dispatch('getPosts');
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      posts() {
        return this.$store.state.posts.reverse();
      }
    },
    methods: {
      deletePost(id) {
        this.$store.dispatch('deletePost', id);
      }
      // logout() {
      //   this.$store.dispatch("logout");
      // }
    }
  };
</script>


<style scoped>
  .card-803 {
    max-width: 100%;
    margin-right: auto !important;
    margin-left: auto !important;
    width: 50%;
  }
  .card-body-with-image {
    display: flex;
    justify-content: center;
    flex-direction: column;
  }
  .card-body-img{
    /* display: unset; */
    height: auto;
    width: auto;
    max-height: 100%;
    max-width: 100%;
  }

  .card,
  .card>* {
    background-color: rgba(85, 1, 163, 0.226);
  }

  .mix-a-lot {
    -webkit-text-fill-color: deepskyblue;
  }

  .title-color {
    -webkit-text-fill-color: cyan;
  }

  .body-color {
    -webkit-text-fill-color: turquoise;
  }
</style>