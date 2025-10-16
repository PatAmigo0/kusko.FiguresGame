using System;
using System.Drawing;

namespace FiguresLib.Core.Shapes
{
    public class Hexagon : Figure
    {
        public Hexagon(Point[] points, Color color) : base(points, FigureType.Hexagon, color)
        {
            // pass
        }

        public double Side(Point point1, Point point2)
        {
            return point1.Lenght(point2);
        }

        public override bool IsContainPoint(Point point)
        {
            return IsPointInPolygon(point, this.Points);
        }

        public override double Perimeter()
        {
            return 6 * this.Side(Points[0], Points[1]);
        }

        public override double Square()
        {
            double square =
                3 * Math.Sqrt(3.0) *
                this.Side(Points[0], Points[1]) *
                this.Side(Points[0], Points[1]) /
                2;
            return square;
        }

        private bool IsPointInPolygon(Point point, Point[] polygon)
        {
            bool result = false;
            int j = polygon.Length - 1;
            for (int i = 0; i < polygon.Length; i++)
            {
                if ((polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y) &&
                    (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X))
                {
                    result = !result;
                }
                j = i;
            }
            return result;
        }

        public override string ToString()
        {
            return $"Шестиугольник: " + base.ToString();
        }
    }
}
