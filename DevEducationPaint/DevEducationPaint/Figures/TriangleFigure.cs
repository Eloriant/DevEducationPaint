using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Drawers;
using DevEducationPaint.Strategies;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Figures
{
    public class TriangleFigure : Figure
    {
        public TriangleFigure(List<Point> points)
        {
            FigurePoints = points;
        }

    }
}

