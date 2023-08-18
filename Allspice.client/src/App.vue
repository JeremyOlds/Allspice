<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <ModalComponentXL id="recipeDetails">
    <template #body>
      <ActiveRecipeComponent />
    </template>

  </ModalComponentXL>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import ModalComponentXL from "./components/ModalComponentXL.vue"
import ActiveRecipeComponent from "./components/ActiveRecipeComponent.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, ModalComponentXL, ActiveRecipeComponent }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
