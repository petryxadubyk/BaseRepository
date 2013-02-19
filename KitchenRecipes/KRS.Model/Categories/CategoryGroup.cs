using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KRS.Model.KRS;

namespace KRS.Model.Categories
{
    public class CategoryGroup: KRSEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Category> GroupCategories { get; set; }
    }
}
