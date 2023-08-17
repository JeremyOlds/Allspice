

namespace Allspice.Repositories;

public class RecipesRepository
{
        private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes (title, instructions, img, category, creatorId)
        VALUES (@Title, @Instructions, @Img, @Category, @CreatorId);
        SELECT LAST_INSERT_ID()
        ;";

        int recipeId = _db.ExecuteScalar<int>(sql, recipeData);
        return recipeId;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT
        r.*,
        acc.*
        FROM recipes r
        JOIN accounts acc ON acc.id = r.creatorId
        WHERE r.id = @recipeId LIMIT 1
        ;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(
          sql,
          (recipe, profile)=>
          {
              recipe.Creator = profile;
              return recipe;
          },
          new {recipeId}).FirstOrDefault();
          return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        string sql = @"
        SELECT
        r.*,
        acc.*
        FROM recipes r
        JOIN accounts acc;
        ;";
        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(
          sql,
          (recipe, profile)=>
          {
            recipe.Creator = profile;
            return recipe;
          }
        ).ToList();
        return recipes;
    }

    internal void RemoveRecipe(Recipe foundRecipe)
    {
        string sql = "DELETE FROM recipes WHERE id = @Id";

        _db.Execute(sql, foundRecipe);
    }

    internal Recipe UpdateRecipe(Recipe foundRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        title = @Title,
        instructions = @Instructions,
        img = @Img,
        category = @Category
        WHERE id = @Id
        LIMIT 1;
        SELECT
        r.*,
        acc.*
        FROM recipes r
        JOIN accounts acc ON acc.id = r.creatorId
        WHERE r.id = @Id
        ";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(
          sql,
          (recipe, profile)=>
          {
            recipe.Creator = profile;
            return recipe;
          },
          foundRecipe).FirstOrDefault();
          return recipe;
    }
}
