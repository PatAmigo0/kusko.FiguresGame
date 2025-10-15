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

        // константы для ясности
        private const int MaxColorValue = 256; // макс не включается для rgb, поэтому генерируется 0-255
        private const int MaxSideDivisor = 8;

        // словарь для хранения логики создания каждого типа фигуры
        private static readonly Dictionary<FigureType, Func<Point, double, Color, Figure>> FigureCreators = new Dictionary<FigureType, Func<Point, double, Color, Figure>>
        {
            [FigureType.Quadrant] = CreateQuadrant,
            [FigureType.Circle] = CreateCircle,
            [FigureType.Triangle] = CreateTriangle,
            [FigureType.Rhomb] = CreateRhomb,
            [FigureType.Hexagon] = CreateHexagon
        };

        /// <summary>
        /// Создает новую случайную фигуру в указанных границах
        /// </summary>
        public static Figure GetNewFigure(int maxX, int maxY, int minX = 0, int minY = 0)
        {

            var center = new Point(rand.Next(minX, maxX), rand.Next(minY, maxY));
            double side = rand.Next(1, Math.Min(maxX, maxY) / MaxSideDivisor);
            var color = Color.FromArgb(rand.Next(MaxColorValue), rand.Next(MaxColorValue), rand.Next(MaxColorValue));

            var figureTypes = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToList();
            var randomType = figureTypes[rand.Next(figureTypes.Count)];

            return FigureCreators[randomType](center, side, color);
        }

        #region Приватные методы создания для каждой фигуры
        /** ----------------------------------------------------
         * приватные методы создания для каждой фигуры
         * эти методы инкапсулируют логику расчета вершин
         * примечание: предполагается, что конструкторы фигур принимают Point[]
         */

        private static Figure CreateQuadrant(Point center, double side, Color color)
        {
            Point[] points =
            {
                new Point(center.X, center.Y),
                new Point(center.X + side, center.Y + side)
            };

            return new Quadrant(points, color);
        }

        private static Figure CreateCircle(Point center, double side, Color color)
        {
            Point[] points =
            {
                new Point(center.X, center.Y),
                new Point(center.X + side, center.Y + side)
            };

            return new Circle(points, color);
        }

        private static Figure CreateTriangle(Point center, double side, Color color)
        {
            Point[] points =
            {
                new Point(center.X - side, center.Y + side),
                new Point(center.X + side, center.Y + side),
                new Point(center.X, center.Y)
            };

            return new Triangle(points, color);
        }

        private static Figure CreateRhomb(Point center, double side, Color color)
        {
            double verticalOffset = Math.Sqrt(3) * side;
            Point[] points =
            {
                new Point(center.X, center.Y - verticalOffset),
                new Point(center.X + side, center.Y),
                new Point(center.X, center.Y + verticalOffset),
                new Point(center.X - side, center.Y)
            };

            return new Rhomb(points, color);
        }

        private static Figure CreateHexagon(Point center, double side, Color color)
        {

            double yOffset = Math.Sqrt(3.0) * side / 2.0;
            Point[] points =
            {
                new Point(center.X + side / 2, center.Y - yOffset),
                new Point(center.X + side, center.Y),
                new Point(center.X + side / 2, center.Y + yOffset),
                new Point(center.X - side / 2, center.Y + yOffset),
                new Point(center.X - side, center.Y),
                new Point(center.X - side / 2, center.Y - yOffset)
            };

            return new Hexagon(points, color);
        }

        #endregion
    }
}