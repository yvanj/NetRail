using NetRail.NMBS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NetRailUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ConnectionTest and is intended
    ///to contain all ConnectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConnectionTest
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
        ///A test for Connection Constructor
        ///</summary>
        [TestMethod()]
        public void ConnectionConstructorTest()
        {
            Connection target = new Connection();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ArrivalPlatform
        ///</summary>
        [TestMethod()]
        public void ArrivalPlatformTest()
        {
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
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
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.ArrivalPlatformChanged = expected;
            actual = target.ArrivalPlatformChanged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ArrivalStation
        ///</summary>
        [TestMethod()]
        public void ArrivalStationTest()
        {
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
            Station expected = null; // TODO: Initialize to an appropriate value
            Station actual;
            target.ArrivalStation = expected;
            actual = target.ArrivalStation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ArrivalTime
        ///</summary>
        [TestMethod()]
        public void ArrivalTimeTest()
        {
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
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
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
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
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.DeparturePlatformChanged = expected;
            actual = target.DeparturePlatformChanged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DepartureStation
        ///</summary>
        [TestMethod()]
        public void DepartureStationTest()
        {
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
            Station expected = null; // TODO: Initialize to an appropriate value
            Station actual;
            target.DepartureStation = expected;
            actual = target.DepartureStation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DepartureTime
        ///</summary>
        [TestMethod()]
        public void DepartureTimeTest()
        {
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.DepartureTime = expected;
            actual = target.DepartureTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Duration
        ///</summary>
        [TestMethod()]
        public void DurationTest()
        {
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Duration = expected;
            actual = target.Duration;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Vias
        ///</summary>
        [TestMethod()]
        public void ViasTest()
        {
            Connection target = new Connection(); // TODO: Initialize to an appropriate value
            IList<Via> expected = null; // TODO: Initialize to an appropriate value
            IList<Via> actual;
            target.Vias = expected;
            actual = target.Vias;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
