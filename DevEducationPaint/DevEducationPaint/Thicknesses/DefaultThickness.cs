using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEducationPaint.Thicknesses
{
    public class DefaultThickness : ThicknessStrategy
    {
        private Point point;

        public DefaultThickness(Point point)
        {
            this.point = point;
        }
        public override List<Point> GetPoints(Point point)
        {
            List<Point> result = new List<Point>();
            result.Add(point);
            return result;
        }
    }
}
