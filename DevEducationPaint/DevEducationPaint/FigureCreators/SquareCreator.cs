using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace DevEducationPaint.FigureCreators
{
    public class SquareCreator : FigureCreator
    {
        bool shiftPressed;
        public SquareCreator(bool shiftPressed)
        {
            this.shiftPressed = shiftPressed;
        }
        public override Figure CreateFigure(Point start, Point end)
        {
            List<Point> squarePoints = new List<Point>();
            if (shiftPressed)//квадрат
            {
                //вправо вверх
                if (end.X > start.X && end.Y < start.Y)
                {
                    int deltaX = end.X - start.X;
                    int deltaY = start.Y - end.Y;
                    int deltaCurrent = deltaX <= deltaY ? deltaX : deltaY;
                    Point point1 = new Point(start.X, start.Y - deltaCurrent);
                    Point point2 = new Point(start.X + deltaCurrent, start.Y);
                    Point pointEnd = new Point(start.X + deltaCurrent, start.Y - deltaCurrent);
                    squarePoints.Add(start);
                    squarePoints.Add(point1);
                    squarePoints.Add(pointEnd);
                    squarePoints.Add(point2);
                    return new SquareFigure(squarePoints);
                }
                //влево вверх
                else if (end.X < start.X && end.Y < start.Y)
                {
                    int deltaX = start.X - end.X;
                    int deltaY = start.Y - end.Y;
                    int deltaCurrent = deltaX <= deltaY ? deltaX : deltaY;
                    Point point1 = new Point(start.X, start.Y - deltaCurrent);
                    Point point2 = new Point(start.X - deltaCurrent, start.Y);
                    Point pointEnd = new Point(start.X - deltaCurrent, start.Y - deltaCurrent);
                    squarePoints.Add(point2);
                    squarePoints.Add(pointEnd);
                    squarePoints.Add(point1);
                    squarePoints.Add(start);
                    return new SquareFigure(squarePoints);
                }
                //вправо вниз
                else if (end.X > start.X && end.Y > start.Y)
                {
                    int deltaX = end.X - start.X;
                    int deltaY = end.Y - start.Y;
                    int deltaCurrent = deltaX <= deltaY ? deltaX : deltaY;
                    Point point1 = new Point(start.X + deltaCurrent, start.Y);
                    Point point2 = new Point(start.X, start.Y + deltaCurrent);
                    Point pointEnd = new Point(start.X + deltaCurrent, start.Y + deltaCurrent);
                    squarePoints.Add(point2);
                    squarePoints.Add(start);
                    squarePoints.Add(point1);
                    squarePoints.Add(pointEnd);
                    return new SquareFigure(squarePoints);
                }
                //влево вниз
                else if (end.X < start.X && end.Y > start.Y)
                {
                    int deltaX = start.X - end.X;
                    int deltaY = end.Y - start.Y;
                    int deltaCurrent = deltaX <= deltaY ? deltaX : deltaY;
                    Point point1 = new Point(start.X, start.Y + deltaCurrent);
                    Point point2 = new Point(start.X - deltaCurrent, start.Y);
                    Point pointEnd = new Point(start.X - deltaCurrent, start.Y + deltaCurrent);
                    squarePoints.Add(pointEnd);
                    squarePoints.Add(point2);
                    squarePoints.Add(start);
                    squarePoints.Add(point1);
                    return new SquareFigure(squarePoints);
                }
                else
                {
                    return new SquareFigure(squarePoints);
                }
            }
            else//прямоугольник
            {
                Point leftDownPoint = new Point(start.X, end.Y);
                Point rightUpPoint = new Point(end.X, start.Y);

                squarePoints.Add(start);
                squarePoints.Add(rightUpPoint);
                squarePoints.Add(end);
                squarePoints.Add(leftDownPoint);

                return new SquareFigure(squarePoints);
            }
        }
    }
}

