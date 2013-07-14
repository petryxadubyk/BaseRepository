define('vm.recipe',
    ['ko', 'datacontext', 'config', 'router', 'messenger', 'sort'],
    function (ko, datacontext, config, router, messenger, sort) {

        var currentRecipeId = ko.observable(),
            logger = config.logger,
            recipe = ko.observable(),
            recipeIngredients = ko.observableArray(),
            validationErrors = ko.observableArray([]),
            canEditRecipe = ko.computed(function() {
                return true;
            }),
            isDirty = ko.computed(function() {
                return false;
            }),
            isValid = ko.computed(function() {
                return canEditRecipe() ? validationErrors().length === 0 : true;
            }),
            activate = function(routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });

                currentRecipeId(routeData.id);
                //getRecipeIngredients();
                getRecipe(callback);

            },
            cancelCmd = ko.asyncCommand({
                execute: function(complete) {
                    var callback = function() {
                        complete();
                        logger.success(config.toasts.retreivedData);
                    };
                    getRecipe(callback, true);
                },
                canExecute: function(isExecuting) {
                    return !isExecuting && isDirty();
                }
            }),
            goBackCmd = ko.asyncCommand({
                execute: function(complete) {
                    router.navigateBack();
                    complete();
                },
                canExecute: function(isExecuting) {
                    return !isExecuting && !isDirty();
                }
            }),
            canLeave = function() {
                return !isDirty() && isValid;
            },
            getRecipe = function(completeCallback, forceRefresh) {
                var callback = function() {
                    if (completeCallback) {
                        completeCallback();
                    }
                    validationErrors = ko.validation.group(recipe());
                };

                datacontext.recipes.getFullRecipeById(
                    currentRecipeId(), {
                        success: function(s) {
                            recipe(s);
                            callback();
                        },
                        error: callback
                    },
                    forceRefresh
                );
            },
            saveCmd = ko.asyncCommand({
                execute: function(complete) {
                    if (canEditRecipe()) {
                        $.when(datacontext.recipes.updateData(recipe()))
                            .always(complete);
                        return;
                    }
                },
                canExecute: function(isExecuting) {
                    return !isExecuting && isDirty() && isValid;
                }
            }),
            tmplName = function() {
                return canEditRecipe() ? 'recipe.edit' : 'recipe.view';
            },
            getRecipeIngredients = function() {
                datacontext.recipes.getRecipeIngredients({
                    results: recipeIngredients, 
                    param: currentRecipeId()
                });
            },
            gotoIngredientDetails = function(selectedIngredient) {
                if (selectedIngredient && selectedIngredient.id()) {
                    router.navigateTo(config.hashes.ingredients + '/' + selectedIngredient.id());
                }
            };

        return {
            activate: activate,
            cancelCmd: cancelCmd,
            canEditRecipe: canEditRecipe,
            canLeave: canLeave,
            goBackCmd: goBackCmd,
            isDirty: isDirty,
            isValid: isValid,
            recipe: recipe,
            saveCmd: saveCmd,
            tmplName: tmplName,
            recipeIngredients: recipeIngredients,
            getRecipeIngredients: getRecipeIngredients,
            gotoIngredientDetails: gotoIngredientDetails
        };
    });