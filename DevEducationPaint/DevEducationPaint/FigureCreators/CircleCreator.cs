using DevEducationPaint.DrawStrategy;
using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class CircleCreator : FigureCreator
    {
        public override Figure CreateFigure(Point start, Point end, int thickness)
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
                // рассчитать точки для остальных дуг
            }



            /*for (int i = 1; i < points.Count; i++)
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

            }*/
            DrawByLine currentStrategy = new DrawByLine();
            switch (thickness)
            {
                case 1:
                    currentStrategy.ConcreteThickness = new DefaultThickness();
                    break;

            }
            currentStrategy.CurrentColor = new Color(255, 0, 0, 0);
            CircleFigure result = new CircleFigure(circlePoints);
            result.ConcreteDraw = currentStrategy;
            return result;
        }
    }
}
