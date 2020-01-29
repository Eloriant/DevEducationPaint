﻿using DevEducationPaint.Thicknesses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using DevEducationPaint.FigureCreators;

namespace DevEducationPaint.Tests
{
    [TestFixture]
    class TriangleCreatorTests
    {
        public Point GetPointByName(string pointName)
        {
            switch (pointName)
            {
                case "pointStart":
                    return new Point(2, 4);
                case "pointEnd":
                    return new Point(4, 2);
                case "expectedPoint":
                    return new Point(5, 5);
                case "pointStart1":
                    return new Point(6, 5);
                case "pointEnd1":
                    return new Point(9, 6);
                case "expectedPoint1":
                    return new Point(7, 8);
                //case "pointEnd2":
                //    return new Point(2, 21);
                default:
                    return new Point();
            }
        }

        public TriangleFigure GetTriangleByName(string name)
        {
            switch (name)
            {
                case "expectedTriangle":
                    return new TriangleFigure(
                        new List<Point>
                        {
                            new Point(14,15),
                            new Point(16,13)
                        }
                    );
                case "expectedTriangle1":
                    return new TriangleFigure(
                        new List<Point>
                        {
                            new Point(18,5),
                            new Point(2,21)
                        }
                    );
                default:
                    return new TriangleFigure(new List<Point>());
            }
        }

        [TestCase("pointStart", "pointEnd", "expectedPoint")]
        public void GetPointHighTest(string pointStart, string pointEnd, string expectedPoint)
        {
            TriangleCreator triangleCreator = new TriangleCreator();
            Point start = GetPointByName("pointStart");
            Point end = GetPointByName("pointEnd");
            Point expected = GetPointByName(expectedPoint);
            Point actual = triangleCreator.GetPointHigh(start, end);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("pointStart1", "pointEnd1", "expectedPoint1")]
        public void GetPointHighTest1(string pointStart1, string pointEnd1, string expectedPoint1)
        {
            TriangleCreator triangleCreator = new TriangleCreator();
            Point start = GetPointByName("pointStart1");
            Point end = GetPointByName("pointEnd1");
            Point expected = GetPointByName(expectedPoint1);
            Point actual = triangleCreator.GetPointHigh(start, end);
            Assert.AreEqual(expected, actual);
        }
    }
}
