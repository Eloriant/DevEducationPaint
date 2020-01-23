using DevEducationPaint.DrawStrategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Strategies
{
    public class DrawByLine : IDrawStrategy
    {
        public List<Point> DrawLine(Point p1, Point p2)
        {
            List<Point> Points = new List<Point>();
            //реализация метода
            return Points;
        }

        public Color CurrentColor { get; set; }
        public ThicknessStrategy ConcreteThickness { get; set; }
    }
}
