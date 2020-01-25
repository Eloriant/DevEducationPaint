using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class TriangleCreator : FigureCreator
    {
        public override Figure CreateFigure(Point start, Point end, int thickness)
        {

            //List<Point> trianglePoints = new List<Point>();
            DrawByLine currentStrategy = new DrawByLine();
            Point high = new Point(start.X, end.Y);  // код для прямоугольного треугольника
            List<Point> firstSide = currentStrategy.DrawLine(start, high);
            DrawByLine(startPoint, endPoint, bitmap);
            DrawByLine(startPoint, high, bitmap);
            DrawByLine(high, endPoint, bitmap);

          
            switch (thickness)
            {
                case 1:
                    currentStrategy.ConcreteThickness = new DefaultThickness();
                    break;

            }
            currentStrategy.CurrentColor = new Color(255, 0, 0, 0);
            CircleFigure result = new CircleFigure(trianglePoints);
            result.ConcreteDraw = currentStrategy;
            return result;
        }

    }
}

