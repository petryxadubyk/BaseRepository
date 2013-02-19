using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.Categories;
using KRS.Model.Infrastructure;

namespace KRS.Model.RecipesParts
{
    public class Ingredient : RecipePart
    {
        [MaxLength(100)]
        public string Manufacturer { get; set; }
        public virtual IngredientCategory Category { get; set; }

        public virtual ICollection<RecipesIngredients> IngredientRecipes { get; set; }
    }
}
