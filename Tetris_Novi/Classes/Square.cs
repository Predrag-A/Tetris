using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Novi.Classes
{
    public class Square
    {
        Rectangle _rect;
        bool _filled;
        SolidBrush _brush;

        public Rectangle Rect { get { return _rect; } set { _rect = value; } }
        public bool Filled { get { return _filled; } set { _filled = value; } }
        public SolidBrush Brush { get { return _brush; } set { _brush = value; } }

        public Square(Point p, Size s, SolidBrush b)
        {
            _rect = new Rectangle(p, s);
            _filled = false;
            _brush = b;
        }
    }
}
