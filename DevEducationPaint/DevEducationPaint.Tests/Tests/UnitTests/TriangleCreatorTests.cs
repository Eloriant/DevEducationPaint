using DevEducationPaint.Thicknesses;
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
                case "pointStart2":
                    return new Point(373, 303);
                case "pointEnd2":
                    return new Point(373, 302);
                case "pointStart3":
                    return new Point(100, 200);
                case "pointEnd3":
                    return new Point(150, 250);
                case "pointStart4":
                    return new Point(389, 194);
                case "pointEnd4":
                    return new Point(390, 196);
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
                case "expectedTriangle2":
                    return new TriangleFigure(
                        new List<Point>
                        {
                            new Point(373, 303),
                            new Point(373, 302),
                            new Point(373, 302)
                        }
                    );
                case "expectedTriangle3":
                    return new TriangleFigure(
                        new List<Point>
                        {
                            new Point(100, 200),
                            new Point(150, 250),
                            new Point(50, 250)
                        }
                    );
                case "expectedTriangle4":
                    return new TriangleFigure(
                        new List<Point>
                        {
                            new Point(389, 194),
                            new Point(390, 196),
                            new Point(388, 196)
                        }
                    );
                default:
                    return new TriangleFigure(new List<Point>());
            }
        }

        [TestCase("pointStart", "pointEnd", "expectedPoint", false, false)]
        public void GetPointHighTest(string pointStart, string pointEnd, string expectedPoint,bool isShiftPressed, bool isCtrlPressed)
        {
            TriangleCreator triangleCreator = new TriangleCreator(false, false);
            Point start = GetPointByName(pointStart);
            Point end = GetPointByName(pointEnd);
            Point expected = GetPointByName(expectedPoint);
            Point actual = triangleCreator.GetPointHigh(start, end);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("pointStart1", "pointEnd1", "expectedPoint1")]
        public void GetPointHighTest1(string pointStart1, string pointEnd1, string expectedPoint1)
        {
            TriangleCreator triangleCreator = new TriangleCreator(false, false);
            Point start = GetPointByName(pointStart1);
            Point end = GetPointByName(pointEnd1);
            Point expected = GetPointByName(expectedPoint1);
            Point actual = triangleCreator.GetPointHigh(start, end);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("pointStart4", "pointEnd4", "expectedTriangle4")] // равносторонний треугольник
        public void GetListOfPoints2(string pointStart4, string pointEnd4, string expectedTriangle4)
        {
            TriangleCreator triangleCreator = new TriangleCreator(false, false);
            TriangleFigure expected = GetTriangleByName(expectedTriangle4);
            Point start = GetPointByName(pointStart4);
            Point end = GetPointByName(pointEnd4);
            Figure actual = triangleCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }


        [TestCase("pointStart2", "pointEnd2", "expectedTriangle2")] // прямоугольный треугольник
        public void GetListOfPoints(string pointStart2, string pointEnd2, string expectedTriangle2)
        {
            TriangleCreator triangleCreator = new TriangleCreator(true, false);
            TriangleFigure expected = GetTriangleByName(expectedTriangle2);
            Point start = GetPointByName(pointStart2);
            Point end = GetPointByName(pointEnd2);
            Figure actual = triangleCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }

        [TestCase("pointStart3", "pointEnd3", "expectedTriangle3")] // равнобедренный треугольник
        public void GetListOfPoints1(string pointStart3, string pointEnd3, string expectedTriangle3)
        {
            TriangleCreator triangleCreator = new TriangleCreator(false, true);
            TriangleFigure expected = GetTriangleByName(expectedTriangle3);
            Point start = GetPointByName(pointStart3);
            Point end = GetPointByName(pointEnd3);
            Figure actual = triangleCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }
    }
}
