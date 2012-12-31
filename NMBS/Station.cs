using System.Collections.Generic;

namespace NetRail.NMBS
{
    /// <summary>
    /// The data structure containing station information.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// The ID of the station
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the station
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The longitude of the station
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// The latitude of the station
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// A list of the current departures in the station
        /// </summary>
        public IList<Departure> Departures
        {
            get
            {
                var n = new NMBS();
                return n.Liveboard(this);
            }
        }
    }
}
