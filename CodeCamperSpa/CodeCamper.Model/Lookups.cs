using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamper.Model
{
    /// <summary>A collection of "lookup" lists</summary>
    /// <remarks>
    /// This is a DTO, not an entity backed by a database object.
    /// </remarks>
    public class Lookups
    {
        public IList<Room> Rooms { get; set; }
        public IList<TimeSlot> TimeSlots { get; set; }
        public IList<Track> Tracks { get; set; }
    }
}
