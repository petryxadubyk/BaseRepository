define('dataservice.ingredient',
    ['amplify'],
    function (amplify) {
        var init = function() {
            amplify.request.define('ingredients', 'ajax', {
                url: '/api/ingredients',
                dataType: 'json',
                type: 'GET'
            });

            amplify.request.define('ingredient', 'ajax', {
                url: 'api/ingredients/{id}',
                dataType: 'json',
                type: 'GET'
            });

            amplify.request.define('ingredientUpdate', 'ajax', {
                url: '/api/ingredients',
                dataType: 'json',
                type: 'PUT',
                contentType: 'application/json; charset=utf-8'
            });

            amplify.request.define('recipe-ingredients', 'ajax', {
                url: '/api/recipes/ingredients?id={id}',
                dataType: 'json',
                type: 'GET'
            });
        },
            getIngredients = function(callbacks) {
                return amplify.request({
                    resourceId: 'ingredients',
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            getIngredient = function(callbacks, id) {
                return amplify.request({
                    resourceId: 'ingredient',
                    data: { id: id },
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            updateIngredient = function(callbacks, data) {
                return amplify.request({
                    resourceId: 'ingredientUpdate',
                    data: data,
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            getRecipeIngredients = function(callbacks, id) {
                return amplify.request({
                    resourceId: 'recipe-ingredients',
                    data: { id: id },
                    success: callbacks.success,
                    error: callbacks.error
                });
            };

        init();

        return {
            getIngredients: getIngredients,
            getIngredient: getIngredient,
            updateIngredient: updateIngredient,
            getRecipeIngredients: getRecipeIngredients
        };
    });