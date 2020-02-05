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
    class BrokenLineCreatorTests
    {
        public Point GetPointByName(string pointName)
        {
            switch (pointName)
            {
                case "pointStart1":
                    return new Point(14, 15);
                case "pointEnd1":
                    return new Point(16, 13);
                case "pointStart2":
                    return new Point(18, 5);
                case "pointEnd2":
                    return new Point(2, 21);
                default:
                    return new Point();
            }
        }

        public BrokenLineFigure GetLineByName(string name)
        {
            switch (name)
            {
                case "expectedLine":
                    return new BrokenLineFigure(
                        new List<Point>
                        {
                            new Point(14,15),
                            new Point(16,13)
                        }
                    );
                case "expectedLine1":
                    return new BrokenLineFigure(
                        new List<Point>
                        {
                            new Point(18,5),
                            new Point(2,21)
                        }
                    );
                default:
                    return new BrokenLineFigure(new List<Point>());
            }
        }

        [TestCase("pointStart1", "pointEnd1", "expectedLine")]
        public void LineCreateTest(string pointStart1, string pointEnd1, string expectedLine)
        {
            BrokenLineCreator lineCreator = new BrokenLineCreator();
            BrokenLineFigure expected = GetLineByName(expectedLine);
            Point start = GetPointByName(pointStart1);
            Point end = GetPointByName(pointEnd1);
            Figure actual = lineCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }

        [TestCase("pointStart2", "pointEnd2", "expectedLine1")]
        public void LineCreateTest1(string pointStart2, string pointEnd2, string expectedLine1)
        {
            LineCreator lineCreator = new LineCreator();
            BrokenLineFigure expected = GetLineByName(expectedLine1);
            Point start = GetPointByName(pointStart2);
            Point end = GetPointByName(pointEnd2);
            Figure actual = lineCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }
    }
}
