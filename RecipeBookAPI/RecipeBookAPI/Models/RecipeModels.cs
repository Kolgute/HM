using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBookAPI.Models
{
    public class RecipeModels
    {
        public int RecipeID { get; set; }
        public int DishID { get; set; }
        public string RecipeName { get; set; }
        public string Products { get; set; }
        public int WeightProduct { get; set; }
        public string Category { get; set; }
        public string CookingTime { get; set; }
        public string CookingTemperature { get; set; }
        public string CookingProcess { get; set; }
        public string PPhotoRecipe { get; set; }
        public string RecipeDescription { get; set; }

    }

    public class ViewRecipeModels
    {
        public int RecipeID { get; set; }
        public int DishID { get; set; }
        public string RecipeName { get; set; }
        public string[] Products { get; set; }
        public int WeightProduct { get; set; }
        public string Category { get; set; }
        public string CookingTime { get; set; }
        public string CookingTemperature { get; set; }
        public string CookingProcess { get; set; }
        public string PPhotoRecipe { get; set; }
        public string RecipeDescription { get; set; }

    }

    public class RecipeCardModels
    {
        public string RecipeName { get; set; }
        public string Category { get; set; }
        public string PPhotoRecipe { get; set; }
        public string RecipeDescription { get; set; }

    }

    public class RecipeAddModels
    {
        public int RecipeID { get; set; }
        public int DishID { get; set; }
        public string RecipeName { get; set; }
        public int ProductID { get; set; }
        public int WeightProduct { get; set; }
        public int CategoryID { get; set; }
        public string CookingTime { get; set; }
        public string CookingTemperature { get; set; }
        public string CookingProcess { get; set; }
        public string PPhotoRecipe { get; set; }
        public string RecipeDescription { get; set; }
    }
}