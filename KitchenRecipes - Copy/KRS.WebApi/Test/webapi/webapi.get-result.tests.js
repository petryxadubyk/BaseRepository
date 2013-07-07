(function () {
    QUnit.config.testTimeout = 10000;

    module('Web API GET result has expected shape');

    asyncTest('Recipes url should return some correct data',
            function () {
                $.ajax({
                    url: '/api/recipes/1',
                    dataType: 'json',
                    success: function (result) {
                        ok(
                            !!result.name
                            && !!result.photoPath
                            && !!result.shortDescription,
                            'Got Name, PhotoPath, ShortDescription');
                        start();
                    },
                    error: function (result) {
                        ok(false, 'Failed with: ' + result.responseText);
                        start();
                    }
                });
            }
        );

}());
