using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.DataAccess.DataContext;
using KRS.Model.Categories;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.SampleData
{
    public class KitchenwareCollection
    {
        public static SampleTextGenerator TextGenerator = new SampleTextGenerator();
        const SampleTextGenerator.SourceNames DescTextSource =
                SampleTextGenerator.SourceNames.Decameron;
        const SampleTextGenerator.SourceNames TextSource =
                SampleTextGenerator.SourceNames.Faust;

        internal static IQueryable<Kitchenware> Kitchenwares(KRSContext context)
        {
            var list = new List<Kitchenware>
                           {
                               new Kitchenware
                                   {
                                        Name  = "Кастрюля",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Кастрюлі"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/pan.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Сковорода",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Сковорідки"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/fray.jpg",
                                        Material = "Тефлон",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Тарілка столова",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Тарілки"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/plate.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Кухонний комбайн",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Електричні прибори"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/combain.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Дошка для нарізання",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Обладнання"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/doshka.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Ніж для мяса",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Ножі"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/knife1.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Ніж для овочів",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Ножі"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/knife2.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Ніж для риби",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Ножі"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/knife3.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Мясорубка",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Електричні прибори"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/meatcut.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Міксер",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Електричні прибори"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/mixer.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Піднос",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Обладнання"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/pidnos.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Штопор",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Обладнання"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/shtopor.jpg",
                                   },
                                   new Kitchenware
                                   {
                                        Name  = "Відкривачка для консерацій",
                                        CreatedOn = DateTime.Now,
                                        ModifiedOn = DateTime.Now,
                                        Description = TextGenerator.GenSentences(3,TextSource),
                                        Category = context.KitchenwareCategories.FirstOrDefault(c=>c.Name=="Відкривачки"),
                                        PhotoPath = "~/Images/RecipeParts/Kitchenwares/vidkruvach.jpg",
                                   },
                           };
            return list.AsQueryable();
        }
    }
}
