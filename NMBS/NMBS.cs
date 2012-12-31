using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace NetRail.NMBS
{
    public enum NMBSLanguage
    {
        NL,
        EN,
        FR,
        DE
    }

    public class NMBS
    {
        /// <summary>
        /// The base URL to form API calls on.
        /// </summary>
        private const string BASE_URL = "http://api.irail.be";

        /// <summary>
        /// Contains the stations list. This is cached to prevent multiple useless requests
        /// to the server, resulting in a faster client with slightly less accurate data if
        /// NMBS plans to change a station's name or location during runtime.
        /// </summary>
        private List<Station> CachedStationsList;

        /// <summary>
        /// The language of the data.
        /// </summary>
        private NMBSLanguage Language {get;set;}

        /// <summary>
        /// Gets the list of stations
        /// </summary>
        /// <returns>A list of stations</returns>
        public List<Station> Stations()
        {
            if (CachedStationsList != null)
                return CachedStationsList;

            XDocument doc = XDocument.Parse(StationsXML(Language.ToString()));

            var data = from station in doc.Descendants("station")
                       select new Station
                       {
                            Id = station.Attribute("id").Value,
                            Latitude = float.Parse(station.Attribute("locationY").Value),
                            Longitude = float.Parse(station.Attribute("locationX").Value),
                            Name = station.Value
                       };

            CachedStationsList = data.ToList<Station>();

            return Stations() ;
        }


        /// <summary>
        /// Fetches the departures based on the station id.
        /// </summary>
        /// <param name="StationID">A string containing the station ID.</param>
        /// <returns>A list of departures for the specified station</returns>
        private List<Departure> _Liveboard(string StationID)
        {
            XDocument doc = XDocument.Parse(DeparturesXML(Language.ToString(), StationID));
            var data = from departure in doc.Descendants("departure")
                       select new Departure
                       {
                            Direction = Stations().First(p => p.Id == departure.Element("station").Attribute("id").Value),
                            Delay = int.Parse(departure.Attribute("delay").Value),
                            Platform = departure.Element("platform").Value,
                            PlatformChanged = departure.Element("platform").Attribute("normal").Value == "1",
                            Time = DateTime.Parse(departure.Element("time").Attribute("formatted").Value),
                            Vehicle = Vehicle(departure.Element("vehicle").Value)
                       };

            return data.ToList<Departure>();
        }


        /// <summary>
        /// Gets the liveboard for the specific station
        /// </summary>
        /// <param name="station">The station to query</param>
        /// <returns>A list of departures for the station</returns>
        public List<Departure> Liveboard(Station station)
        {
            return _Liveboard(station.Id);
        }

        /// <summary>
        /// Gets the liveboard for a specific station
        /// </summary>
        /// <param name="StationName">A string containing the name of the station</param>
        /// <returns>A list of departures for that station</returns>
        public List<Departure> Liveboard(string StationName)
        {
            var applicable_stations = from station in Stations()
                                      where station.Name.ToUpper().Contains(StationName.ToUpper())
                                      select station;
            return Liveboard(applicable_stations.First());
        }


        /// <summary>
        /// Returns the vehicle associated with the specified Vehicle ID.
        /// </summary>
        /// <param name="Id">The ID of the vehicle</param>
        /// <returns>An object containing the data of the vehicle.</returns>
        public Vehicle Vehicle(string Id)
        {
            XDocument doc = XDocument.Parse(VehicleXML(Language.ToString(), Id));
            var vehicle_data = (from vehicle in doc.Descendants("vehicle")
                                select new
                                {
                                    location_x = vehicle.Attribute("locationX").Value,
                                    location_y = vehicle.Attribute("locationY").Value,
                                    id = vehicle.Value
                                }).First();

            Vehicle v = new Vehicle();
            v.Id = Id;
            v.Latitude = float.Parse(vehicle_data.location_x);
            v.Longitude = float.Parse(vehicle_data.location_y);

            var stops = from stop in doc.Descendants("stop")
                        select new Stop
                        {
                            Station = Stations().First(p => p.Id == stop.Element("station").Attribute("id").Value),
                            Time = DateTime.Parse(stop.Element("time").Attribute("formatted").Value)
                        };

            v.Stops = stops.ToList<Stop>();

            return v;
        }

        /// <summary>
        /// Initializes a new NMBS wrapper class with the specified language
        /// </summary>
        /// <param name="Language">The language for the data to appear in</param>
        public NMBS(NMBSLanguage Language)
        {
            this.Language = Language;
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
        private string StationsXML(String lang) {
            WebClient client = new WebClient();
            return client.DownloadString(String.Format("{0}/{1}/?lang={2}", BASE_URL, "stations", lang));
        }

        /// <summary>
        /// Fetches the departures list in XML for the specified station and language
        /// </summary>
        /// <param name="lang">The required language for the data</param>
        /// <param name="id">The ID of the station</param>
        /// <returns>a string containing the XML data returned by the server</returns>
        private string DeparturesXML(String lang, String id)
        {
            WebClient client = new WebClient();
            return client.DownloadString(String.Format("{0}/{1}/?id={3}&lang={2}", BASE_URL, "liveboard", lang, id));
        }

        /// <summary>
        /// Fetches the vehicle data in XML for the specified vehicle and language.
        /// </summary>
        /// <param name="lang">The language of the data</param>
        /// <param name="id">The ID of the vehicle</param>
        /// <returns></returns>
        private string VehicleXML(String lang, String id)
        {
            WebClient client = new WebClient();
            return client.DownloadString(String.Format("{0}/{1}/?id={3}&lang={2}", BASE_URL, "vehicle", lang, id));
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
		private string ConnectionXML(String lang, String fromStation, String toStation) {
			WebClient client = new WebClient();
			return client.DownloadString(String.Format("{0}/{1}/?lang={2}&to={3}&from={4}", BASE_URL, "connections", lang, toStation, fromStation));
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
		private string ConnectionXML(String lang, String fromStation, String toStation, DateTime momentOfDeparture) {
			WebClient client = new WebClient();
			// TODO: update URL.
			return client.DownloadString(String.Format("{0}/{1}/?lang={2}&to={3}&from={4}", BASE_URL, "connections", lang, toStation, fromStation));
		}
    }
}
