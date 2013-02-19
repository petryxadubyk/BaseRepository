using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using KRS.DataAccess.DataContext;
using KRS.Model.Photos;

namespace KRS.DataAccess.SampleData
{
    public class KRSDatabaseInitializer :
        //CreateDatabaseIfNotExists<CodeCamperDbContext>      // when model is stable
        DropCreateDatabaseIfModelChanges<KRSContext> // when iterating
    {
        protected override void Seed(KRSContext context)
        {
            var photos = PhotosCollection.Photos();
            var ingredientCategories = CategoriesCollection.IngredientsCategories();
            var kitchenwareCategories = CategoriesCollection.KitchenwareCategories();
            var recipeCategories = CategoriesCollection.RecipeCategories();
            var recipeCategoriesTypes = CategoriesCollection.RecipeCategoryTypes();

            var ingredients = IngredientsCollection.Ingredients();
            var kitchenwares = KitchenwareCollection.Kitchenwares();

            //AddCookProcesses
            //AddRecipes
            //AddRecipeSchemas
            //AddUsers
        }
    }
}