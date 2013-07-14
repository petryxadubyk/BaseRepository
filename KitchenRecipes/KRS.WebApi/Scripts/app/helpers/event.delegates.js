define('event.delegates',
    ['jquery', 'ko', 'config'],
    function($, ko, config) {
        var
            recipeBriefSelector = '.recipe-brief',
            ingredientsBriefSelector = '.recipe-brief',

        bindEventToList = function (rootSelector, selector, callback, eventName) {
            var eName = eventName || 'click';
            $(rootSelector).on(eName, selector, function () {
                var recipe = ko.dataFor(this);
                callback(recipe);
                return false;
            });
        },
        recipesListItem = function (callback, eventName) {
            bindEventToList(config.viewIds.recipes, recipeBriefSelector, callback, eventName);
        },

        ingredientsListItem = function (callback, eventName) {
            bindEventToList(config.viewIds.ingredients, ingredientsBriefSelector, callback, eventName);
        };

        return {
            recipesListItem: recipesListItem,
            ingredientsListItem: ingredientsListItem
        };
    });