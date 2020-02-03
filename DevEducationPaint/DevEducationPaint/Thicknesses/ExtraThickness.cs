using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Thicknesses
{
   public class ExtraThickness : ThicknessStrategy
    {
        public override List<Point> GetPoints(Point point)
        {
            List<Point> result = new List<Point>();
            result.Add(point);
            result.Add(new Point(point.X, point.Y + 1));
            result.Add(new Point(point.X, point.Y - 1));
            result.Add(new Point(point.X + 1, point.Y));
            result.Add(new Point(point.X - 1, point.Y));

            result.Add(new Point(point.X + 1, point.Y + 1));
            result.Add(new Point(point.X + 1, point.Y - 1));
            result.Add(new Point(point.X - 1, point.Y - 1));
            result.Add(new Point(point.X, point.Y - 2));
            result.Add(new Point(point.X, point.Y + 2));
            result.Add(new Point(point.X - 2, point.Y));
            result.Add(new Point(point.X + 2, point.Y));


            result.Add(new Point(point.X - 1, point.Y - 2));
            result.Add(new Point(point.X - 2, point.Y - 1));
            result.Add(new Point(point.X + 1, point.Y - 2));
            result.Add(new Point(point.X + 2, point.Y - 1));

            result.Add(new Point(point.X + 2, point.Y + 1));
            result.Add(new Point(point.X + 1, point.Y + 2));
            result.Add(new Point(point.X - 1, point.Y + 2));
            result.Add(new Point(point.X - 2, point.Y + 1));
            return result;
        }
    }
}
