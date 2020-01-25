using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class PolygonCreator : FigureCreator
    {
        private int angleNumber;

        public PolygonCreator(int angleNumber)
        {
            this.angleNumber = angleNumber;
        }

        public override Figure CreateFigure(Point start, Point end)
        {
            start.X = Convert.ToInt32(start.X);
            start.Y = Convert.ToInt32(start.Y);
            end.X = Convert.ToInt32(end.X);
            end.Y = Convert.ToInt32(end.Y);
            int deltaX = Convert.ToInt32(Math.Abs(end.X - start.X));
            int deltaY = Convert.ToInt32(Math.Abs(end.Y - start.Y));
            int diametr = deltaX >= deltaY ? deltaX : deltaY;
            Point polygonsTop = new Point(0, diametr / 2);
            double angle = 2 * Math.PI / angleNumber;
            int i = angleNumber - 1;
            Point[] circuitsPoints = new Point[angleNumber];
            circuitsPoints = LineAngle(angle, angleNumber, polygonsTop, circuitsPoints);

            for (int idx = 0; idx < circuitsPoints.Length; idx++)
            {
                circuitsPoints[idx].X += startPoint.X;
                circuitsPoints[idx].Y += startPoint.Y - diametr / 2;
            }
            while (i > 0)
            {
                bitmap = drawer.DrawLine(circuitsPoints[i], circuitsPoints[i - 1], bitmap);
                i--;
            }
            bitmap = drawer.DrawLine(circuitsPoints[0], circuitsPoints[angleNumber - 1], bitmap);
            return bitmap;

            DrawByLine currentStrategy = new DrawByLine();
            switch (thickness)
            {
                case 1:
                    currentStrategy.ConcreteThickness = new DefaultThickness();
                    break;

            }
            currentStrategy.CurrentColor = new Color(255, 0, 0, 0);
            PolygonCreator result = new PolygonCreator(polygonPoints);
            result.ConcreteDraw = currentStrategy;
            return result;
        }
    }
}

