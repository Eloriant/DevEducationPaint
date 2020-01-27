using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Thicknesses
{
    public class BoldThickness : ThicknessStrategy
    {
      
        public override List<Point> GetPoints(Point point)
        {
            List<Point> result = new List<Point>();
            result.Add(point);
            Point upPoint = new Point(point.X, point.Y + 1);
            result.Add(upPoint);
            Point downPoint = new Point(point.X, point.Y - 1);
            result.Add(downPoint);
            Point rightPoint = new Point(point.X + 1, point.Y);
            result.Add(rightPoint);
            Point leftPoint = new Point(point.X - 1, point.Y);
            result.Add(rightPoint);
            Point rightUpSquareAnglePoint = new Point(rightPoint.X, rightPoint.Y + 1);
            result.Add(rightUpSquareAnglePoint);
            Point rightDownSquareAnglePoint = new Point(rightPoint.X, rightPoint.Y - 1);
            result.Add(rightDownSquareAnglePoint);
            Point leftUpSquareAnglePoint = new Point(leftPoint.X, rightPoint.Y + 1);
            result.Add(leftUpSquareAnglePoint);
            Point leftDownSquareAnglePoint = new Point(leftPoint.X, rightPoint.Y - 1);
            result.Add(leftDownSquareAnglePoint);
            Point extraRightPoint = new Point(rightPoint.X + 1 , rightPoint.Y);
            result.Add(extraRightPoint);
            Point extraLeftPoint = new Point(leftPoint.X - 1, rightPoint.Y);
            result.Add(extraLeftPoint);
            return result;
        }
    }
}
