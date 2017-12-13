using System.Drawing;
using System.Windows.Forms;
using Tetris.Klase;

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
            Width = Grid.Instance.Settings.Columns * Grid.Instance.Settings.Size;
            Height = Grid.Instance.Settings.Rows * Grid.Instance.Settings.Size;
            Refresh();
        }

        void paint(PaintEventArgs e)
        {
            for (var i = 0; i < Grid.Instance.Settings.Rows; i++)
            {
                for (var j = 0; j < Grid.Instance.Settings.Columns; j++)
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
