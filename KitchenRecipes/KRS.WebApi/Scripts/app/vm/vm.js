define('vm',
    [
        'vm.recipes',
        'vm.recipe',
        'vm.shell',
        'vm.ingredients',
        'vm.ingredient'
    ],
    function(recipes, recipe, shell, ingredients, ingredient) {
        return {
            recipes: recipes,
            recipe: recipe,
            shell: shell,
            ingredients: ingredients,
            ingredient: ingredient
        };
    });