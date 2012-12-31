using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetRail.NMBS
{
    /// <summary>
    /// The model for a stop from a vehicle.
    /// </summary>
    public class Stop
    {
        /// <summary>
        /// The time the vehicle stops in the station
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// The station in which the vehicle stops
        /// </summary>
        public Station Station { get; set; }
    }
}
