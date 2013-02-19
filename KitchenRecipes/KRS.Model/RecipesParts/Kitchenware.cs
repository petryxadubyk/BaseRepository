using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.Categories;
using KRS.Model.Infrastructure;
using KRS.Model.Recipes;

namespace KRS.Model.RecipesParts
{
    public class Kitchenware: RecipePart
    {
        [MaxLength(100)]
        public string Material { get; set; }
        public virtual KitchenwareCategory Category { get; set; }
        public virtual ICollection<RecipesKitchenwares> KitchenwareRecipes { get; set; }
    }
}
