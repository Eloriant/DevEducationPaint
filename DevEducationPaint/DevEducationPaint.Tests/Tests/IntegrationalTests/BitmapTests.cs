using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevEducationPaint.FigureCreators;
using NUnit.Framework;
using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;

namespace DevEducationPaint.Tests.Tests.IntegrationalTests
{
    [TestFixture]
    class BitmapTests
    {
        [TestCase()]
        public void GetLineOnTheBitmap()
        {
            //private IDrawStrategy drawStrategy;
            DevEducationPaint.Figures.Figure resultFigure;
            WriteableBitmap bitmap = new WriteableBitmap(10,
            10, 96, 96, PixelFormats.Bgra32, null);
            FigureCreator currentCreator = new LineCreator();
            Point prev = new Point(2, 1);
            Point position = new Point(9, 9);
            resultFigure = currentCreator.CreateFigure(prev, position);
            resultFigure.ConcreteDraw = IDrawStrategy.DrawByLine;
            resultFigure.Draw();

            
        }


    }
}
