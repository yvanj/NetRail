using NetRail.NMBS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetRailUnitTests
{
    
    
    /// <summary>
    ///This is a test class for DepartureTest and is intended
    ///to contain all DepartureTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DepartureTest
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
        ///A test for Departure Constructor
        ///</summary>
        [TestMethod()]
        public void DepartureConstructorTest()
        {
            Departure target = new Departure();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Delay
        ///</summary>
        [TestMethod()]
        public void DelayTest()
        {
            Departure target = new Departure(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Delay = expected;
            actual = target.Delay;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Direction
        ///</summary>
        [TestMethod()]
        public void DirectionTest()
        {
            Departure target = new Departure(); // TODO: Initialize to an appropriate value
            Station expected = null; // TODO: Initialize to an appropriate value
            Station actual;
            target.Direction = expected;
            actual = target.Direction;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Platform
        ///</summary>
        [TestMethod()]
        public void PlatformTest()
        {
            Departure target = new Departure(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Platform = expected;
            actual = target.Platform;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PlatformChanged
        ///</summary>
        [TestMethod()]
        public void PlatformChangedTest()
        {
            Departure target = new Departure(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.PlatformChanged = expected;
            actual = target.PlatformChanged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            Departure target = new Departure(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.Time = expected;
            actual = target.Time;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Vehicle
        ///</summary>
        [TestMethod()]
        public void VehicleTest()
        {
            Departure target = new Departure(); // TODO: Initialize to an appropriate value
            Vehicle expected = null; // TODO: Initialize to an appropriate value
            Vehicle actual;
            target.Vehicle = expected;
            actual = target.Vehicle;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
