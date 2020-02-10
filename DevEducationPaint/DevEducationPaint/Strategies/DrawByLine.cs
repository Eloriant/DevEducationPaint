using DevEducationPaint.Bitmap;
using DevEducationPaint.Share;
using DevEducationPaint.Surface_Strategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Strategies
{
  public class DrawByLine : IDrawStrategy
  {
    public override void CalculatePointsForDrawMethod(Point p1, Point p2, bool isVector)
    {
      if (isVector)
      {
        SurfaceStrategy.DrawLine(p1, p2);
      }
      else
      {
        List<Point> points1 = SurfaceStrategy.ConcreteThickness.GetPoints(p1);
        List<Point> points2 = SurfaceStrategy.ConcreteThickness.GetPoints(p2);

        for (int i = 0; i < points1.Count; i++)
        {
          SurfaceStrategy.DrawLine(points1[i], points2[i]);
        }
      }


    }
  }
}