using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using KRS.DataAccess.DataContext;
using KRS.Model.Infrastructure;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.SampleData
{
    public class KRSDatabaseInitializer :
        //CreateDatabaseIfNotExists<CodeCamperDbContext>      // when model is stable
        DropCreateDatabaseIfModelChanges<KRSContext> // when iterating
    {
        protected override void Seed(KRSContext context)
        {
            DbInitializer.InitializeDb(context);
        }
    }
}