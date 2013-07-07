define('model.recipe',
    ['ko', 'config'],
    function (ko, config) {
        var Recipe = function () {
            var self = this;
            self.id = ko.observable();
            self.name = ko.observable().extend({ required: true });
            self.shortDescription = ko.observable();
            self.photoPath = ko.observable();
            self.likes = ko.observable();
            self.dislikes = ko.observable();
            //self.categoryFilter = ko.observable();
            //self.cookProcessFilter = ko.observable();
            //self.kitchenwareFilter = ko.observable();
            //self.ingredientFilter = ko.observable();

            self.recipeHash = ko.computed(function () {
                return config.hashes.recipes + '/' + self.id();
            });

            self.isBrief = ko.observable(true);
            self.dirtyFlag = new ko.DirtyFlag(self);
            return self;
        };

        Recipe.Nullo = new Recipe()
            .id(0)
            .name('Not a Recipe')
            .shortDescription('');
        Recipe.Nullo.isNullo = true;
        Recipe.Nullo.isBrief = function () { return false; }; // nullo is never brief
        Recipe.Nullo.dirtyFlag().reset();

        var _dc = null;
        // Static member, no access to instances of Session
        Recipe.datacontext = function (dc) {
            if (dc) { _dc = dc; }
            return _dc;
        };


        // Prototype is available to all instances.
        // It has access to the properties of the instance of Session.
        Recipe.prototype = function () {
            var dc = Recipe.datacontext;
                /*categories = function () {
                    return dc().categories.getLocalCategories(this.id());
                },

                kitchenwares = function () {
                    return dc().kitchenwares.getLocalKitchenwares(this.id());
                },

                ingredients = function () {
                    return dc().ingredients.getLocalIngredients(this.id());
                },

                cookProcesses = function () {
                    return dc().cookProcesses.getLocalCookProcesses(this.id());
                },

                photos = function () {
                    return dc().photos.getLocalPhotos(this.id());
                },
                
                users = function () {
                    return dc().users.getLocalUsers(this.id());
                };*/
            
                

            return {
                isNullo: false,
                //categories: categories,
                //kitchenwares: kitchenwares,
                //ingredients: ingredients,
                //cookProcesses: cookProcesses,
                //photos: photos,
                //users: users
            };
        }();

        return Recipe;
    });