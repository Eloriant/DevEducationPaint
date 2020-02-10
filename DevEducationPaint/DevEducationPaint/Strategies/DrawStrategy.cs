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
        public abstract void CalculatePointsForDrawMethod(Point p1, Point p2, bool isVector);
        public ISurfaceStrategy SurfaceStrategy { get; set; }
        public static IDrawStrategy DrawByLine { get; set; }
    }
}


