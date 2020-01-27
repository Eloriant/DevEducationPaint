using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace DevEducationPaint.FigureCreators
{
    public class SquareCreator : FigureCreator
    {
        public override Figure CreateFigure(Point start, Point end)
        {
          /*  Прямоугольник 
            Point leftDownPoint = new Point(start.X, end.Y);
            Point rightUpPoint = new Point(end.X, start.Y);

            List<Point> squarePoints = new List<Point>();

            squarePoints.Add(start);
            squarePoints.Add(rightUpPoint);
            squarePoints.Add(end);
            squarePoints.Add(leftDownPoint);

            return new SquareFigure(squarePoints); */


            // Квадрат

            Point leftDownPoint = new Point(start.X, end.Y);
            Point rightUpPoint = new Point(end.X, start.Y);

            List<Point> squarePoints = new List<Point>();

            if (end.X < start.X && end.Y < start.Y)
            {
                if (Math.Abs(start.X - end.X) < Math.Abs(start.Y - end.Y))
                {
                    leftDownPoint = new Point(start.X, Math.Abs(start.Y - Math.Abs(start.X - end.X)));
                    end = new Point(end.X, Math.Abs(start.Y - Math.Abs(start.X - end.X)));
                }
                else if (Math.Abs(start.X - end.X) > Math.Abs(start.Y - end.Y))
                {
                    rightUpPoint = new Point((start.X - Math.Abs(start.Y - end.Y)), start.Y);
                    end = new Point((start.X - Math.Abs(start.Y - end.Y)), end.Y);
                }
            }
            else
            {
                if (Math.Abs(end.X - start.X) < Math.Abs(end.Y - start.Y))
                {
                    leftDownPoint = new Point(start.X, (start.Y + Math.Abs(end.X - start.X)));
                    end = new Point(end.X, (start.Y + Math.Abs(end.X - start.X)));
                }
                else if (Math.Abs(end.X - start.X) > Math.Abs(end.Y - start.Y))
                {
                    rightUpPoint = new Point((start.X + Math.Abs(end.Y - start.Y)), start.Y);
                    end = new Point((start.X + Math.Abs(end.Y - start.Y)), end.Y);
                }
            }
            squarePoints.Add(start);
            squarePoints.Add(rightUpPoint);
            squarePoints.Add(end);
            squarePoints.Add(leftDownPoint);

            return new SquareFigure(squarePoints);
        }

    }
}
