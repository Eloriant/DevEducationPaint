using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using DevEducationPaint.FigureCreators;
using DevEducationPaint.Thicknesses;
using NUnit.Framework;

namespace DevEducationPaint.Tests
{
    [TestFixture]
    class ThicknessTests
    {
        public Point GetPointByName(string pointName)
        {
            switch (pointName)
            {
                case "pointStart1":
                    return new Point(152, 221);
                case "pointStart2":
                    return new Point(269, 164);
                case "pointStart3":
                    return new Point(256, 152);
                default:
                    return new Point();
            }
        }

        public List<Point> GetLineByName(string name)
        {
            switch (name)
            {
                case "expectedList1":
                    return
                        new List<Point>
                        {
                            new Point(152, 221),
                            new Point(152, 222),
                            new Point(152, 220),
                            new Point(153, 221),
                            new Point(151, 221),
                

                        };
                case "expectedList2":
                    return 
                        new List<Point>
                        {
                            new Point(269, 164),
                            new Point(269, 163),
                            new Point(269, 165),
                            new Point(270, 164),
                            new Point(268, 164),
                            new Point(270, 165),
                            new Point(270, 163),
                            new Point(268, 165),
                            new Point(268, 163),
                            new Point(269, 162),
                            new Point(269, 166),
                            new Point(271, 164),
                            new Point(267, 164)
                        };
                case "expectedList3":
                    return
                        new List<Point>
                        {
                            new Point(256, 152),
                            new Point(256, 153),
                            new Point(256, 151),
                            new Point(257, 152),
                            new Point(255, 152),
                            new Point(257, 153),
                            new Point(257, 151),
                            new Point(255, 151),
                            new Point(256, 150),
                            new Point(256, 154),
                            new Point(254, 152),
                            new Point(258, 152),
                            new Point(255, 150),
                            new Point(254, 151),
                            new Point(257, 150),
                            new Point(258, 151),
                            new Point(258, 153),
                            new Point(257, 154),
                            new Point(255, 154),
                            new Point(254, 153)
                        };
                default:
                    return new List<Point>();
            }
        }

        [TestCase("pointStart1", "expectedList1")]
        public void GetlistTest(string pointStart1, string expectedList1)
        {
            MediumThickness lineCreator = new MediumThickness();
            List<Point> expected = GetLineByName(expectedList1);
            Point start = GetPointByName(pointStart1);
            List<Point> actual = lineCreator.GetPoints(start);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("pointStart2", "expectedList2")]
        public void GetlistTest2(string pointStart2, string expectedList2)
        {
            BoldThickness lineCreator = new BoldThickness();
            List<Point> expected = GetLineByName(expectedList2);
            Point start = GetPointByName(pointStart2);
            List<Point> actual = lineCreator.GetPoints(start);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("pointStart3", "expectedList3")]
        public void GetlistTest3(string pointStart3, string expectedList3)
        {
            ExtraThickness lineCreator = new ExtraThickness();
            List<Point> expected = GetLineByName(expectedList3);
            Point start = GetPointByName(pointStart3);
            List<Point> actual = lineCreator.GetPoints(start);
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
