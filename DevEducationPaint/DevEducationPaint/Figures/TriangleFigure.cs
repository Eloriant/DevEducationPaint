using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Text;
using System.Windows.Media.Imaging;
using DevEducationPaint.Drawers;
using DevEducationPaint.Strategies;
using Point = System.Windows.Point;

namespace DevEducationPaint.Figures
{
    class TriangleFigure : IFigureStrategy
    {
        private RastrDrawer drawer = RastrDrawer.GetDrawer();
        public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, System.Windows.Point startPoint, System.Windows.Point endPoint, int angleNumber = -1)
        {
            //Point high = new Point(startPoint.X, endPoint.Y);  // код для прямоугольного треугольника
            //bitmap = drawer.DrawLine(startPoint, endPoint, bitmap);
            //bitmap = drawer.DrawLine(startPoint, high, bitmap);
            //bitmap = drawer.DrawLine(high, endPoint, bitmap);

            Point high = new Point(startPoint.X-(endPoint.X - startPoint.X), endPoint.Y);  // код для равнобедренного треугольника
            bitmap = drawer.DrawLine(startPoint, endPoint, bitmap);
            bitmap = drawer.DrawLine(startPoint, high, bitmap);
            bitmap = drawer.DrawLine(high, endPoint, bitmap);

            //bitmap = drawer.DrawLine(startPoint, endPoint, bitmap);  // код для равностороннего треугольника + метод для поиска третьей вершины треугольника через поворот
            //Point high1 = GetPointHigh(startPoint, endPoint);
            //bitmap = drawer.DrawLine(endPoint, high1, bitmap);
            //Point startXY = new Point(startPoint.X, startPoint.Y);
            //bitmap = drawer.DrawLine(high1, startXY, bitmap);

            return bitmap;
        }

        public WriteableBitmap DrawAlgorithm(WriteableBitmap bitmap, Point startPoint, Point endPoint)
        {
          throw new NotImplementedException();
        }

        Point GetPointHigh(System.Windows.Point startPoint, System.Windows.Point endPoint)
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

