using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RecipeIngredientDto
    {
    public int Ordered { get; set; }
    public int? RecipeId { get; set; }
    public int? IngredientId { get; set; }
    public string Measurement { get; set; } = null!;
    public string? IngredientName { get; set; }

    }
}