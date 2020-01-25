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
    class BrokenLineFigure : Figure
    {
        public BrokenLineFigure(List<Point> points)
        {
            FigurePoints = points;
        }
        private RastrDrawer drawer = RastrDrawer.GetDrawer();

        public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint, int angleNumber = -1)
        {
            bitmap = drawer.DrawLine(startPoint, endPoint, bitmap);
            return bitmap;
        }


    }
}



