using System.Drawing;
using System.Linq;

namespace FiguresLib.Core
{
    public abstract class Figure
    {
        public Point[] Points { get; private set; }
        public FigureType Type { get; }
        public Color Color { get; private set; }

        public Figure(Point[] points, FigureType type, Color color)
        {
            this.Points = points;
            this.Type = type;
            this.Color = color;
        }

        public abstract double Perimeter();
        public abstract double Square();
        public abstract bool IsContainPoint(Point point);

        public Point FindCenter()
        {
            if (Points == null || !Points.Any())
            {
                return new Point(0, 0);
            }

            Point sum = new Point(0, 0);

            foreach (Point p in Points)
            {
                sum += p;
            }

            sum /= Points.Length;
            return sum;
        }

        public override string ToString()
        {
            // Используем исправленное название свойства Perimeter
            return $"P = {this.Perimeter():F2}, S = {this.Square():F2}";
        }
    }
}