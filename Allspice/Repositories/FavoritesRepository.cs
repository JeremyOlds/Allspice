using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allspice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateFavorite(Favorite favoriteData)
    {
      string sql = @"
      INSERT INTO favorites (accountId, recipeId)
      VALUES (@AccountId, @RecipeId);
      SELECT LAST_INSERT_ID()
      ;";
      int favoriteId = _db.ExecuteScalar<int>(sql, favoriteData);
      return favoriteId;
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
      string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";

      Favorite favorite = _db.QueryFirstOrDefault<Favorite>(sql,new {favoriteId});
      return favorite;
    }

    internal List<RecipeFavorite> GetMyRecipeFavorites(string userId)
    {
        string sql = @"
        SELECT
        fav.*,
        r.*,
        acc.*
        FROM favorites fav
        JOIN recipes r ON r.id = fav.recipeId
        JOIN accounts acc ON acc.id = fav.accountId
        WHERE fav.accountId = @userId
        ;";

        List<RecipeFavorite> recipes = _db.Query<Favorite, RecipeFavorite, Profile,RecipeFavorite>(
          sql,
          (favorite, recipe, profile)=>
          {
            recipe.FavoriteId = favorite.Id;
            recipe.Creator = profile;
            return recipe;
          },
        new {userId}).ToList();
        return recipes;
    }

    internal void RemoveFavorite(int favoriteId)
    {
      string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1;";

      _db.Execute(sql, new {favoriteId});
    }
}
