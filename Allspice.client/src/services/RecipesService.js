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
}


export const recipesService = new RecipesService;