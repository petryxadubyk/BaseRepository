(function () {
    QUnit.config.testTimeout = 10000;
    
    var okAsync = QUnit.okAsync,
        stringformat = QUnit.stringformat;
    
    var baseUrl = '/api/recipes',
        getMsgPrefix = function(id, rqstUrl) {
            return stringformat(
                ' of recipe with id=\'{0}\' to \'{1}\'',
                id, rqstUrl);
        },
        onCallSuccess = function(msgPrefix) {
            ok(true, msgPrefix + " succeeded.");
        },
        onError = function (result, msgPrefix) {
            okAsync(false, msgPrefix +
                stringformat(' failed with status=\'{1}\': {2}.',
                    result.status, result.responseText));
        };

    var testRecipeId = 6,
        testUrl,
        testMsgBase,
        testRecipe,
        origName,
        testName;

    module('Web API Recipe update tests',
        {
          setup: function () {
              testUrl = stringformat(
                  '{0}/?id={1}', baseUrl, testRecipeId);
              testMsgBase = getMsgPrefix(testRecipeId, testUrl);
          } 
        });
       
    test('Can update the test Recipe',
        function() {
            testRecipe = null;
            stop();
            getTestRecipe(changeTestRecipe);
        }
    );

    // Step 1: Get test person (this fnc is re-used several times)
    function getTestRecipe(succeedCallback) {
        var msgPrefix = 'GET' + testMsgBase;
        $.ajax({
            type: 'GET',
            url: testUrl,
            success: function(result) {
                onCallSuccess(msgPrefix);
                okAsync(result.id === testRecipeId,
                    "returned key matches testRecipe Id.");
                if (typeof succeedCallback !== 'function') {
                    start(); // no 'succeed' callback; end of the line
                    return;
                } else {
                    succeedCallback(result);
                };
            },
            error: function(result) { onError(result, msgPrefix); }
        });
    };

    // Step 2: Change test person and save it
    function changeTestRecipe(recipe) {
        testRecipe = recipe;
        origName = testRecipe.name;
        testName = origName === "Вінігрет" ? "ВінігретНовий" : "Вінігрет"; // make it different
        testRecipe.name = testName;

        var msgPrefix = 'PUT (change)' + testMsgBase,
            data = JSON.stringify(testRecipe);

        $.ajax({
            type: 'PUT',
            url: baseUrl,
            data: data,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function() {
                onCallSuccess(msgPrefix);
                getTestRecipe(confirmUpdated);
            },
            error: function(result) { onError(result, msgPrefix); }
        });
    };

    // Step 3: Confirm test person updated, then call restore
    function confirmUpdated(recipe) {
        okAsync(recipe.name === testName, "test recipe's Name was updated ");
        restoreTestRecipe();
    };

    // Step 4: Restore orig test person in db
    function restoreTestRecipe() {
        testRecipe.name = origName;
        var msgPrefix = 'PUT (restore)' + testMsgBase,
            data = JSON.stringify(testRecipe);

        $.ajax({
            type: 'PUT',
            url: baseUrl,
            data: data,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function() {
                getTestRecipe(confirmRestored);
            },
            error: function(result) { onError(result, msgPrefix); }
        });
    };

    // Step 5: Confirm test person was restored
    function confirmRestored(recipe) {
        okAsync(recipe.name === origName, "test recipe's Name was restored ");
        start();
    };

    /////////////////////   
})();