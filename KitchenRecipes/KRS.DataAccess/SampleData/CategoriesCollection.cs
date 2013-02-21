using System;
using System.Collections.Generic;
using System.Linq;
using KRS.DataAccess.DataContext;
using KRS.Model.Categories;

namespace KRS.DataAccess.SampleData
{
    internal static class CategoriesCollection
    {
        public static SampleTextGenerator TextGenerator = new SampleTextGenerator();
        const SampleTextGenerator.SourceNames DescTextSource =
                SampleTextGenerator.SourceNames.Decameron;
        const SampleTextGenerator.SourceNames TextSource =
                SampleTextGenerator.SourceNames.Faust;

        internal static IQueryable<IngredientCategory> IngredientsCategories()
        {
            var list = new List<IngredientCategory>
                           {
                               new IngredientCategory
                                   {
                                       Name = "Інгредієнти",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       ParentCategoryId = null,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Приправи",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/prupravu.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Фрукти",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/fruits.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Яблука",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/apples.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1, //todo id of category 'Фрукти'
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Овочі",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/vegetables.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Цитрусові",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/citruses.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Мясо",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/meat.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Крупи",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/krypu.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Риба",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/fish.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Вина",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/vines.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Коньяки",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/konjak.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Рослинні добавки",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/ros-dobavku.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Тваринні добавки",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/anymal-dobavku.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Консервації",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/konservacij.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new IngredientCategory
                                   {
                                       Name = "Гриби",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Ingredients/mashroms.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                           };
            return list.AsQueryable();
        }

        internal static IQueryable<KitchenwareCategory> KitchenwareCategories()
        {
            var list = new List<KitchenwareCategory>
                           {
                               new KitchenwareCategory
                                   {
                                       Name = "Kухонне обладнання",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                   },
                               new KitchenwareCategory
                                   {
                                       Name = "Сковорідки",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Kitchenware/skovorodki.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new KitchenwareCategory
                                   {
                                       Name = "Ножі",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Kitchenware/knifes.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new KitchenwareCategory
                                   {
                                       Name = "Відкривачки",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Kitchenware/vidkruvachki.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new KitchenwareCategory
                                   {
                                       Name = "Тарілки",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Kitchenware/plates.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new KitchenwareCategory
                                   {
                                       Name = "Кастрюлі",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Kitchenware/pans.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new KitchenwareCategory
                                   {
                                       Name = "Електричні прибори",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Kitchenware/elektr-devices.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                                   new KitchenwareCategory
                                   {
                                       Name = "Обладнання",
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Kitchenware/kitchen-devices.jpg",
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       ParentCategoryId = 1,
                                   },
                           };
            return list.AsQueryable();
        }

        internal static IQueryable<RecipeCategory> RecipeCategories(KRSContext context)
        {
            var list = new List<RecipeCategory>
                           {
                               new RecipeCategory
                                   {
                                       Name  = "Категорії рецептів",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                   },
                               new RecipeCategory
                                   {
                                       Name  = "Українська кухня",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/ukr.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Національна приналежність"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Російська кухня",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/rus.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Національна приналежність"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Казахська кухня",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/kazak.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Національна приналежність"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Авторські страви",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/avtorski-stravu.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Напитки",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/beverages.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Десерти",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/desertu.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Другі страви",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/drugi-stravu.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Грузинська кухня",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/georgia.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Національна приналежність"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Соки",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/juses.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Перші страви",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/pershi-stravu.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Салати",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/salads.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Соуси",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/soysu.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Випічка",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/vupichka.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Закуски",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/zakuski.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                                   new RecipeCategory
                                   {
                                       Name  = "Вина",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/GroupCategories/Recipes/vines.jpg",
                                       Group = context.CategoryTypes.FirstOrDefault(x => x.Name=="Типи страв"),
                                   },
                           };
            return list.AsQueryable();
        }

        internal static IQueryable<CategoryGroup> RecipeCategoryTypes()
        {
            var list = new List<CategoryGroup>
                           {
                               new CategoryGroup
                                   {
                                       Name  = "Національна приналежність",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                   },
                                new CategoryGroup
                                   {
                                       Name  = "Типи страв",
                                       Description = TextGenerator.GenSentences(10, DescTextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                   },
                           };
            return list.AsQueryable();
        }
    }
}
