using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.IRecipesParts;
using KRS.Model.Photos;
using KRS.Model.Recipes;

namespace KRS.Model.RecipesParts.CookProcesses
{
    public class CookProcess : KRS.KRSEntity, ICookProcess
    {
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public string Name { get; set; }
    }
}
