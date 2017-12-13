using System.Drawing;

namespace Tetris.Classes
{
    public class Square
    {

        #region Properties

        public Rectangle Rect { get; set; }

        public bool Filled { get; set; }

        public SolidBrush Brush { get; set; }

        #endregion

        #region Constructors

        public Square(Point p, Size s, SolidBrush b)
        {
            Rect = new Rectangle(p, s);
            Filled = false;
            Brush = b;
        }

        #endregion

    }
}
