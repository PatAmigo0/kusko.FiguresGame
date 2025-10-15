using FiguresLib.Core;

namespace DrawLib.Core
{
    /// <summary>
    /// Предоставляет контракт для классов, которые могут отрисовывать фигуры
    /// </summary>
    public interface IDraw
    {
        /// <summary>
        /// Рисует указанную фигуру на холсте
        /// </summary>
        /// <param name="figure">Фигура для отрисовки</param>
        void Draw(Figure figure);

        /// <summary>
        /// Стирает указанную фигуру с холста (обычно путем отрисовки цветом фона)
        /// </summary>
        /// <param name="figure">Фигура для стирания</param>
        void Erase(Figure figure);

        /// <summary>
        /// Полностью очищает весь холст
        /// </summary>
        void Clear();
    }
}
