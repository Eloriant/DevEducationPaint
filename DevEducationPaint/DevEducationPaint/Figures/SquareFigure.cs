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
    class SquareFigure : Figure
    {
        private RastrDrawer drawer = RastrDrawer.GetDrawer();

        public SquareFigure(List<Point> points)
        {
            FigurePoints = points;
        }
        //public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint, int angleNumber = -1)
        //{
        //    /*ТРАПЕЦИЯ
        //    Point leftDownPoint = new Point(startPoint.X, endPoint.Y);
        //    Point rightUpPoint = new Point(endPoint.X, startPoint.Y);
        //    if (Math.Abs(endPoint.X - startPoint.X) < Math.Abs(endPoint.Y - startPoint.Y))
        //    {
        //        int l = Convert.ToInt32(endPoint.X - startPoint.X);
        //        endPoint.Y = startPoint.Y + l;
        //        //rightUpPoint = new Point(startPoint.X, (startPoint.X + Math.Abs(endPoint.X - startPoint.X)));
        //        //leftDownPoint = new Point( (startPoint.Y + Math.Abs(endPoint.X - startPoint.X)), endPoint.Y);
        //    }
        //    else if (Math.Abs(endPoint.X - startPoint.X) > Math.Abs(endPoint.Y - startPoint.Y))
        //    {
        //        int l = Convert.ToInt32(endPoint.Y - startPoint.Y);
        //        endPoint.X = startPoint.X + l;
        //        //rightUpPoint = new Point(startPoint.X, (startPoint.X + Math.Abs(endPoint.Y - startPoint.Y)));
        //        //leftDownPoint = new Point(startPoint.Y, (startPoint.Y + Math.Abs(endPoint.Y - startPoint.Y)));
        //    }
        //    bitmap = drawer.DrawLine(startPoint, rightUpPoint, bitmap);
        //    bitmap = drawer.DrawLine(rightUpPoint, endPoint, bitmap);
        //    bitmap = drawer.DrawLine(endPoint, leftDownPoint, bitmap);
        //    bitmap = drawer.DrawLine(leftDownPoint, startPoint, bitmap);*/

      

    }
}
