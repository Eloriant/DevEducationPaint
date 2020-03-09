using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Surface_Strategy.AbstractFactory
{
    class BitmapFactory : ISurfaceFactory
    {
        public ISurface CreateSurface()
        {
            return new BitmapSurface();
        }
    }
}
