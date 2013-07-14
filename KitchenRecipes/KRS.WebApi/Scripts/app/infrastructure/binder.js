define('binder',
    ['jquery', 'ko', 'config', 'vm'],
    function ($, ko, config, vm) {
        var
            ids = config.viewIds,

            bind = function () {
                ko.applyBindings(vm.shell, getView(ids.shellTop));
                ko.applyBindings(vm.recipe, getView(ids.recipe));
                ko.applyBindings(vm.recipes, getView(ids.recipes));
                ko.applyBindings(vm.ingredient, getView(ids.ingredient));
                ko.applyBindings(vm.ingredients, getView(ids.ingredients));
            },
            
            getView = function (viewName) {
                return $(viewName).get(0);
            };
            
        return {
            bind: bind
        };
    });