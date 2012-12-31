using System;
using System.Collections.Generic;

namespace NetRail.NMBS
{
	public class Connection
	{
		/// <summary>
		/// Gets or sets the departure station.
		/// </summary>
		/// <value>
		/// The departure station.
		/// </value>
		public Station DepartureStation { get; set; }

		/// <summary>
		/// Gets or sets the arrival station.
		/// </summary>
		/// <value>
		/// The arrival station.
		/// </value>
		public Station ArrivalStation { get; set; }

		/// <summary>
		/// Gets or sets the time of departure
		/// </summary>
		/// <value>
		/// The time departure.
		/// </value>
		public DateTime DepartureTime { get; set; }

		/// <summary>
		/// Gets or sets the time of arrival
		/// </summary>
		/// <value>
		/// The time of arrival.
		/// </value>
		public DateTime ArrivalTime { get; set; }

		/// <summary>
		/// Gets or sets the platform of departure
		/// </summary>
		/// <value>
		/// The platform of departure.
		/// </value>
		public string DeparturePlatform { get; set; }

		/// <summary>
		/// Gets or sets the platform of arrival.
		/// </summary>
		/// <value>
		/// The platform of arrival.
		/// </value>
		public string ArrivalPlatform { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="NetRail.NMBS.Connection"/> departure platform changed.
		/// </summary>
		/// <value>
		/// <c>true</c> if departure platform changed; otherwise, <c>false</c>.
		/// </value>
		public bool DeparturePlatformChanged { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="NetRail.NMBS.Connection"/> arrival platform changed.
		/// </summary>
		/// <value>
		/// <c>true</c> if arrival platform changed; otherwise, <c>false</c>.
		/// </value>
		public bool ArrivalPlatformChanged { get; set; }

		/// <summary>
		/// Gets or sets the duration.
		/// </summary>
		/// <value>
		/// The duration.
		/// </value>
		public int Duration { get; set; }

		/// <summary>
		/// Gets or sets the vias.
		/// </summary>
		/// <value>
		/// The vias.
		/// </value>
		public IList<Via> Vias { get; set; }

		public Connection ()
		{
		}
	}
}

