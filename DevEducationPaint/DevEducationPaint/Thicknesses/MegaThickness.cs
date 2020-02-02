//using System.Collections.Generic;
//using Point = System.Drawing.Point;

//namespace DevEducationPaint.Thicknesses
//{
//    class MegaThickness : ThicknessStrategy
//    {
//        public override List<Point> GetPoints(Point point)
//        {
//            List<Point> result = new List<Point>();
//            result.Add(point);
//            result.Add(new Point(point.X, point.Y + 1));
//            result.Add(new Point(point.X, point.Y - 1));
//            result.Add(new Point(point.X + 1, point.Y));
//            result.Add(new Point(point.X - 1, point.Y));

//            result.Add(new Point(point.X + 1, point.Y + 1));
//            result.Add(new Point(point.X + 1, point.Y - 1));
//            result.Add(new Point(point.X - 1, point.Y - 1));
//            result.Add(new Point(point.X, point.Y - 2));
//            result.Add(new Point(point.X, point.Y + 2));
//            result.Add(new Point(point.X - 2, point.Y));
//            result.Add(new Point(point.X + 2, point.Y));


//            result.Add(new Point(point.X - 1, point.Y - 2));
//            result.Add(new Point(point.X - 2, point.Y - 1));
//            result.Add(new Point(point.X + 1, point.Y - 2));
//            result.Add(new Point(point.X + 2, point.Y - 1));

//            result.Add(new Point(point.X + 2, point.Y + 1));
//            result.Add(new Point(point.X + 1, point.Y + 2));
//            result.Add(new Point(point.X - 1, point.Y + 2));
//            result.Add(new Point(point.X - 2, point.Y + 1));
            
//            // след. наращивание +3

//            result.Add(new Point(point.X - 3, point.Y));
//            result.Add(new Point(point.X - 3, point.Y - 1));
//            result.Add(new Point(point.X - 3, point.Y + 1));
//            result.Add(new Point(point.X - 2, point.Y - 2));
//            result.Add(new Point(point.X - 2, point.Y + 2));

//            result.Add(new Point(point.X, point.Y - 3));
//            result.Add(new Point(point.X - 1, point.Y - 3));
//            result.Add(new Point(point.X + 1, point.Y - 3));
//            result.Add(new Point(point.X + 2, point.Y - 2));

//            result.Add(new Point(point.X + 3, point.Y));
//            result.Add(new Point(point.X + 3, point.Y - 1));
//            result.Add(new Point(point.X + 3, point.Y + 1));
//            result.Add(new Point(point.X + 2, point.Y + 2));

//            result.Add(new Point(point.X , point.Y + 3));
//            result.Add(new Point(point.X - 1 , point.Y + 3));
//            result.Add(new Point(point.X + 1, point.Y + 3));

//            // следующее наращие + 4

//            result.Add(new Point(point.X - 4, point.Y));
//            result.Add(new Point(point.X - 4, point.Y - 1));
//            result.Add(new Point(point.X - 4, point.Y + 1));
//            result.Add(new Point(point.X - 3, point.Y - 2));
//            result.Add(new Point(point.X - 3, point.Y + 2));

//            result.Add(new Point(point.X - 2, point.Y - 3));
//            result.Add(new Point(point.X - 2, point.Y + 3));
//            result.Add(new Point(point.X + 1, point.Y - 4));
//            result.Add(new Point(point.X, point.Y - 4));
//            result.Add(new Point(point.X - 1, point.Y - 4));
//            result.Add(new Point(point.X + 1, point.Y + 4));
//            result.Add(new Point(point.X, point.Y + 4));
//            result.Add(new Point(point.X - 1, point.Y + 4));

//            result.Add(new Point(point.X + 2, point.Y - 3));
//            result.Add(new Point(point.X + 3, point.Y - 2));

//            result.Add(new Point(point.X + 4, point.Y + 1));
//            result.Add(new Point(point.X + 4, point.Y));
//            result.Add(new Point(point.X + 4, point.Y - 1));

//            result.Add(new Point(point.X + 3, point.Y + 2));
//            result.Add(new Point(point.X + 2, point.Y + 3));

//            // след. наращивание + 5


           
//            return result;
//        }
//    }
//}
