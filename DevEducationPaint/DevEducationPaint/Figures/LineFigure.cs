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
    public class LineFigure : Figure
    {
        public LineFigure(List<Point> points)
        {
            FigurePoints = points;
        }
    }
}
