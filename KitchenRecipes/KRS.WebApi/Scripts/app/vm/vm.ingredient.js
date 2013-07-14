define('vm.ingredient',
    ['ko', 'datacontext', 'config', 'router', 'messenger', 'sort'],
    function (ko, datacontext, config, router, messenger, sort) {

        var
            currentIngredientId = ko.observable(),
            logger = config.logger,
            ingredient = ko.observable(),
            validationErrors = ko.observableArray([]),

            canEditIngredient = ko.computed(function () {
                return true;
            }),

            isDirty = ko.computed(function () {
                return false;
            }),

            isValid = ko.computed(function () {
                return canEditIngredient() ? validationErrors().length === 0 : true;
            }),

            activate = function (routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
                currentIngredientId(routeData.id);
                getIngredient(callback);
            },

            cancelCmd = ko.asyncCommand({
                execute: function (complete) {
                    var callback = function () {
                        complete();
                        logger.success(config.toasts.retreivedData);
                    };
                    getIngredient(callback, true);
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && isDirty();
                }
            }),

            goBackCmd = ko.asyncCommand({
                execute: function (complete) {
                    router.navigateBack();
                    complete();
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && !isDirty();
                }
            }),

            canLeave = function () {
                return !isDirty() && isValid;
            },

            getIngredient = function (completeCallback, forceRefresh) {
                var callback = function () {
                    if (completeCallback) {
                        completeCallback();
                    }
                    validationErrors = ko.validation.group(ingredient());
                };

                var elem = datacontext.ingredients.getLocalById(currentIngredientId());
                ingredient(elem);
            },

            saveCmd = ko.asyncCommand({
                execute: function (complete) {
                    if (canEditIngredient()) {
                        $.when(datacontext.ingredients.updateData(ingredient()))
                            .always(complete);
                        return;
                    }
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && isDirty() && isValid;
                }
            }),

            tmplName = function () {
                return canEditIngredient() ? 'ingredient.view' : 'ingredient.view';
            };

        return {
            activate: activate,
            cancelCmd: cancelCmd,
            canEditIngredient: canEditIngredient,
            canLeave: canLeave,
            goBackCmd: goBackCmd,
            isDirty: isDirty,
            isValid: isValid,
            ingredient: ingredient,
            saveCmd: saveCmd,
            tmplName: tmplName
        };
    });