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
    public partial class MainForm : Form
    {
        Shape _trenutnaFigura;
        Shape _sledecaFigura;
        int _brojPoena;
        int _velicinaKockice;
        int _kolikoSmallSquareSuFigure;
        int _vrm;
        int _nivo = 1;
        bool _pause = false;

        public MainForm()
        { 
            InitializeComponent();
            this.Width = (int)(TC.Width * 1.1);
            this.Height = (int)(TC.Height * 1.1);
            postaviVrednosti();
            ListaFigura.Instance.dodajOblike(_kolikoSmallSquareSuFigure);
            postavi();
        }
        
        public void postaviVrednosti()
        {
            _velicinaKockice = 31;
            _kolikoSmallSquareSuFigure = 3;
        }

        public void postavi()
        {
            randomSledeca();
            _brojPoena = 0;
            lblTrenutniRezultat.Text = _brojPoena.ToString();
        }

        public void randomSledeca()
        {
            Random k = new Random();
            int r = (int)(k.NextDouble() * ListaFigura.Instance.vratiBrojFiguraUlisti());
            _sledecaFigura = new Shape(ListaFigura.Instance.vratiFiguru(r));
        }

        public void staviSledecuFiguru()
        {
            _trenutnaFigura = _sledecaFigura;
            randomSledeca();
        }

        private void moveDown()
        {
            //obrisemo je sa tebele
            Grid.ObjekatKlaseGrid.obrisiFiguru(_trenutnaFigura);
            //pomerimo
            _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X + 1, _trenutnaFigura.GlavnaKoordinata.Y));
            //pitamo da li ima mesta za nju gde sam je pomerio
            if(Grid.ObjekatKlaseGrid.ZauzetoJe(_trenutnaFigura))
            {
                //ako nema vratim joj trenutnu poziciju
                _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X - 1, _trenutnaFigura.GlavnaKoordinata.Y ));
                //dodamo je na staru poziciju I proveravamo redove da se nije spojio ceo
                Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
                _brojPoena += ((int)Math.Pow(Grid.ObjekatKlaseGrid.obrisiRedove(), 2) * 100);
                lblTrenutniRezultat.Text = _brojPoena.ToString();
                staviSledecuFiguru();
                if(Grid.ObjekatKlaseGrid.ZauzetoJe(_trenutnaFigura))
                {
                    //izgubljena igra 
                    IzgubljenaIgra();
                    return;
                }
                Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura); //ako ne dodajemo je u tablu

            }
            else
            {
                Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);

            }
            this.Refresh();
        }

        public void IzgubljenaIgra()
        {
            timer1.Stop();
            if(int.Parse(lblTrenutniRezultat.Text) == 0)
            {
                DialogResult s = MessageBox.Show("Kraj igre. Da li zelite novu partiju?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (s == DialogResult.Yes)
                {
                    novaIgraToolStripMenuItem.PerformClick();
                }
                else
                    this.Close();
            }
            else
            {
                var frm = new FormIgrac(lblTrenutniRezultat.Text);
                DialogResult x = frm.ShowDialog();
                if (x == DialogResult.Yes)
                {
                    ListaIgraca l = new ListaIgraca();
                    l = l.DeSerialize("Top10.xml");
                    l.AddIgrac(frm.trenutniIgrac);
                    l.Serialize("Top10.xml");
                }
                DialogResult s = MessageBox.Show("Kraj igre. Da li zelite novu partiju?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (s == DialogResult.Yes)
                {
                    novaIgraToolStripMenuItem.PerformClick();
                }
                else
                    this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //VIDETI KAKO DA UKOMBINUJEMO DA MU POSALJEMO OBJEKAT
            //TetrisControl.OsvesiDelegat = new TetrisControl.OsvesiDelegat();
        }

        private void novaIgraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            postavi();
            _pause = false;
            _vrm = 0;
            staviSledecuFiguru();
            timer1.Start();
            Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
            this.Refresh();
        }

        //funkcija koja nam dozvoljava da koristimo strelice nasao na steckoverflow
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //ako nije ukljucen tajmer to znaci da je igrica na puzi
            if(timer1.Enabled)
            {
                if(keyData==Keys.Left || keyData==Keys.Right)
                {
                    //ovo je slicno kao pomeranje na dole
                    int move;
                    if (keyData == Keys.Left)
                    {
                        move = -1;
                    }
                    else
                        move = 1;
                    Grid.ObjekatKlaseGrid.obrisiFiguru(_trenutnaFigura); //obrisemo ga
                    _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X, _trenutnaFigura.GlavnaKoordinata.Y + move));
                    if(Grid.ObjekatKlaseGrid.ZauzetoJe(_trenutnaFigura))
                    {
                        _trenutnaFigura.PodesiLokaciju(new Point(_trenutnaFigura.GlavnaKoordinata.X, _trenutnaFigura.GlavnaKoordinata.Y - move));
                        Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
                    }
                    else
                    {
                        Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
                        this.Refresh();
                    }
                    return true;
                }
                if(keyData==Keys.Space)
                {
                    Grid.ObjekatKlaseGrid.obrisiFiguru(_trenutnaFigura);
                    _trenutnaFigura.RotacijaLevo();
                    if(Grid.ObjekatKlaseGrid.ZauzetoJe(_trenutnaFigura))
                    {
                        _trenutnaFigura.RotacijaDesno();
                        Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
                    }
                    else
                    {
                        Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
                        this.Refresh();
                    }
                    return true;
                }
                if(keyData==Keys.S)
                {
                    Grid.ObjekatKlaseGrid.obrisiFiguru(_trenutnaFigura);
                    _trenutnaFigura.RotacijaDesno();
                    if(Grid.ObjekatKlaseGrid.ZauzetoJe(_trenutnaFigura))
                    {
                        _trenutnaFigura.RotacijaLevo();
                        Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
                    }
                    else
                    {
                        Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
                        this.Refresh();
                    }
                    return true;
                }
                if(keyData==Keys.Down)
                {
                    moveDown();
                    return true;
                }
                if(keyData ==Keys.D)
                {
                    randomSledeca();
                    this.Refresh();
                    return true;
                }
                if(keyData == Keys.P)
                {
                    pauzaToolStripMenuItem.PerformClick();
                }
                if(keyData == Keys.N)
                {
                    promeniTrenutnu();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);            
        }

        public void promeniTrenutnu()
        {
            Grid.ObjekatKlaseGrid.obrisiFiguru(_trenutnaFigura);
            Random k = new Random();
            int r = (int)(k.NextDouble() * ListaFigura.Instance.vratiBrojFiguraUlisti());
            _trenutnaFigura = new Shape(ListaFigura.Instance.vratiFiguru(r));
            Grid.ObjekatKlaseGrid.dodajFiguru(_trenutnaFigura);
        }

        private void pauzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!_pause)
            {
                timer1.Stop();
                _pause = true;
                lblPauzirano.Visible = true;
                pauzaToolStripMenuItem.Text = "Nastavi";
                this.Refresh();
            }
            else
            {
                timer1.Start();
                _pause = false;
                lblPauzirano.Visible = false;
                this.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle zaSledeca;
            for(int i=0;i<_sledecaFigura.N;i++)
            {
                for(int j=0;j<_sledecaFigura.N;j++)
                {
                    Color chosen = Color.Transparent;
                    if(_sledecaFigura.Matrica[i][j])
                    {
                        chosen = _sledecaFigura.Boja;
                    }
                    zaSledeca = new Rectangle(new Point(30+j * _velicinaKockice, 30 + i * _velicinaKockice), new Size(_velicinaKockice, _velicinaKockice));
                    e.Graphics.FillRectangle(new SolidBrush(chosen), zaSledeca);
                }
            }
        }

        public void postaviNivo()
        {
            lblNivo.Text = _nivo.ToString();
            if(_brojPoena >= 0 && _brojPoena < 1000)
            {
                _nivo = 1;
                lblNivo.Text = "1";
                timer1.Interval = 1000;
            }
            if(_brojPoena >= 1000 && _brojPoena < 2000)
            {
                _nivo = 2;
                lblNivo.Text = "2";
                timer1.Interval = 900;
            }
            if (_brojPoena >= 2000 && _brojPoena < 3000)
            {
                _nivo = 3;
                lblNivo.Text = "3";
                timer1.Interval = 800;
            }
            if (_brojPoena >= 3000 && _brojPoena < 4000)
            {
                _nivo = 4;
                lblNivo.Text = "4";
                timer1.Interval = 700;
            }
            if (_brojPoena >= 4000 && _brojPoena < 5000)
            {
                _nivo = 5;
                lblNivo.Text = "5";
                timer1.Interval = 600;
            }
            if (_brojPoena >= 5000 && _brojPoena < 6000)
            {
                _nivo = 6;
                lblNivo.Text = "6";
                timer1.Interval = 500;
            }
            if (_brojPoena >= 6000 && _brojPoena < 7000)
            {
                _nivo = 7;
                lblNivo.Text = "7";
                timer1.Interval = 400;
            }
            if (_brojPoena >= 7000 && _brojPoena < 8000)
            {
                _nivo = 8;
                lblNivo.Text = "8";
                timer1.Interval = 300;
            }
            if (_brojPoena >= 8000 && _brojPoena < 9000)
            {
                _nivo = 9;
                lblNivo.Text = "9";
                timer1.Interval = 200;
            }
            if (_brojPoena >= 9000)
            {
                _nivo = 10;
                lblNivo.Text = "10";
                timer1.Interval = 100;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            postaviNivo();
            _vrm++;
            lblVreme.Text = _vrm.ToString();
            moveDown();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult dlg;
            dlg = MessageBox.Show("Da li ste sigurni da zelite da izadjete?", "Infromacija", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlg == DialogResult.Yes)
            {
                this.Close();
            }
            else
                timer1.Start();
        }

        private void najboljiRezultatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Top10();
            DialogResult x = frm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TC.ShowOptions() == DialogResult.OK)
            {
                Grid.ObjekatKlaseGrid.Resize();
                TC.Refresh();
                TC.Width = Grid.ObjekatKlaseGrid.N * Grid.ObjekatKlaseGrid.Settings.SingleSquareWidth;
                TC.Height = Grid.ObjekatKlaseGrid.M * Grid.ObjekatKlaseGrid.Settings.SingleSquareWidth;
                this.Width = (int)(TC.Width*1.1);
                this.Height = (int)(TC.Height*1.1);
            }
        }
    }
}
