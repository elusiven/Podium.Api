<template>
  <div id="app">
    <app-nav-bar />
    <main role="main" class="flex-shrink-0">
      <router-view />
    </main>
  </div>
</template>

<script>
// @ is an alias to /src
import NavBar from "@/components/NavBar.vue";

export default {
  name: "App",
  components: {
    "app-nav-bar": NavBar
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

main {
  padding-top: 100px;
}
</style>
