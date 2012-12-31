using System.Collections.Generic;

namespace NetRail.NMBS
{
    /// <summary>
    /// The data structure containing vehicle information
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// The ID of the vehicle
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The latitude of the vehicle
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// The longitude of the vehicle
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// The list of stations in which this train stops.
        /// </summary>
        public IList<Stop> Stops { get; set; }
    }
}
