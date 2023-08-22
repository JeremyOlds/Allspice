import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

  async getRecipes() {
    const res = await api.get('api/recipes')
    logger.log("get recipes res data", res.data)
    const recipes = res.data.map(r => new Recipe(r));
    logger.log("mapped res data", recipes)
    AppState.recipes = recipes;
    logger.log("Appstate Recipes", AppState.recipes)
  }
  setActiveRecipe(recipe) {
    AppState.activeRecipe = recipe
    logger.log("setting active recipe", AppState.activeRecipe)
  }
  async createRecipe(formData) {
    const res = await api.post('api/recipes', formData)
    logger.log('create recipe res data', res.data)
    const recipe = new Recipe(res.data)
    logger.log('create turned to class', recipe)
    AppState.recipes.push(recipe)
    logger.log('appstate create', AppState.recipes)
  }
  async removeRecipe(recipeId) {
    const res = await api.delete(`api/recipes/${recipeId}`)
    const recipeIndex = AppState.recipes.findIndex(r => r.id == recipeId)
    AppState.recipes.splice(recipeIndex, 1)
  }

}


export const recipesService = new RecipesService;