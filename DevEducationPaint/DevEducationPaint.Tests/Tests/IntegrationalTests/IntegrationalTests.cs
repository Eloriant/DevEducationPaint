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
        public void BrokenLineCreatorTest_WithTrueAssert()
        {
            BrokenLineFigure brokenLine = new BrokenLineFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(brokenLine is BrokenLineFigure);
        }
        [TestCase()]
        public void BrokenLineCreatorTest_WithFalseAssert()
        {
            BrokenLineFigure brokenLine = new BrokenLineFigure(new List<System.Drawing.Point>());
            Assert.IsFalse(brokenLine is CircleFigure);
        }
        [TestCase()]
        public void CircleFigureCreatorTest_WithTrueAssert()
        {
            CircleFigure circleFigure = new CircleFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(circleFigure is CircleFigure);
        }
        [TestCase()]
        public void CircleFigureCreatorTest_WithFalseAssert()
        {
            CircleFigure circleFigure = new CircleFigure(new List<System.Drawing.Point>());
            Assert.IsFalse(circleFigure is PolygonFigure);
        }
        [TestCase()]
        public void LineFigureCreatorTest_WithTrueAssert()
        {
            LineFigure lineFigure = new LineFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(lineFigure is LineFigure);
        }
        [TestCase()]
        public void LineFigureCreatorTest_WithFalseAssert()
        {
            LineFigure lineFigure = new LineFigure(new List<System.Drawing.Point>());
            Assert.IsFalse(lineFigure is PolygonFigure);
        }
        [TestCase()]
        public void PencilFigureCreatorTest_WithTrueAssert()
        {
            PencilFigure pencilFigure = new PencilFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(pencilFigure is PencilFigure);
        }
        [TestCase()]
        public void PencilFigureCreatorTest_WithFalseAssert()
        {
            PencilFigure pencilFigure = new PencilFigure(new List<System.Drawing.Point>());
            Assert.IsFalse(pencilFigure is PolygonFigure);
        }
        [TestCase()]
        public void PolygonFigureCreatorTest_WithTrueAssert()
        {
            PolygonFigure polygonFigure = new PolygonFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(polygonFigure is PolygonFigure);
        }
        [TestCase()]
        public void PolygonFigureCreatorTest1_WithFalseAssert()
        {
            PolygonFigure polygonFigure = new PolygonFigure(new List<System.Drawing.Point>());
            Assert.IsFalse(polygonFigure is LineFigure);
        }
        [TestCase()]
        public void SquareFigureCreatorTest_WithTrueAssert()
        {
            SquareFigure squareFigure = new SquareFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(squareFigure is SquareFigure);
        }
        [TestCase()]
        public void SquareFigureCreatorTest_WithFalseAssert()
        {
            SquareFigure squareFigure = new SquareFigure(new List<System.Drawing.Point>());
            Assert.IsFalse(squareFigure is LineFigure);
        }
        [TestCase()]
        public void TriangleFigureCreatorTest_WithTrueAssert()
        {
            TriangleFigure triangleFigure = new TriangleFigure(new List<System.Drawing.Point>());
            Assert.IsTrue(triangleFigure is TriangleFigure);
        }
        [TestCase()]
        public void TriangleFigureCreatorTest_WithFalseAssert()
        {
            TriangleFigure triangleFigure = new TriangleFigure(new List<System.Drawing.Point>());
            Assert.IsFalse(triangleFigure is LineFigure);
        }
    }
}
