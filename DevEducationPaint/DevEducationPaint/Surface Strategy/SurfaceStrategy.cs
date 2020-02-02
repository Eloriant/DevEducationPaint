using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Surface_Strategy
{
    public interface ISurfaceStrategy
    {
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
        public void DrawLine(Point p1, Point p2);

        public int FindQuarter(Point prev, Point position)
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
  }
}
