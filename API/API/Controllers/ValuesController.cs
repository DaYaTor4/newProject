using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public TraderRecipeContext Context { get; }

        public ValuesController(TraderRecipeContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Ingredient> ing = Context.Ingredients.ToList();
            return Ok(ing);
        }
    }

}
