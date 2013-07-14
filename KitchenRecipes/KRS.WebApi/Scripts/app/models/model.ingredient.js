define('model.ingredient',
    ['ko', 'config'],
    function(ko, config) {
        var Ingredient = function() {
            var self = this;
            self.id = ko.observable();
            self.name = ko.observable().extend({ required: true });
            self.description = ko.observable();
            self.photoPath = ko.observable();
            self.manufacturer = ko.observable();
            self.createdOn = ko.observable();
            self.modifiedOn = ko.observable();
            self.createdBy = ko.observable();
            self.modifiedBy = ko.observable();
            
            self.recipeHash = ko.computed(function () {
                return config.hashes.ingredients + '/' + self.id();
            });

            self.dirtyFlag = new ko.DirtyFlag(self);
            return self;
        };

        Ingredient.Nullo = new Ingredient()
            .id(0)
            .name('Not a Ingredient')
            .description('')
            .manufacturer('')
            .photoPath('');
        Ingredient.Nullo.isNullo = true;
        Ingredient.Nullo.dirtyFlag().reset();

        var _dc = null;
        // Static member, no access to instances of Session
        Ingredient.datacontext = function (dc) {
            if (dc) { _dc = dc; }
            return _dc;
        };
        
        // Prototype is available to all instances.
        // It has access to the properties of the instance of Session.
        Ingredient.prototype = function () {
            var dc = Ingredient.datacontext;
              

            /*categories = function () {
                return dc().categories.getLocalCategories(this.id());
            },

            photos = function () {
                return dc().photos.getLocalPhotos(this.id());
            };*/

            return {
                isNullo: false,
                //categories: categories,
                //photos: photos,
            };
        }();
        return Ingredient;
    });