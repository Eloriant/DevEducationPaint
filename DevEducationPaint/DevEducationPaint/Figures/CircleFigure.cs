using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Strategies;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Figures
{
    public class CircleFigure : Figure
    {
        public CircleFigure(List<Point> points) {
            FigurePoints = points;
        }
    }
}
