using System.ComponentModel.DataAnnotations;
using KRS.Model.Recipes;

namespace KRS.Model.Infrastructure
{
    public class RecipeSchema
    {
        [Key]
        public int SchemaId { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        
        public int StepId { get; set; }
        
        public int RecipePartId { get; set; }
        public int? RecipePartMajor { get; set; }
    }
}
