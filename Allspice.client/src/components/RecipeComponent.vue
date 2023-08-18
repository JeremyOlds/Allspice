<template>
  <div @click="setActiveRecipe(recipeProp), getIngredientsByRecipe(recipeProp.id)" data-bs-toggle="modal"
    data-bs-target="#recipeDetails" class="img my-3 card d-flex justify-content-between text-white selectable"
    v-bind:style="{ 'background-image': 'url(' + recipeProp.img + ')' }">
    <div>
      <h4>{{ recipeProp.category }} <span><i class="mdi mdi-heart-outline text-danger"></i></span></h4>
    </div>
    <div>
      <h4>{{ recipeProp.title }}</h4>
    </div>
  </div>
</template>


<script>
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { ingredientsService } from "../services/IngredientsService.js"

export default {
  props: {
    recipeProp: { type: Recipe, required: true }
  },
  setup() {

    return {

      setActiveRecipe(recipe) {
        try {
          recipesService.setActiveRecipe(recipe)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      },
      async getIngredientsByRecipe(recipeId) {
        try {
          await ingredientsService.getIngredientsByRecipe(recipeId)
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
.card {
  height: 40vh;
  width: 30vh;
  background-size: cover;
  background-position: center;
}

@media screen and (max-width: 769px) {
  .card {
    height: 40vh;
    width: 42vh;
    background-size: cover;
    background-position: center;
  }
}
</style>