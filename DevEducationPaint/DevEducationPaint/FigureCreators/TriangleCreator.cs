using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class TriangleCreator : FigureCreator
    {

        bool shiftPressed;
        bool ctlrPressed;
        public TriangleCreator(bool shiftPressed, bool ctlrPressed)
        {
            this.shiftPressed = shiftPressed;
            this.ctlrPressed = ctlrPressed;
        }
        public override Figure CreateFigure(Point start, Point end)
        {
            if (shiftPressed)
            {
                Point high = new Point(start.X, end.Y);  // код для прямоугольного треугольника

                List<Point> trianglePoints = new List<Point>();

                trianglePoints.Add(start);
                trianglePoints.Add(end);
                trianglePoints.Add(high);

                return new TriangleFigure(trianglePoints);
            }
           else if (ctlrPressed)
            {
                Point high = new Point(start.X - (end.X - start.X), end.Y);//Равнобедренный треугольник

                List<Point> trianglePoints = new List<Point>();

                trianglePoints.Add(start);
                trianglePoints.Add(end);
                trianglePoints.Add(high);

                return new TriangleFigure(trianglePoints);
            }

            else
            {
                List<Point> trianglePoints = new List<Point>();// код для равностороннего треугольника + метод для поиска третьей вершины треугольника через поворот

                trianglePoints.Add(start);
                trianglePoints.Add(end);
                Point high1 = GetPointHigh(start, end);
                trianglePoints.Add(high1);
                return new TriangleFigure(trianglePoints);
            }
        }

        public Point GetPointHigh(Point startPoint, Point endPoint)
        {
            Double weigth = Math.Abs(endPoint.X - startPoint.X);
            Double high = Math.Abs(endPoint.Y - startPoint.Y);
            int findX;
            int findY;
            if (endPoint.X > startPoint.X)
            {
                if (endPoint.Y > startPoint.Y)
                {
                    findX = Convert.ToInt32(weigth * Math.Cos(Math.PI / 3) - high * Math.Sin(Math.PI / 3) + startPoint.X);
                    findY = Convert.ToInt32(weigth * Math.Sin(Math.PI / 3) + high * Math.Cos(Math.PI / 3) + startPoint.Y);
                }
                else
                {
                    findX = Convert.ToInt32(Math.Abs(weigth * Math.Cos(Math.PI / 3) - high * Math.Sin(Math.PI / 3) - endPoint.X));
                    findY = Convert.ToInt32(weigth * Math.Sin(Math.PI / 3) + high * Math.Cos(Math.PI / 3) + endPoint.Y);
                }
            }
            else
            {
                if (endPoint.Y > startPoint.Y)
                {
                    findX = Convert.ToInt32(endPoint.X + weigth * Math.Cos(Math.PI / 3) - high * Math.Sin(Math.PI / 3));
                    findY = Convert.ToInt32(endPoint.Y - (weigth * Math.Sin(Math.PI / 3) + high * Math.Cos(Math.PI / 3)));
                }

                else
                {
                    findX = Convert.ToInt32(startPoint.X + Math.Abs(weigth * Math.Cos(Math.PI / 3) - high * Math.Sin(Math.PI / 3)));
                    if (high == 0)
                    {
                        findX = Convert.ToInt32(endPoint.X + Math.Abs(weigth * Math.Cos(Math.PI / 3) - high * Math.Sin(Math.PI / 3)));
                    }
                    if (weigth != 0 && Math.Atan(high / weigth) <= Math.PI / 6)
                    {
                        findX = Convert.ToInt32(endPoint.X + Math.Abs(weigth * Math.Cos(Math.PI / 3) + high * Math.Sin(Math.PI / 3)));
                    }
                    findY = Convert.ToInt32(startPoint.Y - (weigth * Math.Sin(Math.PI / 3) + high * Math.Cos(Math.PI / 3)));
                }
            }
            return new Point(findX, findY);
        }
    }
}

