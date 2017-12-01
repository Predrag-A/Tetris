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
            _list.Deserialize("Leaderboard.xml");
            _gameRunning = false;
        }

        #endregion

        #region Methods

        //Resizes form
        public void ResizeForm()
        {
            this.Width = Grid.Instance.Settings.Columns * Grid.Instance.Settings.Size + 250;
            this.Height = Grid.Instance.Settings.Rows * Grid.Instance.Settings.Size+64;
            TC.ResizeGrid();
        }

        //Initializes the starting values of a game
        public void Initialize()
        {
            _pause = false;
            _nextShape = GetShape();
            _score = 0;
            _time = 0;
            _level = Grid.Instance.Settings.StartLevel;
            lblScore.Text = "Score:" + _score.ToString();
            ResizeForm();
        }

        //Sets the current shape as the one in the preview and gets a new one for the preview
        public void SetCurrent()
        {
            _currentShape = _nextShape;
            _nextShape = GetShape();
        }

        //Method that moves the current shape down
        private void MoveDown()
        {
            //Delete, move position, check if occupied
            Grid.Instance.DeleteShape(_currentShape);
            _currentShape.SetLocation(new Point(_currentShape.Location.X + 1, _currentShape.Location.Y));            
            if (Grid.Instance.IsTaken(_currentShape))
            {
                //If the shape cannot move, return to original position and check for completed lines
                _currentShape.SetLocation(new Point(_currentShape.Location.X - 1, _currentShape.Location.Y));                
                Grid.Instance.AddShape(_currentShape);
                _score += ((int)Math.Pow(Grid.Instance.DeleteRows(), 2) * 100);
                lblScore.Text = "Score: " + _score.ToString();
                //Set the next shape as current. If the position is taken after setting the next shape, the game is over
                SetCurrent();
                if (Grid.Instance.IsTaken(_currentShape))
                {                     
                    GameEnd();
                    return;
                }
                Grid.Instance.AddShape(_currentShape);

            }
            else
            {
                //The shape moves down normally if the position is unoccupied
                Grid.Instance.AddShape(_currentShape);

            }
            this.Refresh();
        }

        //Method that gets called after game ends
        public void GameEnd()
        {
            _gameRunning = false;
            timerGame.Stop();
            timerDrop.Stop();
            
            if(_score > 0)
            {
                _list.Add(new Player(_playerName, _score));
                _list.Serialize("Leaderboard.xml");
            }
            DialogResult s = MessageBox.Show("Game over. Do you want to start another game?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Grid.Instance.Initialize();
            if (s == DialogResult.Yes)
            {
                newGameToolStripMenuItem.PerformClick();
            }
            
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

        //Movement handler
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Does not work if the game is not running
            if (_gameRunning)
            {                
                if (keyData == Grid.Instance.Settings.LeftKey || keyData == Grid.Instance.Settings.RightKey)
                {                    
                    int move;
                    if (keyData == Grid.Instance.Settings.LeftKey)
                    {
                        move = -1;
                    }
                    else
                        move = 1;
                    Grid.Instance.DeleteShape(_currentShape);
                    _currentShape.SetLocation(new Point(_currentShape.Location.X, _currentShape.Location.Y + move));
                    if (Grid.Instance.IsTaken(_currentShape))
                    {
                        _currentShape.SetLocation(new Point(_currentShape.Location.X, _currentShape.Location.Y - move));
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
                    pauseToolStripMenuItem.PerformClick();
                }
                //if (keyData == Keys.N)
                //{
                //    SetCurrent();
                //}
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }        

        //Event that paints the preivew shape
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle next;
            for (int i = 0; i < _nextShape.Dim; i++)
            {
                for (int j = 0; j < _nextShape.Dim; j++)
                {
                    Color chosen = Color.Transparent;
                    if (_nextShape.Matrix[i,j])
                    {
                        chosen = _nextShape.Color;
                    }
                    next = new Rectangle(new Point(30 + j * Grid.Instance.Settings.Size, 30 + i * Grid.Instance.Settings.Size),
                        new Size(Grid.Instance.Settings.Size, Grid.Instance.Settings.Size));
                    e.Graphics.FillRectangle(new SolidBrush(chosen), next);
                }
            }
        }


        #region Timer Events

        private void timerDown_Tick(object sender, EventArgs e)
        {
            SetLevel();
            MoveDown();
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            _time++;
            lblTime.Text = "Time: " + _time.ToString();
        }

        #endregion

        #region MenuStrip Events

        //Event that triggers to start the game. Cannot be used if game is already running
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
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
                SetCurrent();
                timerGame.Start();
                timerDrop.Start();
                Grid.Instance.AddShape(_currentShape);
                this.Refresh();
            }
        }

        //Pauses the game
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_gameRunning)
                return;
            if (!_pause)
            {
                timerGame.Stop();
                timerDrop.Stop();
                _pause = true;
                lblPause.Visible = true;
                pauseToolStripMenuItem.Text = "Continue";
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void leaderboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LeaderboardForm(_list);
            frm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_gameRunning)
                return;
            
            OptionsForm frm = new OptionsForm(Grid.Instance.Settings);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Grid.Instance.Initialize();
                this.ResizeForm();
                lblScore.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblTime.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblLevel.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblNext.ForeColor = Grid.Instance.Settings.TetrisBorder;                
            }
            TC.Refresh();
        }
        
        private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_gameRunning)
                return;
            GameEnd();
        }

        #endregion

        #endregion

    }
}
