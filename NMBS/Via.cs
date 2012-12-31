using System;

namespace NetRail.NMBS
{
	public class Via
	{
		/// <summary>
		/// Gets or sets the arrival time.
		/// </summary>
		/// <value>
		/// The arrival time.
		/// </value>
		public DateTime ArrivalTime { get; set; }

		/// <summary>
		/// Gets or sets the departure time.
		/// </summary>
		/// <value>
		/// The departure time.
		/// </value>
		public DateTime DepartureTime { get; set; }

		/// <summary>
		/// Gets or sets the arrival platform.
		/// </summary>
		/// <value>
		/// The arrival platform.
		/// </value>
		public string ArrivalPlatform { get; set; }

		/// <summary>
		/// Gets or sets the departure platform.
		/// </summary>
		/// <value>
		/// The departure platform.
		/// </value>
		public string DeparturePlatform { get; set; }

		/// <summary>
		/// Gets or sets the time between transits.
		/// </summary>
		/// <value>
		/// The time between the transit.
		/// </value>
		public int TimeBetween { get; set; }


		/// <summary>
		/// Gets or sets the vehicle used.
		/// </summary>
		/// <value>
		/// The vehicle used.
		/// </value>
		public Vehicle VehicleUsed {get;set;}

		/// <summary>
		/// Gets or sets the arrival station.
		/// This is the station in which you make the transit to another train.
		/// </summary>
		/// <value>
		/// The arrival station.
		/// </value>
		public Station ArrivalStation { get; set; }

		/// <summary>
		/// Gets or sets the destination station.
		/// This is the station to where the train is heading to after you performed
		/// the transit.
		/// </summary>
		/// <value>
		/// The destination station.
		/// </value>
		public Station DestinationStation { get; set; }

		public Via ()
		{
		}
	}
}

