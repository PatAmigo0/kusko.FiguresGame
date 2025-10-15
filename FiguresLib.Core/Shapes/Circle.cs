using System;
using System.Drawing;

namespace FiguresLib.Core.Shapes
{
    public class Circle : Figure
    {
        public Circle(Point[] points, Color color) : base(points, FigureType.Circle, color)
        {
            // pass
        }

        public double Radius()
        {
            return Points[0].Lenght(Points[1]);
        }

        public override bool IsContainPoint(Point point)
        {
            return (Math.Pow(point.X - Points[0].X, 2) + Math.Pow(point.Y - Points[0].Y, 2)) <= Math.Pow(Radius(), 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius();
        }

        public override double Square()
        {
            return Math.PI * Radius() * Radius();
        }

        public new Point FindCenter()
        {
            return Points[0];
        }

        public new void ChangeScale(double scaleFactor)
        {
            Point center = FindCenter();
            Point radiusPoint = Points[1];

            double dx = radiusPoint.X - center.X;
            double dy = radiusPoint.Y - center.Y;

            dx *= scaleFactor;
            dy *= scaleFactor;

            Points[1] = new Point(center.X + dx, center.Y + dy);
        }

        public override string ToString()
        {
            return $"Окружность: " + base.ToString();
        }
    }
}
