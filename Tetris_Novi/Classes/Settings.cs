using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris.Classes
{
    public class Settings
    {

        #region Fields        

        int _squareWidth;
        int _columns;
        int _rows;
        byte _startLevel;

        #endregion

        #region Constructor

        public Settings()
        {
            Default();
        }

        public Settings(Settings s)
        {
            CrossColor = s.CrossColor;
            LineColor = s.LineColor;
            BigSquareColor = s.BigSquareColor;
            TriangleColor = s.TriangleColor;
            SmallSquareColor = s.SmallSquareColor;

            TetrisBorder = s.TetrisBorder;
            TetrisBackground = s.TetrisBackground;

            LeftKey = s.LeftKey;
            RightKey = s.RightKey;
            DownKey = s.DownKey;
            RotateKey = s.RotateKey;
            PauseKey = s.PauseKey;

            _squareWidth = s._squareWidth;
            _columns = s._columns;
            _rows = s._rows;

            _startLevel = s._startLevel;
        }


        #endregion        

        #region Methods       

        //Sets the default settings
        public void Default()
        {
            CrossColor = Color.Purple;
            LineColor = Color.Blue;
            BigSquareColor = Color.DarkGreen;
            TriangleColor = Color.Red;
            SmallSquareColor = Color.Orange;

            TetrisBorder = Color.DarkMagenta;
            TetrisBackground = Color.Black;

            LeftKey = Keys.Left;
            RightKey = Keys.Right;
            DownKey = Keys.Down;
            RotateKey = Keys.Up;
            PauseKey = Keys.P;

            _squareWidth = 30;
            _columns = 10;
            _rows = 20;

            _startLevel = 1;
        }
        
        #endregion

        #region Properties

        #region Color Properties

        [Category("Figure Colors")]
        [DisplayName("Small Square Color")]
        [Description("The Small square figure back color")]
        public Color SmallSquareColor { get; set; }

        [Category("Figure Colors")]
        [DisplayName("Cross Color")]
        [Description("The Cross figure back color")]
        public Color CrossColor { get; set; }

        [Category("Figure Colors")]
        [DisplayName("Big Square Color")]
        [Description("The Big Square figure back color")]
        public Color BigSquareColor { get; set; }

        [Category("Figure Colors")]
        [DisplayName("Line Color")]
        [Description("The Line figure back color")]
        public Color LineColor { get; set; }

        [Category("Figure Colors")]
        [DisplayName("Triangle Color")]
        [Description("The Triangle figure back color")]
        public Color TriangleColor { get; set; }

        [Category("Tetris Colors")]
        [DisplayName("Square Border Color")]
        [Description("Color of the border of Tetris squares")]
        public Color TetrisBorder { get; set; }

        [Category("Tetris Colors")]
        [DisplayName("Tetris Background Color")]
        [Description("Color of the Tetris grid background")]
        public Color TetrisBackground { get; set; }

        #endregion

        #region Keyboard Properties

        [Category("Keyboard")]
        [DisplayName("Left Key")]
        [Description("The key value for moving figures left")]
        public Keys LeftKey { get; set; }

        [Category("Keyboard")]
        [DisplayName("Right Key")]
        [Description("The key value for moving figures right")]
        public Keys RightKey { get; set; }

        [Category("Keyboard")]
        [DisplayName("Down Key")]
        [Description("The key value for moving figures down")]
        public Keys DownKey { get; set; }

        [Category("Keyboard")]
        [DisplayName("Rotate Key")]
        [Description("The key value for rotating figures")]
        public Keys RotateKey { get; set; }

        [Category("Keyboard")]
        [DisplayName("Pause Key")]
        [Description("The key value for pausing game")]
        public Keys PauseKey { get; set; }

        #endregion

        #region Size Properties

        [Category("Dimensions")]
        [Description("The width(height) of a single square in the Tetris grid. Varies from 10 to 30")]
        [DefaultValue(20)]
        public int Size
        {
            get => _squareWidth;
            set
            {
                if (value > 30 || value < 10)
                    return;
                if (_squareWidth == value)
                    return;
                _squareWidth = value;
            }
        }

        [Category("Dimensions")]
        [Description("The number of columns in the Tetris grid. Varies from 10 to 20")]
        [DefaultValue(10)]
        public int Columns
        {
            get => _columns;
            set
            {
                if (value > 20 || value < 10)
                    return;
                if (_columns == value)
                    return;
                _columns = value;
            }
        }

        [Category("Dimensions")]
        [Description("The number of rows in the Tetris grid. Varies from 15 to 30")]
        [DefaultValue(20)]
        public int Rows
        {
            get => _rows;
            set
            {
                if (value > 30 || value < 15)
                    return;
                if (_rows == value)
                    return;
                _rows = value;
            }
        }

        #endregion

        #region Misc Properties

        [DisplayName("Start Level")]
        [Description("The start level. Varies from 1 to 12")]
        public byte StartLevel
        {
            get => _startLevel;
            set
            {
                if (value > 12 || value < 1)
                    return;
                _startLevel = value;
            }
        }

        #endregion

        #endregion

    }
}
