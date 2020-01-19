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
    public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, System.Windows.Point startPoint, System.Windows.Point endPoint)
    {
      //AB = √(xb - xa)2 + (yb - ya)2
      //vec2 Center = ({ 1}+{ 2})/ 2
      //vec2 HalfDiagonal = cross2d({ 1}-Center);
      //{ 3} = Center + HalfDiagonal;
      //{ 4} = Center - HalfDiagonal;

      var center = (Math.Pow(Math.Sqrt(endPoint.X - startPoint.X), 2) +
                    Math.Pow(Math.Sqrt(endPoint.Y - startPoint.Y), 2)) / 2;
      //var halfDiogonal = 
      Point leftDownPoint = new Point(startPoint.Y,endPoint.X);
      Point rightUpPoint = new Point(startPoint.X,endPoint.Y);

      bitmap = drawer.DrawLine(startPoint, rightUpPoint, bitmap);
      bitmap = drawer.DrawLine(rightUpPoint, endPoint, bitmap);
      bitmap = drawer.DrawLine(endPoint, leftDownPoint, bitmap);
      bitmap = drawer.DrawLine(leftDownPoint, startPoint, bitmap);
      return bitmap;
    }
  }
}
