<template>
  <div id="creatVault">
    <form class="post-new" @submit.prevent="postVaultToApi">
      <!-- aria-describedby="emailHelp" -->
      <label for="PostTitle" class="col-sm-2 col-form-label">Title</label>
      <input required type="text" class="form-control form-scheme" id="PostTitle" placeholder="What will you call it?"
        v-model="newVault.Name" />
      <label for="postBody" class="col-sm-2 col-form-label">Post Body and Description</label>
      <textarea required class="form-control form-scheme" placeholder="What would you like to talk about?" id="postBody"
        rows="3" v-model="newVault.Description"></textarea>
      <button class="btn btn-info btn-sm" type="submit">Post</button>
    </form>
  </div>
</template>


<script>
  export default {
    name: 'createVault',
    data() {
      return {
        newVault: {
          Name: "",
          Description: ""
        }
      };
    },
    methods: {
      clearForm() {
        this.newVault.Name = "";
        this.newVault.Description = "";
      },
      postVaultToApi() {
        if (this.newVault.Name && this.newVault.Description) {
          this.$store.dispatch("postVaultToApi", { ...this.newVault })
          // .then(this.clearForm());
          this.clearForm();
        }
      },
    }
  }
</script>


<style scoped>

</style>