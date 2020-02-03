using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Strategies;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Figures
{
    public class SquareFigure : Figure
    {
        public SquareFigure(List<Point> points)
        {
            FigurePoints = points;
        }
    }
}
