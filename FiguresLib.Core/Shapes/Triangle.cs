using System;
using System.Drawing;

namespace FiguresLib.Core.Shapes
{
    public class Triangle : Figure
    {
        public Triangle(Point[] points, Color color) : base(points, FigureType.Triangle, color)
        {
            // pass
        }

        public double Side(Point[] points)
        {
            return Points[0].Lenght(points[1]);
        }

        public override bool IsContainPoint(Point point)
        {
            Point p1 = Points[0], p2 = Points[1], p3 = Points[2];

            double sign1 = (p1.X - point.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p1.Y - point.Y);
            double sign2 = (p2.X - point.X) * (p3.Y - p2.Y) - (p3.X - p2.X) * (p2.Y - point.Y);
            double sign3 = (p3.X - point.X) * (p1.Y - p3.Y) - (p1.X - p3.X) * (p3.Y - point.Y);

            bool has_neg = (sign1 < 0) || (sign2 < 0) || (sign3 < 0);
            bool has_pos = (sign1 > 0) || (sign2 > 0) || (sign3 > 0);

            return !(has_neg && has_pos);
        }

        public override double Perimeter()
        {
            return 3 * this.Side(new Point[] { Points[0], Points[1] });
        }
            
        public override double Square()
        {
            double side1 = this.Side(new Point[] { this.Points[0], this.Points[1] });
            double side2 = this.Side(new Point[] { this.Points[0], this.Points[2] });
            double side3 = this.Side(new Point[] { this.Points[1], this.Points[2] });
            double p = (side1 + side2 + side3) / 2;

            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

        public override string ToString()
        {
            return $"Треугольник: " + base.ToString();
        }
    }
}
