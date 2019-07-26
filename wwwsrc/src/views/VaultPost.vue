<template>
  <!-- vault-keep-group -->
  <div class="VaultPost container-fluid">
    <div class="row">
      <div
        class="card col-2"
        v-for="post in vaultposts"
        :key="post.id"
        style="width: 18rem;"
      >
        <img v-if="post.img" :src="post.img" class="card-img-top" />
        <div v-else style=" width:100%; height: 33% "></div>
        <div class="card-body">
          <h5 class="card-title title-color">{{ post.name }}</h5>
          <p class="card-text mix-a-lot">{{ post.description }}</p>
          <button @click="removeVK(post.id)" class="btn btn-danger">
            Remove
          </button>
        </div>
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
    },
    methods: {
      removeVK(id) {
        let data = {
          KeepId: id,
          VaultId: this.id
        };
        this.$store.dispatch("removeVaultKeep", data);
      }
    }
  };
</script>

<style scoped>
  .vault-keep-group {
    display: inline-block;
  }
  .card,
  .card > * {
    background-color: rgba(85, 1, 163, 0.226);
  }
  card > img {
    width: 100%;
    height: auto;
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
