using DevEducationPaint.DrawStrategy;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Strategies
{
  public interface IDrawStrategy
  {
        public List<Point> DrawLine(Point p1, Point p2);
        public Color CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
  }
}
