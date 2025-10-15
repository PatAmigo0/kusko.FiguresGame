using System;
using System.Drawing;

namespace FiguresLib.Core.Shapes
{
    public class Rhomb : Figure
    {
        public Rhomb(Point[] points, Color color) : base(points, FigureType.Rhomb, color)
        {
            // pass
        }

        public double Side(Point point1, Point point2)
        {
            return point1.Lenght(point2);
        }

        public override bool IsContainPoint(Point point)
        {
            Triangle tr1 = new Triangle(new Point[]  { point, new Point(Points[0].X, Points[0].Y),
                                                    new Point(Points[1].X, Points[1].Y)}, Color);

            Triangle tr2 = new Triangle(new Point[]  { point, new Point(Points[1].X, Points[1].Y),
                                                    new Point(Points[2].X, Points[2].Y)}, Color);

            Triangle tr3 = new Triangle(new Point[]  { point, new Point(Points[2].X, Points[2].Y),
                                                    new Point(Points[3].X, Points[3].Y)}, Color);

            Triangle tr4 = new Triangle(new Point[]  { point, new Point(Points[3].X, Points[3].Y),
                                                    new Point(Points[0].X, Points[0].Y)}, Color);


            return Math.Round(tr1.Square() + tr2.Square() + tr3.Square() + tr4.Square(), 2) == Math.Round(this.Square(), 2);
        }

        public override double Perimeter()
        {
            return 4 * this.Side(Points[0], Points[1]);
        }

        public override double Square()
        {
            double square = this.Side(Points[0], Points[1]) * 
                this.Side(Points[0], Points[1]) * 
                Math.Sqrt(3) / 2;
            return square;
        }

        public override string ToString()
        {
            return $"Ромб: " + base.ToString();
        }
    }
}
