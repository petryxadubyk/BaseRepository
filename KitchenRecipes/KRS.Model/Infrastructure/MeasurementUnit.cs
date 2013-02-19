using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KRS.Model.Infrastructure
{
    [ComplexType]
    public class MeasurementUnit
    {
        [MaxLength(100)]
        public string Value { get; set; }
        [MaxLength(100)]
        public string MeasureSign { get; set; }
    }
}
