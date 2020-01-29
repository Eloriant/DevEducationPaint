using DevEducationPaint.Figures;
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class CircleCreator : FigureCreator
    {
        public override Figure CreateFigure(Point start, Point end)
        {
            int cx =  start.X;
            int cy =  start.Y;
            int r =  Math.Abs(end.X - start.X);

            List<Point> arcPoints = new List<Point>();
            for (int i = 0; i <= r; i++)
            {
                arcPoints.Add(new Point(i, Convert.ToInt32(Math.Round(Math.Sqrt(r * r - i * i)))));
            }

            List<Point> circlePoints = new List<Point>();
            List<Point> circlePoints1 = new List<Point>();
            List<Point> circlePoints2 = new List<Point>();
            List<Point> circlePoints3 = new List<Point>();
            List<Point> circlePoints4 = new List<Point>();
            for (int i = 1; i < arcPoints.Count; i++)
            {
                circlePoints1.Add(new Point(arcPoints[i].X + cx, arcPoints[i].Y + cy));
                circlePoints2.Add(new Point(arcPoints[arcPoints.Count - i - 1].X + cx, Math.Abs(arcPoints[arcPoints.Count - i - 1].Y - cy)));
                circlePoints3.Add(new Point(Math.Abs(arcPoints[i - 1].X - cx), Math.Abs(arcPoints[i - 1].Y - cy)));
                circlePoints4.Add(new Point(Math.Abs(arcPoints[arcPoints.Count - i - 1].X - cx), Math.Abs(arcPoints[arcPoints.Count - i - 1].Y + cy)));
            }
            circlePoints.AddRange(circlePoints1);
            circlePoints.AddRange(circlePoints2);
            circlePoints.AddRange(circlePoints3);
            circlePoints.AddRange(circlePoints4);

            return new CircleFigure(circlePoints);
        }
    }
}
