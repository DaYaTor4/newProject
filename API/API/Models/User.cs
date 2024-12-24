﻿using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<RecipeComment> RecipeComments { get; set; } = new List<RecipeComment>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}