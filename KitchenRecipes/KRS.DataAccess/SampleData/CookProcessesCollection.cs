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

        internal static IQueryable<CookProcess> CookProcesses()
        {
            var list = new List<CookProcess>
                           {
                               new CookProcess
                                   {
                                       Name = "Порізати на кубики", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/cut-cubs.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Порізати кругами", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/cut-circles.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Порізати на кусочки", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/cut-into-pieces.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Порізати дрібною соломкою", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/cut-lines.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Порізати на дрібні кусочки", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/cut-into-pieces.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Порізати соломкою", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/cut-solomka.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Обжарити", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/obgarutu.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Подрібнити", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/podribnutu.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Смажити", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/smazhutu.jpg",
                                   },
                                   new CookProcess
                                   {
                                       Name = "Збити", 
                                       Description = TextGenerator.GenSentences(3, TextSource),
                                       CreatedOn = DateTime.Now,
                                       ModifiedOn = DateTime.Now,
                                       PhotoPath = "~/Images/RecipeParts/CookProcesses/zbutu.jpg",
                                   },
                           };
            return list.AsQueryable();
        }
    }
}
