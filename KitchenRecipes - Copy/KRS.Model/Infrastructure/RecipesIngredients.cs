using KRS.Model.KRS;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.Model.Infrastructure
{
    public class RecipesIngredients : KRSEntity
    {
        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public int? ParentStep { get; set; }
        public int? Step { get; set; }
        public MeasurementUnit Unit { get; set; }
    }
}
