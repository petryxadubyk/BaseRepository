define('dataservice.recipe',
    ['amplify'],
    function(amplify) {
        var 
            init = function () {

                amplify.request.define('recipes', 'ajax', {
                    url: '/api/recipes/all',
                    dataType: 'json',
                    type: 'GET'
                });

                amplify.request.define('recipe-briefs', 'ajax', {
                    url: '/api/recipes/recipebriefs',
                    dataType: 'json',
                    type: 'GET'
                    //cache: true
                    //cache: 60000 // 1 minute
                    //cache: 'persist'
                });

                amplify.request.define('recipe', 'ajax', {
                    url: '/api/recipes/getrecipebyid?id={id}',
                    dataType: 'json',
                    type: 'GET'
                });

                amplify.request.define('recipeUpdate', 'ajax', {
                    url: '/api/recipes',
                    dataType: 'json',
                    type: 'PUT',
                    contentType: 'application/json; charset=utf-8'
                });
            },
            
            getRecipes = function(callbacks) {
                return amplify.request({
                    resourceId: 'recipes',
                    success: callbacks.success,
                    error: callbacks.error
                });
            }, 
            
            getRecipeBriefs = function (callbacks) {
                return amplify.request({
                    resourceId: 'recipe-briefs',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },

            getRecipe = function (callbacks, id) {
                return amplify.request({
                    resourceId: 'recipe',
                    data: { id: id },
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            
            updateRecipe = function (callbacks, data) {
                return amplify.request({
                    resourceId: 'recipeUpdate',
                    data: data,
                    success: callbacks.success,
                    error: callbacks.error
                });
            };

        init();

        return {
            getRecipes: getRecipes,
            getRecipeBriefs: getRecipeBriefs,
            getRecipe: getRecipe,
            updateRecipe: updateRecipe
        };
    });