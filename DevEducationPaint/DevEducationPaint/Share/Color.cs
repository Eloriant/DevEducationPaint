using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Share
{
    public class DrawColor
    {
        public byte[] Instance { get; set; }


        public DrawColor(byte alpha, byte red, byte green, byte blue)
        {
            Instance = new byte[] {blue, green, red, alpha };
        }

        public System.Windows.Media.Color CurColor()
        {
          return System.Windows.Media.Color.FromArgb(Instance[3], Instance[2], Instance[1], Instance[0]);
        }
    }
}
