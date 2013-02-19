using System.ComponentModel.DataAnnotations;
using KRS.Model.KRS;

namespace KRS.Model.Photos
{
    public class Photo : KRSEntity
    {
        [Required, MaxLength(300)]
        public string PhotoPath { get; set; }
        public int? Order { get; set; }

    }
}
