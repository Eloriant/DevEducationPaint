using DevEducationPaint.Figures;
using DevEducationPaint.Share;
using DevEducationPaint.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEducationPaint.FigureCreators
{
    public class BrokenLineCreator : FigureCreator
    {
        //List<Point> alllinePoints = new List<Point>();
        //List<Point> linePoints = new List<Point>();
        public override Figure CreateFigure(Point start, Point end)
        {
            List<Point> linePoints = new List<Point>();
            linePoints.Add(start);
            linePoints.Add(end);

            //if (alllinePoints.Count == 0 || alllinePoints.Count > 1)
            //{
            //    alllinePoints.Add(start);
            //}

            return new BrokenLineFigure(linePoints);
        }

        //    public List<Point> GetPoints(bool isDoubleClicked)
        //    {
        //    if (!isDoubleClicked)
        //    {
        //        return new BrokenLineFigure(this.CreateFigure();
        //    }
        //    else 
        //    { 
                
        //        return new ;
        //    }

        //}
    }
}
