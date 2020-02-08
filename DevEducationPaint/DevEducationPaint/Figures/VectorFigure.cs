using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Shapes;
using DevEducationPaint.Share;

namespace DevEducationPaint.Figures
{
    public class VectorFigure : Figure
    {
        public List<Line> lines { get; set; }

        //FigurePoints[i], i + 1 >= FigurePoints.Count? FigurePoints[0] : FigurePoints[i + 1]
        private List<Line> CreateVectorFigure(List<Point> points)
        {
            List<Line> figureLine = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                figureLine.Add(new Line()
                {
                    X1 = points[i].X,
                    Y1 = points[i].Y,
                    X2 = i + 1 >= points.Count ? points[0].X : points[i + 1].X,
                    Y2 = i + 1 >= points.Count ? points[0].Y : points[i + 1].Y
                });
            }

            return figureLine;
        }

        public VectorFigure(List<Point> points)
        {
            lines = CreateVectorFigure(points);
        }


        //public new List<Point> FigurePoints { get; set; }
        public List<Line> FigureLine { get; set; }

    }


}

