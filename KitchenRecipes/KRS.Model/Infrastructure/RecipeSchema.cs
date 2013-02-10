using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRS.Model.Infrastructure
{
    public class RecipeSchema
    {
        public int RecipeId { get; set; }
        public int RecipePartId { get; set; }
        public int RecipePartMajor { get; set; }
    }
}
