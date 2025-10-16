using System;
using System.Drawing;

namespace FiguresLib.Core.Shapes
{
    public class Quadrant : Figure
    {
        public Quadrant(Point[] points, Color color) : base(points, FigureType.Quadrant, color)
        {
            // pass
        }

        public double Side()
        {
            double diag = Points[0].Lenght(Points[1]);
            return diag / Math.Sqrt(2);
        }

        public override bool IsContainPoint(Point point)
        {
            bool isContain = false;

            if ((point.X >= Points[0].X) && (point.X <= Points[1].X) && (point.Y <= Points[1].Y) && (point.Y >= Points[0].Y))
                isContain = true;

            return isContain;
        }

        public override double Perimeter()
        {
            return 4 * this.Side();
        }

        public override double Square()
        {
            return this.Side() * this.Side();
        }

        public override string ToString()
        {
            return $"Квадрат: " + base.ToString();
        }
    }
}
