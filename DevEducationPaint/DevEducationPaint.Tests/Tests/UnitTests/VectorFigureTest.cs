using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Shapes;
using DevEducationPaint.Figures;
using NUnit.Framework;

namespace DevEducationPaint.Tests
{
    [TestFixture]
    class VectorFigureTests
    {
        public List<Point> GetPointByName(string name)
        {
            switch (name)
            {
                case "pointList":
                    return new List<Point>
                    {
                            new Point(14,15),
                            new Point(16,13),
                            new Point(100,101),
                            new Point(105,108)
                    };
                default:
                    return new List<Point>();
            }
        }
        public List<Line> GetListLineByName(string name)
        {
            switch (name)
            {
                case "expectedLineList":
                    return new List<Line>
                    {
                        new Line()
                        {
                            X1 = 14,
                            X2 = 16,
                            Y1 = 15,
                            Y2 = 13

                        },
                        new Line()
                        {
                            X1 = 16,
                            X2 = 100,
                            Y1 = 13,
                            Y2 = 101
                        },
                         new Line()
                        {
                            X1 = 100,
                            X2 = 105,
                            Y1 = 101,
                            Y2 = 108
                        },
                    };
                default:
                    return new List<Line>();
            }
        }

        [STAThreadAttribute]
        [TestCase("pointList", "expectedLineList")]
        public void GetLineListFromListOfPointsTest_InPutIsListPoint_OutPutIsListLines(string pointList, string expectedLineList)
        {
            VectorFigure vectorFigure = new VectorFigure(GetPointByName("pointList"));
            //List<Point> listPoint = GetPointByName("pointList");
            List<Line> expected = GetListLineByName("expectedLineList");
            List<Line> actual = vectorFigure.lines;
            Assert.AreEqual(expected, actual);
        }
    }
}
