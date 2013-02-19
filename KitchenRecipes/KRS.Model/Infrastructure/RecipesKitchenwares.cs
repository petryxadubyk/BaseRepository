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
    public class RecipesKitchenwares
    {
        [Key]
        public int Id { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Kitchenware Kitchenware { get; set; }

        public int? Quontity { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
