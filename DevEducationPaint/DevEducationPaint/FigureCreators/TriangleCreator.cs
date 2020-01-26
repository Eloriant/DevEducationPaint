using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class TriangleCreator : FigureCreator
    {
        public override Figure CreateFigure(Point start, Point end)
        {

            Point high = new Point(start.X, end.Y);  // код для прямоугольного треугольника

            List<Point> trianglePoints = new List<Point> ();

            trianglePoints.Add(start);
            trianglePoints.Add(end);
            trianglePoints.Add(high);

            return new TriangleFigure(trianglePoints);
        }

    }
}

