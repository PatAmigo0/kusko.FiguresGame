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
            return IsPointInPolygon(point, this.Points);
        }

        public override double Perimeter()
        {
            return 4 * this.Side(Points[0], Points[1]);
        }

        public override double Square()
        {
            double diagonal1 = Points[0].Lenght(Points[2]);
            double diagonal2 = Points[1].Lenght(Points[3]);
            return (diagonal1 * diagonal2) / 2.0;
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
            return $"Ромб: " + base.ToString();
        }
    }
}
