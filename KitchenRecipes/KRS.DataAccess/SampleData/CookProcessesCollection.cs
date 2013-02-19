using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Categories;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.SampleData
{
    public class CookProcessesCollection
    {
        public static SampleTextGenerator TextGenerator = new SampleTextGenerator();
        const SampleTextGenerator.SourceNames DescTextSource =
                SampleTextGenerator.SourceNames.Decameron;
        const SampleTextGenerator.SourceNames TextSource =
                SampleTextGenerator.SourceNames.Faust;
        private static readonly IQueryable<KitchenwareCategory> Categories;
        static CookProcessesCollection()
        {
            Categories = CategoriesCollection.KitchenwareCategories();
        }
        internal static IQueryable<Kitchenware> Kitchenwares()
        {
            var list = new List<Kitchenware>
                           {
                               
                           };
            return list.AsQueryable();
        }
    }
}
