using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Categories;
using KRS.Model.Infrastructure;
using KRS.Model.Photos;
using KRS.Model.Recipes;
using KRS.Model.Users;

namespace KRS.Model.ViewModels
{
    public class RecipeBrief
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(300), Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string ShortDescription { get; set; }
        [MaxLength(300)]
        public string PhotoPath { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
