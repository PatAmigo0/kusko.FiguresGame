using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FiguresLib.Core;
using Point = FiguresLib.Core.Point;
using System.Diagnostics;

namespace Kusko.FiguresGame.WFA.Engine
{
    public class GameEngine
    {
        private List<GameFigure> _figures = new List<GameFigure>();
        private readonly Random _rand = new Random();
        private int _width;
        private int _height;
        private readonly Color _backgroundColor;
        private readonly Label _scoreLabel;

        public int Score { get; private set; }

        public GameEngine(int width, int height, Color backgroundColor, Label scoreLabel)
        {
            _width = width;
            _height = height;
            _backgroundColor = backgroundColor;
            _scoreLabel = scoreLabel;
            this.UpdateScoreLabel();
        }

        public void Update()
        {
            if (_rand.Next(100) < 5)
                this.AddNewFigure();

            foreach (var figure in this._figures)
                figure.Update(_backgroundColor);

            for (int i = _figures.Count - 1; i >= 0; i--)
                if (!this._figures[i].IsAlive())
                    this._figures.RemoveAt(i);
        }

        public void Draw(Graphics g)
        {
            var drawer = new DrawLib.Platform.WFA.WFADraw(_backgroundColor, g);
            drawer.Clear();

            if (this._figures.Count > 0)
                Debug.WriteLine($"[Frame Tick]: Рисую {this._figures.Count} фигур");

            foreach (var figure in this._figures)
            {
                drawer.Draw(figure.Shape);
            }
        }

        public void HandleMouseClick(Point clickPoint)
        {
            GameFigure clickedFigure = null;
            for (int i = this._figures.Count - 1; i >= 0; i--)
            {
                if (this._figures[i].Shape.IsContainPoint(clickPoint))
                {
                    clickedFigure = this._figures[i];
                    break;
                }
            }

            if (clickedFigure != null)
            {
                Score += clickedFigure.GetScore();
                this._figures.Remove(clickedFigure);
                this.UpdateScoreLabel();
            }
        }

        public void UpdateDimensions(int newWidth, int newHeight)
        {
            this._width = newWidth;
            this._height = newHeight;
        }

        private void AddNewFigure()
        {
            var gameFigure = GameFigureFabric.CreateGameFigure(_width, _height);
            if (gameFigure != null)
            {
                _figures.Add(gameFigure);
                Debug.WriteLine($"[]: Новая фигура {gameFigure.Shape.Type} была успешно создана!");
            }
        }

        private void UpdateScoreText()
        {
            this._scoreLabel.Text = $"Score: {Score}";
        }

        private void UpdateScoreLabel()
        {
            if (_scoreLabel.InvokeRequired)
                this._scoreLabel.Invoke(new Action(UpdateScoreText));
            else
                this.UpdateScoreText();
        }


    }
}