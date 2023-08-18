<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-6 col-12 d-flex ps-0">
        <!-- STUB image and like -->
        <img class="img-fluid rounded-start" :src="recipe.img" alt="uh oh">
        <div>
          <i class="fs-2 mdi mdi-heart-outline like selectable text-danger rounded-bottom"></i>
        </div>
      </div>
      <div class="col-md-6 col-12">
        <!-- STUB name and category -->
        <div class="row">
          <div class="col-12 fs-3">{{ recipe.title }} <span class="category rounded px-1">{{ recipe.category }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {



    return {

      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients)
    }
  }
}
</script>


<style lang="scss" scoped>
.img {
  max-height: 60vh;
}

.like {
  position: relative;
  top: 0em;
  left: -2em;
  background-color: gray;
  opacity: 80%;

}

.category {
  background-color: gray;
  color: white;
}


.instructions {
  max-width: 40vh;
}
</style>