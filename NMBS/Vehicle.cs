using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetRail.NMBS
{
    /// <summary>
    /// The data structure containing vehicle information
    /// </summary>
    class Vehicle
    {
        /// <summary>
        /// The ID of the vehicle
        /// </summary>
        public string Id { get; set; }

        
        /// <summary>
        /// The list of stations in which this train stops.
        /// </summary>
        public List<Stop> Stops
        {
            get
            {
                // TODO: implement stops fetching.
                return null;
            }
            set
            {

            }
        }
    }
}
