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

        [HttpGet(Name = "GetRecipes")]
        public IEnumerable<Recipe> Get()
        {
            return Recipes;
        }

        [HttpPost("add")]
        public IActionResult AddRecipe([FromBody] Recipe recipe)
        {
            if (Recipes.Any(r => r.Id == recipe.Id))
            {
                return BadRequest($"Рецепт с ID {recipe.Id} уже существует.");
            }

            var validationResult = ValidateRecipe(recipe);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            recipe.Id = Recipes.Count > 0 ? Recipes.Max(r => r.Id) + 1 : 1;
            Recipes.Add(recipe);
            return Ok(recipe);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateRecipe(int id, [FromBody] Recipe updatedRecipe)
        {
            var recipe = Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound("Рецепт не найден.");
            }

            var validationResult = ValidateRecipe(updatedRecipe);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            recipe.DishName = updatedRecipe.DishName;
            recipe.Ingredients = updatedRecipe.Ingredients;
            recipe.CookingTime = updatedRecipe.CookingTime;
            recipe.Instructions = updatedRecipe.Instructions;

            return Ok(recipe);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = Recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound("Рецепт не найден.");
            }

            Recipes.Remove(recipe);
            return Ok($"Рецепт с ID {id} удален.");
        }

        private (bool IsValid, string ErrorMessage) ValidateRecipe(Recipe recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.DishName))
            {
                return (false, "Название блюда не должно быть пустым.");
            }

            if (recipe.Ingredients == null || recipe.Ingredients.Length == 0 || recipe.Ingredients.Any(i => string.IsNullOrWhiteSpace(i)))
            {
                return (false, "Ингредиенты должны быть указаны и не должны содержать пустых значений.");
            }

            if (recipe.CookingTime <= 0)
            {
                return (false, "Время приготовления должно быть больше 0.");
            }

            if (string.IsNullOrWhiteSpace(recipe.Instructions))
            {
                return (false, "Инструкции должны быть указаны.");
            }

            return (true, string.Empty);
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
