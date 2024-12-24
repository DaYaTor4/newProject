using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        public TraderRecipeContext Context { get;}

        public IngredientController(TraderRecipeContext context)
        {
            Context = context;  
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Ingredient> ingredients = Context.Ingredients.ToList();
            return Ok(ingredients);
        }

    }
}
