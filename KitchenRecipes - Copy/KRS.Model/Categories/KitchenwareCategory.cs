using System.Collections.Generic;
using KRS.Model.RecipesParts;

namespace KRS.Model.Categories
{
    public class KitchenwareCategory: Category
    {
        public virtual ICollection<Kitchenware> Kitchenwares { get; set; }
    }
}
