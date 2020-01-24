using System;
using System.Collections.Generic;
using System.Text;

namespace DevEducationPaint.Bitmap
{
    public class Bitmap
    {
        private static Bitmap instance;

        private Bitmap()
        { }

        public static Bitmap getInstance()
        {
            if (instance == null)
                instance = new Bitmap();
            return instance;
        }
    }
}
