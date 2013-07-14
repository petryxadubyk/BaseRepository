define('model',
    [
        'model.recipe', 'model.ingredient'
    ],
    function(recipe, ingredient) {
        var model = {
            Recipe: recipe,
            Ingredient: ingredient
        };

        model.setDataContext = function(dc) {
            model.Recipe.datacontext(dc);
            model.Ingredient.datacontext(dc);
        };

        return model;
    });