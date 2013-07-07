define('model.mapper',
    ['model'],
    function(model) {
        var recipe = {
            getDtoId: function(dto) {
                return dto.id;
            },
            fromDto: function(dto, item) {
                item = item || new model.Recipe().id(dto.id);
                item.name(dto.name)
                    .shortDescription(dto.shortDescription)
                    .photoPath(dto.photoPath)
                    .likes(dto.likes)
                    .dislikes(dto.dislikes);
                item.dirtyFlag().reset();
                return item;
            }
        };

        return {
            recipe: recipe
        };
    });