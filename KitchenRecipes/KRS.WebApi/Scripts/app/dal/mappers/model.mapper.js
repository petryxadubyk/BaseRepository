define('model.mapper',
    ['model'],
    function (model) {
        var recipe = {
            getDtoId: function (dto) {
                return dto.id;
            },
            fromDto: function (dto, item) {
                item = item || new model.Recipe().id(dto.id);
                item.name(dto.name)
                    .shortDescription(dto.shortDescription)
                    .photoPath(dto.photoPath)
                    .likes(dto.likes)
                    .dislikes(dto.dislikes)
                    .createdOn(dto.createdOn)
                    .modifiedOn(dto.modifiedOn)
                    .createdBy(dto.createdBy)
                    .modifiedBy(dto.modifiedBy);

                item.dirtyFlag().reset();
                return item;
            }
        },
            ingredient = {
                getDtoId: function (dto) {
                    return dto.id;
                },
                fromDto: function (dto, item) {
                    item = item || new model.Ingredient().id(dto.id);
                    item.name(dto.name)
                        .description(dto.description)
                        .photoPath(dto.photoPath)
                        .manufacturer(dto.manufacturer)
                        .createdOn(dto.createdOn)
                        .modifiedOn(dto.modifiedOn)
                        .createdBy(dto.createdBy)
                        .modifiedBy(dto.modifiedBy);

                    item.dirtyFlag().reset();
                    return item;
                }
            };

        return {
            recipe: recipe,
            ingredient: ingredient
        };
    });