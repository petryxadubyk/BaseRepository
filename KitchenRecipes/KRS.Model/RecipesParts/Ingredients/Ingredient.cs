﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Categories;
using KRS.Model.IRecipesParts;
using KRS.Model.KRS;
using KRS.Model.Photos;
using KRS.Model.Recipes;

namespace KRS.Model.RecipesParts.Ingredients
{
    public class Ingredient : KRSEntity, IIngredient
    {
        public virtual IngredientCategory Category { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public string Name { get; set; }
    }
}
