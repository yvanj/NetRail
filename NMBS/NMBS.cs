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
                            Direction = Stations().First(p => p.Id == departure.Element("station").Attribute("id").Value),
                            Delay = int.Parse(departure.Attribute("delay").Value),
                            Platform = departure.Element("platform").Value,
                            PlatformChanged = departure.Element("platform").Attribute("normal").Value == "1",
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

            var stops = from stop in doc.Descendants("stop")
                        select new Stop
                        {
                            Station = Stations().First(p => p.Id == stop.Element("station").Attribute("id").Value),
                            Time = DateTime.Parse(stop.Element("time").Attribute("formatted").Value)
                        };

            v.Stops = stops.ToList();

            return v;
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
        private string VehicleXML(String lang, String id)
        {
            var client = new WebClient();

            return client.DownloadString(String.Format("{0}/{1}/?id={3}&lang={2}", BaseUrl, "vehicle", lang, id));
        }
    }
}
