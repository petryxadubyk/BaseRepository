using System;
using System.Collections.Generic;
using KRS.Model.Categories;
using KRS.Model.IRecipes;
using KRS.Model.IRecipesParts;
using KRS.Model.KRS;
using KRS.Model.Photos;
using KRS.Model.Users;

namespace KRS.Model.Recipes
{
    public class Recipe: KRSEntity, IRecipe
    {
        public String Name { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public virtual RecipeCategory Category { get; set; }
        public virtual NationalCategory NationalCategory { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<IRecipePart> RecipeParts { get; set; }
        public virtual ICollection<KRSUser> Users { get; set; }
    }
}
