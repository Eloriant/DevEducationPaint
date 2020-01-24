using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Share
{
    public class DrawColor
    {
        private static byte[] instance;

        private DrawColor()
        { }

        public static byte[] getInstance()
        {
            if (instance == null)
                instance =new byte[] { 255, 0,0, 0};
            return instance;
        }
    }
}
