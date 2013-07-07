using System.ComponentModel.DataAnnotations;
using KRS.Model.KRS;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.Model.Infrastructure
{
    public class RecipesKitchenwares : KRSEntity
    {
        public virtual Recipe Recipe { get; set; }
        public virtual Kitchenware Kitchenware { get; set; }

        public int? ParentStep { get; set; }
        public int? Step { get; set; }
        public int? Quontity { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
