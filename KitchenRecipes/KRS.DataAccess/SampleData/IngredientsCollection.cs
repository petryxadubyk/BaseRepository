using System;
using System.Collections.Generic;
using System.Linq;
using KRS.Model.Categories;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.SampleData
{
    internal class IngredientsCollection
    {
        public static SampleTextGenerator TextGenerator = new SampleTextGenerator();

        const SampleTextGenerator.SourceNames TextSource =
                SampleTextGenerator.SourceNames.Faust;
        private static readonly IQueryable<IngredientCategory> Categories;
        static IngredientsCollection()
        {
            Categories = CategoriesCollection.IngredientsCategories();
        }
        public static IQueryable<Ingredient> Ingredients()
        {
            var list = new List<Ingredient>
                           {
                               new Ingredient
                                   {
                                       Name = "Ранети",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Яблука"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/apple.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods",
                                   },
                                   new Ingredient
                                   {
                                       Name = "Апельсини",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Цитрусові"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/orange.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Часник",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Овочі"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/chasnuk.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Червоний Перець",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Овочі"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/chili.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Цибуля звичайна",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Овочі"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/onion.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Імбир",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Овочі"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/imbur.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Мандарин",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Цитрусові"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/mandarun.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Свинина",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Мясо"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/meat.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Картопля",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Овочі"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/potato.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Болгарський перець",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Овочі"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/redperec.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                                   new Ingredient
                                   {
                                       Name = "Морква",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       Category = Categories.FirstOrDefault(c => c.Name == "Овочі"),
                                       PhotoPath = "~/Images/RecipeParts/Ingredients/carrot.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       Manufacturer = "ВАТ AllFoods"
                                   },
                           };
            return list.AsQueryable();
        }
    }
}
