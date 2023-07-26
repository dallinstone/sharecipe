using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
        public List<RecipeIngredientDto>? RecipeIngredients {get; set;}
        public List<RecipeStepDto>? RecipeSteps{get; set; }
    }
}