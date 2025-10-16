using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Kusko.FiguresGame.WFA.Engine;
using Point = FiguresLib.Core.Point;

namespace Kusko.FiguresGame.WFA
{
    public partial class MainGameWindow : Form
    {
        private GameEngine _engine;
        private Timer _gameTimer;

        public MainGameWindow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.BackColor = Color.FromArgb(45, 45, 48);
            scoreLabel.ForeColor = Color.White;
            lifesLabel.ForeColor = Color.White;

            this.Paint += new PaintEventHandler(MainGameWindow_Paint);
            this.MouseClick += new MouseEventHandler(MainGameWindow_MouseClick);
            this.Resize += new EventHandler(MainGameWindow_Resize);
        }

        private void MainGameWindow_Load(object sender, EventArgs e)
        {
            _engine = new GameEngine(this.ClientSize.Width, this.ClientSize.Height, this.BackColor, scoreLabel, lifesLabel);
            _gameTimer = new Timer
            {
                Interval = (int)(1000.0 / 30)
            };
            _gameTimer.Tick += GameTimer_Tick;
            _gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _engine.Update();
            this.Invalidate();
        }

        private void MainGameWindow_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"Успешно реагирую на клик. Координаты клика: [{e.X}:{e.Y}]");
            _engine.HandleMouseClick(new Point(e.X, e.Y));
        }

        private void MainGameWindow_Resize(object sender, EventArgs e)
        {
            _engine?.UpdateDimensions(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void MainGameWindow_Paint(object sender, PaintEventArgs e)
        {
            _engine?.Draw(e.Graphics);
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}