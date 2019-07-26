<template>
  <div class="vaults-contain">
    <router-link v-for="vault in vaults" :key="vault.id" class="card card-803 bg-mine mb-3" style="max-width: 20rem;"
      :to="routerStr + vault.id">
      <div class="card-header">{{ vault.name }}</div>
      <div class="card-body">
        <h4 class="card-title">Description</h4>
        <p class="card-text">{{ vault.description }}</p>
      </div>
    </router-link>
  </div>
</template>

<script>
  export default {
    name: "Vaults",
    data() {
      return {
        routerStr: "/vault/"
      };
    },
    mounted() {
      this.$store.dispatch("getVaults");
    },
    computed: {
      vaults() {
        return this.$store.state.vaults;
      }
    }
  };
</script>

<style scoped>
  a.bg-mine:hover {
    background-color: black;
  }
  a.bg-mine > *:hover {
    -webkit-text-fill-color: red;
  }

  .card-title {
    -webkit-text-fill-color: cyan;
  }

  .card-header {
    -webkit-text-fill-color: cyan;

  }

  .card-text {
    -webkit-text-fill-color: turquoise;

  }

  .vaults-contain {
    margin-right: auto;
    margin-left: auto;
  }

  .card {
    margin-right: auto;
    margin-left: auto;
  }

  .card,
  .card>* {
    background-color: rgba(85, 1, 163, 0.226) !important;
  }
</style>