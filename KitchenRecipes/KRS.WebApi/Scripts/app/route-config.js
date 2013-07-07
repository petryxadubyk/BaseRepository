define('route-config',
    ['config', 'router', 'vm'],
    function (config, router, vm) {
        var
            logger = config.logger,

            register = function () {

                var routeData = [
                    // Recipes routes
                    {
                        isDefault: true,
                        view: config.viewIds.recipes,
                        route: config.hashes.recipes,
                        title: 'recipes',
                        callback: vm.recipes.activate,
                        group: '.route-top'
                    },

                    // Recipe details routes
                    {
                        view: config.viewIds.recipe,
                        route: config.hashes.recipes + '/:id',
                        title: 'recipe',
                        callback: vm.recipe.activate,
                        group: '.route-top'
                    }


                ];

                for (var i = 0; i < routeData.length; i++) {
                    router.register(routeData[i]);
                }

                // Crank up the router
                router.run();
            };


        return {
            register: register
        };
    });