using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FiguresLib.Core.Shapes;

namespace FiguresLib.Core
{
    public class FigureFactory
    {
        private static readonly Random rand = new Random();
        private const int _maxColorValue = 256;
        private const int _maxSideDivisor = 8;
        private const int _minFigureSide = 20;

        private static readonly Dictionary<FigureType, Func<Point, double, Color, Figure>> FigureCreators = new Dictionary<FigureType, Func<Point, double, Color, Figure>>
        {
            [FigureType.Quadrant] = CreateQuadrant,
            [FigureType.Circle] = CreateCircle,
            [FigureType.Triangle] = CreateTriangle,
            [FigureType.Rhomb] = CreateRhomb,
            [FigureType.Hexagon] = CreateHexagon
        };

        public static Figure GetNewFigure(int maxX, int maxY, int minX = 0, int minY = 0)
        {
            var center = new Point(rand.Next(minX, maxX), rand.Next(minY, maxY));

            int maxSide = Math.Min(maxX, maxY) / _maxSideDivisor;
            if (maxSide <= _minFigureSide) maxSide = _minFigureSide + 1;
            double side = rand.Next(_minFigureSide, maxSide);

            var color = Color.FromArgb(rand.Next(_maxColorValue), rand.Next(_maxColorValue), rand.Next(_maxColorValue));
            var figureTypes = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
            var randomType = figureTypes[rand.Next(figureTypes.Count)];

            return FigureCreators[randomType](center, side, color);
        }

        #region Приватные методы создания фигур

        private static Figure CreateQuadrant(Point center, double side, Color color)
        {
            Point[] points = {
                new Point(center.X - side / 2, center.Y - side / 2),
                new Point(center.X + side / 2, center.Y + side / 2)
            };
            return new Quadrant(points, color);
        }

        private static Figure CreateCircle(Point center, double side, Color color)
        {
            Point[] points = { center, new Point(center.X + side, center.Y) };
            return new Circle(points, color);
        }

        private static Figure CreateTriangle(Point center, double side, Color color)
        {
            double height = Math.Sqrt(3) / 2 * side;
            Point[] points = {
                new Point(center.X, center.Y - height / 2),
                new Point(center.X - side / 2, center.Y + height / 2),
                new Point(center.X + side / 2, center.Y + height / 2),
            };
            return new Triangle(points, color);
        }

        private static Figure CreateRhomb(Point center, double side, Color color)
        {
            Point[] points = {
                new Point(center.X, center.Y - side),
                new Point(center.X + side / 2, center.Y),
                new Point(center.X, center.Y + side),
                new Point(center.X - side / 2, center.Y)
            };
            return new Rhomb(points, color);
        }

        private static Figure CreateHexagon(Point center, double side, Color color)
        {
            double yOffset = Math.Sqrt(3.0) * side / 2.0;
            Point[] points = {
                new Point(center.X - side, center.Y), new Point(center.X - side / 2, center.Y - yOffset),
                new Point(center.X + side / 2, center.Y - yOffset), new Point(center.X + side, center.Y),
                new Point(center.X + side / 2, center.Y + yOffset), new Point(center.X - side / 2, center.Y + yOffset)
            };
            return new Hexagon(points, color);
        }
        #endregion
    }
}

