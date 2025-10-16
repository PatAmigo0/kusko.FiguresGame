using System;
using System.Drawing;
using FiguresLib.Core;
using DrawLib.Core;
using Kusko.FiguresGame.WFA.Engine.Core;
using FiguresLib.Core.Shapes;
using System.Diagnostics;

namespace DrawLib.Platform.WFA
{
    public class WFADraw : IDraw
    {
        private readonly Graphics _graphics;
        private readonly Color _backgroundColor;

        public WFADraw(Color background, Graphics graphics)
        {
            _backgroundColor = background;
            _graphics = graphics;
        }

        public void Clear() { _graphics.Clear(_backgroundColor); }
        public void Erase(Figure figure) { this.Draw(figure, _backgroundColor); }
        public void Draw(Figure figure) { this.Draw(figure, figure.Color); }

        private void Draw(Figure figure, Color color)
        {
            if (figure?.Points == null || figure.Points.Length == 0) return;

            // если фигура является декоратором, мы извлекаем из нее исходную фигуру для отрисовки
            Figure figureToDraw = figure;
            if (figure is ChangeableFigureDecorator decorator)
                figureToDraw = decorator.WrappedFigure;

            var center = figureToDraw.FindCenter();
            Debug.WriteLine($"Пытаюсь нарисовать {figureToDraw.Type} на X: {center.X:F1}, Y: {center.Y:F1}");

            using (Brush brush = new SolidBrush(color))
            {
                switch (figureToDraw.Type)
                {
                    case FigureType.Circle:
                        var circle = (Circle)figureToDraw;
                        float radius = (float)circle.Radius();
                        _graphics.FillEllipse(brush, (float)circle.Points[0].X - radius, (float)circle.Points[0].Y - radius, radius * 2, radius * 2);
                        break;

                    case FigureType.Quadrant:
                        var quadrant = (Quadrant)figureToDraw;
                        var p1 = quadrant.Points[0];
                        var p2 = quadrant.Points[1];
                        _graphics.FillRectangle(brush, (float)Math.Min(p1.X, p2.X), (float)Math.Min(p1.Y, p2.Y), (float)quadrant.Side(), (float)quadrant.Side());
                        break;

                    case FigureType.Triangle:
                    case FigureType.Rhomb:
                    case FigureType.Hexagon:
                        _graphics.FillPolygon(brush, GetPointsForDrawing(figureToDraw));
                        break;
                }
            }
        }

        // вспомогательный метод
        private PointF[] GetPointsForDrawing(Figure figure)
        {
            PointF[] pointsF = new PointF[figure.Points.Length];

            for (int i = 0; i < figure.Points.Length; i++)
                pointsF[i] = new PointF((float)figure.Points[i].X, (float)figure.Points[i].Y);

            return pointsF;
        }
    }
}