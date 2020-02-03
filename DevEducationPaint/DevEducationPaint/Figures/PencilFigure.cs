﻿using System;
using System.Collections.Generic;
using Point = System.Drawing.Point;
using System.Text;

namespace DevEducationPaint.Figures
{
    public class PencilFigure : Figure
    {
        public PencilFigure(List<Point> points)
        {
            FigurePoints = points;
        }
    }
}
