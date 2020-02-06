using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Surface_Strategy
{
  class DrawOnCanvas : ISurfaceStrategy
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
        StrokeThickness = 5/*getThickness()*/,
        Stroke = new SolidColorBrush(Colors.Black),

      };
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
          thickness = 4;
          break;
        case nameof(ExtraThickness):
          thickness = 8;
          break;
        
      }

      return thickness;
    }

  }








  //Line myLine = new Line();
  ////myLine.Stroke = ThicknessStrategy.
  //myLine.X1 = p1.X;
  //myLine.X2 = p2.X;
  //myLine.Y1 = p1.Y;
  //myLine.Y2 = p2.Y;
  ////myLine.HorizontalAlignment = HorizontalAlignment.Left;
  ////myLine.VerticalAlignment = VerticalAlignment.Center;
  //myLine.StrokeThickness = 2;//Thickness
  //DrawWindow1.Children.Add(myLine);
}
