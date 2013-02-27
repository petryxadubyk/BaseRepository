(function () {

    var baseUrl = '/api/recipes';

    asyncTest("Update Recipe - Null Name - Throws Validation Error",
        function () {
            //ARRANGE
            var
                badTestRecipe = {
                    name: null,
                    shortDescription: "This recipe has no name and should not been valid.",
                },
                data = JSON.stringify(badTestRecipe);

            //ACT
            $.ajax({
                type: 'PUT',
                url: baseUrl,
                data: data,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',

                // ASSERT
                success: function() {
                    ok(false, 'Validation did not catch the null name');
                    start();
                },
                error: function (result) {
                    debugger;
                    equal(result.responseText, '{\"recipe.Name\":\"The Name field is required.\"}', 'Validation caught the null name');
                    start();
                }
            });
            var
                badTestRecipe2 = {
                    name: "ya",
                    shortDescription: "This recipe has no name and should not been valid.",
                },
                data2 = JSON.stringify(badTestRecipe2);

            //ACT
            $.ajax({
                type: 'PUT',
                url: baseUrl,
                data: data2,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',

                // ASSERT
                success: function () {
                    ok(false, 'Validation did not catch the 2 characters name');
                    start();
                },
                error: function (result) {
                    debugger;
                    equal(result.responseText, '{\"recipe.Name\":\"The field Name must be a string or array type with a minimum length of \'3\'.\"}', 'Validation caught the 2 characters name');
                    start();
                }
            });
        }
    );   
 
})();