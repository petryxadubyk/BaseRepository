using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.Model.Infrastructure
{
    public class RecipesIngredients
    {
        [Key]
        public int Id { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public virtual MeasurementUnit Unit { get; set; }
    }
}
