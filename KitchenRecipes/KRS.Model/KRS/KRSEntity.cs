using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRS.Model.KRS
{
    public class KRSEntity
    {
        public KRSEntity()
        {
            CreatedOn = DateTime.Now.ToUniversalTime();
            ModifiedOn = DateTime.Now.ToUniversalTime();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
