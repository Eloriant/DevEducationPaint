using DevEducationPaint.Figures;
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class LineCreator : FigureCreator
    {
        public override Figure CreateFigure(Point start, Point end)
        {
            List<Point> linePoints = new List<Point>();

            Point one = new Point(start.X, start.Y);
            linePoints.Add(start);
            linePoints.Add(end);


            return new LineFigure(linePoints);
        }
    }
}
