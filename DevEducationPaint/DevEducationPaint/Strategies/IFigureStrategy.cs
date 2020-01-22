using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using Point = System.Windows.Point;

namespace DevEducationPaint.Strategies
{
  public interface IFigureStrategy
  {
    public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint, int angleNumber = -1);
  }
}
