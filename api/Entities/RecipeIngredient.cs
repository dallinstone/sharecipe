using System;
using System.Collections.Generic;

namespace api;

public partial class RecipeIngredient
{
    public int RecipeIngredientId { get; set; }

    public int Ordered { get; set; }

    public int RecipeId { get; set; }

    public int IngredientId { get; set; }

    public string Measurement { get; set; } = null!;

    public bool? Approved { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
