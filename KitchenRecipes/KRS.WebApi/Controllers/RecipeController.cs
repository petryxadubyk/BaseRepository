using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KRS.DataAccess.Repositories;
using KRS.Model.Recipes;

namespace KRS.WebApi.Controllers
{
    public class RecipeController : ApiController
    {
         private readonly IRecipeRepository _recipeRepository;
        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public IQueryable<Recipe> Get(string name)
        {
            var recipes = _recipeRepository.CreateRecipe(name);
            if (recipes == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recipes.AsQueryable();
        }

        public IEnumerable<Recipe> InsertRecipe(string name)
        {
            var recipes = _recipeRepository.CreateRecipe(name);
            if (recipes == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recipes;
        }

    }
}
