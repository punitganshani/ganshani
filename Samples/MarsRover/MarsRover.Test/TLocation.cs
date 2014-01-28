using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.Test
{
    /// <summary>
    ///This is a test class for TLocation and is intended
    ///to contain all TLocation Unit Tests
    ///</summary>
    [TestClass()]
    public class TLocation
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

        /// <summary>
        ///A test for Location Constructor
        ///</summary>
        [TestMethod()]
        public void TLocationConstructor()
        {
            MarsRover.Point point = new Point(2, 3);
            MarsRover.Direction direction = Direction.E;
            MarsRover.Location target = new MarsRover.Location(point, direction);
            Assert.AreEqual(target.ToString(), "2 3 E");
        }

        /// <summary>
        ///A test for Location Constructor. Check for Null value for point
        ///</summary>
        [TestMethod()]
        public void TLocationConstructor1()
        {
            try
            {
                MarsRover.Point point = null;
                MarsRover.Direction direction = Direction.E;
                MarsRover.Location target = new MarsRover.Location(point, direction);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///A test for Location Constructor. Check for Default value of Direction = N
        ///</summary>
        [TestMethod()]
        public void TLocationConstructor2()
        {
            MarsRover.Point point = new Point(2,2);
            MarsRover.Location target = new MarsRover.Location(point);
            Assert.AreEqual(target.ToString(), "2 2 N");
        }

        /// <summary>
        ///A test for Location Constructor. Negative values in Location.
        ///</summary>
        [TestMethod()]
        public void TLocationConstructor3()
        {
            try
            {
                MarsRover.Point point = new Point(-1, -1);
                MarsRover.Location target = new MarsRover.Location(point);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///A test for GetLocation
        ///</summary>
        [TestMethod()]
        public void TGetLocation()
        {
            string directionInput = "1 2 E";  
            MarsRover.Location expected = new Location(new Point(1, 2), Direction.E);  
            MarsRover.Location actual;
            actual = MarsRover.Location.GetLocation(directionInput);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        /// <summary>
        ///A test for GetLocation
        ///</summary>
        [TestMethod()]
        public void TGetLocation2()
        {
            try
            {
                string directionInput = string.Empty;
                MarsRover.Location expected = new Location(new Point(1, 2), Direction.E);
                MarsRover.Location actual;
                actual = MarsRover.Location.GetLocation(directionInput);
                Assert.AreEqual(expected.ToString(), actual.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
