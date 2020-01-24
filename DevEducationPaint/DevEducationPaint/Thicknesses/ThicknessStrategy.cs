using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

namespace DevEducationPaint.DrawStrategy
{
    public abstract class ThicknessStrategy
    {
        public abstract List<Point> GetPoints(Point start);
        //задать толщину
    }
}
