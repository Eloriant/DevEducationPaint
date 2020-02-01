using DevEducationPaint.Share;
using DevEducationPaint.Thicknesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Surface_Strategy
{
    class DrawOnBitmap : ISurfaceStrategy
    {
        public DrawColor CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
        public void DrawLine()
        {

        }
    }
}
