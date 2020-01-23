using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Drawers;
using DevEducationPaint.Strategies;
using Point = System.Windows.Point;

namespace DevEducationPaint.Figures
{
  class BrokenLine : Figure
    {
    private RastrDrawer drawer = RastrDrawer.GetDrawer();
    public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, System.Windows.Point startPoint, System.Windows.Point endPoint)
    {
      Point one = new Point(startPoint.X, startPoint.Y);
      bitmap = drawer.DrawLine(startPoint, endPoint, bitmap);
      return bitmap;
      
    }


  }
}
