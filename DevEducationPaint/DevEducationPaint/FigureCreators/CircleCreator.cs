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
            int cx = start.X;
            int cy = start.Y;
            int r = Math.Abs(end.X - start.X);

            List<Point> arcPoints = new List<Point>();
            for (int i = 0; i <= r; i++)
            {
                arcPoints.Add(new Point(i, Convert.ToInt32(Math.Round(Math.Sqrt(r * r - i * i)))));
            }

            List<Point> circlePoints = new List<Point>();
            for (int i = 0; i < arcPoints.Count; i++)
            {
                circlePoints.Add(new Point(arcPoints[i].X + cx, arcPoints[i].Y + cy));
                new Point(arcPoints[i].X + cx, arcPoints[i].Y + cy);
                circlePoints.Add(new Point(arcPoints[i - 1].X + cx, Math.Abs(arcPoints[i - 1].Y - cy)));
                new Point(arcPoints[i].X + cx, Math.Abs(arcPoints[i].Y - cy));
                circlePoints.Add(new Point(Math.Abs(arcPoints[i - 1].X - cx), arcPoints[i - 1].Y + cy));
                new Point(Math.Abs(arcPoints[i].X - cx), arcPoints[i].Y + cy);
                circlePoints.Add(new Point(Math.Abs(arcPoints[i - 1].X - cx), Math.Abs(arcPoints[i - 1].Y - cy)));
                new Point(Math.Abs(arcPoints[i].X - cx), Math.Abs(arcPoints[i].Y - cy));

                // рассчитать точки для остальных дуг
            }
               

            return new CircleFigure(circlePoints);
        }
    }
}
