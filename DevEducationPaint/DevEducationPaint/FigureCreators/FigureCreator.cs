using DevEducationPaint.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.FigureCreators
{
    public abstract class FigureCreator
    {
        public abstract Figure CreateFigure(Point start, Point end);

        public int GetFigureDiametr(Point start, Point end)
        {
            int deltaX = 2 * Math.Abs(end.X - start.X);
            int deltaY = Convert.ToInt32(Math.Abs(end.Y - start.Y));
            int diametr = deltaX >= deltaY ? deltaX : deltaY;
            return diametr;
        }
    }
}