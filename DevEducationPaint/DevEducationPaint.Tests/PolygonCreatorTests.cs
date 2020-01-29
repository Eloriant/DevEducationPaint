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
    public class PolygonCreatorTests
    {
        public List<Point> GetListPointByName(string name)
        {
            switch (name)
            {
                case "expectedList":
                    return new List<Point>//тут надо посчитать под точку 0;6
                    {
                            new Point(0,6),
                            new Point(-5,3),
                            new Point(-5,-3),
                            new Point(0,-6),
                            new Point(5,-3),
                            new Point(5,3)
                    };
                case "listWithShiftExpected":
                    return new List<Point>//тут надо посчитать под точку 0;6
                    {
                            new Point(5,0),
                            new Point(0,3),
                            new Point(0,9),
                            new Point(5,12),
                            new Point(10,9),
                            new Point(10,3)
                    };
                default:
                    return new List<Point> { };
            }
        }
        public Point GetPointByName(string pointName)
        {
            switch (pointName)
            {
                case "pointStart1":
                    return new Point(5, 12);
                case "pointEnd1":
                    return new Point(10, 0);
                case "polygonsTop":
                    return new Point(0, 6);
                default:
                    return new Point();
            }
        }

        public PolygonFigure GetPolygonByName(string name)
        {
            switch (name)
            {
                case "expectedPolygon":
                    return new PolygonFigure(
                        new List<Point>
                        {
                            new Point(5,0),
                            new Point(0,3),
                            new Point(0,9),
                            new Point(5,12),
                            new Point(10,9),
                            new Point(10,3)
                        }
                    );
                default:
                    return new PolygonFigure(new List<Point>());
            }
        }

        [TestCase("pointStart1", "pointEnd1", 12)]
        public void GetFigureDiametrTest(string pointStart1, string pointEnd1, int expected)
        {
            PolygonCreator polygonCreator = new PolygonCreator(6);
            Point start = GetPointByName("pointStart1");
            Point end = GetPointByName("pointEnd1");
            int actual = polygonCreator.GetFigureDiametr(start, end);
            Assert.AreEqual(expected, actual);
        }


        [TestCase((2 * Math.PI / 6), 6, "polygonsTop", "expectedList")]
        public void GetPointsByAngleTest(double angle, int angleNumber, string polygonsTop, string expectedList)
        {
            PolygonCreator polygonCreator = new PolygonCreator(6);
            Point polygonTop = GetPointByName("polygonsTop");
            List<Point> circuitsPoints = polygonCreator.GetPointsByAngle(angle, angleNumber, polygonTop);
            List<Point> circuitsPointsExpected = GetListPointByName(expectedList);
            CollectionAssert.AreEqual(circuitsPointsExpected, circuitsPoints);
        }

        [TestCase("expectedList", "pointStart1", "listWithShiftExpected")]
        public void GetPointsWithShiftTest(string expectedList, string pointStart1, string listWithShiftExpected)
        {
            PolygonCreator polygonCreator = new PolygonCreator(6);
            List<Point> circuitsPoints = GetListPointByName(expectedList);
            Point start = GetPointByName("pointStart1");
            List<Point> listExpected = GetListPointByName(listWithShiftExpected);
            List<Point> list = polygonCreator.GetPointsWithShift(circuitsPoints, start);
            CollectionAssert.AreEqual(listExpected, list);
        }

        [TestCase("pointStart1", "pointEnd1", "expectedPolygon")]
        public void PolygonCreateTest(string pointStart1, string pointEnd1, string expectedPolygon)
        {
            PolygonCreator polygonCreator = new PolygonCreator(6);
            PolygonFigure expected = GetPolygonByName(expectedPolygon);
            Point start = GetPointByName("pointStart1");
            Point end = GetPointByName("pointEnd1");
            Figure actual = polygonCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }


    }
}