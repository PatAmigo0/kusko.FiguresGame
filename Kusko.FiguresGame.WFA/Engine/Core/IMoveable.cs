namespace Kusko.FiguresGame.WFA.Engine.Core
{
    public interface IMoveable
    {
        /// <summary>
        /// смещает объект на заданное расстояние
        /// </summary>
        void Move(double dx, double dy);
    }
}
