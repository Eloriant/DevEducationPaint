using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Share
{
    public class DrawColor
    {
        public byte[] Instance { get; set; }

        public DrawColor(byte alpha, byte red, byte green, byte blue)
        {
            Instance = new byte[] { alpha, red, green, blue };
        }
    }
}
