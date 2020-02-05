using System;
using System.Collections.Generic;
using System.Text;
using DevEducationPaint.Figures;
using NUnit.Framework;

namespace DevEducationPaint.Tests.Tests.IntegrationalTests
{
    [TestFixture]
    class IntegrationalTests
    {
        [TestCase()]
        public void BrokenLineCreatorTest()
        {
            BrokenLineFigure brokenLine = new BrokenLineFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(brokenLine is BrokenLineFigure);
        }
        [TestCase()]
        public void CircleFigureCreatorTest()
        {
            CircleFigure circleFigure = new CircleFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(circleFigure is CircleFigure);
        }
        [TestCase()]
        public void LineFigureCreatorTest()
        {
            LineFigure lineFigure = new LineFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(lineFigure is LineFigure);
        }
        [TestCase()]
        public void PencilFigureCreatorTest()
        {
            PencilFigure pencilFigure = new PencilFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(pencilFigure is PencilFigure);
        }
        [TestCase()]
        public void PolygonFigureCreatorTest()
        {
            PolygonFigure polygonFigure = new PolygonFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(polygonFigure is PolygonFigure);
        }
        [TestCase()]
        public void SquareFigureCreatorTest()
        {
            SquareFigure squareFigure = new SquareFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(squareFigure is SquareFigure);
        }
        [TestCase()]
        public void TriangleFigureCreatorTest()
        {
            TriangleFigure triangleFigure = new TriangleFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(triangleFigure is TriangleFigure);
        }
    }
}
