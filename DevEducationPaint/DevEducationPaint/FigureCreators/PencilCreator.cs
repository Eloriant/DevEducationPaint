using DevEducationPaint.Figures;
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class PencilCreator : FigureCreator
    {
        public override Figure CreateFigure(Point start, Point end)
        {
            List<Point> linePoints = new List<Point>();

            linePoints.Add(start);
            linePoints.Add(end);

            return new LineFigure(linePoints);
        }
    }
}
