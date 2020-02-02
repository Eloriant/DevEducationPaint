using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DevEducationPaint.Surface_Strategy
{
    class DrawOnCanvas : ISurfaceStrategy
    {
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
        public Canvas DrawWindow1 { get; private set; }

        public void DrawLine(Point p1, Point p2)
        {
            Line myLine = new Line();
            //myLine.Stroke = ThicknessStrategy.
            myLine.X1 = p1.X;
            myLine.X2 = p2.X;
            myLine.Y1 = p1.Y;
            myLine.Y2 = p2.Y;
            //myLine.HorizontalAlignment = HorizontalAlignment.Left;
            //myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;//Thickness
            DrawWindow1.Children.Add(myLine);
        }
    }
}
