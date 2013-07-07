define('datacontext', 
    ['jquery', 'underscore', 'ko', 'model', 'model.mapper', 'dataservice', 'config', 'utils'],
    function ($, _, ko, model, modelmapper, dataservice, config, utils) {
        var
            logger = config.logger,
            
            getCurrentUserId = function() {
                return config.currentUser().id();
            },
            
            itemsToArray = function(items, observableArray, filter, sortFunction) {
                if (!observableArray) return;

                var underlyingArray = utils.mapMemoToArray(items);

                if (filter) {
                    underlyingArray = _.filter(underlyingArray, function(o) {
                        var match = filter.predicate(filter, o);
                        return match;
                    });
                }
                if (sortFunction) {
                    underlyingArray.sort(sortFunction);
                }

                observableArray(underlyingArray);
            },
            
            mapToContext = function(dtoList, items, results, mapper, filter, sortFunction) {
                items = _.reduce(dtoList, function(memo, dto) {
                    var id = mapper.getDtoId(dto);
                    var existingItem = items[id];
                    memo[id] = mapper.fromDto(dto, existingItem);
                    return memo;
                }, { });
                itemsToArray(items, results, filter, sortFunction);
                return items;
            },
            
            EntitySet = function(getFunction, mapper, nullo, updateFunction) {
                var items = { },
                    mapDtoToContext = function(dto) {
                        var id = mapper.getDtoId(dto);
                        var existingItem = items[id];
                        items[id] = mapper.fromDto(dto, existingItem);
                        return items[id];
                    },
                    add = function(newObj) {
                        items[newObj.id()] = newObj;
                    },
                    removeById = function(id) {
                        delete items[id];
                    },
                    getLocalById = function(id) {
                        // This is the only place we set to NULLO
                        return !!id && !!items[id] ? items[id] : nullo;
                    },
                    getAllLocal = function() {
                        return utils.mapMemoToArray(items);
                    },
                    getData = function(options) {
                        return $.Deferred(function(def) {
                            var results = options && options.results,
                                sortFunction = options && options.sortFunction,
                                filter = options && options.filter,
                                forceRefresh = options && options.forceRefresh,
                                param = options && options.param,
                                getFunctionOverride = options && options.getFunctionOverride;

                            getFunction = getFunctionOverride || getFunction;

                            // If the internal items object doesnt exist, 
                            // or it exists but has no properties, 
                            // or we force a refresh
                            if (forceRefresh || !items || !utils.hasProperties(items)) {
                                getFunction({
                                    success: function(dtoList) {
                                        items = mapToContext(dtoList, items, results, mapper, filter, sortFunction);
                                        def.resolve(results);
                                    },
                                    error: function(response) {
                                        logger.error(config.toasts.errorGettingData);
                                        def.reject();
                                    }
                                }, param);
                            } else {
                                itemsToArray(items, results, filter, sortFunction);
                                def.resolve(results);
                            }
                        }).promise();
                    },
                    updateData = function(entity, callbacks) {
                        var entityJson = ko.toJSON(entity);

                        return $.Deferred(function(def) {
                            if (!updateFunction) {
                                logger.error('updateData method not implemented');
                                if (callbacks && callbacks.error) {
                                    callbacks.error();
                                }
                                def.reject();
                                return;
                            }

                            updateFunction({
                                success: function(response) {
                                    logger.success(config.toasts.savedData);
                                    entity.dirtyFlag().reset();
                                    if (callbacks && callbacks.success) {
                                        callbacks.success();
                                    }
                                    def.resolve(response);
                                },
                                error: function(response) {
                                    logger.error(config.toasts.errorSavingData);
                                    if (callbacks && callbacks.error) {
                                        callbacks.error();
                                    }
                                    def.reject(response);
                                    return;
                                }
                            });
                        }).promise();
                    };

                return {
                    mapDtoToContext: mapDtoToContext,
                    add: add,
                    getAllLocal: getAllLocal,
                    getLocalById: getLocalById,
                    getData: getData,
                    removeById: removeById,
                    updateData: updateData
                };
            },
            //----------------------------------
            // Repositories
            //
            // Pass: 
            //  dataservice's 'get' method
            //  model mapper
            //----------------------------------
            recipes = new EntitySet(dataservice.recipe.getRecipes, modelmapper.recipe, model.Recipe.Nullo, dataservice.recipe.updateRecipe);

        // extend Recipes EntitySet
        recipes.getFullRecipeById = function (id, callbacks, forceRefresh) {
            return $.Deferred(function (def) {
                var recipe = recipes.getLocalById(id);
                if (recipe.isNullo || recipe.isBrief() || forceRefresh) {
                    // if nullo or brief, get fresh from database
                    dataservice.recipe.getRecipe({
                        success: function (dto) {
                            // updates the recipe returned from getLocalById() above
                            recipe = recipes.mapDtoToContext(dto);
                            recipe.isBrief(false); // now a full recipe
                            if (callbacks && callbacks.success) { callbacks.success(recipe); }
                            def.resolve(dto);
                        },
                        error: function (response) {
                            logger.error('oops! could not retrieve recipe ' + id);
                            if (callbacks && callbacks.error) { callbacks.error(response); }
                            def.reject(response);
                        }
                    },
                    id);
                }
                else {
                    if (callbacks && callbacks.success) { callbacks.success(recipe); }
                    def.resolve(recipe);
                }
            }).promise();
        };

        var datacontext = {
            recipes: recipes
        };

        model.setDataContext(datacontext);

        return datacontext;
    });
 