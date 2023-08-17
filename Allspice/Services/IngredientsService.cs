using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _ingredientsRepository;

    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
        _ingredientsRepository = ingredientsRepository;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {

        int ingredientId = _ingredientsRepository.CreateIngredient(ingredientData);
        Ingredient ingredient = GetIngredientById(ingredientId);
        return ingredient;
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);
        if(ingredient == null)
        {
          throw new Exception("BAD ID");
        }
        return ingredient;
    }

    internal List<Ingredient> GetIngredientRecipeById(int recipeId)
    {
        List<Ingredient> ingredients = _ingredientsRepository.GetIngredientRecipeById(recipeId);
        return ingredients;
    }

    internal void RemoveIngredient(int ingredientId, string userId)
    {
        Ingredient foundIngredient = GetIngredientById(ingredientId);
        if(foundIngredient.creatorId != userId)
        {
          throw new Exception("You cannot delete others ingredients");
        }
        _ingredientsRepository.RemoveIngredient(ingredientId);
    }
}
