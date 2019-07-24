<template>
  <div id="Vaults">
    <!-- <div class="card bg-secondary mb-3" v-for="vault in vault" :key="vault.id" style="max-width: 20rem;">
      <div class="card-header">{{vault.name}}</div>
      <div class="card-body">
        <h4 class="card-title">Description</h4>
        <p class="card-text">{{vault.description}}</p>
      </div>
    </div> -->
  </div>
</template>


<script>
  export default {
    name: 'Vaults',
    mounted() {
      this.$store.dispatch('getVaults');
    },
    computed: {
      vaults() {
        return this.$store.state.vaults;
      }
    }
  }
</script>


<style scoped>

</style>