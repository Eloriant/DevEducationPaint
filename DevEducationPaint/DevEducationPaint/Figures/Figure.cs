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
    public DrawStrategy ConcreteDraw { get; set; }
    public void Draw()
    {
      for (int i = 0; i < FigurePoints.Count; i++)
      {
        ConcreteDraw.DrawLineWithThickness(FigurePoints[i], i + 1 >= FigurePoints.Count ? FigurePoints[0] : FigurePoints[i + 1]);
      }

    }
  }
}
