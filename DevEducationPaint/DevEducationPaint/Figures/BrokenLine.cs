using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Drawers;
using DevEducationPaint.Strategies;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Figures
{
  class BrokenLine : Figure
  {
    public BrokenLine(List<Point> points) : base(points)
    {
    }

    private RastrDrawer drawer = RastrDrawer.GetDrawer();
    public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint)
    {
      Point one = new Point(startPoint.X, startPoint.Y);
      bitmap = drawer.DrawLine(startPoint, endPoint, bitmap);
      return bitmap;

    }



  }
}
