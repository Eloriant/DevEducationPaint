using DevEducationPaint.Bitmap;
using DevEducationPaint.Share;
using DevEducationPaint.Surface_Strategy;
using DevEducationPaint.Thicknesses;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Strategies
{
  public abstract class IDrawStrategy    ///   это стратегия говорит о том, какие именно линии мы рисуем - пунктирные, сплошные, волнистые
  {
        public abstract void CalculatePointsForDrawMethod(Point p1, Point p2);
        public ISurfaceStrategy SurfaceStrategy { get; set; }

  }
}


//это должно быть нутри серфэйс стрэтежджи upd: перенесла
//public DrawColor CurrentColor { get; set; }
//public ThicknessStrategy ConcreteThickness { get; set; }
//

//protected int FindQuarter(Point prev, Point position)
//{
//    int quarter = 0;
//    if (position.X >= prev.X && position.Y >= prev.Y)
//    {
//        quarter = 4;
//    }
//    if (position.X <= prev.X && position.Y <= prev.Y)
//    {
//        quarter = 2;
//    }
//    if (position.X >= prev.X && position.Y <= prev.Y)
//    {
//        quarter = 1;
//    }
//    if (position.X <= prev.X && position.Y >= prev.Y)
//    {
//        quarter = 3;
//    }
//    return quarter;
//}

//protected void SetPixel(Point pixelPoint)
//{
//    var rect = new System.Windows.Int32Rect(pixelPoint.X, pixelPoint.Y, 1, 1);
//    SuperBitmap.GetInstanceCopy().WritePixels(rect, SurfaceStrategy.CurrentColor.Instance, 4, 0);
//}


