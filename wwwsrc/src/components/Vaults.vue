<template>
  <div class="vaults-contain">
    <router-link
      v-for="vault in vaults"
      :key="vault.id"
      class="card bg-secondary mb-3"
      style="max-width: 20rem;"
      :to="routerStr + vault.id"
    >
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
  .vaults-contain {
    margin-right: auto;
    margin-left: auto;
  }
  .card {
    margin-right: auto;
    margin-left: auto;
  }
</style>
