import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class IngredientsService {

  async getIngredientsByRecipe(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('ingredients res data', res.data)
    const ingredients = res.data.map(i => new Ingredient(i))
    logger.log('mapped ingredients', ingredients)
    AppState.ingredients = ingredients
    logger.log('appstate ingredients', AppState.ingredients)

  }
}


export const ingredientsService = new IngredientsService;