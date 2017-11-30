using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_Novi.Classes;
using Tetris_Novi.Forms;
using Tetris_Novi.Klase;
using Tetris_Novi.User_control;

namespace Tetris_Novi
{

    //TODO Initialize problem

    public partial class MainForm : Form
    {

        #region Attributes

        Shape _trenutnaFigura;
        Shape _sledecaFigura;
        int _score;
        int _vrm;
        int _level;
        string _playerName;
        bool _pause = false;
        PlayerList _list;

        #endregion

        #region Constructors
        
        public MainForm()
        {
            InitializeComponent();
            ShapeList.Instance.AddAllShapes(3);
            postavi();
            lblPause.Visible = false;
            _list = new PlayerList();
            _list.Deserialize("Leaderboard.xml");
        }

        #endregion

        #region Methods

        public void postavi()
        {
            randomSledeca();
            _score = 0;
            _level = Grid.Instance.Settings.StartLevel;
            lblScore.Text = "Score:" + _score.ToString();
        }

        public void randomSledeca()
        {
            Random k = new Random();
            int r = k.Next(0, ShapeList.Instance.GetCount());
            _sledecaFigura = new Shape(ShapeList.Instance.GetShape(r));
        }

        public void staviSledecuFiguru()
        {
            _trenutnaFigura = _sledecaFigura;
            randomSledeca();
        }

        private void moveDown()
        {
            //obrisemo je sa tebele
            Grid.Instance.DeleteShape(_trenutnaFigura);
            //pomerimo
            _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X + 1, _trenutnaFigura.GlavnaKoordinata.Y));
            //pitamo da li ima mesta za nju gde sam je pomerio
            if (Grid.Instance.IsTaken(_trenutnaFigura))
            {
                //ako nema vratim joj trenutnu poziciju
                _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X - 1, _trenutnaFigura.GlavnaKoordinata.Y));
                //dodamo je na staru poziciju I proveravamo redove da se nije spojio ceo
                Grid.Instance.AddShape(_trenutnaFigura);
                _score += ((int)Math.Pow(Grid.Instance.DeleteRows(), 2) * 100);
                lblScore.Text = "Score: " + _score.ToString();
                staviSledecuFiguru();
                if (Grid.Instance.IsTaken(_trenutnaFigura))
                {
                    //izgubljena igra 
                    GameEnd();
                    return;
                }
                Grid.Instance.AddShape(_trenutnaFigura); //ako ne dodajemo je u tablu

            }
            else
            {
                Grid.Instance.AddShape(_trenutnaFigura);

            }
            this.Refresh();
        }

        public void GameEnd()
        {
            timerGame.Stop();
            timerDrop.Stop();
            if (_score == 0)
            {
                DialogResult s = MessageBox.Show("Kraj igre. Da li zelite novu partiju?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                
                DialogResult s = MessageBox.Show("Kraj igre. Da li zelite novu partiju?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            Grid.Instance.DeleteShape(_trenutnaFigura);
            Random k = new Random();
            int r = (int)(k.NextDouble() * ShapeList.Instance.GetCount());
            _trenutnaFigura = new Shape(ShapeList.Instance.GetShape(r));
            Grid.Instance.AddShape(_trenutnaFigura);
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
            NameForm frm = new NameForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _playerName = frm.PlayerName;
                preview.Visible = true;
                postavi();
                _pause = false;
                _vrm = 0;
                staviSledecuFiguru();
                timerGame.Start();
                timerDrop.Start();
                Grid.Instance.AddShape(_trenutnaFigura);
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
                    Grid.Instance.DeleteShape(_trenutnaFigura); //obrisemo ga
                    _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X, _trenutnaFigura.GlavnaKoordinata.Y + move));
                    if (Grid.Instance.IsTaken(_trenutnaFigura))
                    {
                        _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X, _trenutnaFigura.GlavnaKoordinata.Y - move));
                        Grid.Instance.AddShape(_trenutnaFigura);
                    }
                    else
                    {
                        Grid.Instance.AddShape(_trenutnaFigura);
                        this.Refresh();
                    }
                    return true;
                }
                if (keyData == Grid.Instance.Settings.RotateKey)
                {
                    Grid.Instance.DeleteShape(_trenutnaFigura);
                    _trenutnaFigura.RotacijaLevo();
                    if (Grid.Instance.IsTaken(_trenutnaFigura))
                    {
                        _trenutnaFigura.RotacijaDesno();
                        Grid.Instance.AddShape(_trenutnaFigura);
                    }
                    else
                    {
                        Grid.Instance.AddShape(_trenutnaFigura);
                        this.Refresh();
                    }
                    return true;
                }
                if (keyData == Grid.Instance.Settings.DownKey)
                {
                    moveDown();
                    return true;
                }
                if (keyData == Keys.D)
                {
                    randomSledeca();
                    this.Refresh();
                    return true;
                }
                if (keyData == Keys.P)
                {
                    pauzaToolStripMenuItem.PerformClick();
                }
                if (keyData == Keys.N)
                {
                    promeniTrenutnu();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        

        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_pause)
            {
                timerGame.Stop();
                timerDrop.Stop();
                _pause = true;
                lblPause.Visible = true;
                pauzaToolStripMenuItem.Text = "Nastavi";
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
            for (int i = 0; i < _sledecaFigura.N; i++)
            {
                for (int j = 0; j < _sledecaFigura.N; j++)
                {
                    Color chosen = Color.Transparent;
                    if (_sledecaFigura.Matrica[i][j])
                    {
                        chosen = _sledecaFigura.Boja;
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
            moveDown();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerGame.Stop();
            timerDrop.Stop();
            DialogResult dlg;
            dlg = MessageBox.Show("Da li ste sigurni da zelite da izadjete?", "Infromacija", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlg == DialogResult.Yes)
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
            if (timerDrop.Enabled || _pause)
                return;
            if (TC.ShowOptions() == DialogResult.OK)
            {
                Grid.Instance.Initialize();
                TC.Refresh();
                ShapeList.Instance.AddAllShapes(3);
                lblScore.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblTime.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblLevel.ForeColor = Grid.Instance.Settings.TetrisBorder;
                lblNext.ForeColor = Grid.Instance.Settings.TetrisBorder;
            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            _vrm++;
            lblTime.Text = "Time: " + _vrm.ToString();
        }

        #endregion

    }
}
