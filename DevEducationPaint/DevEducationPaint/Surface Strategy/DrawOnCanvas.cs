using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace DevEducationPaint.Surface_Strategy
{
    class DrawOnCanvas : ISurfaceStrategy
    {
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
        public Canvas DrawWindow1 { get; private set; }

        public void DrawLine(Point p1, Point p2)
        {
            //DrawWindow1.Children.Add(fugureName);
        }

        

        //private void Draw(Point prev, Point position)
        //{
        //    MainWindow.Content = DrawWindow1;
        //    MainWindow.Show();
        //}
    }
}
