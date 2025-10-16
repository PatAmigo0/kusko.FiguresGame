using System;
using System.Drawing;
using FiguresLib.Core;
using Kusko.FiguresGame.WFA.Engine.Core;
using Point = FiguresLib.Core.Point;

namespace Kusko.FiguresGame.WFA.Engine
{
    public class GameFigureFabric
    {
        private const int MinLifeTime = 100;
        private const int MaxLifeTime = 301;
        private static readonly Random rand = new Random();

        // создает полностью готовую игровую фигуру со всеми свойствами
        public static GameFigure CreateGameFigure(int canvasWidth, int canvasHeight)
        {
            // 1 получаем стандартную, неподвижную фигуру из основной фабрики
            Figure baseFigure = FigureFactory.GetNewFigure(canvasWidth, canvasHeight);
            if (baseFigure == null) return null;

            // 2 оборачиваем ее в декоратор, чтобы дать ей возможность двигаться/изменяться в размере
            ChangeableFigureDecorator changeableFigure = new ChangeableFigureDecorator(baseFigure);

            // 3 создаем игровую фигуру, используя новую декорированную форму
            int lifeTime = rand.Next(MinLifeTime, MaxLifeTime);
            GameFigure gameFigure = new GameFigure(changeableFigure, lifeTime)
            {
                Velocity = new PointF(
                    (float)(rand.NextDouble() * 2 - 1),
                    (float)(rand.NextDouble() * 2 - 1)
                )
            };

            return gameFigure;
        }
    }
}