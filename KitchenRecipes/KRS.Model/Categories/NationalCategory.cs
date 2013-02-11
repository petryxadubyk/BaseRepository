using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Recipes;

namespace KRS.Model.Categories
{
    public class NationalCategory : Category
    {
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
