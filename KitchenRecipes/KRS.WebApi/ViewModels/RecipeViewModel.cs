using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KRS.Model.Categories;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.WebApi.ViewModels
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Kitchenware> Kitchenwares { get; set; }

    }
}