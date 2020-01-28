using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Thicknesses
{
    class ExtraThickness : ThicknessStrategy
    {
        public override List<Point> GetPoints(Point point)
        {
            List<Point> result = new List<Point>();
            result.Add(point);
            //Point upPoint = new Point(point.X, point.Y + 1);
            result.Add(new Point(point.X, point.Y + 1));
            //Point downPoint = new Point(point.X, point.Y - 1);
            result.Add(new Point(point.X, point.Y - 1));
            //Point rightPoint = new Point(point.X + 1, point.Y);
            result.Add(new Point(point.X + 1, point.Y));
            //Point leftPoint = new Point(point.X - 1, point.Y);
            result.Add(new Point(point.X - 1, point.Y));

            //Point rightUpSquareAnglePoint = new Point(rightPoint.X, rightPoint.Y + 1);
            result.Add(new Point(point.X + 1, point.Y + 1));
            //Point rightDownSquareAnglePoint = new Point(rightPoint.X, rightPoint.Y - 1);
            result.Add(new Point(point.X + 1, point.Y - 1));
            //Point leftUpSquareAnglePoint = new Point(leftPoint.X, rightPoint.Y + 1);
            result.Add(new Point(point.X - 1, point.Y - 1));
            //Point leftDownSquareAnglePoint = new Point(leftPoint.X, rightPoint.Y - 1);
            result.Add(new Point(point.X, point.Y - 2));
            //Point extraRightPoint = new Point(rightPoint.X + 1, rightPoint.Y);
            result.Add(new Point(point.X, point.Y + 2));
            //Point extraLeftPoint = new Point(leftPoint.X - 1, rightPoint.Y);
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





            //List<Point> result = new List<Point>();
            //result.Add(point);
            ////Point upPoint = new Point(point.X, point.Y + 1);
            //result.Add(new Point(point.X, point.Y + 1));
            ////Point downPoint = new Point(point.X, point.Y - 1);
            //result.Add(new Point(point.X, point.Y - 1));
            ////Point rightPoint = new Point(point.X + 1, point.Y);
            //result.Add(new Point(point.X + 1, point.Y));
            ////Point leftPoint = new Point(point.X - 1, point.Y);
            //result.Add(new Point(point.X - 1, point.Y));
            ////Point rightUpSquareAnglePoint = new Point(rightPoint.X, rightPoint.Y + 1);
            //result.Add(new Point(rightPoint.X, rightPoint.Y + 1));
            ////Point rightDownSquareAnglePoint = new Point(rightPoint.X, rightPoint.Y - 1);
            //result.Add(new Point(rightPoint.X, rightPoint.Y - 1));
            ////Point leftUpSquareAnglePoint = new Point(leftPoint.X, rightPoint.Y + 1);
            //result.Add(new Point(leftPoint.X, rightPoint.Y + 1);
            ////Point leftDownSquareAnglePoint = new Point(leftPoint.X, rightPoint.Y - 1);
            //result.Add(new Point(leftPoint.X, rightPoint.Y - 1));
            ////Point extraRightPoint = new Point(rightPoint.X + 1, rightPoint.Y);
            //result.Add(new Point(rightPoint.X + 1, rightPoint.Y));
            ////Point extraLeftPoint = new Point(leftPoint.X - 1, rightPoint.Y);
            //result.Add(new Point(leftPoint.X - 1, rightPoint.Y));
        }
    }
}
