using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        string Id { get; set; }
        /// <summary>
        /// The name of the station
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The longitude of the station
        /// </summary>
        float Longitude { get; set; }
        /// <summary>
        /// The latitude of the station
        /// </summary>
        float Latitude { get; set; }

        /// <summary>
        /// A list of the current departures in the station
        /// </summary>
        public List<Departure> Departures
        {
            
            get
            {
                // TODO: make the Station fetch the Departures.
                return null;
            }
            set
            {


            }
        }
    }
}
