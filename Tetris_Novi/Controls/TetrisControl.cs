using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_Novi.Klase;
using Tetris_Novi.Classes;
using Tetris_Novi.Forms;

namespace Tetris_Novi.User_control
{
    public partial class TetrisControl : UserControl
    {
        public TetrisControl()
        {
            InitializeComponent();
        }
        
        public DialogResult ShowOptions()
        {
            OptionsForm frm = new OptionsForm(Grid.ObjekatKlaseGrid.Settings);
            return frm.ShowDialog();
        }


        public void paint(PaintEventArgs e)
        {
            for (int i = 0; i < Grid.ObjekatKlaseGrid.N; i++)
            {
                for (int j = 0; j < Grid.ObjekatKlaseGrid.M; j++)
                {
                    if (Grid.ObjekatKlaseGrid.Matrix[i,j].Filled)
                    {
                        e.Graphics.FillRectangle(Grid.ObjekatKlaseGrid.Matrix[i,j].Brush, Grid.ObjekatKlaseGrid.Matrix[i,j].Rect);
                    }
                }
            }

            for (int i = 0; i < Grid.ObjekatKlaseGrid.N; i++)
            {
                for (int j = 0; j < Grid.ObjekatKlaseGrid.M; j++)
                {
                    if (!Grid.ObjekatKlaseGrid.Matrix[i,j].Filled)
                    {
                        e.Graphics.FillRectangle(Grid.ObjekatKlaseGrid.Matrix[i, j].Brush, Grid.ObjekatKlaseGrid.Matrix[i, j].Rect);                        
                        e.Graphics.DrawRectangle(new Pen(Grid.ObjekatKlaseGrid.Settings.TetrisBorder), Grid.ObjekatKlaseGrid.Matrix[i, j].Rect);

                    }
                }
            }
        }

        private void pbTetris_Paint_1(object sender, PaintEventArgs e)
        {
            paint(e);
        }
    }
}
