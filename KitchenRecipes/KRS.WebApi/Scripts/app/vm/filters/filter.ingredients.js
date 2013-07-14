define('filter.ingredients',
    ['ko', 'utils', 'config'],
    function (ko, utils, config) {

        var IngredientsFilter = function () {
            var self = this;
            self.searchText = ko.observable().extend({ throttle: config.throttle });
        };

        IngredientsFilter.prototype = function () {
            var
                searchTest = function (searchText, ingredient) {
                    if (!searchText) return true; // always succeeds if no search text
                    var srch = utils.regExEscape(searchText.toLowerCase());
                    if (ingredient.name().toLowerCase().search(srch) !== -1) return true;
                    return false;
                },
                predicate = function (self, ingredient) {
                    // Return true if all of these meet the filter criteria. Otherwise, return false
                    var match = searchTest(self.searchText(), ingredient);
                    return match;
                };
            return {
                predicate: predicate
            };
        }();

        return IngredientsFilter;
    });