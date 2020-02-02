using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DevEducationPaint.Bitmap;

namespace DevEducationPaint.Share
{
  class Pixel
  {
    public static void SetPixel(Point pixelPoint, DrawColor color)
    {
      var rect = new System.Windows.Int32Rect(pixelPoint.X, pixelPoint.Y, 1, 1);
      SuperBitmap.GetInstanceCopy().WritePixels(rect, color.Instance, 4, 0);
    }
  }
}
