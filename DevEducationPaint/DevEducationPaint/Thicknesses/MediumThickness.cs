using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Thicknesses
{
    public class MediumThickness : ThicknessStrategy
    {
   
        public override List<Point> GetPoints(Point point)
        {
            List<Point> result = new List<Point>();
            result.Add(point);
            Point upPoint = new Point(point.X, point.Y += 1);
            result.Add(upPoint);
            Point downPoint = new Point(point.X, point.Y -= 1);
            result.Add(downPoint);
            Point rightPoint = new Point(point.X += 1, point.Y);
            result.Add(rightPoint);
            Point leftPoint = new Point(point.X -= 1, point.Y);
            result.Add(rightPoint);
            return result;
        }
    }
}
