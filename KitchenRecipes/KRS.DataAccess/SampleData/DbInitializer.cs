using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.DataAccess.DataContext;
using KRS.DataAccess.DataContext;
using KRS.Model.Infrastructure;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.SampleData
{
    public static class DbInitializer
    {
        public static void InitializeDb(KRSContext context)
        {

            var photos = PhotosCollection.Photos();
            photos.ToList().ForEach(s => context.Photos.AddOrUpdate(s));
            context.SaveChanges();


            var recipeCategoriesTypes = CategoriesCollection.RecipeCategoryTypes();
            recipeCategoriesTypes.ToList().ForEach(s => context.CategoryTypes.AddOrUpdate(s));
            context.SaveChanges();

            var ingredientCategories = CategoriesCollection.IngredientsCategories();
            ingredientCategories.ToList().ForEach(s => context.IngredientCategories.AddOrUpdate(s));

            var kitchenwareCategories = CategoriesCollection.KitchenwareCategories();
            kitchenwareCategories.ToList().ForEach(s => context.KitchenwareCategories.AddOrUpdate(s));

            var recipeCategories = CategoriesCollection.RecipeCategories(context);
            recipeCategories.ToList().ForEach(s => context.RecipeCategories.AddOrUpdate(s));
            context.SaveChanges();

            
            var ingredients = IngredientsCollection.Ingredients(context);
            foreach (var ingredient in ingredients)
            {
                ingredient.Photos = RandomSelector.Deal(context.Photos.ToList(), 5);
            }
            ingredients.ToList().ForEach(s => context.Ingredients.AddOrUpdate(s));

            var kitchenwares = KitchenwareCollection.Kitchenwares(context);
            kitchenwares.ToList().ForEach(s => context.Kitchenwares.AddOrUpdate(s));

            var cookProcesses = CookProcessesCollection.CookProcesses();
            cookProcesses.ToList().ForEach(s => context.CookProcesses.AddOrUpdate(s));
            context.SaveChanges();


            var recipes = RecipesCollection.Recipes(context);
            recipes.ToList().ForEach(s => context.Recipes.AddOrUpdate(s));
            context.SaveChanges();

            
            var rand = new Random();

            foreach (var recipe in context.Recipes.ToList())
            {
                recipe.Photos = RandomSelector.Deal(context.Photos.ToList(), 6);

                List<Ingredient> recipeIngredients = RandomSelector.Deal(context.Ingredients.ToList(), 7);
                foreach (var recipeIngredient in recipeIngredients)
                {
                    var schema = new RecipesIngredients
                    {
                        Step = rand.Next(1, 7),
                        Recipe = recipe,
                        Ingredient = recipeIngredient,
                        Unit = new MeasurementUnit
                        {
                            MeasureSign = "одиниць",
                            Value = rand.Next(1, 100).ToString(CultureInfo.InvariantCulture),
                        }
                    };
                    context.RecipesIngredients.Add(schema);
                    recipe.IngredientsRelation.Add(schema);
                    recipeIngredient.IngredientRecipes.Add(schema);
                }
                context.SaveChanges();

                List<Kitchenware> recipeKitchenware = RandomSelector.Deal(context.Kitchenwares.ToList(), 4);
                foreach (var recipeKware in recipeKitchenware)
                {
                    var schema = new RecipesKitchenwares
                    {
                        Step = rand.Next(1, 7),
                        Recipe = recipe,
                        Kitchenware = recipeKware,
                        Quontity = rand.Next(1, 4),
                    };
                    context.RecipesKitchenwares.Add(schema);
                    recipe.KitchenwaresRelation.Add(schema);
                    recipeKware.KitchenwareRecipes.Add(schema);
                }
                context.SaveChanges();

                List<CookProcess> recipeCookProesses = RandomSelector.Deal(context.CookProcesses.ToList(), 5);
                foreach (var recipeCookProc in recipeCookProesses)
                {
                    var schema = new RecipesCookProcesses
                    {
                        Step = rand.Next(1, 7),
                        Recipe = recipe,
                        CookProcess = recipeCookProc,
                    };
                    context.RecipesCookProcesses.Add(schema);
                    recipe.CookProcessesRelation.Add(schema);
                    recipeCookProc.CookProcessRecipes.Add(schema);
                }
                context.SaveChanges();
            }
            
        }
    }
}
