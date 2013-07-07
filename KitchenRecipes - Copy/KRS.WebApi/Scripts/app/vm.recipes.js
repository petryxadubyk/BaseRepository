define('vm.recipes',
    ['jquery', 'underscore', 'ko', 'datacontext', 'router', 'filter.recipes', 'sort', 'event.delegates', 'utils', 'messenger', 'config', 'store'],
// ReSharper disable InconsistentNaming
    function($, _, ko, datacontext, router, RecipesFilter, sort, eventDelegates, utils, messenger, config, store) {
// ReSharper restore InconsistentNaming
        var 
            filterTemplate = 'recipes.filterbox',
            isBusy = false,
            isRefreshing = false,
            recipeFilter = new RecipesFilter(),
            recipeTemplate = 'recipes.view',
            recipes = ko.observableArray(),
            //stateKey = {filter: 'vm.recipes.filter'},
            
            activate = function(routeData, callback) {
                messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
                getRecipes(callback);
            },
            
            addFilterSubscriptions = function () {
                recipeFilter.searchText.subscribe(onFilterChange);
            },
            
            canLeave = function () {
                return true;
            },

            clearAllFilters = function () {
                recipeFilter.searchText('');
                getRecipes();
            },

            clearFilter = function () {
                recipeFilter.searchText('');
            },
            
            dataOptions = function (force) {
                return {
                    results: recipes,
                    filter: recipeFilter,
                    sortFunction: sort.recipeSort,
                    forceRefresh: force
                };
            },
            
            getRecipes = function (callback) {
                if (!isRefreshing) {
                    isRefreshing = true;
                    restoreFilter();
                    $.when(datacontext.recipes.getData(dataOptions(false)))
                        .always(utils.invokeFunctionIfExists(callback));
                    isRefreshing = false;
                } 
            },
            
            gotoDetails = function (selectedRecipe) {
                if (selectedRecipe && selectedRecipe.id()) {
                    router.navigateTo(config.hashes.recipes + '/' + selectedRecipe.id());
                }
            },

            onFilterChange = function () {
                if (!isRefreshing) {
                    store.save(stateKey.filter, ko.toJS(recipeFilter));
                    getRecipes();
                }
            },

            restoreFilter = function () {
                var stored = store.fetch(stateKey.filter);
                if (!stored) { return; }
                utils.restoreFilter({
                    stored: stored,
                    filter: recipeFilter,
                    datacontext: datacontext
                });
            },
            
            init = function () {
                // Bind jQuery delegated events
                eventDelegates.recipesListItem(gotoDetails);

                // Subscribe to specific changes of observables
                addFilterSubscriptions();
            };

        init();
        
        return {
            activate: activate,
            canLeave: canLeave,
            clearFilter: clearFilter,
            clearAllFilters: clearAllFilters,
            filterTemplate: filterTemplate,
            recipeFilter: recipeFilter,
            recipes: recipes,
            recipeTemplate: recipeTemplate,
        };
    });