using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.IRecipesParts;

namespace KRS.Model.Categories
{
    public class KitchenwareCategory: Category
    {
        public virtual ICollection<IKitchenware> Kitchenwares { get; set; }
    }
}
