using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Point = System.Drawing.Point;

namespace DevEducationPaint.Figures
{
    public abstract class Figure
    {
        public List<Point> FigurePoints { get; set; }
        public IDrawStrategy ConcreteDraw { get; set; }
        public void Draw(bool isVector)
        {
            for (int i = 0; i < FigurePoints.Count; i++)
            {
                ConcreteDraw.CalculatePointsForDrawMethod(FigurePoints[i], i + 1 >= FigurePoints.Count ? FigurePoints[0] : FigurePoints[i + 1], isVector);
            }
        }
    }
}
