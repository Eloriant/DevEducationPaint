using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Drawers;
using DevEducationPaint.Strategies;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Figures
{
    public class CircleFigure : Figure
    {
        public CircleFigure(List<Point> points) {
            FigurePoints = points;
        }
    }
}

/*public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint, int angleNumber = -1)
{
    int cx = (int)startPoint.X;
    int cy = (int)startPoint.Y;
    int r = Math.Abs((int)(endPoint.X - startPoint.X));
    int x = (int)endPoint.X;
    int y = (int)endPoint.Y;

    List<Point> points = new List<Point>();
    for (int i = 0; i <= r; i++)
    {
        points.Add(new Point(i, Math.Sqrt(r * r - i * i)));
    }

    for (int i = 1; i < points.Count; i++)
    {
        //SetPixel(new Point(points[i].X + cx, points[i].Y + cy));
        bitmap = drawer.DrawLine(new Point(points[i - 1].X + cx, points[i - 1].Y + cy),
          new Point(points[i].X + cx, points[i].Y + cy), bitmap);
        bitmap = drawer.DrawLine(new Point(points[i - 1].X + cx, Math.Abs(points[i - 1].Y - cy)),
          new Point(points[i].X + cx, Math.Abs(points[i].Y - cy)), bitmap);
        bitmap = drawer.DrawLine(new Point(Math.Abs(points[i - 1].X - cx), points[i - 1].Y + cy),
          new Point(Math.Abs(points[i].X - cx), points[i].Y + cy), bitmap);
        bitmap = drawer.DrawLine(new Point(Math.Abs(points[i - 1].X - cx), Math.Abs(points[i - 1].Y - cy)),
          new Point(Math.Abs(points[i].X - cx), Math.Abs(points[i].Y - cy)), bitmap);

    }

    return bitmap;
}*/
