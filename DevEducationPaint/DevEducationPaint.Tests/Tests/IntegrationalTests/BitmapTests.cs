using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevEducationPaint.Bitmap;
using DevEducationPaint.FigureCreators;
using NUnit.Framework;
using DevEducationPaint.Figures;
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using DevEducationPaint.Surface_Strategy;
using DevEducationPaint.Thicknesses;
using Figure = DevEducationPaint.Figures.Figure;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Tests.Tests.IntegrationalTests
{
  [TestFixture]
  class BitmapTests
  {
    [TestCase]
    public void GetLineOnTheBitmap()
    {
      var prev = new Point(5, 3);
      var position = new Point(5, 9);

      Figure resultFigure = getFigure(prev, position);

      SuperBitmap.Instance = new WriteableBitmap(10,
    10, 96, 96, PixelFormats.Bgra32, null);

      WriteableBitmap bitmap = GetBitmap();
      resultFigure.Draw();
     
      var expected = bitmapToArray(bitmap);
      var actual = bitmapToArray(SuperBitmap.GetInstanceCopy());

      Assert.AreEqual(expected, actual);
    }


    private Figure getFigure(Point prev, Point position)
    {
      Figure resultFigure;
      FigureCreator currentCreator = new LineCreator();
      resultFigure = currentCreator.CreateFigure(prev, position);
      resultFigure.ConcreteDraw = new DrawByLine
      {
        SurfaceStrategy = new DrawOnBitmap
        {
          CurrentColor = new DrawColor(255, 255, 255, 255),
          ConcreteThickness = new DefaultThickness()
        }
      };
      return resultFigure;
    }


    private WriteableBitmap GetBitmap()
    {
      
      var bitmap = new WriteableBitmap(10,
        10, 96, 96, PixelFormats.Bgra32, null);

      var colorBytes = new byte[] {255, 255, 255, 255};
      bitmap.WritePixels(new Int32Rect(5, 3,1,1), colorBytes, 4,0 );
      bitmap.WritePixels(new Int32Rect(5, 4, 1, 1), colorBytes, 4, 0);
      bitmap.WritePixels(new Int32Rect(5, 5, 1, 1), colorBytes, 4, 0);
      bitmap.WritePixels(new Int32Rect(5, 6, 1, 1), colorBytes, 4, 0);
      bitmap.WritePixels(new Int32Rect(5, 7, 1, 1), colorBytes, 4, 0);
      bitmap.WritePixels(new Int32Rect(5, 8, 1, 1), colorBytes, 4, 0);
      bitmap.WritePixels(new Int32Rect(5, 9, 1, 1), colorBytes, 4, 0);
      return bitmap;
    }


    private Array bitmapToArray(WriteableBitmap bitmap)
    {
      if (bitmap == null || bitmap.PixelHeight == 0 || bitmap.PixelWidth == 0)
        return null;

      int stride = bitmap.PixelWidth * bitmap.Format.BitsPerPixel / 8;
      int size = stride * bitmap.PixelHeight;

      byte[] buffer = new byte[size];

      bitmap.CopyPixels(buffer, stride, 0);

      return buffer;
    }

    


  }
}
