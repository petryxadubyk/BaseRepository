using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KRS.Model.Infrastructure;

namespace KRS.DataAccess.SampleData
{
    internal static class MeasureUnits
    {
        public static Dictionary<string, MeasurementUnit> Units = new Dictionary<string, MeasurementUnit>
                                                                             {
                                                                                 {
                                                                                     "kg",
                                                                                     new MeasurementUnit
                                                                                         {
                                                                                             MeasureSign = "кг",
                                                                                         }

                                                                                 },
                                                                                 {
                                                                                     "gram",
                                                                                     new MeasurementUnit
                                                                                         {
                                                                                             MeasureSign = "г",
                                                                                         }

                                                                                 },
                                                                                 {
                                                                                     "count",
                                                                                     new MeasurementUnit
                                                                                         {
                                                                                             MeasureSign = "",
                                                                                         }

                                                                                 },
 
                                                                             };
    }
}
