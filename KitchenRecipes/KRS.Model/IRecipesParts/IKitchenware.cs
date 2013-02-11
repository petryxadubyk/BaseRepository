using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Categories;

namespace KRS.Model.IRecipesParts
{
    public interface IKitchenware: IRecipePart
    {
        KitchenwareCategory Category { get; set; }
    }
}
