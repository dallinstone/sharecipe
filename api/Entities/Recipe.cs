using System;
using System.Collections.Generic;

namespace api;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public sbyte? Approved { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();

    public virtual User User { get; set; } = null!;
}
