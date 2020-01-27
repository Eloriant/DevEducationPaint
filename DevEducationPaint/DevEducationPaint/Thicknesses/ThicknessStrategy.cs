using System.Collections.Generic;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Thicknesses
{
    public abstract class ThicknessStrategy
    {
        public abstract List<Point> GetPoints(Point point);
        //задать толщину
    }
}
