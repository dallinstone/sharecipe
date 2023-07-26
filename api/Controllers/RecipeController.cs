using api.Models;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using API.Controllers;

namespace api.Controllers
{
    [ApiController]
    [Route("recipe")]
    public class RecipeController : BaseApiController
    {
        private readonly ILogger<Recipe> _logger;
        private readonly SharecipedevContext _dbcontext;
        private readonly IMapper _mapper;

        //get all recipes
        [HttpGet] //api/recipe
        public async Task<ActionResult> GetRecipes()
        {
            RecipeDto recipeDto = new();
            try
            {
                //only get approved recipes
                var recipe = _dbcontext.Recipes.Where(x => x.Approved == 1);
                if (recipe != null)
                {
                    recipeDto = _mapper.Map<RecipeDto>(recipe);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Api request failed with error {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(recipeDto);
        }

        //get recipe by id
        [HttpGet("id")] //api/recipe/id
        public async Task<ActionResult> GetRecipe(int id)
        {
            RecipeDto recipeDto = new();
            RecipeIngredientDto riDto = new();
            try
            {
                //find recipe by id
                var recipe = _dbcontext.Recipes.Where(x => x.RecipeId == id);
                if (recipe != null)
                {
                    //map the recipe, as well as its steps and its ingredients
                    recipeDto = _mapper.Map<RecipeDto>(recipe);
                    var ri = _dbcontext.RecipeIngredients.Where(x => x.RecipeId == id).ToListAsync();
                    recipeDto.RecipeIngredients = _mapper.Map<List<RecipeIngredientDto>>(ri);
                    var rs = _dbcontext.RecipeSteps.Where(x => x.RecipeId == id).ToListAsync();
                    recipeDto.RecipeSteps = _mapper.Map<List<RecipeStepDto>>(rs);

                    foreach (var ingDto in recipeDto.RecipeIngredients)
                    {
                        //add ingredient name to pass to front end
                        if (String.IsNullOrEmpty(ingDto.IngredientName)) 
                        {
                            ingDto.IngredientName = GetIngredientName(ingDto.IngredientId);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Api request failed with error {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(recipeDto);
        }

        //add a new recipe
        [HttpPost("addRecipe")] //api/recipe
        public async Task<IActionResult> AddRecipe(RecipeDto newRecipe)
        {
            //default to the recipe being approved 
            sbyte approved = 1;

            //for each ingredient in the recipe, add it as an ingredient if it doesn't exist
            //and set the recipe and ingredient to unapproved
            foreach (var ingDto in newRecipe.RecipeIngredients)
            {
                if (ingDto.IngredientId == null)
                {
                    Ingredient ingredient = _mapper.Map<Ingredient>(ingDto);
                    ingredient.Approved = 0;
                    approved = 0;
                    _dbcontext.Ingredients.Add(ingredient);
                    _dbcontext.SaveChangesAsync();
                }
            }

            //add the recipe itself
            Recipe recipe = _mapper.Map<Recipe>(newRecipe);
            recipe.Approved = approved;
            _dbcontext.Recipes.Add(recipe);
            _dbcontext.SaveChangesAsync();

            //add the entries to the recipeIngredients table
            foreach (var ri in newRecipe.RecipeIngredients)
            {
                RecipeIngredient recipeIngredient = _mapper.Map<RecipeIngredient>(ri);
                recipeIngredient.RecipeId = recipe.RecipeId;
                _dbcontext.RecipeIngredients.Add(recipeIngredient);
                _dbcontext.SaveChangesAsync();
            }
            return Ok(newRecipe);
        }

        //a quick method to get the ingredient name by id 
        private string? GetIngredientName(int? ingredientId)
        {
            var ingredient = _dbcontext.Ingredients.FirstOrDefault(x => x.IngredientId == ingredientId);
            if (ingredient != null)
            {
                return ingredient.Name;
            }
            return null;
        }
    }
}