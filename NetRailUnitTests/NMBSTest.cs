using NetRail.NMBS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NetRail;
using System.Collections.Generic;
using System.Xml.Linq;

namespace NetRailUnitTests
{
    
    
    /// <summary>
    ///This is a test class for NMBSTest and is intended
    ///to contain all NMBSTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NMBSTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for NMBS Constructor
        ///</summary>
        [TestMethod()]
        public void NMBSConstructorTest()
        {
            NMBSLanguage language = new NMBSLanguage(); // TODO: Initialize to an appropriate value
            NMBS target = new NMBS(language);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for NMBS Constructor
        ///</summary>
        [TestMethod()]
        public void NMBSConstructorTest1()
        {
            NMBS target = new NMBS();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ConnectionXML
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void ConnectionXMLTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            string lang = string.Empty; // TODO: Initialize to an appropriate value
            string fromStation = string.Empty; // TODO: Initialize to an appropriate value
            string toStation = string.Empty; // TODO: Initialize to an appropriate value
            DateTime momentOfDeparture = new DateTime(); // TODO: Initialize to an appropriate value
            NMBSTimeSelection timeSelection = new NMBSTimeSelection(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ConnectionXML(lang, fromStation, toStation, momentOfDeparture, timeSelection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConnectionXML
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void ConnectionXMLTest1()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            string lang = string.Empty; // TODO: Initialize to an appropriate value
            string fromStation = string.Empty; // TODO: Initialize to an appropriate value
            string toStation = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ConnectionXML(lang, fromStation, toStation);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Connections
        ///</summary>
        [TestMethod()]
        public void ConnectionsTest()
        {
            NMBS target = new NMBS(); // TODO: Initialize to an appropriate value
            Station fromStation = null; // TODO: Initialize to an appropriate value
            Station destinationStation = null; // TODO: Initialize to an appropriate value
            IList<Connection> expected = null; // TODO: Initialize to an appropriate value
            IList<Connection> actual;
            actual = target.Connections(fromStation, destinationStation);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Connections
        ///</summary>
        [TestMethod()]
        public void ConnectionsTest1()
        {
            NMBS target = new NMBS(); // TODO: Initialize to an appropriate value
            Station fromStation = null; // TODO: Initialize to an appropriate value
            Station destinationStation = null; // TODO: Initialize to an appropriate value
            NMBSTimeSelection timeType = new NMBSTimeSelection(); // TODO: Initialize to an appropriate value
            DateTime moment = new DateTime(); // TODO: Initialize to an appropriate value
            IList<Connection> expected = null; // TODO: Initialize to an appropriate value
            IList<Connection> actual;
            actual = target.Connections(fromStation, destinationStation, timeType, moment);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeparturesXML
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void DeparturesXMLTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            string lang = string.Empty; // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.DeparturesXML(lang, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Liveboard
        ///</summary>
        [TestMethod()]
        public void LiveboardTest()
        {
            NMBS target = new NMBS(); // TODO: Initialize to an appropriate value
            string stationName = string.Empty; // TODO: Initialize to an appropriate value
            IList<Departure> expected = null; // TODO: Initialize to an appropriate value
            IList<Departure> actual;
            actual = target.Liveboard(stationName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Liveboard
        ///</summary>
        [TestMethod()]
        public void LiveboardTest1()
        {
            NMBS target = new NMBS(); // TODO: Initialize to an appropriate value
            Station station = null; // TODO: Initialize to an appropriate value
            IList<Departure> expected = null; // TODO: Initialize to an appropriate value
            IList<Departure> actual;
            actual = target.Liveboard(station);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Stations
        ///</summary>
        [TestMethod()]
        public void StationsTest()
        {
            NMBS target = new NMBS(); // TODO: Initialize to an appropriate value
            IList<Station> expected = null; // TODO: Initialize to an appropriate value
            IList<Station> actual;
            actual = target.Stations();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StationsXML
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void StationsXMLTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            string lang = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.StationsXML(lang);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Vehicle
        ///</summary>
        [TestMethod()]
        public void VehicleTest()
        {
            NMBS target = new NMBS(); // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            Vehicle expected = null; // TODO: Initialize to an appropriate value
            Vehicle actual;
            actual = target.Vehicle(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VehicleXML
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void VehicleXMLTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            string lang = string.Empty; // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.VehicleXML(lang, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _Liveboard
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void _LiveboardTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            string stationId = string.Empty; // TODO: Initialize to an appropriate value
            IList<Departure> expected = null; // TODO: Initialize to an appropriate value
            IList<Departure> actual;
            actual = target._Liveboard(stationId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _parseConnections
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void _parseConnectionsTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            XDocument documentToParse = null; // TODO: Initialize to an appropriate value
            IList<Connection> expected = null; // TODO: Initialize to an appropriate value
            IList<Connection> actual;
            actual = target._parseConnections(documentToParse);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for parseVias
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void parseViasTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            XElement viasElement = null; // TODO: Initialize to an appropriate value
            IList<Via> expected = null; // TODO: Initialize to an appropriate value
            IList<Via> actual;
            actual = target.parseVias(viasElement);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Language
        ///</summary>
        [TestMethod()]
        [DeploymentItem("NetRail.dll")]
        public void LanguageTest()
        {
            NMBS_Accessor target = new NMBS_Accessor(); // TODO: Initialize to an appropriate value
            NMBSLanguage expected = new NMBSLanguage(); // TODO: Initialize to an appropriate value
            NMBSLanguage actual;
            target.Language = expected;
            actual = target.Language;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
