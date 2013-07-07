define('sort', [], function() {
    var
        recipeSort = function (recipeA, recipeB) {
            return recipeA.name() > recipeB.name() ? 1 : -1;
        };

    return {
        recipeSort: recipeSort
    };
});