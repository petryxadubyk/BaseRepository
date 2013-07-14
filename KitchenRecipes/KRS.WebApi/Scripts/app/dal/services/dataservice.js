define('dataservice',
    [
        'dataservice.recipe',
        'dataservice.ingredient'
    ],
    function(recipe, ingredient) {
        return {
            recipe: recipe,
            ingredient: ingredient
        };
    });