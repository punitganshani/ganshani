using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.Test
{


    /// <summary>
    ///This is a test class for TPlateau and is intended
    ///to contain all TPlateau Unit Tests
    ///</summary>
    [TestClass()]
    public class TPlateau
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
        ///A test for Contains. Coodinates out of bounds.
        ///</summary>
        [TestMethod()]
        public void TContains()
        {
            Plateau plateau = Plateau.FormSize(2, 2);
            MarsRover.Point point = new Point(5, 5);
            bool expected = false;
            bool actual;
            actual = MarsRover.Plateau.Contains(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Contains. Both coordinates in bounds
        ///</summary>
        [TestMethod()]
        public void TContains1()
        {
            Plateau plateau = Plateau.FormSize(2, 2);
            MarsRover.Point point = new Point(1, 1);
            bool expected = true;
            bool actual;
            actual = MarsRover.Plateau.Contains(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Contains. Both coordinates in bounds
        ///</summary>
        [TestMethod()]
        public void TContains2()
        {
            Plateau plateau = Plateau.FormSize(2, 2);
            MarsRover.Point point = new Point(2, 2);
            bool expected = true;
            bool actual;
            actual = MarsRover.Plateau.Contains(point);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Contains. Both coordinates in bounds.
        ///</summary>
        [TestMethod()]
        public void TContains3()
        {
            Plateau plateau = Plateau.FormSize(2, 2);
            int x = 2;  
            int y = 2;  
            bool expected = true;  
            bool actual;
            actual = MarsRover.Plateau.Contains(x, y);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Contains. X is out of bounds
        ///</summary>
        [TestMethod()]
        public void TContains4()
        {
            Plateau plateau = Plateau.FormSize(2, 2);
            int x = 5;
            int y = 2;
            bool expected = false;
            bool actual;
            actual = MarsRover.Plateau.Contains(x, y);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Contains. Y is out of bounds
        ///</summary>
        [TestMethod()]
        public void TContains5()
        {
            Plateau plateau = Plateau.FormSize(2, 2);
            int x = 2;
            int y = 5;
            bool expected = false;
            bool actual;
            actual = MarsRover.Plateau.Contains(x, y);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Contains. X is -ve
        ///</summary>
        [TestMethod()]
        public void TContains6()
        {
            Plateau plateau = Plateau.FormSize(2, 2);
            int x = -1;
            int y = 2;
            bool expected = false;
            bool actual;
            actual = MarsRover.Plateau.Contains(x, y);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Constructor.
        /// </summary>
        [TestMethod()]
        public void TPlateauConstructor()
        {
            try
            {
                Plateau plateau = Plateau.FormSize(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        /// <summary>
        /// A test for Constructor.
        /// </summary>
        [TestMethod()]
        public void TPlateauConstructor1()
        {
            try
            {
                Plateau plateau = Plateau.FormSize(-1, -2);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
