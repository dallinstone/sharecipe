using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RecipeStepDto
    {
    public int RecipeStepId { get; set; }
    public int Step { get; set; }
    public string StepText { get; set; }
    }
}