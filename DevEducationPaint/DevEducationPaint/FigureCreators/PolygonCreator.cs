using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class PolygonCreator : FigureCreator
    {
    private int angleNumber;

    public PolygonCreator(int angleNumber)
    {
      this.angleNumber = angleNumber;
    }

    private Point[] LineAngle(double angle, int angleNumber, Point polygonsTop, Point[] circuitsPoints)
    {
      double z = 0;
      int i = 1;
      Point[] circuitsPointsArray = new Point[angleNumber];
      circuitsPointsArray[0] = polygonsTop;

      while (i < angleNumber)
      {
        z += angle;
        circuitsPointsArray[i].X = Convert.ToInt32(polygonsTop.X * Math.Cos(z) - polygonsTop.Y * Math.Sin(z));
        circuitsPointsArray[i].Y = Convert.ToInt32(polygonsTop.X * Math.Sin(z) + polygonsTop.Y * Math.Cos(z));
        i++;
      }
      return circuitsPoints;
    }

    public override Figure CreateFigure(Point start, Point end)
    {
      start.X = Convert.ToInt32(start.X);
      start.Y = Convert.ToInt32(start.Y);
      end.X = Convert.ToInt32(end.X);
      end.Y = Convert.ToInt32(end.Y);

      int deltaX = Convert.ToInt32(Math.Abs(end.X - start.X));
      int deltaY = Convert.ToInt32(Math.Abs(end.Y - start.Y));
      int diametr = deltaX >= deltaY ? deltaX : deltaY;
      Point polygonsTop = new Point(0, diametr / 2);
      double angle = 2 * Math.PI / angleNumber;
      int i = angleNumber - 1;
      Point[] circuitsPoints = new Point[angleNumber];
      circuitsPoints = LineAngle(angle, angleNumber, polygonsTop, circuitsPoints);

      for (int idx = 0; idx < circuitsPoints.Length; idx++)
      {
        circuitsPoints[idx].X += start.X;
        circuitsPoints[idx].Y += start.Y - diametr / 2;
      }

      List<Point> polygonPoints = new List<Point>();
      for (int z = 0; z < circuitsPoints.Length; z++)
      {
        polygonPoints.Add(circuitsPoints[i]);
        // рассчитать точки для остальных дуг
      }

      return new PolygonFigure(polygonPoints);
    }
  }
}

