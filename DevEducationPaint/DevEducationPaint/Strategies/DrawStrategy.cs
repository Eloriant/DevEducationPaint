using DevEducationPaint.Bitmap;
using DevEducationPaint.Share;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Strategies
{
  public abstract class DrawStrategy
  {
        public abstract void DrawLineWithThickness(Point p1, Point p2);
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }

        protected int FindQuarter(Point prev, Point position)
        {
            int quarter = 0;
            if (position.X >= prev.X && position.Y >= prev.Y)
            {
                quarter = 4;
            }
            if (position.X <= prev.X && position.Y <= prev.Y)
            {
                quarter = 2;
            }
            if (position.X >= prev.X && position.Y <= prev.Y)
            {
                quarter = 1;
            }
            if (position.X <= prev.X && position.Y >= prev.Y)
            {
                quarter = 3;
            }
            return quarter;
        }

        protected void SetPixel(Point pixelPoint)
        {
            var rect = new System.Windows.Int32Rect(pixelPoint.X, pixelPoint.Y, 1, 1);
            SuperBitmap.GetInstanceCopy().WritePixels(rect, CurrentColor.Instance, 4, 0);
        }
    }
}
