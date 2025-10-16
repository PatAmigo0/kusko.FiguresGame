using FiguresLib.Core;
using Kusko.FiguresGame.WFA.Engine.Core;
using System.Diagnostics;
using System.Drawing;

namespace Kusko.FiguresGame.WFA.Engine
{
    public class GameFigure
    {
        public Figure Shape { get; set; } // Является по своей сути ChangeableFigureDecorator, хоть тут и Figure для удобства
        public PointF Velocity { get; set; }
        public int LifeTime { get; private set; }

        private readonly int _maxLifeTime;
        private readonly Color _initialColor;

        public bool IsAlive() { return LifeTime > 0; }

        public GameFigure(Figure shape, int lifeTime)
        {
            Shape = shape;
            LifeTime = lifeTime;
            Velocity = new PointF(0, 0);
            _maxLifeTime = lifeTime;
            _initialColor = shape.Color;
        }

        public void Update(Color backgroundColor)
        {
            if (!IsAlive()) return;


            if (Shape is IMoveable moveableShape)
                moveableShape.Move(Velocity.X, Velocity.Y);
            LifeTime--;

            UpdateColor(backgroundColor);
        }

        private void UpdateColor(Color background)
        {
            if (_maxLifeTime <= 0) return;

            float lifeRatio = (float)LifeTime / _maxLifeTime;
            int r = (int)(background.R + (_initialColor.R - background.R) * lifeRatio);
            int g = (int)(background.G + (_initialColor.G - background.G) * lifeRatio);
            int b = (int)(background.B + (_initialColor.B - background.B) * lifeRatio);
            Shape.Color = Color.FromArgb(r, g, b);
        }

        public int GetScore()
        {
            return (int)(Shape.Square() / 10.0);
        }
    }
}
