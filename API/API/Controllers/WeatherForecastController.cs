using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private static List<Recipe> Recipes = new List<Recipe>();

        public RecipeController(ILogger<RecipeController> logger)
        {
            _logger = logger;
        }

        public static List<Recipe> recipes = new()
        {
            new Recipe {Id = 1, DishName = "Борщ", Ingredients = new[] { "весь холодос" }, CookingTime = 1488, Instructions = "хз, чел"},
            new Recipe {Id = 3, DishName = "Бутеры", Ingredients = new[] { "кусок хлеба", "гнилая колбоса" }, CookingTime = 1, Instructions = "накидай на хлеб все ингридиенты"},
        };

        [HttpPost("add")]
        public IActionResult AddRecipe(Recipe data)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes[i].Id == data.Id)
                {
                    return BadRequest("Запись с таким id уже существует");
                }
            }

            recipes.Add(data);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRecipe(Recipe data)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes[i].Id == data.Id)
                {
                    recipes[i] = data;
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes[i].Id == id)
                {
                    recipes.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpGet]
        public List<Recipe> GetAll()
        {
            return recipes;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes[i].Id == id)
                {
                    return Ok(recipes[i]);
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }
    }

    public class Recipe
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public string[] Ingredients { get; set; }
        public int CookingTime { get; set; }
        public string Instructions { get; set; }
    }
}