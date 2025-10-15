using FiguresLib.Core;
using System.Drawing;
using Point = FiguresLib.Core.Point;

namespace Kusko.FiguresGame.WFA.Engine.Core
{
    /// <summary>
    /// представляет фигуру, которая может изменять свое положение и размер,
    /// реализуя контракты IMoveable и IResizeable
    /// </summary>
    public abstract class ChangeableFigure : Figure, IMoveable, IResizeable
    {
        /// <summary>
        /// конструктор для создания экземпляра подвижной фигуры
        /// </summary>
        public ChangeableFigure(Point[] points, FigureType type, Color color)
            : base(points, type, color) { }

        /// <summary>
        /// смещает фигуру на заданное расстояние (реализация из IMoveable)
        /// </summary>
        public void Move(double dx, double dy)
        {
            for (int i = 0; i < Points.Length; i++)
                Points[i] = new Point(Points[i].X + dx, Points[i].Y + dy);
        }

        /// <summary>
        /// изменяет масштаб фигуры относительно ее центра (реализация из IResizeable)
        /// </summary>
        public void ChangeScale(double scale)
        {
            Point center = this.FindCenter();
            for (int i = 0; i < Points.Length; i++)
            {
                double dx = Points[i].X - center.X;
                double dy = Points[i].Y - center.Y;
                Points[i] = new Point(center.X + (dx * scale), center.Y + (dy * scale));
            }
        }
    }
}

