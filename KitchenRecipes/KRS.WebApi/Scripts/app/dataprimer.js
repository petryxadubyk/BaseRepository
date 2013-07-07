define('dataprimer',
    ['ko', 'datacontext', 'config'],
    function (ko, datacontext, config) {

        var logger = config.logger,
            
            fetch = function () {
                
                return $.Deferred(function (def) {

                    var data = {
                        recipes: ko.observable(),
                    };

                    $.when(
                        datacontext.recipes.getData({ results: data.recipes })
                    )
                    .pipe(function() {
                        logger.success('Fetched data for: '
                            + '<div>' + data.recipes().length + ' recipes </div>'
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