using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Surface_Strategy.AbstractFactory
{
    interface ISurfaceFactory
    {
        public ISurface CreateSurface();
    }
}
