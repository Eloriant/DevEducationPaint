using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;

namespace DevEducationPaint.Surface_Strategy.AbstractFactory
{
    public interface ISurface
    {
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
        public void DrawLine(Point p1, Point p2);
    }
}
