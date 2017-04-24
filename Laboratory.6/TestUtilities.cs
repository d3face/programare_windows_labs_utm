using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory._6
{
    [TestClass]
    public class TestUtilitiesByHour
    {
        private const int radius = 200;

        [TestMethod]
        public void Should_Return_0_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(0, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(0, radius), p);
        }
        [TestMethod]
        public void Should_Return_3_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(3, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(radius, 0), p);
        }
        [TestMethod]
        public void Should_Return_15_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(15, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(radius, 0), p);
        }
        [TestMethod]
        public void Should_Return_12_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(12, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(0, radius), p);
        }
        [TestMethod]
        public void Should_Return_6_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(6, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(0, -radius), p);
        }
        [TestMethod]
        public void Should_Return_18_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(18, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(0, -radius), p);
        }
        [TestMethod]
        public void Should_Return_9_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(9, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(-radius, 0), p);
        }
        [TestMethod]
        public void Should_Return_21_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(21, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(-radius, 0), p);
        }
        [TestMethod]
        public void Should_Return_24_Value_From_Hour()
        {
            var p = Utilities.GetPointFromNumber(24, radius, R.H);
            Assert.AreEqual(new System.Drawing.Point(0, radius), p);
        }
    }
    [TestClass]
    public class TestUtilitiesByMinute
    {
        private const int radius = 200;

        [TestMethod]
        public void Should_Return_0_Value_From_Minutes()
        {
            var p = Utilities.GetPointFromNumber(0, radius, R.M);
            Assert.AreEqual(new System.Drawing.Point(0, radius), p);
        }
    }
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class TestUtilities
    {
        private const int radius = 200;

        [TestMethod]
        public void Should_Return_0_Value()
        {
            var p = Utilities.GetPointFromNumber(0, radius);
            Assert.AreEqual(new System.Drawing.Point(0, radius), p);
        }
        [TestMethod]
        public void Should_Return_10_Value()
        {
            var p = Utilities.GetPointFromNumber(10, radius);

            Assert.AreEqual(new System.Drawing.Point(173, 100), p);
        }
        [TestMethod]
        public void Should_Return_15_Value()
        {
            var p = Utilities.GetPointFromNumber(15, radius);
            Assert.AreEqual(new System.Drawing.Point(radius, 0), p);
        }
        [TestMethod]
        public void Should_Return_30_Value()
        {
            var p = Utilities.GetPointFromNumber(30, radius);
            Assert.AreEqual(new System.Drawing.Point(0, -radius), p);
        }
        [TestMethod]
        public void Should_Return_45_Value()
        {
            var p = Utilities.GetPointFromNumber(45, radius);
            Assert.AreEqual(new System.Drawing.Point(-radius, 0), p);
        }
        [TestMethod]
        public void Should_Return_60_Value()
        {
            var p = Utilities.GetPointFromNumber(60, radius);
            Assert.AreEqual(new System.Drawing.Point(0, radius), p);
        }
    }
}
