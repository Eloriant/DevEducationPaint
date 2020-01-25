﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Thicknesses
{
    public class BoldThickness : ThicknessStrategy
    {
        public override List<Point> GetPoints(Point point)
        {
            List<Point> result = new List<Point>();
            result.Add(point);
            return result;
        }
    }
}
