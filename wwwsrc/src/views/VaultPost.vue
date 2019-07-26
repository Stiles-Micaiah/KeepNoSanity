<template>
  <div class="VaultPost">
    <div
      style="height: auto; margin: 25px;"
      class="card card-803"
      v-for="post in vaultposts"
      :key="post.id"
    >
      <h3 class="title-color card-header">{{ post.name }}</h3>
      <h6 class="mix-a-lot">Post By:{{ post.userId }}</h6>
      <div class="card-body card-body-with-image">
        <p class="body-color card-text">{{ post.description }}</p>
        <div v-if="post.img" class="card-body-img">
          <img :src="post.img" alt="Card image" />
        </div>
      </div>

      <div class="card-body">
        <div v-if="user.id != post.userId">
          <button class="btn btn-info rounded-pill">Like</button>
          <button class="btn btn-info rounded-pill">Dislike</button>
        </div>
        <button
          v-else
          @click="deletePost(post.id)"
          class="btn btn-danger rounded-pill"
        >
          Delete
        </button>
      </div>
      <div
        style="-webkit-text-fill-color: blueviolet;"
        class="card-footer text-muted"
      >
        {{ post.userId }} but in Purple
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "VaultPost",
    props: ["id"],
    mounted() {
      this.$store.dispatch("openVault", this.id);
      if (!user) router.push({ name: "home" });
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaultposts() {
        return this.$store.state.vaultPosts;
      }
    }
  };
</script>

<style scoped></style>
