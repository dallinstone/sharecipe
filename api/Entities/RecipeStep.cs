using System;
using System.Collections.Generic;

namespace api;

public partial class RecipeStep
{
    public int RecipeStepId { get; set; }

    public int RecipeId { get; set; }

    public int Step { get; set; }

    public string StepText { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
