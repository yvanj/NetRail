using NetRail.NMBS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetRailUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ViaTest and is intended
    ///to contain all ViaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ViaTest
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
        ///A test for Via Constructor
        ///</summary>
        [TestMethod()]
        public void ViaConstructorTest()
        {
            Via target = new Via();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ArrivalPlatform
        ///</summary>
        [TestMethod()]
        public void ArrivalPlatformTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.ArrivalPlatform = expected;
            actual = target.ArrivalPlatform;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ArrivalPlatformChanged
        ///</summary>
        [TestMethod()]
        public void ArrivalPlatformChangedTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ArrivalPlatformChanged = expected;
            actual = target.ArrivalPlatformChanged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ArrivalTime
        ///</summary>
        [TestMethod()]
        public void ArrivalTimeTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.ArrivalTime = expected;
            actual = target.ArrivalTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeparturePlatform
        ///</summary>
        [TestMethod()]
        public void DeparturePlatformTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.DeparturePlatform = expected;
            actual = target.DeparturePlatform;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeparturePlatformChanged
        ///</summary>
        [TestMethod()]
        public void DeparturePlatformChangedTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.DeparturePlatformChanged = expected;
            actual = target.DeparturePlatformChanged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DepartureTime
        ///</summary>
        [TestMethod()]
        public void DepartureTimeTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.DepartureTime = expected;
            actual = target.DepartureTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DestinationStation
        ///</summary>
        [TestMethod()]
        public void DestinationStationTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            Station expected = null; // TODO: Initialize to an appropriate value
            Station actual;
            target.DestinationStation = expected;
            actual = target.DestinationStation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Station
        ///</summary>
        [TestMethod()]
        public void StationTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            Station expected = null; // TODO: Initialize to an appropriate value
            Station actual;
            target.Station = expected;
            actual = target.Station;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TimeBetween
        ///</summary>
        [TestMethod()]
        public void TimeBetweenTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.TimeBetween = expected;
            actual = target.TimeBetween;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VehicleUsed
        ///</summary>
        [TestMethod()]
        public void VehicleUsedTest()
        {
            Via target = new Via(); // TODO: Initialize to an appropriate value
            Vehicle expected = null; // TODO: Initialize to an appropriate value
            Vehicle actual;
            target.VehicleUsed = expected;
            actual = target.VehicleUsed;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
