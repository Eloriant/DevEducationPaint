using System.Collections.Generic;
using Point = System.Drawing.Point;

namespace DevEducationPaint.DrawStrategy
{
    public abstract class ThicknessStrategy
    {
        public abstract List<Point> GetPoints(Point start);
        //задать толщину
    }
}
