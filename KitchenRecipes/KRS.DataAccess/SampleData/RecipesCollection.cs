using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.DataAccess.DataContext;
using KRS.Model.Categories;
using KRS.Model.Recipes;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.SampleData
{
    public class RecipesCollection
    {
        public static SampleTextGenerator TextGenerator = new SampleTextGenerator();

        const SampleTextGenerator.SourceNames TextSource =
                SampleTextGenerator.SourceNames.Faust;

        public static IQueryable<Recipe> Recipes(KRSContext context)
        {
            var list = new List<Recipe>
                           {
                               new Recipe
                                   {
                                       Name = "Грейпфруктовий соус",
                                       PhotoPath = "~/Images/Recipes/greyprutovyj-sous.jpg",
                                       ShortDescription = TextGenerator.GenSentences(1,TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Likes = 2,
                                       Dislikes = 0,
                                       Categories = new List<RecipeCategory>
                                                        {
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Соуси"),
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Грузинська кухня"),
                                                        },
                                       ExtRecipe = new ExtRecipe
                                                       {
                                                           FullDescription = TextGenerator.GenSentences(15, SampleTextGenerator.SourceNames.Decameron)
                                                       }
                                   },
                                   new Recipe
                                   {
                                       Name = "Курка по Китайське",
                                       PhotoPath = "~/Images/Recipes/kuryache-file-kitaysky.jpg",
                                       ShortDescription = TextGenerator.GenSentences(1,TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Likes = 2,
                                       Dislikes = 0,
                                       Categories = new List<RecipeCategory>
                                                        {
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Другі страви"),
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Грузинська кухня"),
                                                        },
                                       ExtRecipe = new ExtRecipe
                                                       {
                                                           FullDescription = TextGenerator.GenSentences(15, SampleTextGenerator.SourceNames.Decameron)
                                                       }
                                   },
                                   new Recipe
                                   {
                                       Name = "Бутерброди з ікрою і авокадо",
                                       PhotoPath = "~/Images/Recipes/mini-buterbrody-ikroyu-avokado.jpg",
                                       ShortDescription = TextGenerator.GenSentences(1,TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Likes = 2,
                                       Dislikes = 0,
                                       Categories = new List<RecipeCategory>
                                                        {
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Закуски"),
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Авторські страви"),
                                                        },
                                       ExtRecipe = new ExtRecipe
                                                       {
                                                           FullDescription = TextGenerator.GenSentences(15, SampleTextGenerator.SourceNames.Decameron)
                                                       }
                                   },
                                   new Recipe
                                   {
                                       Name = "Мясо по французьки",
                                       PhotoPath = "~/Images/Recipes/myaso-francuzky.jpg",
                                       ShortDescription = TextGenerator.GenSentences(1,TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Likes = 2,
                                       Dislikes = 0,
                                       Categories = new List<RecipeCategory>
                                                        {
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Другі страви"),
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Російська кухня"),
                                                        },
                                       ExtRecipe = new ExtRecipe
                                                       {
                                                           FullDescription = TextGenerator.GenSentences(15, SampleTextGenerator.SourceNames.Decameron)
                                                       }
                                   },
                                   new Recipe
                                   {
                                       Name = "Салат Шопський",
                                       PhotoPath = "~/Images/Recipes/saladshopsky.jpg",
                                       ShortDescription = TextGenerator.GenSentences(1,TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Likes = 2,
                                       Dislikes = 0,
                                       Categories = new List<RecipeCategory>
                                                        {
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Салати"),
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Українська кухня"),
                                                        },
                                       ExtRecipe = new ExtRecipe
                                                       {
                                                           FullDescription = TextGenerator.GenSentences(15, SampleTextGenerator.SourceNames.Decameron)
                                                       }
                                   },
                                   new Recipe
                                   {
                                       Name = "Вінігрет",
                                       PhotoPath = "~/Images/Recipes/vinegret.jpg",
                                       ShortDescription = TextGenerator.GenSentences(1,TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Likes = 2,
                                       Dislikes = 0,
                                       Categories = new List<RecipeCategory>
                                                        {
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Салати"),
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Російська кухня"),
                                                        },
                                       ExtRecipe = new ExtRecipe
                                                       {
                                                           FullDescription = TextGenerator.GenSentences(15, SampleTextGenerator.SourceNames.Decameron)
                                                       }
                                   },
                                   new Recipe
                                   {
                                       Name = "Десерти з сухофруктів",
                                       PhotoPath = "~/Images/Recipes/cukerky-suhofruktiv.jpg",
                                       ShortDescription = TextGenerator.GenSentences(1,TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Likes = 2,
                                       Dislikes = 0,
                                       Categories = new List<RecipeCategory>
                                                        {
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Десерти"),
                                                             context.RecipeCategories.FirstOrDefault(c => c.Name == "Казахська кухня"),
                                                        },
                                       ExtRecipe = new ExtRecipe
                                                       {
                                                           FullDescription = TextGenerator.GenSentences(15, SampleTextGenerator.SourceNames.Decameron)
                                                       }
                                   },
                           };
            return list.AsQueryable();
        }
    }
}
