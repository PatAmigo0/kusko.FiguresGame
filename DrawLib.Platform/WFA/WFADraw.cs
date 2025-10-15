using System.Drawing;
using FiguresLib.Core;
using FiguresLib.Core.Shapes;
using DrawLib.Core;

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

        public void Clear()
        {
            _graphics.Clear(_backgroundColor);
        }

        public void Erase(Figure figure)
        {
            this.Draw(figure, _backgroundColor);
        }

        public void Draw(Figure figure)
        {
            this.Draw(figure, figure.Color);
        }

        private void Draw(Figure figure, Color color)
        {
            if (figure == null) return;

            using (Brush brush = new SolidBrush(color))
            {
                switch (figure.Type)
                {
                    case FigureType.Circle:
                        var circle = (Circle)figure;
                        int r = (int)System.Math.Round(circle.Radius());
                        int diameter = 2 * r;
                        int x_c = (int)circle.Points[0].X - r;
                        int y_c = (int)circle.Points[0].Y - r;

                        _graphics.FillEllipse(brush, x_c, y_c, diameter, diameter);
                        break;

                    case FigureType.Quadrant:
                        var quadrant = (Quadrant)figure;
                        int x_q = (int)quadrant.Points[0].X;
                        int y_q = (int)quadrant.Points[0].Y;
                        int side = (int)quadrant.Side();

                        _graphics.FillRectangle(brush, x_q, y_q, side, side);
                        break;

                    case FigureType.Triangle:
                    case FigureType.Rhomb:
                    case FigureType.Hexagon:
                        _graphics.FillPolygon(brush, GetPointsForDrawing(figure));
                        break;
                }
            }
        }

        private PointF[] GetPointsForDrawing(Figure figure)
        {
            PointF[] pointsF = new PointF[figure.Points.Length];

            // конвертируем Point (с double) в PointF (с float) и добавляем в новый массив
            for (int i = 0; i < figure.Points.Length; i++)
                pointsF[i] = new PointF((float)figure.Points[i].X, (float)figure.Points[i].Y);

            return pointsF;
        }
    }
}

