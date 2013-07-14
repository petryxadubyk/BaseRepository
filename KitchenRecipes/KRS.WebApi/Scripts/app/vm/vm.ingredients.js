define('vm.ingredients',
    ['jquery', 'underscore', 'ko', 'datacontext', 'router', 'filter.ingredients', 'sort', 'event.delegates', 'utils', 'messenger', 'config', 'store'],
// ReSharper disable InconsistentNaming
    function ($, _, ko, datacontext, router, IngredientsFilter, sort, eventDelegates, utils, messenger, config, store) {
        // ReSharper restore InconsistentNaming
        var
            filterTemplate = 'ingredients.filterbox',
            isRefreshing = false,
            ingredientFilter = new IngredientsFilter(),
            ingredientTemplate = 'ingredients.view',
            ingredients = ko.observableArray(),
            stateKey = { filter: 'vm.ingredient.filter' },

            activate = function (routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
                getIngredients(callback);
            },

            addFilterSubscriptions = function () {
                ingredientFilter.searchText.subscribe(onFilterChange);
            },

            canLeave = function () {
                return true;
            },

            clearAllFilters = function () {
                ingredientFilter.searchText('');
                getIngredients();
            },

            clearFilter = function () {
                recipeFilter.searchText('');
            },

            dataOptions = function (force) {
                return {
                    results: ingredients,
                    filter: ingredientFilter,
                    sortFunction: sort.ingredientSort,
                    forceRefresh: force
                };
            },

            forceRefreshCmd = ko.asyncCommand({
                execute: function (complete) {
                    //complete();
                }
            }),

            getIngredients = function (callback) {
                if (!isRefreshing) {
                    isRefreshing = true;
                    restoreFilter();
                    $.when(datacontext.ingredients.getData(dataOptions(false)))
                        .always(utils.invokeFunctionIfExists(callback));
                    isRefreshing = false;
                }
            },

            gotoDetails = function (selectedIngredient) {
                if (selectedIngredient && selectedIngredient.id()) {
                    router.navigateTo(config.hashes.ingredients + '/' + selectedIngredient.id());
                }
            },

            onFilterChange = function () {
                if (!isRefreshing) {
                    store.save(stateKey.filter, ko.toJS(ingredientFilter));
                    getIngredients();
                }
            },

            restoreFilter = function () {
                var stored = store.fetch(stateKey.filter);
                if (!stored) { return; }
                utils.restoreFilter({
                    stored: stored,
                    filter: ingredientFilter,
                    datacontext: datacontext
                });
            },

            init = function () {
                // Bind jQuery delegated events
                eventDelegates.ingredientsListItem(gotoDetails);

                // Subscribe to specific changes of observables
                addFilterSubscriptions();
            };

        init();

        return {
            activate: activate,
            canLeave: canLeave,
            clearFilter: clearFilter,
            clearAllFilters: clearAllFilters,
            forceRefreshCmd: forceRefreshCmd,
            filterTemplate: filterTemplate,
            ingredientFilter: ingredientFilter,
            ingredients: ingredients,
            ingredientTemplate: ingredientTemplate,
        };
    });