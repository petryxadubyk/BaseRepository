define('filter.recipes',
    ['ko', 'utils', 'config'],
    function(ko, utils, config) {

        var RecipeFilter = function() {
            var self = this;
            self.searchText = ko.observable().extend({ throttle: config.throttle });
        };

        RecipeFilter.prototype = function() {
            var 
                searchTest = function(searchText, recipe) {
                    if (!searchText) return true; // always succeeds if no search text
                    var srch = utils.regExEscape(searchText.toLowerCase());
                    if (recipe.name().toLowerCase().search(srch) !== -1) return true;
                    return false;
                },
                predicate = function (self, recipe) {
                    // Return true if all of these meet the filter criteria. Otherwise, return false
                    var match = searchTest(self.searchText(), recipe);
                    return match;
                };
            return {
                predicate: predicate
            };
        }();

        return RecipeFilter;
    });