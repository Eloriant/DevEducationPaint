using DevEducationPaint.Share;
using DevEducationPaint.Surface_Strategy;
using DevEducationPaint.Thicknesses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Strategies
{
    public class DrawByDash : IDrawStrategy
    {
        public ISurfaceStrategy SurfaceStrategy { get; set; }

        public void DrawLine(Point p1, Point p2)
        {
            throw new NotImplementedException();
        }
    }
}
