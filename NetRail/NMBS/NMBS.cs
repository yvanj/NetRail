using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace NetRail.NMBS
{
    public class NMBS
    {
        /// <summary>
        /// The base URL to form API calls on.
        /// </summary>
        private const string BaseUrl = "http://api.irail.be";

        /// <summary>
        /// Contains the stations list. This is cached to prevent multiple useless requests
        /// to the server, resulting in a faster client with slightly less accurate data if
        /// NMBS plans to change a station's name or location during runtime.
        /// </summary>
        private IList<Station> _cachedStationsList;

        /// <summary>
        /// The language of the data.
        /// </summary>
        private NMBSLanguage Language {get;set;}


        /// <summary>
        /// Gets the station by its ID.
        /// </summary>
        /// <param name="id">The station ID.</param>
        /// <returns>The station object associated with the ID, or Null if inexistent.</returns>
        public Station GetStation(string id)
        {
            try
            {
                return Stations().First(p => p.Id == id);
            }
            catch (InvalidOperationException invalidop)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the list of stations
        /// </summary>
        /// <returns>A list of stations</returns>
        public IList<Station> Stations()
        {
            if (_cachedStationsList != null)
                return _cachedStationsList;

            var doc = XDocument.Parse(StationsXML(Language.ToString()));

            var data = from station in doc.Descendants("station")
                       select new Station
                       {
                            Id = station.Attribute("id").Value,
                            Latitude = float.Parse(station.Attribute("locationY").Value),
                            Longitude = float.Parse(station.Attribute("locationX").Value),
                            Name = station.Value
                       };

            _cachedStationsList = data.ToList();

            return Stations() ;
        }


        /// <summary>
        /// Fetches the departures based on the station id.
        /// </summary>
        /// <param name="stationId">A string containing the station ID.</param>
        /// <returns>A list of departures for the specified station</returns>
        private IList<Departure> _Liveboard(string stationId)
        {
            var doc = XDocument.Parse(DeparturesXML(Language.ToString(), stationId));

            var data = from departure in doc.Descendants("departure")
                       select new Departure
                       {
                            Direction = GetStation(departure.Element("station").Attribute("id").Value),
                            Delay = int.Parse(departure.Attribute("delay").Value),
                            Platform = departure.Element("platform").Value,
                            PlatformChanged = departure.Element("platform").Attribute("normal").Value != "1",
                            Time = DateTime.Parse(departure.Element("time").Attribute("formatted").Value),
                            Vehicle = Vehicle(departure.Element("vehicle").Value)
                       };

            return data.ToList();
        }


        /// <summary>
        /// Gets the liveboard for the specific station
        /// </summary>
        /// <param name="station">The station to query</param>
        /// <returns>A list of departures for the station</returns>
        public IList<Departure> Liveboard(Station station)
        {
            return _Liveboard(station.Id);
        }

        /// <summary>
        /// Gets the liveboard for a specific station
        /// </summary>
        /// <param name="stationName">A string containing the name of the station</param>
        /// <returns>A list of departures for that station</returns>
        public IList<Departure> Liveboard(string stationName)
        {
            var applicableStations = from station in Stations()
                                     where station.Name.ToUpper().Contains(stationName.ToUpper())
                                     select station;

            return Liveboard(applicableStations.First());
        }


        /// <summary>
        /// Returns the vehicle associated with the specified Vehicle ID.
        /// </summary>
        /// <param name="id">The ID of the vehicle</param>
        /// <returns>An object containing the data of the vehicle.</returns>
        public Vehicle Vehicle(string id)
        {
            var doc = XDocument.Parse(VehicleXML(Language.ToString(), id));

            var vehicleData = (from vehicle in doc.Descendants("vehicle")
                                select new
                                {
                                    location_x = vehicle.Attribute("locationX").Value,
                                    location_y = vehicle.Attribute("locationY").Value,
                                    id = vehicle.Value
                                }).First();

            var v = new Vehicle
                        {
                            Id = id,
                            Latitude = float.Parse(vehicleData.location_x),
                            Longitude = float.Parse(vehicleData.location_y)
                        };

            try
            {
                var stops = from stop in doc.Descendants("stop")
                            select new Stop
                            {
                                Station = GetStation(stop.Element("station").Attribute("id").Value),
                                Time = DateTime.Parse(stop.Element("time").Attribute("formatted").Value)
                            };

                v.Stops = stops.ToList();

            }
            catch (InvalidOperationException invalidop)
            {
                // station could not be fetched, clearing stops.
                v.Stops = new List<Stop>();
            }
            return v;
        }

		private IList<Via> parseVias (XElement viasElement)
		{
            
			var vias = from via in viasElement.Descendants("via")
				select new Via {
				ArrivalPlatform = via.Element("arrival").Element("platform").Value,
				ArrivalPlatformChanged = via.Element("arrival").Element("platform").Attribute("normal").Value != "1",
				ArrivalTime = DateTime.Parse(via.Element("arrival").Element("time").Attribute("formatted").Value),
				DeparturePlatform = via.Element("departure").Element("platform").Value,
				DeparturePlatformChanged = via.Element("departure").Element("platform").Attribute("normal").Value != "1",
				DepartureTime = DateTime.Parse(via.Element("departure").Element("time").Attribute("formatted").Value),

				Station = GetStation(via.Element("station").Attribute("id").Value),
				DestinationStation = GetStation(via.Element("direction").Attribute("id").Value),
				VehicleUsed = Vehicle(via.Element("vehicle").Value),
				TimeBetween = int.Parse(via.Element("timeBetween").Value),

			};
			return vias.ToList<Via>();
		}

		/// <summary>
		/// parses the XDocument containing the connections.
		/// </summary>
		/// <returns>
		/// An IList containing instances of the Connection object.
		/// </returns>
		/// <param name='documentToParse'>
		/// The document which requires parsing.
		/// </param>
		private IList<Connection> _parseConnections(XDocument documentToParse) {
			var connections = from connection in documentToParse.Descendants("connection")
			select new Connection {
				DepartureStation = GetStation(connection.Element("departure").Element("station").Attribute("id").Value),
				ArrivalStation = GetStation(connection.Element("arrival").Element("station").Attribute("id").Value),
				ArrivalPlatform = connection.Element("arrival").Element("platform").Value,
				ArrivalPlatformChanged = connection.Element("arrival").Element("platform").Attribute("normal").Value != "1",
				DeparturePlatformChanged = connection.Element("departure").Element("platform").Attribute("normal").Value != "1",
				ArrivalTime = DateTime.Parse(connection.Element("arrival").Element("time").Attribute("formatted").Value),
				DepartureTime = DateTime.Parse(connection.Element("departure").Element("time").Attribute("formatted").Value),
				DeparturePlatform = connection.Element("departure").Element("platform").Value,
				Vias = parseVias(connection.Element("vias")),
                Duration = int.Parse(connection.Element("duration").Value)
			};
			return connections.ToList<Connection>();
		}


		/// <summary>
		/// Connections between the specified stations
		/// </summary>
		/// <param name='fromStation'>
		/// The station of departure.
		/// </param>
		/// <param name='destinationStation'>
		/// The station of destination.
		/// </param>
		public IList<Connection> Connections (Station fromStation, Station destinationStation)
		{
			var doc = XDocument.Parse(ConnectionXML(Language.ToString(), fromStation.Name, destinationStation.Name));
			return _parseConnections(doc);
		}

		/// <summary>
		/// Connections between the specified stations at the given moment.
		/// The moment can either be the time of arrival or the time of departure.
		/// </summary>
		/// <param name='fromStation'>
		/// FThe station of departure.
		/// </param>
		/// <param name='destinationStation'>
		/// The station of destination.
		/// </param>
		/// <param name='TimeType'>
		/// The type of the time. Passing NMBSTimeSelection.DepartureTime will force the specified
		/// moment to be interpreted as the time of departure, specifying NMBSTimeSelection.ArrivalTime 
		/// will mark the moment specified as the time of arrival.
		/// </param>
		/// <param name='moment'>
		/// The time and date to which the data should be applicable.
		/// </param>
		public IList<Connection> Connections (Station fromStation, Station destinationStation, NMBSTimeSelection timeType, DateTime moment)
		{
			var doc = XDocument.Parse(ConnectionXML(Language.ToString(), fromStation.Name, destinationStation.Name, moment, timeType));
			return _parseConnections(doc);
		}


        /// <summary>
        /// Initializes a new NMBS wrapper class with the specified language
        /// </summary>
        /// <param name="language">The language for the data to appear in</param>
        public NMBS(NMBSLanguage language)
        {
            Language = language;
        }

        /// <summary>
        /// Initializes a new NMBS wrapper class with the default language (English)
        /// </summary>
        public NMBS() : this(NMBSLanguage.EN)
        {

        }

        /// <summary>
        /// Fetches the raw stations list in XML for the specified language.
        /// </summary>
        /// <param name="lang">The language to be used</param>
        /// <returns>a string containing the XML data returned by the server</returns>
        private string StationsXML(string lang) {
            var client = new WebClient();

            return client.DownloadString(String.Format("{0}/{1}/?lang={2}", BaseUrl, "stations", lang));
        }

        /// <summary>
        /// Fetches the departures list in XML for the specified station and language
        /// </summary>
        /// <param name="lang">The required language for the data</param>
        /// <param name="id">The ID of the station</param>
        /// <returns>a string containing the XML data returned by the server</returns>
        private string DeparturesXML(string lang, string id)
        {
            var client = new WebClient();

            return client.DownloadString(String.Format("{0}/{1}/?id={3}&lang={2}", BaseUrl, "liveboard", lang, id));
        }

        /// <summary>
        /// Fetches the vehicle data in XML for the specified vehicle and language.
        /// </summary>
        /// <param name="lang">The language of the data</param>
        /// <param name="id">The ID of the vehicle</param>
        /// <returns></returns>
        private string VehicleXML(string lang, string id)
        {
            var client = new WebClient();

            return client.DownloadString(String.Format("{0}/{1}/?id={3}&lang={2}", BaseUrl, "vehicle", lang, id));
        }

		/// <summary>
		/// Fetches the raw XML for the connections for the specified route.
		/// </summary>
		/// <returns>
		/// The XML code generated by the server.
		/// </returns>
		/// <param name='lang'>
		/// The language used for the data
		/// </param>
		/// <param name='fromStation'>
		/// The station of departure
		/// </param>
		/// <param name='toStation'>
		/// The station of (planned) arrival
		/// </param>
		private string ConnectionXML(string lang, string fromStation, string toStation) {
			WebClient client = new WebClient();
			return client.DownloadString(String.Format("{0}/{1}/?lang={2}&to={3}&from={4}", BaseUrl, "connections", lang, toStation, fromStation));
		}

		/// <summary>
		/// Fetches the raw XML for the connections for the specified route.
		/// </summary>
		/// <returns>
		/// The XML code generated by the server.
		/// </returns>
		/// <param name='lang'>
		/// The language for the data.
		/// </param>
		/// <param name='fromStation'>
		/// The station of departure
		/// </param>
		/// <param name='toStation'>
		/// The station of (planned) arrival
		/// </param>
		/// <param name='momentOfDeparture'>
		/// Moment of departure.
		/// </param>
		private string ConnectionXML(string lang, string fromStation, string toStation, DateTime momentOfDeparture, NMBSTimeSelection timeSelection) {
			WebClient client = new WebClient();
			return client.DownloadString(String.Format("{0}/{1}/?lang={2}&to={3}&from={4}&date={5:ddMMyy}&time={6:HHmm}&timeSel={7}", BaseUrl, "connections", lang, toStation, 
			                                           fromStation, momentOfDeparture, momentOfDeparture,
			                                           timeSelection == NMBSTimeSelection.DepartureTime ? "depart" : "arrive"
			                                           ));
		}
    }
}
