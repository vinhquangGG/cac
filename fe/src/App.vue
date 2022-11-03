<template>
  <div class="app">
    <the-header></the-header>
    <the-content></the-content>
  </div>
</template>

<script>
import TheHeader from "@/layout/TheHeader.vue";
import TheContent from "@/layout/TheContent.vue";

export default {
  name: "App",
  components: {
    TheHeader,
    TheContent,
  },
};
</script>

<style>
.app {
  position: relative;
  height: 100vh;
}
</style>
