using System.Collections.Generic;
using KRS.Model.Recipes;

namespace KRS.Model.Categories
{
    public class RecipeCategory: Category
    {
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
