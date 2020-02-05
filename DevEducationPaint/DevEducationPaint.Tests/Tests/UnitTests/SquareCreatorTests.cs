using DevEducationPaint.Thicknesses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DevEducationPaint.Figures;
using DevEducationPaint.Strategies;
using DevEducationPaint.FigureCreators;

namespace DevEducationPaint.Tests
{
    [TestFixture]
    class SquareCreatorTests
    {
        public Point GetPointByName(string pointName)
        {
            switch (pointName)
            {
                case "pointStart":
                    return new Point(212, 242);
                case "pointEnd":
                    return new Point(214, 244);
                case "pointStart1":
                    return new Point(398, 150);
                case "pointEnd1":
                    return new Point(400, 151);
                case "pointStart2":
                    return new Point(345, 166);
                case "pointEnd2":
                    return new Point(346, 167);
                case "pointStart3":
                    return new Point(345, 235);
                case "pointEnd3":
                    return new Point(344, 236);
                default:
                    return new Point();
            }
        }

        public SquareFigure GetSquareByName(string name)
        {
            switch (name)
            {
                case "expectedSquare":
                    return new SquareFigure(
                        new List<Point>
                        {
                            new Point(212,242),
                            new Point(214,242),
                            new Point(214,244),
                            new Point(212,244)
                        }
                    );
                case "expectedSquare1":
                    return new SquareFigure(
                        new List<Point>
                        {
                            new Point(398,150),
                            new Point(400,150),
                            new Point(400,151),
                            new Point(398,151)
                        }
                        );
                case "expectedSquare2":
                    return new SquareFigure(
                        new List<Point>
                        {
                            new Point(345,167),
                            new Point(345,166),
                            new Point(346,166),
                            new Point(346,167)
                        }
                        );
                case "expectedSquare3":
                    return new SquareFigure(
                        new List<Point>
                        {
                            new Point(344,236),
                            new Point(344,235),
                            new Point(345,235),
                            new Point(345,236)
                        }
                        );
                default:
                    return new SquareFigure(new List<Point>());
            }
        }

        [TestCase("pointStart", "pointEnd", "expectedSquare")] // для прямоугольника
        public void SquareCreateTest(string pointStart, string pointEnd, string expectedSquare)
        {
            SquareCreator squareCreator = new SquareCreator(false);
            SquareFigure expected = GetSquareByName(expectedSquare);
            Point start = GetPointByName(pointStart);
            Point end = GetPointByName(pointEnd);
            Figure actual = squareCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }

        [TestCase("pointStart1", "pointEnd1", "expectedSquare1")] // для прямоугольника
        public void SquareCreateTest1(string pointStart1, string pointEnd1, string expectedSquare)
        {
            SquareCreator squareCreator = new SquareCreator(false);
            SquareFigure expected = GetSquareByName(expectedSquare);
            Point start = GetPointByName(pointStart1);
            Point end = GetPointByName(pointEnd1);
            Figure actual = squareCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }

        [TestCase("pointStart2", "pointEnd2", "expectedSquare2")] // тест для квадрата с shift 
        public void SquareCreateTest2(string pointStart2, string pointEnd2, string expectedSquare)
        {
            SquareCreator squareCreator = new SquareCreator(true);
            SquareFigure expected = GetSquareByName(expectedSquare);
            Point start = GetPointByName(pointStart2);
            Point end = GetPointByName(pointEnd2);
            Figure actual = squareCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }

        [TestCase("pointStart3", "pointEnd3", "expectedSquare3")] // тест для квадрата с shift № 2 (влево-вниз)
        public void SquareCreateTest3(string pointStart3, string pointEnd3, string expectedSquare)
        {
            SquareCreator squareCreator = new SquareCreator(true);
            SquareFigure expected = GetSquareByName(expectedSquare);
            Point start = GetPointByName(pointStart3);
            Point end = GetPointByName(pointEnd3);
            Figure actual = squareCreator.CreateFigure(start, end);
            CollectionAssert.AreEqual(expected.FigurePoints, actual.FigurePoints);
        }
    }
}
