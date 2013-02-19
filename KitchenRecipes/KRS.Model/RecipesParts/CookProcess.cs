using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.Recipes;

namespace KRS.Model.RecipesParts
{
    public class CookProcess: RecipePart
    {
        [MaxLength(300)]
        public string ResultImagePath { get; set; }
        public TimeSpan? Time { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
