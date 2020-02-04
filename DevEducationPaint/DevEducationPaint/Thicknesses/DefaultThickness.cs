using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Thicknesses
{
    public class DefaultThickness : ThicknessStrategy
    {
      public override List<Point> GetPoints(Point point)
        {
            List<Point> result = new List<Point>();
            result.Add(point);
            return result;
        }
    }
}
