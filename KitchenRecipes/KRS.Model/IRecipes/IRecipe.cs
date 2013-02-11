using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Categories;
using KRS.Model.IRecipesParts;
using KRS.Model.Photos;

namespace KRS.Model.IRecipes
{
    public interface IRecipe
    {
        RecipeCategory Category { get; set; }
        NationalCategory NationalCategory { get; set; }
        ICollection<Photo> Photos { get; set; }
        ICollection<IRecipePart> RecipeParts { get; set; }
    }
}
