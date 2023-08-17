
namespace Allspice.Controllers;


[ApiController]
[Route("api/[controller]")]
public class IngredientsController :ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0Provider;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
    {
        _ingredientsService = ingredientsService;
        _auth0Provider = auth0Provider;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
      try 
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        ingredientData.creatorId = userInfo.Id;
        Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{ingredientId}")]
    public async Task<ActionResult<string>> RemoveIngredient(int ingredientId)
    {
      try 
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        _ingredientsService.RemoveIngredient(ingredientId, userInfo.Id);
        return Ok("Ingredient was deleted.");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

}
