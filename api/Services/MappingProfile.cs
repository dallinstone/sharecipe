using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using AutoMapper;

namespace api.Services
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeStep, RecipeStepDto>();
            CreateMap<RecipeIngredient,RecipeIngredientDto>();
            CreateMap<User,UserDto>();
        }
    }
    
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<IngredientDto, Ingredient>();
            CreateMap<RecipeDto, Recipe>();
            CreateMap<RecipeStepDto, RecipeStep>();
            CreateMap<RecipeIngredientDto, RecipeIngredient>();
            CreateMap<UserDto, User>();
        }
    }
}