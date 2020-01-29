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

        public List<Point> GetPointsByAngle(double angle, int angleNumber, Point polygonsTop)
        {
            double z = 0;
            int i = 1;
            List<Point> circuitsPoints = new List<Point>();
            circuitsPoints.Add(polygonsTop);

            while (i < angleNumber)
            {
                z += angle;
                circuitsPoints.Add(new Point(
                    Convert.ToInt32(polygonsTop.X * Math.Cos(z) - polygonsTop.Y * Math.Sin(z)),
                    Convert.ToInt32(polygonsTop.X * Math.Sin(z) + polygonsTop.Y * Math.Cos(z))
                ));
                i++;
            }
            return circuitsPoints;
        }

        public List<Point> GetPointsWithShift(List<Point> circuitsPoints, Point start, int diametr)
        {
            List<Point> polygonPoints = new List<Point>();
            for (int idx = 0; idx < circuitsPoints.Count; idx++)
            {
                polygonPoints.Add(new Point(
                    circuitsPoints[idx].X + start.X,
                    circuitsPoints[idx].Y + start.Y - diametr / 2
                ));
            };
            return polygonPoints;
        }

        //public List<Point> GetPointsWithShift(List<Point> circuitsPoints, Point start)
        //{
        //    List<Point> polygonPoints = new List<Point>();
        //    for (int idx = 0; idx < circuitsPoints.Count; idx++)
        //    {
        //        polygonPoints.Add(new Point(
        //            circuitsPoints[idx].X + start.X,
        //            Math.Abs(circuitsPoints[idx].Y - start.Y / 2)
        //        ));
        //    };
        //    return polygonPoints;
        //}

        public override Figure CreateFigure(Point start, Point end)
        {
            int diametr = GetFigureDiametr(start, end);
            Point polygonsTop = new Point(0, diametr / 2);
            double angle = 2 * Math.PI / angleNumber;
            List<Point> circuitsPoints = GetPointsByAngle(angle, angleNumber, polygonsTop);
            List<Point> polygonPoints = GetPointsWithShift(circuitsPoints, start, diametr);
            return new PolygonFigure(polygonPoints);
        }
    }
}