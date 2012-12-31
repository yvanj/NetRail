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
                            Latitude = float.Parse(station.Attribute("latitude").Value),
                            Longitude = float.Parse(station.Attribute("longitude").Value),
                            Name = station.Value
                       };

            CachedStationsList = data.ToList<Station>();

            return Stations() ;
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
        /// Fetches the raw stations list in XML for the specified language.
        /// </summary>
        /// <param name="lang">The language to be used</param>
        /// <returns>a string containing the XML data returned by the server</returns>
        private string StationsXML(String lang) {
            WebClient client = new WebClient();
            return client.DownloadString(String.Format("{0}/{1}/?lang={2}", BASE_URL, "stations", lang));
        }
    }
}
