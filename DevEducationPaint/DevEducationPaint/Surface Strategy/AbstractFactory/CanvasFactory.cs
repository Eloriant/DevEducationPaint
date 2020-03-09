using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Surface_Strategy.AbstractFactory
{
    class CanvasFactory : ISurfaceFactory
    {
        public ISurface CreateSurface()
        {
            return new CanvasSurface();
        }
    }
}
