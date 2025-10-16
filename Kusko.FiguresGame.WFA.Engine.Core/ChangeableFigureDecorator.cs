using FiguresLib.Core;
using System.Drawing;
using Point = FiguresLib.Core.Point;

namespace Kusko.FiguresGame.WFA.Engine.Core
{
    public class ChangeableFigureDecorator : Figure, IMoveable, IResizeable
    {
        // здесь хранится оригинальная фигура
        public Figure WrappedFigure { get; private set; }

        public ChangeableFigureDecorator(Figure figureToWrap)
            : base(figureToWrap.Points, figureToWrap.Type, figureToWrap.Color)
        {
            this.WrappedFigure = figureToWrap;
        }

        // перемещает фигуру, обновляя точки как у декоратора, так и у обернутой фигуры
        public void Move(double dx, double dy)
        {
            for (int i = 0; i < Points.Length; i++)
                Points[i] = new Point(Points[i].X + dx, Points[i].Y + dy);

            WrappedFigure.Points = this.Points;
        }

        // изменяет размер фигуры, обновляя точки аналогично методу Move
        public void ChangeScale(double scale)
        {
            Point center = this.FindCenter();
            for (int i = 0; i < Points.Length; i++)
            {
                double dx = Points[i].X - center.X;
                double dy = Points[i].Y - center.Y;
                Points[i] = new Point(center.X + (dx * scale), center.Y + (dy * scale));
            }

            WrappedFigure.Points = this.Points;
        }

        public override double Perimeter() { return WrappedFigure.Perimeter(); }
        public override double Square() { return WrappedFigure.Square(); }
        public override bool IsContainPoint(Point point) { return WrappedFigure.IsContainPoint(point); }
    }
}