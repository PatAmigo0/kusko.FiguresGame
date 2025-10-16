using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Point = FiguresLib.Core.Point;
using System.Diagnostics;

namespace Kusko.FiguresGame.WFA.Engine
{
    public class GameEngine
    {
        #region Поля класса
        private readonly List<GameFigure> _figures = new List<GameFigure>();
        private readonly Random _rand = new Random();
        private int _width;
        private int _height;
        private readonly Color _backgroundColor;
        private readonly Label _scoreLabel;
        private readonly Label _lifesLabel;
        private int _extraLifes;
        private int _hardCoeff; // поле для хранения коэффицента сложности 

        public int Score { get; private set; }
        #endregion

        #region Публичные методы
        public GameEngine(int width, int height, Color backgroundColor, Label scoreLabel, Label lifesLabel)
        {
            _width = width;
            _height = height;
            _backgroundColor = backgroundColor;
            _scoreLabel = scoreLabel;
            _lifesLabel = lifesLabel;

            Score = 0;
            _extraLifes = 3;

            this.UpdateScoreLabel();
            this.UpdateExtraLifesLabel();
        }

        public void Update()
        {
            if (_rand.Next(100) < 5)
                this.AddNewFigure();

            foreach (var figure in this._figures)
                figure.Update(_backgroundColor);

            for (int i = _figures.Count - 1; i >= 0; i--)
                if (!this._figures[i].IsAlive())
                {
                    this._figures.RemoveAt(i);
                    this.HandleFigureMiss();
                }
        }

        public void Draw(Graphics g)
        {
            var drawer = new DrawLib.Platform.WFA.WFADraw(_backgroundColor, g);
            drawer.Clear();

            if (this._figures.Count > 0)
                Debug.WriteLine($"[Frame Tick]: Рисую {this._figures.Count} фигур");

            foreach (var figure in this._figures)
                drawer.Draw(figure.Shape);
        }

        public void HandleMouseClick(Point clickPoint)
        {
            GameFigure clickedFigure = null;

            for (int i = this._figures.Count - 1; i >= 0; i--)
                if (this._figures[i].Shape.IsContainPoint(clickPoint))
                {
                    clickedFigure = this._figures[i];
                    break;
                }

            if (clickedFigure != null)
            {
                Score += clickedFigure.GetScore();
                this._figures.Remove(clickedFigure);
                this.UpdateScoreLabel();
            }
        }

        public void HandleFigureMiss()
        {
            this._extraLifes--;
            this.UpdateExtraLifesLabel();
            if (this._extraLifes < 0) Application.Exit();
        }

        public void UpdateDimensions(int newWidth, int newHeight)
        {
            this._width = newWidth;
            this._height = newHeight;
        }
        #endregion

        #region Приватные методы
        private void AddNewFigure()
        {
            var gameFigure = GameFigureFabric.CreateGameFigure(_width, _height);
            if (gameFigure != null)
            {
                _figures.Add(gameFigure);
                Debug.WriteLine($"[ S ]: Новая фигура {gameFigure.Shape.Type} была успешно создана!");
            }
        }

        private void UpdateScoreText()
        {
            this._scoreLabel.Text = $"Score: {Score}";
        }
        
        private void UpdateExtraLifesText()
        {
            this._lifesLabel.Text = $"Extra lifes: {_extraLifes}";
        }

        private void UpdateScoreLabel()
        {
            if (_scoreLabel.InvokeRequired)
                this._scoreLabel.Invoke(new Action(UpdateScoreText));
            else this.UpdateScoreText();
        }

        private void UpdateExtraLifesLabel()
        {
            if (this._lifesLabel.InvokeRequired)
                this._lifesLabel.Invoke(new Action(UpdateExtraLifesText));
            else this.UpdateExtraLifesText(); 
        }
        #endregion
    }
}