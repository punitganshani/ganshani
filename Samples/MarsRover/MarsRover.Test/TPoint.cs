using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.Test
{
    
    
    /// <summary>
    ///This is a test class for TPoint and is intended
    ///to contain all TPoint Unit Tests
    ///</summary>
    [TestClass()]
    public class TPoint
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
        ///A test for IsWithinArea. Lower boundary check
        ///</summary>
        [TestMethod()]
        public void TIsWithinArea()
        {
            MarsRover.Point target = new MarsRover.Point(5, 5);  
            bool expected = true;  
            bool actual;
            actual = target.IsWithinArea(0, 0);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsWithinArea. Upper boundary check
        ///</summary>
        [TestMethod()]
        public void TIsWithinArea1()
        {
            MarsRover.Point target = new MarsRover.Point(5, 5);
            bool expected = true;
            bool actual;
            actual = target.IsWithinArea(5, 5);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsWithinArea. Negative check
        ///</summary>
        [TestMethod()]
        public void TIsWithinArea2()
        {
            MarsRover.Point target = new MarsRover.Point(5, 5);
            bool expected = false;
            bool actual;
            actual = target.IsWithinArea(-1, 5);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for IsWithinArea. Within range check
        ///</summary>
        [TestMethod()]
        public void TIsWithinArea3()
        {
            MarsRover.Point target = new MarsRover.Point(5, 5);
            bool expected = true;
            bool actual;
            actual = target.IsWithinArea(1, 2);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsWithinArea. Out of bound check
        ///</summary>
        [TestMethod()]
        public void TIsWithinArea4()
        {
            MarsRover.Point target = new MarsRover.Point(5, 5);
            bool expected = false;
            bool actual;
            actual = target.IsWithinArea(6, 2);
            Assert.AreEqual(expected, actual);
        }
    }
}
