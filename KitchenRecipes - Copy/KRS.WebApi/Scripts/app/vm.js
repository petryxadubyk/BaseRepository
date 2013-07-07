define('vm',
    [
        'vm.recipes',
        'vm.recipe'
    ],
    function(recipes, recipe) {
        return {
            recipes: recipes,
            recipe: recipe
        };
    });