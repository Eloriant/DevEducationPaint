using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Drawers;
using DevEducationPaint.Strategies;
using Point = System.Windows.Point;

namespace DevEducationPaint.Figures
{
  class SquareFigure : IFigureStrategy
  {
    private RastrDrawer drawer = RastrDrawer.GetDrawer();


    public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, System.Windows.Point startPoint, System.Windows.Point endPoint, int angleNumber = -1)
    {
      /*ТРАПЕЦИЯ
      Point leftDownPoint = new Point(startPoint.X, endPoint.Y);
      Point rightUpPoint = new Point(endPoint.X, startPoint.Y);
      if (Math.Abs(endPoint.X - startPoint.X) < Math.Abs(endPoint.Y - startPoint.Y))
      {
          int l = Convert.ToInt32(endPoint.X - startPoint.X);
          endPoint.Y = startPoint.Y + l;
          //rightUpPoint = new Point(startPoint.X, (startPoint.X + Math.Abs(endPoint.X - startPoint.X)));
          //leftDownPoint = new Point( (startPoint.Y + Math.Abs(endPoint.X - startPoint.X)), endPoint.Y);
      }
      else if (Math.Abs(endPoint.X - startPoint.X) > Math.Abs(endPoint.Y - startPoint.Y))
      {
          int l = Convert.ToInt32(endPoint.Y - startPoint.Y);
          endPoint.X = startPoint.X + l;
          //rightUpPoint = new Point(startPoint.X, (startPoint.X + Math.Abs(endPoint.Y - startPoint.Y)));
          //leftDownPoint = new Point(startPoint.Y, (startPoint.Y + Math.Abs(endPoint.Y - startPoint.Y)));
      }
      bitmap = drawer.DrawLine(startPoint, rightUpPoint, bitmap);
      bitmap = drawer.DrawLine(rightUpPoint, endPoint, bitmap);
      bitmap = drawer.DrawLine(endPoint, leftDownPoint, bitmap);
      bitmap = drawer.DrawLine(leftDownPoint, startPoint, bitmap);*/

      /* ПРЯМОУГОЛЬНИК 
      Point leftDownPoint = new Point(startPoint.X, endPoint.Y);
      Point rightUpPoint = new Point(endPoint.X, startPoint.Y);

      bitmap = drawer.DrawLine(startPoint, rightUpPoint, bitmap);
      bitmap = drawer.DrawLine(rightUpPoint, endPoint, bitmap);
      bitmap = drawer.DrawLine(endPoint, leftDownPoint, bitmap);
      bitmap = drawer.DrawLine(leftDownPoint, startPoint, bitmap);*/

      Point leftDownPoint = new Point(startPoint.X, endPoint.Y);
      Point rightUpPoint = new Point(endPoint.X, startPoint.Y);
      if (endPoint.X < startPoint.X && endPoint.Y < startPoint.Y)
      {
        if (Math.Abs(startPoint.X - endPoint.X) < Math.Abs(startPoint.Y - endPoint.Y))
        {
          leftDownPoint = new Point(startPoint.X, Math.Abs(startPoint.Y - Math.Abs(startPoint.X - endPoint.X)));
          endPoint = new Point(endPoint.X, Math.Abs(startPoint.Y - Math.Abs(startPoint.X - endPoint.X)));
        }
        else if (Math.Abs(startPoint.X - endPoint.X) > Math.Abs(startPoint.Y - endPoint.Y))
        {
          rightUpPoint = new Point((startPoint.X - Math.Abs(startPoint.Y - endPoint.Y)), startPoint.Y);
          endPoint = new Point((startPoint.X - Math.Abs(startPoint.Y - endPoint.Y)), endPoint.Y);
        }
      }
      else
      {
        if (Math.Abs(endPoint.X - startPoint.X) < Math.Abs(endPoint.Y - startPoint.Y))
        {
          leftDownPoint = new Point(startPoint.X, (startPoint.Y + Math.Abs(endPoint.X - startPoint.X)));
          endPoint = new Point(endPoint.X, (startPoint.Y + Math.Abs(endPoint.X - startPoint.X)));
        }
        else if (Math.Abs(endPoint.X - startPoint.X) > Math.Abs(endPoint.Y - startPoint.Y))
        {
          rightUpPoint = new Point((startPoint.X + Math.Abs(endPoint.Y - startPoint.Y)), startPoint.Y);
          endPoint = new Point((startPoint.X + Math.Abs(endPoint.Y - startPoint.Y)), endPoint.Y);
        }
      }
      bitmap = drawer.DrawLine(startPoint, rightUpPoint, bitmap);
      bitmap = drawer.DrawLine(rightUpPoint, endPoint, bitmap);
      bitmap = drawer.DrawLine(endPoint, leftDownPoint, bitmap);
      bitmap = drawer.DrawLine(leftDownPoint, startPoint, bitmap);

      return bitmap;

    }

  }
}
