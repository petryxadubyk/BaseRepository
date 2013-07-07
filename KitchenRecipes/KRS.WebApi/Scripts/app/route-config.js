define('route-config',
    ['config', 'router', 'vm'],
    function (config, router, vm) {
        var
            logger = config.logger,

            register = function () {

                var routeData = [
                    // Recipes routes
                    {
                        view: config.viewIds.recipes,
                        routes:
                            [{
                                isDefault: true,
                                route: config.hashes.recipes,
                                title: 'Recipes',
                                callback: vm.recipes.activate,
                                group: '.route-top'
                            }]
                    },

                    // Recipe details routes
                    {
                        view: config.viewIds.recipe,
                        route: config.hashes.recipes + '/:id',
                        title: 'Recipe',
                        callback: vm.recipe.activate,
                        group: '.route-top'
                    },

                    // Invalid routes
                    {
                        view: '',
                        route: /.*/,
                        title: '',
                        callback: function () {
                            logger.error(config.toasts.invalidRoute);
                        }
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