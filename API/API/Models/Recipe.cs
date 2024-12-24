using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Instructions { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<RecipeComment> RecipeComments { get; set; } = new List<RecipeComment>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual User? User { get; set; }
}
