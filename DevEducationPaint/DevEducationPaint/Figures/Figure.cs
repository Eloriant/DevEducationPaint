using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Figures
{
    public abstract class Figure
    {
        public List<Point> FigurePoints { get; set; }
        public IDrawStrategy ConcreteDraw { get; set; }
        public void Draw() {
            ConcreteDraw.DrawLine(FigurePoints[0], FigurePoints[1]);
        }

        public Figure(List<Point> points)
        {
            FigurePoints = points;
        }
    }
}
