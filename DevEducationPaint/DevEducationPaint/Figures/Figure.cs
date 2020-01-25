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
        public DrawStrategy ConcreteDraw { get; set; }
        public void Draw() {
            ConcreteDraw.DrawLineWithThickness(FigurePoints[0], FigurePoints[1]);
        }
    }
}
