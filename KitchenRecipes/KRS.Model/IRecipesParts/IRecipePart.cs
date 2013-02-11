using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Photos;
using KRS.Model.Recipes;

namespace KRS.Model.IRecipesParts
{
    public interface IRecipePart
    {
        ICollection<Photo> Photos { get; set; }
        ICollection<Recipe> Recipes { get; set; }
        String Name { get; set; }
    }
}
