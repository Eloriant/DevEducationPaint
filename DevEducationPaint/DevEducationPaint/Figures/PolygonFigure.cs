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
  class PolygonFigure : Figure
  {
    private RastrDrawer drawer = RastrDrawer.GetDrawer();
    public PolygonFigure(List<Point> points) : base(points)
    {
    }

    public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint, int angleNumber = -1)
    {
      startPoint.X = Convert.ToInt32(startPoint.X);
      startPoint.Y = Convert.ToInt32(startPoint.Y);
      endPoint.X = Convert.ToInt32(endPoint.X);
      endPoint.Y = Convert.ToInt32(endPoint.Y);
      int deltaX = Convert.ToInt32(Math.Abs(endPoint.X - startPoint.X));
      int deltaY = Convert.ToInt32(Math.Abs(endPoint.Y - startPoint.Y));
      int diametr = deltaX >= deltaY ? deltaX : deltaY;
      Point polygonsTop = new Point(0, diametr / 2);
      double angle = 2 * Math.PI / angleNumber;
      int i = angleNumber - 1;
      Point[] circuitsPoints = new Point[angleNumber];
      circuitsPoints = LineAngle(angle, angleNumber, polygonsTop, circuitsPoints);
      for (int idx = 0; idx < circuitsPoints.Length; idx++)
      {
        circuitsPoints[idx].X += startPoint.X;
        circuitsPoints[idx].Y += startPoint.Y - diametr / 2;
      }
      while (i > 0)
      {
        bitmap = drawer.DrawLine(circuitsPoints[i], circuitsPoints[i - 1], bitmap);
        i--;
      }
      bitmap = drawer.DrawLine(circuitsPoints[0], circuitsPoints[angleNumber - 1], bitmap);
      return bitmap;
    }

    public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint)
    {
      throw new NotImplementedException();
    }

    private Point[] LineAngle(double angle, int angleNumber, Point polygonsTop, Point[] circuitsPoints)
    {
      double z = 0;
      int i = 1;
      circuitsPoints[0] = polygonsTop;
      while (i < angleNumber)
      {
        z += angle;
        circuitsPoints[i].X = Convert.ToInt32(polygonsTop.X * Math.Cos(z) - polygonsTop.Y * Math.Sin(z));
        circuitsPoints[i].Y = Convert.ToInt32(polygonsTop.X * Math.Sin(z) + polygonsTop.Y * Math.Cos(z));
        i++;
      }
      return circuitsPoints;
    }


  }
}
