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

        #region Constructors

        public TetrisControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public DialogResult ShowOptions()
        {
            OptionsForm frm = new OptionsForm(Grid.Instance.Settings);
            return frm.ShowDialog();
        }

        #endregion

        #region events

        public void paint(PaintEventArgs e)
        {
            for (int i = 0; i < Grid.Instance.Settings.Rows; i++)
            {
                for (int j = 0; j < Grid.Instance.Settings.Columns; j++)
                {
                    if (Grid.Instance.Matrix[i,j].Filled)
                    {
                        e.Graphics.FillRectangle(Grid.Instance.Matrix[i,j].Brush, Grid.Instance.Matrix[i,j].Rect);
                    }
                }
            }

            for (int i = 0; i < Grid.Instance.Settings.Rows; i++)
            {
                for (int j = 0; j < Grid.Instance.Settings.Columns; j++)
                {
                    if (!Grid.Instance.Matrix[i,j].Filled)
                    {
                        e.Graphics.FillRectangle(Grid.Instance.Matrix[i, j].Brush, Grid.Instance.Matrix[i, j].Rect);                        
                        e.Graphics.DrawRectangle(new Pen(Grid.Instance.Settings.TetrisBorder), Grid.Instance.Matrix[i, j].Rect);

                    }
                }
            }            
        }

        private void pbTetris_Paint_1(object sender, PaintEventArgs e)
        {
            paint(e);
        }

        #endregion

    }
}
