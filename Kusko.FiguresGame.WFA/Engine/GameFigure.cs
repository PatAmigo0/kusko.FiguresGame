using FiguresLib.Core;
using Kusko.FiguresGame.WFA.Engine.Core;
using System.Drawing;

namespace Kusko.FiguresGame.WFA.Engine
{
    /// <summary>
    /// представляет игровой объект, который имеет геометрическую форму и игровое состояние
    /// </summary>
    public class GameFigure
    {
        /// <summary>
        /// геометрическая форма объекта
        /// </summary>
        public ChangeableFigure Shape { get; }

        /// <summary>
        /// текущая скорость и направление движения объекта
        /// </summary>
        public PointF Velocity { get; set; }

        /// <summary>
        /// оставшееся время жизни объекта в игровых тиках
        /// </summary>
        public int LifeTime { get; private set; }

        /// <summary>
        /// жив ли еще этот игровой объект
        /// </summary>
        public bool IsAlive()
        {
            return LifeTime > 0;
        }

        public GameFigure(ChangeableFigure shape, int lifeTime)
        {
            Shape = shape;
            LifeTime = lifeTime;
            Velocity = new PointF(0, 0); // начальная скорость по умолчанию
        }

        /// <summary>
        /// обновляет состояние объекта на каждом кадре игры
        /// </summary>
        public void Update()
        {
            if (!IsAlive()) return;

            Shape.Move(Velocity.X, Velocity.Y);

            LifeTime--;
        }

        /// <summary>
        /// вычисляет количество очков за фигуру
        /// </summary>
        public int GetScore()
        {
            double square = Shape.Square();
            if (square == 0) return 0;
            return (int)(10000 / square);
        }
    }
}

