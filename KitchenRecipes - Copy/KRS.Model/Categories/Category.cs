using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.KRS;
using KRS.Model.Photos;

namespace KRS.Model.Categories
{
    public class Category: KRSEntity
    {
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string PhotoPath { get; set; }
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual CategoryGroup Group { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
