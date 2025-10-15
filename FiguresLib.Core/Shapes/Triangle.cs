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
            Triangle tr1 = new Triangle(new Point[]  { point, new Point(Points[0].X, Points[0].Y),
                                                    new Point(Points[1].X, Points[1].Y)}, Color);

            Triangle tr2 = new Triangle(new Point[]  { point, new Point(Points[1].X, Points[1].Y),
                                                    new Point(Points[2].X, Points[2].Y)}, Color);

            Triangle tr3 = new Triangle(new Point[]  { point, new Point(Points[0].X, Points[0].Y),
                                                    new Point(Points[2].X, Points[2].Y)}, Color);


            return Math.Round(tr1.Square() + tr2.Square() + tr3.Square(), 2) == Math.Round(this.Square(), 2);
        }

        public override double Perimeter()
        {
            return 3 * this.Side(new Point[] { Points[0], Points[1] });
        }
            
        public override double Square()
        {
            double square = 0;
            double side1 = this.Side(new Point[] { this.Points[0], this.Points[1] });
            double side2 = this.Side(new Point[] { this.Points[0], this.Points[2] });
            double side3 = this.Side(new Point[] { this.Points[1], this.Points[2] });
            double p = (side1 + side2 + side3) / 2;
            square = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
            return square;
        }

        public override string ToString()
        {
            return $"Треугольник: " + base.ToString();
        }
    }
}
