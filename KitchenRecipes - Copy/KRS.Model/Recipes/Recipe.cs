using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.Categories;
using KRS.Model.Infrastructure;
using KRS.Model.KRS;
using KRS.Model.Photos;
using KRS.Model.Users;

namespace KRS.Model.Recipes
{
    public class Recipe : KRSEntity
    {
        public Recipe()
        {
            Likes = 0;
            Dislikes = 0;
        }

        [MinLength(3), MaxLength(300), Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string ShortDescription { get; set; }
        [MaxLength(300)]
        public string PhotoPath { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }

        [MaxLength(300)]
        public string CategoryFilter { get; set; }
        [MaxLength(300)]
        public string CookProcessFilter { get; set; }
        [MaxLength(300)]
        public string KitchenwareFilter { get; set; }
        [MaxLength(300)]
        public string IngredientFilter { get; set; }

        public virtual ExtRecipe ExtRecipe { get; set; }

        public virtual ICollection<RecipeCategory> Categories { get; set; }
        public virtual ICollection<RecipesKitchenwares> KitchenwaresRelation { get; set; }
        public virtual ICollection<RecipesIngredients> IngredientsRelation { get; set; }
        public virtual ICollection<RecipesCookProcesses> CookProcessesRelation { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<KRSUser> Users { get; set; }
    }
}
