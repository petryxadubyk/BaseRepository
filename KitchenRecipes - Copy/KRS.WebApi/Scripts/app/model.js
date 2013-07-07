define('model',
    [
        'model.recipe'
    ],
    function(recipe) {
        var model = {
            Recipe: recipe
        };

        model.setDataContext = function(dc) {
            model.Recipe.datacontext(dc);
        };

        return model;
    });