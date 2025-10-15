using System;

namespace FiguresLib.Core
{
    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Lenght(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - X, 2) +
                             Math.Pow(point.Y - Y, 2));
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator +(Point a, int b)
        {
            return new Point(a.X + b, a.Y + b);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point operator -(Point a, int b)
        {
            return new Point(a.X - b, a.Y - b);
        }

        public static Point operator /(Point a, Point b)
        {
            return new Point(a.X / b.X, a.Y / b.Y);
        }

        public static Point operator /(Point a, int b)
        {
            return new Point(a.X / b, a.Y / b);
        }
    }
}
