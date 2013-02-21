using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.Infrastructure;
using KRS.Model.Recipes;

namespace KRS.Model.RecipesParts
{
    public class CookProcess: RecipePart
    {
        public TimeSpan? Time { get; set; }

        public virtual ICollection<RecipesCookProcesses> CookProcessRecipes { get; set; }
    }
}
