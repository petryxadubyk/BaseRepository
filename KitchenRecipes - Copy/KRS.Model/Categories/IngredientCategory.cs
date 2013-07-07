using System.Collections.Generic;
using KRS.Model.RecipesParts;

namespace KRS.Model.Categories
{
    public class IngredientCategory: Category
    {
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
