using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Klase;
using Tetris.Classes;
using Tetris.Forms;

namespace Tetris.User_control
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

        public void ResizeGrid()
        {
            this.Width = Grid.Instance.Settings.Columns * Grid.Instance.Settings.Size;
            this.Height = Grid.Instance.Settings.Rows * Grid.Instance.Settings.Size;
            this.Refresh();
        }

        void paint(PaintEventArgs e)
        {
            for (int i = 0; i < Grid.Instance.Settings.Rows; i++)
            {
                for (int j = 0; j < Grid.Instance.Settings.Columns; j++)
                {
                    if (Grid.Instance.Matrix[i, j].Filled)
                        e.Graphics.FillRectangle(Grid.Instance.Matrix[i, j].Brush, Grid.Instance.Matrix[i, j].Rect);
                    else
                    {
                        e.Graphics.FillRectangle(Grid.Instance.Matrix[i, j].Brush, Grid.Instance.Matrix[i, j].Rect);
                        e.Graphics.DrawRectangle(new Pen(Grid.Instance.Settings.TetrisBorder), Grid.Instance.Matrix[i, j].Rect);
                    }
                }
            }
        }

        #endregion

        #region Events
        
        private void pbTetris_Paint_1(object sender, PaintEventArgs e)
        {
            paint(e);
        }

        #endregion

    }
}
