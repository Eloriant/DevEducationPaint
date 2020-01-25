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
    }
}
