using System;
using System.ComponentModel.DataAnnotations;
using KRS.Model.KRS;

namespace KRS.Model.Photos
{
    public class Photo : KRSEntity
    {
        [Required]
        public String PhotoPath { get; set; }
        public int? Order { get; set; }

    }
}
