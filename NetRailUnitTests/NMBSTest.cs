using NetRail.NMBS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;
using NetRail;
using System.Linq;

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
        /// Tests if a list of stations can be fetched in every language.
        ///</summary>
        [TestMethod()]
        public void StationsTestInEveryLanguage()
        {
            int first_amount = 0;
            NMBS target = new NMBS(NMBSLanguage.DE);
            first_amount = target.Stations().Count;
            Assert.IsFalse( first_amount < 1, "No stations could be fetched");

            target = new NMBS(NMBSLanguage.EN);
            Assert.IsTrue(target.Stations().Count == first_amount, "EN list of stations behaves odd");
            target = new NMBS(NMBSLanguage.FR);
            Assert.IsTrue(target.Stations().Count == first_amount, "FR list of stations behaves odd");
            target = new NMBS(NMBSLanguage.NL);
            Assert.IsTrue(target.Stations().Count == first_amount, "NL list of stations behaves odd");

        }

        /// <summary>
        /// Tests the functionality of the Connections handler.
        /// It simulates four queries with random data.
        ///</summary>
        [TestMethod()]
        public void ConnectionsTest()
        {
            NMBS target = new NMBS();
            Random r = new Random();

            for (int i = 0; i < 4; i++)
            {
                Station fromStation = target.Stations().ElementAt(r.Next(target.Stations().Count));
                Station destinationStation = target.Stations().ElementAt(r.Next(target.Stations().Count));
                IList<Connection> actual;
                actual = target.Connections(fromStation, destinationStation);
                
            }
        }

        /// <summary>
        /// Tests for arriving/departing tomorrow around 12 between two random stations.
        ///</summary>
        [TestMethod()]
        public void ConnectionsTest1()
        {
            NMBS target = new NMBS();
            Random r = new Random();
            Station fromStation = target.Stations().ElementAt(r.Next(target.Stations().Count));
            Station destinationStation = target.Stations().ElementAt(r.Next(target.Stations().Count));
            NMBSTimeSelection timeType = NMBSTimeSelection.DepartureTime; 
            DateTime moment = DateTime.Now.AddDays(1);
            IList<Connection> actual;
            actual = target.Connections(fromStation, destinationStation, timeType, moment);
            Assert.IsTrue(actual.Count > 0,String.Format("Departing at {0} from {1} to {2} failed.", moment, fromStation.Name, destinationStation.Name));
            timeType = NMBSTimeSelection.DepartureTime;
            actual = target.Connections(fromStation, destinationStation, timeType, moment);
            Assert.IsTrue(actual.Count > 0, String.Format( "Arriving at {0} from {1} to {2} failed.", moment, fromStation.Name, destinationStation.Name));
        }

        /// <summary>
        ///  Tests the basic functionality of the Liveboard.
        ///</summary>
        [TestMethod()]
        public void LiveboardTest()
        {
            NMBS target = new NMBS();
            Random r = new Random();
            Station station = target.Stations().ElementAt(r.Next(target.Stations().Count));
             
            IList<Departure> actual;
            actual = target.Liveboard(station);
            Assert.IsNull(actual, "Failed to fetch a liveboard for " + station.Name);
           
        }


      
    }
}
