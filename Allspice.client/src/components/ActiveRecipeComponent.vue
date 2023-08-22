<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-6 col-12 d-flex ps-0">
        <!-- STUB image and like -->
        <img class="img-fluid rounded-start" :src="recipe.img" alt="uh oh">
        <div v-if="favorite == null">
          <i @click="createFavorite(recipe.id)"
            class="fs-2 mdi mdi-heart-outline like selectable text-danger rounded-bottom"></i>
        </div>
        <div v-else>
          <i @click="removeFavorite(favorite?.id)"
            class="fs-2 mdi mdi-heart like selectable text-danger rounded-bottom"></i>
        </div>
      </div>
      <div class="col-md-6 col-12">
        <!-- STUB name and category -->
        <div class="row">
          <div class="col-12 fs-3 d-flex justify-content-between">
            <div>
              {{ recipe.title }} <span class="category rounded px-1">{{ recipe.category }}</span>
            </div>
            <div><button class="btn btn-danger">Delete</button></div>
          </div>
        </div>
        <!-- STUB instructions and ingredients -->
        <div class="row pt-3 justify-content-around">
          <div class="col-md-5 col-12 elevation-3">
            <div class="fs-3 instructions rounded"> Recipe Instructions</div>
            <div>{{ recipe.instructions }}</div>
          </div>
          <div class="col-md-5 col-12 elevation-3">
            <div class="fs-3 instructions rounded">Recipe Ingredients</div>
            <div class="pb-1" v-for="i in ingredients" :key="i.id">{{ i?.quantity }} {{ i?.name }}</div>
            <div class="d-flex justify-content-end">
              <button class="btn btn-success rounded">create Ingredient</button>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="d-flex justify-content-end">
            <p>Published by: {{ recipe.Creator?.name }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { favoritesService } from "../services/FavoritesService.js";
import { recipesService } from "../services/RecipesService.js"

export default {
  setup() {



    return {

      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients),
      favorite: computed(() => {
        const result = AppState.favorites.find(f => f.recipeId == AppState.activeRecipe.id)
        let int = 2 + 2
        return result
      }),


      async createFavorite(recipeId) {
        try {
          const favoriteData = { recipeId }
          await favoritesService.createFavorite(favoriteData)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      },
      async removeFavorite(favoriteId) {
        try {
          await favoritesService.removeFavorite(favoriteId)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      },
      async removeRecipe() {
        try {
          const recipeId = AppState.activeRecipe
          await recipesService.removeRecipe(recipeId)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      }
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
  background-color: green;
}
</style>