using DevEducationPaint.Thicknesses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using DevEducationPaint.FigureCreators;
using DevEducationPaint.Share;


namespace DevEducationPaint.Tests
{
    [TestFixture]
    class FindQuarterTests
    {   
        
        public Point GetPointByName(string pointName)
        {
            switch (pointName)
            {
                case "pointStart":
                    return new Point(14, 15);
                case "pointEnd":
                    return new Point(16, 13);
                case "pointStart1":
                    return new Point(271, 173);
                case "pointEnd1":
                    return new Point(263, 177);
                case "pointStart2":
                    return new Point(300, 200);
                case "pointEnd2":
                    return new Point(245, 115);
                case "pointStart3":
                    return new Point(220, 311);
                case "pointEnd3":
                    return new Point(250, 400);
                default:
                    return new Point();
            }
        }

        public int GetQuarterByName(string name)
        {
            switch (name)
            {
                case "expectedQuarter":
                    return 1;
                case "expectedQuarter1":
                    return 3;
                case "expectedQuarter2":
                    return 2;
                case "expectedQuarter3":
                    return 4;
                default:
                    return -1;
            }
        }

        [TestCase("pointStart", "pointEnd", "expectedQuarter")]
        public void GetQuarter(string pointStart, string pointEnd, string expectedQuarter)
        {
            Point start = GetPointByName(pointStart);
            Point end = GetPointByName(pointEnd);
            int expected = GetQuarterByName(expectedQuarter);
            int actual = Quarter.FindQuarter(start, end);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("pointStart1", "pointEnd1", "expectedQuarter1")]
        public void GetQuarter1(string pointStart1, string pointEnd1, string expectedQuarter)
        {
            Point start = GetPointByName(pointStart1);
            Point end = GetPointByName(pointEnd1);
            int expected = GetQuarterByName(expectedQuarter);
            int actual = Quarter.FindQuarter(start, end);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("pointStart2", "pointEnd2", "expectedQuarter2")]
        public void GetQuarter2(string pointStart2, string pointEnd2, string expectedQuarter)
        {
            Point start = GetPointByName(pointStart2);
            Point end = GetPointByName(pointEnd2);
            int expected = GetQuarterByName(expectedQuarter);
            int actual = Quarter.FindQuarter(start, end);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("pointStart3", "pointEnd3", "expectedQuarter3")]
        public void GetQuarter3(string pointStart3, string pointEnd3, string expectedQuarter)
        {
            Point start = GetPointByName(pointStart3);
            Point end = GetPointByName(pointEnd3);
            int expected = GetQuarterByName(expectedQuarter);
            int actual = Quarter.FindQuarter(start, end);
            Assert.AreEqual(expected, actual);
        }

    }
}
