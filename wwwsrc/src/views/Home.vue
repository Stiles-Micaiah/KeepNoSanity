<template>
  <div class="home">
    <!-- <h1>Welcome Home {{ user.username }}</h1> -->
    <!-- <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>-->
    <form class="post-new" @submit.prevent="postToApi">
      <!-- aria-describedby="emailHelp" -->
      <label for="PostTitle" class="col-sm-2 col-form-label">Title</label>
      <input
        required
        type="text"
        class="form-control form-scheme"
        id="PostTitle"
        placeholder="What will you call it?"
        v-model="newPost.Name"
      />
      <label for="postBody" class="col-sm-2 col-form-label">Post Body and Description</label>
      <textarea
        required
        class="form-control form-scheme"
        placeholder="What would you like to talk about?"
        id="postBody"
        rows="3"
        v-model="newPost.Description"
      ></textarea>
      <button class="btn btn-info btn-sm" type="submit">Post</button>
    </form>
    <router-link
      v-if="user.id"
      class="btn btn-primary float-left"
      to="/createvault"
      style="margin-right: -4vw;"
    >Create Vault</router-link>
    <img src="http://wac.450f.edgecastcdn.net/80450F/loudwire.com/files/2015/06/Disturbed-Immortalized.jpg" alt="">
    <div
      style="height: auto; margin: 25px;"
      class="card card-803"
      v-for="post in posts"
      :key="post.id"
    >
      <h3 class="title-color card-header wrapped-text">{{post.name}}</h3>
      <h6 class="mix-a-lot wrapped-text">Post By:{{post.userId}}</h6>
      <div class="card-body card-body-with-image">
        <p class="body-color card-text wrapped-text">{{post.img}}</p>
        <!-- <div v-if="post.img" :style="{ 'background-image': 'url(' + post.img + ')' }" class="Display-Images card-body-img"> -->
          <img v-if="post.img" :src="post.img" alt="Card image" />
        <!-- </div> -->
      </div>

      <div class="card-body">
        <div v-if="user.id != post.userId" class="justify-content-between">
          <button @click="like(post.id, true)" class="btn btn-info btn-sm">Like</button>
          {{post.views}}
          <button
            @click="like(post.id, false)"
            class="btn btn-info btn-sm"
          >Dislike</button>
        </div>
        <button v-else @click="deletePost(post.id)" class="btn btn-danger rounded-pill">Delete</button>

        <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
          <div class="btn-group" role="group">
            <button
              id="btnGroupDrop2"
              type="button"
              class="btn btn-success dropdown-toggle"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Add To Vault</button>
            <div class="dropdown-menu" aria-labelledby="btnGroupDrop2">
              <a
                v-for="vault in vaults"
                :key="vault.id"
                class="dropdown-item"
                @click="addToVault(post.id, vault.id)"
              >{{vault.name}}</a>
            </div>
          </div>
        </div>
      </div>
      <div
        style="-webkit-text-fill-color: blueviolet;"
        class="card-footer text-muted"
      >{{post.userId}} but in Purple</div>
    </div>

    <Vaults />
  </div>
</template>


<script>
import Vaults from "@/components/Vaults.vue";
export default {
  name: "home",
  data() {
    return {
      newPost: {
        Name: "",
        Description: "",
        img: ""
      }
    };
  },
  mounted() {
    // alert("ninjas");
    // if (!user) router.push({ name: "login" });
    this.$store.dispatch("getPosts");
    this.$store.dispatch("getVaults");
  },
  created() {
    // if (!user) router.push({ name: "login" });
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    posts() {
      return this.$store.state.posts.reverse();
    }
  },
  methods: {
    clearForm() {
      this.newPost.Name = "";
      this.newPost.Description = "";
      this.newPost.img = "";
    },
    deletePost(id) {
      this.$store.dispatch("deletePost", id);
    },
    postToApi() {
      if (this.newPost.Name && this.newPost.Description) {
        this.$store.dispatch("postToApi", { ...this.newPost });
        // .then(this.clearForm());
        this.clearForm();
      }
    },
    like(id, isLike) {
      let data = {
        Bool: isLike,
        id: id
      };
      this.$store.dispatch("likeDislike", data);
    },
    addToVault(PostId, VaultId) {
      let data = {
        vkId: VaultId,
        KeepId: PostId
      };
      this.$store.dispatch("addVaultKeep", data);
    }
    // logout() {
      //   this.$store.dispatch("logout");
    // }
  },
  components: {
    Vaults
  }
};
</script>


<style scoped>
.dropdown-menu {
  background-image: linear-gradient(
    to top right,
    rgba(195, 0, 255, 0.473),
    rgb(0, 255, 221, 0.473)
  );
  background-color: #00000000;
}

.dropdown-item {
  -webkit-text-fill-color: cyan;
}

.dropdown-item:hover {
  color: black;
  -webkit-text-fill-color: red;
  background-color: #000000;
}

.post-new {
  /* height: 18vh; */
  display: grid;
  margin: 5px;
  margin-right: auto;
  margin-left: auto;
  width: 30vw !important;
  background-image: linear-gradient(
    to top right,
    rgba(195, 0, 255, 0.219),
    rgb(0, 255, 221, 0.219)
  ) !important;
}

.post-new > label {
  text-shadow: 0px 0px 0px blue, 0px 0px 0px blue, 0px 0px 0px blue,
    0px 0px 0px blue;
  display: contents;
  color: rgb(190, 190, 224);
}

.form-scheme {
  background-color: rgba(0, 0, 0, 0.363);
}

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
  height: 45vh;/*this is limiting immage div height */
}

.card-body-img {
 /* // display: unset;
  height: auto;
  width: auto; */
  height: 50vw;
  width: 100%; 
}

.Display-Images {
   background-position: center;
   background-size: cover;
   height: 50vw;
 }

img {
  /* max-width: 100%; */
  height: 100%;
  /* height: auto; */
  /* width: auto; */
  /* margin: 20px; */
}

.card,
.card > * {
  background-color: rgba(85, 1, 163, 0.226);
}

 .wrapped-text {
  white-space: nowrap;
  height: 1rem;
  overflow: hidden;
  text-overflow: ellipsis;
}

.mix-a-lot,
.dropdown-item {
  -webkit-text-fill-color: deepskyblue;
}

.title-color {
  -webkit-text-fill-color: cyan;
}

.body-color {
  -webkit-text-fill-color: turquoise;
}
</style>







        <!-- 

                this URL is the only one that wont wont as a background URL 


        origanal code        
         <div v-if="post.img" :style="{ 'background-image': 'url(' + post.img + ')' }" class="card-body-img">


        even hardcoded

        <div v-if="post.img" style="https://img.discogs.com/daMncbYMxHFu1_hj1q4V9FJ3tLU=/fit-in/600x530/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-7376871-1441820995-7082.jpeg.jpg" class="card-body-img"> 
        
        -->