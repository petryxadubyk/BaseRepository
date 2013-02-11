using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.IRecipes;
using KRS.Model.Recipes;

namespace KRS.Model.Categories
{
    public class RecipeCategory: Category
    {
        public virtual ICollection<IRecipe> Recipes { get; set; }
    }
}
