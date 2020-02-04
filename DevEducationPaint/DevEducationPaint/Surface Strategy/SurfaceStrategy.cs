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

      
  }
}
