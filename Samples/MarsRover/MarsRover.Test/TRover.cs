using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRover.Test
{
    /// <summary>
    ///This is a test class for TRover and is intended
    ///to contain all TRover Unit Tests
    ///</summary>
    [TestClass()]
    public class TRover
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
        ///A test for Rover Constructor
        ///</summary>
        [TestMethod()]
        public void TRoverConstructor()
        {
            MarsRover.Plateau plateau = Plateau.FormSize(5, 5);
            string baseLocation = "1 2 N";
            string name = "rover1";
            MarsRover.Rover target = new MarsRover.Rover(plateau, baseLocation, name);
            Assert.AreEqual(target.BaseLocation.ToString(), baseLocation);
        }

        /// <summary>
        ///A test for Rover Constructor
        ///</summary>
        [TestMethod()]
        public void TRoverConstructor2()
        {
            try
            {
                MarsRover.Plateau plateau = Plateau.FormSize(5, 5);
                string baseLocation = "1 2 D";
                string name = "rover1";
                MarsRover.Rover target = new MarsRover.Rover(plateau, baseLocation, name);
                Assert.AreEqual(target.BaseLocation.ToString(), baseLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///A test for Rover Constructor
        ///</summary>
        [TestMethod()]
        public void TRoverConstructor3()
        {
            try
            {
                MarsRover.Plateau plateau = Plateau.FormSize(5, 5);
                string baseLocation = "1 2 D F";
                string name = "rover1";
                MarsRover.Rover target = new MarsRover.Rover(plateau, baseLocation, name);
                Assert.AreEqual(target.BaseLocation.ToString(), baseLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///A test for Move
        ///</summary>
        [TestMethod()]
        public void TMove()
        {
            try
            {
                MarsRover.Plateau plateau = Plateau.FormSize(5, 6);
                string baseLocation = string.Empty;
                string name = string.Empty;
                MarsRover.Rover target = new MarsRover.Rover(plateau, baseLocation, name); // TODO: Initialize to an appropriate value
                string movements = string.Empty; // TODO: Initialize to an appropriate value
                target.Move(movements);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///A test for Move
        ///</summary>
        [TestMethod()]
        public void TMove1()
        {
            try
            {
                MarsRover.Plateau plateau = Plateau.FormSize(5, 6);
                string baseLocation = "1 1 N";
                string name = "rover1";
                MarsRover.Rover target = new MarsRover.Rover(plateau, baseLocation, name);
                string movements = "LMLM";
                target.Move(movements);
                Assert.IsTrue(target.CurrentLocation != target.BaseLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///A test for Move
        ///</summary>
        [TestMethod()]
        public void TMove2()
        {
            try
            {
                MarsRover.Plateau plateau = Plateau.FormSize(5, 6);
                string baseLocation = "0 1 N";
                string name = "rover1";
                MarsRover.Rover target = new MarsRover.Rover(plateau, baseLocation, name);
                string movements = "LMLM";
                target.Move(movements);
                Assert.IsTrue(target.CurrentLocation != target.BaseLocation);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}