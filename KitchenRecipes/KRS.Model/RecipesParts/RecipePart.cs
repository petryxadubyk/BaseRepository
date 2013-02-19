using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.KRS;
using KRS.Model.Photos;
using KRS.Model.Recipes;

namespace KRS.Model.RecipesParts
{
    public class RecipePart: KRSEntity
    {
        [MaxLength(300), Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(300)]
        public string PhotoPath { get; set; }
    }
}
