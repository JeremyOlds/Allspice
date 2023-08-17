

namespace Allspice.Services;

public class RecipesService
{
        private readonly RecipesRepository _recipeRepository;

    public RecipesService(RecipesRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        int recipeId = _recipeRepository.CreateRecipe(recipeData);
        Recipe recipe = GetRecipeById(recipeId);
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _recipeRepository.GetRecipeById(recipeId);
        if(recipe == null)
        {
          throw new Exception("Bad Id");
        }
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _recipeRepository.GetRecipes();
        return recipes;
    }

    internal void RemoveRecipe(int recipeId, Account userInfo)
    {
        Recipe foundRecipe = GetRecipeById(recipeId);
        if(foundRecipe.CreatorId != userInfo.Id)
        {
          throw new Exception("You cannot delete Recipes that aren't yours.");
        }
        _recipeRepository.RemoveRecipe(foundRecipe);
    }

    internal Recipe UpdateRecipe(int recipeId, Recipe recipeData, Account userInfo)
    {
        Recipe foundRecipe = GetRecipeById(recipeId);
        if(foundRecipe.CreatorId != userInfo.Id)
        {
          throw new Exception("You are not the creator of this recipe");
        }
        foundRecipe.Title = recipeData.Title ?? foundRecipe.Title;
        foundRecipe.Instructions = recipeData.Instructions ?? foundRecipe.Instructions;
        foundRecipe.Category = recipeData.Category ?? foundRecipe.Category;
        foundRecipe.Img = recipeData.Img ?? foundRecipe.Img;

        Recipe editedRecipe = _recipeRepository.UpdateRecipe(foundRecipe);
        return editedRecipe;
    }
}
