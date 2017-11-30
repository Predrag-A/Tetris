using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Classes;
using Tetris.Forms;
using Tetris.Klase;
using Tetris.User_control;

namespace Tetris
{

    //TODO Resize problem

    public partial class MainForm : Form
    {

        #region Attributes

        Shape _currentShape;
        Shape _nextShape;
        int _score;
        int _time;
        int _level;
        string _playerName;
        bool _pause = false;
        bool _gameRunning;
        PlayerList _list;

        #endregion

        #region Constructors
        
        public MainForm()
        {
            InitializeComponent();
            Initialize();
            lblPause.Visible = false;
            _list = new PlayerList();
            //_list.Deserialize("Leaderboard.xml");
            _gameRunning = false;
        }

        #endregion

        #region Methods

        public void Initialize()
        {
            _nextShape = GetShape();
            _score = 0;
            _level = Grid.Instance.Settings.StartLevel;
            lblScore.Text = "Score:" + _score.ToString();
        }

        public void SetCurrent()
        {
            _currentShape = _nextShape;
            _nextShape = GetShape();
        }

        private void MoveDown()
        {
            //obrisemo je sa tebele
            Grid.Instance.DeleteShape(_currentShape);
            //pomerimo
            _currentShape.SetLocation(new Point(_currentShape.MainPoint.X + 1, _currentShape.MainPoint.Y));
            //pitamo da li ima mesta za nju gde sam je pomerio
            if (Grid.Instance.IsTaken(_currentShape))
            {
                //ako nema vratim joj trenutnu poziciju
                _currentShape.SetLocation(new Point(_currentShape.MainPoint.X - 1, _currentShape.MainPoint.Y));
                //dodamo je na staru poziciju I proveravamo redove da se nije spojio ceo
                Grid.Instance.AddShape(_currentShape);
                _score += ((int)Math.Pow(Grid.Instance.DeleteRows(), 2) * 100);
                lblScore.Text = "Score: " + _score.ToString();
                SetCurrent();
                if (Grid.Instance.IsTaken(_currentShape))
                {
                    //izgubljena igra 
                    GameEnd();
                    return;
                }
                Grid.Instance.AddShape(_currentShape); //ako ne dodajemo je u tablu

            }
            else
            {
                Grid.Instance.AddShape(_currentShape);

            }
            this.Refresh();
        }

        public void GameEnd()
        {
            _gameRunning = false;
            timerGame.Stop();
            timerDrop.Stop();
            if (_score == 0)
            {
                DialogResult s = MessageBox.Show("Game over. Do you want to start another game?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (s == DialogResult.Yes)
                {
                    novaIgraToolStripMenuItem.PerformClick();
                }
                else
                    Grid.Instance.Initialize();
            }
            else
            {
                _list.Add(new Player(_playerName, _score));
                _list.Serialize("Leaderboard.xml");                
                
                DialogResult s = MessageBox.Show("Game over. Do you want to start another game?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (s == DialogResult.Yes)
                {
                    novaIgraToolStripMenuItem.PerformClick();
                }
                else
                {
                    Grid.Instance.Initialize();
                }
            }
        }

        public void promeniTrenutnu()
        {
            Grid.Instance.DeleteShape(_currentShape);
            _currentShape = GetShape();
            Grid.Instance.AddShape(_currentShape);
        }

        //Returns a random shape
        public Shape GetShape()
        {
            Random rand = new Random();
            switch (rand.Next(0, 5))
            {
                case 1:
                    return new BigSquare(3);
                case 2:
                    return new Cross(3);
                case 3:
                    return new Line(3);
                case 4:
                    return new SmallSquare(3);
                default:
                    return new Triangle(3);
            }
        }


        //The level is set depending on the score
        public void SetLevel()
        {
            lblLevel.Text = "LEVEL: " + _level.ToString();

            switch (_level)
            {
                case 1:
                    if (_score >= 1000)
                        _level++;
                    break;
                case 2:
                    if (_score >= 2000)
                        _level++;
                    break;
                case 3:
                    if (_score >= 3000)
                        _level++;
                    break;
                case 4:
                    if (_score >= 4000)
                        _level++;
                    break;
                case 5:
                    if (_score >= 5000)
                        _level++;
                    break;
                case 6:
                    if (_score >= 6000)
                        _level++;
                    break;
                case 7:
                    if (_score >= 7000)
                        _level++;
                    break;
                case 8:
                    if (_score >= 8000)
                        _level++;
                    break;
                case 9:
                    if (_score >= 9000)
                        _level++;
                    break;
                case 10:
                    if (_score >= 10000)
                        _level++;
                    break;
                case 11:
                    if (_score >= 15000)
                        _level++;
                    break;
                default:
                    return;
            }

            UpdateInterval();

        }

        //Updates timer to intervals depending on level
        void UpdateInterval()
        {
            switch (_level)
            {
                case 1:
                    timerDrop.Interval = 1000;
                    break;
                case 2:
                    timerDrop.Interval = 900;
                    break;
                case 3:
                    timerDrop.Interval = 800;
                    break;
                case 4:
                    timerDrop.Interval = 700;
                    break;
                case 5:
                    timerDrop.Interval = 600;
                    break;
                case 6:
                    timerDrop.Interval = 500;
                    break;
                case 7:
                    timerDrop.Interval = 400;
                    break;
                case 8:
                    timerDrop.Interval = 300;
                    break;
                case 9:
                    timerDrop.Interval = 200;
                    break;
                case 10:
                    timerDrop.Interval = 100;
                    break;
                case 11:
                    timerDrop.Interval = 80;
                    break;
                case 12:
                    timerDrop.Interval = 60;
                    break;
            }
        }

        #endregion

        #region Events

        private void novaIgraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gameRunning)
                return;
            NameForm frm = new NameForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _gameRunning = true;
                _playerName = frm.PlayerName;
                preview.Visible = true;
                Initialize();
                _pause = false;
                _time = 0;
                SetCurrent();
                timerGame.Start();
                timerDrop.Start();
                Grid.Instance.AddShape(_currentShape);
                this.Refresh();
            }
        }

        //funkcija koja nam dozvoljava da koristimo strelice nasao na steckoverflow
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //ako nije ukljucen tajmer to znaci da je igrica na puzi
            if (timerDrop.Enabled)
            {
                if (keyData == Grid.Instance.Settings.LeftKey || keyData == Grid.Instance.Settings.RightKey)
                {
                    //ovo je slicno kao pomeranje na dole
                    int move;
                    if (keyData == Grid.Instance.Settings.LeftKey)
                    {
                        move = -1;
                    }
                    else
                        move = 1;
                    Grid.Instance.DeleteShape(_currentShape); //obrisemo ga
                    _currentShape.SetLocation(new Point(_currentShape.MainPoint.X, _currentShape.MainPoint.Y + move));
                    if (Grid.Instance.IsTaken(_currentShape))
                    {
                        _currentShape.SetLocation(new Point(_currentShape.MainPoint.X, _currentShape.MainPoint.Y - move));
                        Grid.Instance.AddShape(_currentShape);
                    }
                    else
                    {
                        Grid.Instance.AddShape(_currentShape);
                        this.Refresh();
                    }
                    return true;
                }
                if (keyData == Grid.Instance.Settings.RotateKey)
                {
                    //Rotates the shape right. If the new location is free, set it as the new location.
                    //If it is not free, rotate back to original position.
                    Grid.Instance.DeleteShape(_currentShape);
                    _currentShape.RotateR();
                    if (Grid.Instance.IsTaken(_currentShape))
                    {
                        _currentShape.RotateL();
                        Grid.Instance.AddShape(_currentShape);
                    }
                    else
                    {
                        Grid.Instance.AddShape(_currentShape);
                        this.Refresh();
                    }
                    return true;
                }
                if (keyData == Grid.Instance.Settings.DownKey)
                {
                    MoveDown();
                    return true;
                }
                //if (keyData == Keys.D)
                //{
                //    _nextShape() = GetShape();
                //    this.Refresh();
                //    return true;
                //}
                if (keyData == Grid.Instance.Settings.PauseKey)
                {
                    pauzaToolStripMenuItem.PerformClick();
                }
                //if (keyData == Keys.N)
                //{
                //    promeniTrenutnu();
                //}
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        

        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_gameRunning)
                return;
            if (!_pause)
            {
                timerGame.Stop();
                timerDrop.Stop();
                _pause = true;
                lblPause.Visible = true;
                pauzaToolStripMenuItem.Text = "Continue";
                this.Refresh();
            }
            else
            {
                timerGame.Start();
                timerDrop.Start();
                _pause = false;
                lblPause.Visible = false;
                this.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle zaSledeca;
            for (int i = 0; i < _nextShape.Dim; i++)
            {
                for (int j = 0; j < _nextShape.Dim; j++)
                {
                    Color chosen = Color.Transparent;
                    if (_nextShape.Matrix[i,j])
                    {
                        chosen = _nextShape.Color;
                    }
                    zaSledeca = new Rectangle(new Point(30 + j * Grid.Instance.Settings.Size, 30 + i * Grid.Instance.Settings.Size),
                        new Size(Grid.Instance.Settings.Size, Grid.Instance.Settings.Size));
                    e.Graphics.FillRectangle(new SolidBrush(chosen), zaSledeca);
                }
            }
        }
        
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            SetLevel();
            MoveDown();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerGame.Stop();
            timerDrop.Stop();          
            if (MessageBox.Show("Are you sure you want to quit the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                timerGame.Start();
                timerDrop.Start();
            }
        }

        private void najboljiRezultatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LeaderboardForm(_list);
            frm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gameRunning)
                return;
            if (TC.ShowOptions() == DialogResult.OK)
            {
                Grid.Instance.Initialize();
                TC.Refresh();
                lblScore.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblTime.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblLevel.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblNext.ForeColor = Grid.Instance.Settings.TetrisBorder;
            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            _time++;
            lblTime.Text = "Time: " + _time.ToString();
        }

        private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_gameRunning)
                return;
            GameEnd();
        }

        #endregion

    }
}
