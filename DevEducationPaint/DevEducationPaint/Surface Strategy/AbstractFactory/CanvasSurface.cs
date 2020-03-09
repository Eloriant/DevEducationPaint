using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Surface_Strategy.AbstractFactory
{
    class CanvasSurface : ISurface
    {
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
        public void DrawLine(Point p1, Point p2)
        {
            Line newLine = new Line
            {
                X1 = p1.X,
                X2 = p2.X,
                Y1 = p1.Y,
                Y2 = p2.Y,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = getThickness(),
                Stroke = new SolidColorBrush(CurrentColor.CurColor()),
                Tag = SuperCanvas.CurrentFigure,
                Uid = Guid.NewGuid().ToString(),
            };
            SuperCanvas.CurrentFigure.lines.Add(newLine);
            SuperCanvas.GetInstanceCopy().Children.Add(newLine);
        }


        private double getThickness()
        {
            double thickness = 1;


            switch (ConcreteThickness.GetType().Name)
            {
                case nameof(DefaultThickness):
                    thickness = 1;
                    break;
                case nameof(MediumThickness):
                    thickness = 2;
                    break;
                case nameof(BoldThickness):
                    thickness = 3;
                    break;
                case nameof(ExtraThickness):
                    thickness = 4;
                    break;

            }

            return thickness;
        }
    }
}
