

namespace Allspice.Models;

public class Favorite
{
    public int Id { get; set; }
    public string AccountId { get; set; }
    public int RecipeId { get; set; }
}
public class ProfileFavorite : Profile
{
  public int FavoriteId { get; set; }
}
public class RecipeFavorite : Recipe
{
  public int FavoriteId { get; set; }
}
