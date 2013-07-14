define('dataprimer',
    ['ko', 'datacontext', 'config'],
    function (ko, datacontext, config) {

        var logger = config.logger,
            
            fetch = function () {
                
                return $.Deferred(function (def) {

                    var data = {
                        recipes: ko.observable(),
                        ingredients: ko.observable(),
                    };

                    $.when(
                        datacontext.recipes.getData({ results: data.recipes }),
                        datacontext.ingredients.getData({results: data.ingredients})
                    )
                    .pipe(function() {
                        logger.success('Fetched data for: '
                            + '<div>' + data.recipes().length + ' recipes </div>'
                            + '<div>' + data.ingredients().length + ' ingredients </div>'
                        );
                    })
                    .fail(function () { def.reject(); })
                    .done(function () { def.resolve(); });
                }).promise();
            };

        return {
            fetch: fetch
        };
    });