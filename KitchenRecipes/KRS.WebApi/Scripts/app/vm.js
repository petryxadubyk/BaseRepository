define('vm',
    [
        'vm.recipes',
        'vm.recipe',
        'vm.shell'
    ],
    function(recipes, recipe, shell) {
        return {
            recipes: recipes,
            recipe: recipe,
            shell: shell
        };
    });