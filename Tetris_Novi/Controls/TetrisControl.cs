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

namespace Tetris_Novi.User_control
{
    public partial class TetrisControl : UserControl
    {
        public TetrisControl()
        {
            InitializeComponent();
        }

       public void paint(PaintEventArgs e)
        {
            for (int i = 0; i < Grid.ObjekatKlaseGrid.N; i++)
            {
                for (int j = 0; j < Grid.ObjekatKlaseGrid.M; j++)
                {
                    if (Grid.ObjekatKlaseGrid.MatricaProvera[i][j])
                    {
                        e.Graphics.FillRectangle(Grid.ObjekatKlaseGrid.MatricaBoja[i][j], Grid.ObjekatKlaseGrid.Matrica[i][j]);
                    }
                }
            }

            for (int i = 0; i < Grid.ObjekatKlaseGrid.N; i++)
            {
                for (int j = 0; j < Grid.ObjekatKlaseGrid.M; j++)
                {
                    if (!Grid.ObjekatKlaseGrid.MatricaProvera[i][j])
                    {
                        e.Graphics.FillRectangle(Grid.ObjekatKlaseGrid.MatricaBoja[i][j], Grid.ObjekatKlaseGrid.Matrica[i][j]);
                        e.Graphics.DrawRectangle(new Pen(Color.Crimson), Grid.ObjekatKlaseGrid.Matrica[i][j]);
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
