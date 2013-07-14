define('sort', [], function() {
    var
        recipeSort = function (recipeA, recipeB) {
            return recipeA.name() > recipeB.name() ? 1 : -1;
        },
        ingredientSort = function(ingredientA, ingredientB) {
            return ingredientA.name() > ingredientB.name() ? 1 : -1;
        };

    return {
        recipeSort: recipeSort,
        ingredientSort: ingredientSort
    };
});