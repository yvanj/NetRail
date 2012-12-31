using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetRail.NMBS
{
    /// <summary>
    /// The data structure containing departure information
    /// </summary>
    public class Departure
    {
        /// <summary>
        /// The time the train departs.
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// The delay (if applicable) of the train
        /// </summary>
        public int Delay { get; set; }
        /// <summary>
        /// The termination point of the station
        /// </summary>
        public Station Direction { get; set; }
        /// <summary>
        /// The vehicle object related to the departure.
        /// </summary>
        public Vehicle Vehicle { get; set; }
        /// <summary>
        /// The number of the platform of the train
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Returns true if the platform specified in the data is not the planned platform
        /// </summary>
        public bool PlatformChanged { get; set; }
    }
}
