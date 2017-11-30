using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Klase;

namespace Tetris.Classes
{
    public class Settings
    {

        #region Attributes        
        
        Color lineColor;
        Color smallSquareColor;
        Color crossColor;
        Color squareColor;
        Color triangleColor;

        
        Color tetrisBorder;
        Color tetrisBackground;
        
        Keys leftKey;
        Keys rightKey;
        Keys downKey;
        Keys rotateKey;
        Keys pauseKey;
        
        int squareWidth;
        int columns;
        int rows;
        byte startLevel;

        #endregion

        #region Constructor

        public Settings()
        {
            Default();
        }


        #endregion        

        #region Methods       

        //Sets the default settings
        public void Default()
        {
            crossColor = Color.Purple;
            lineColor = Color.Blue;
            squareColor = Color.DarkGreen;
            triangleColor = Color.Red;
            smallSquareColor = Color.Orange;

            tetrisBorder = Color.DarkMagenta;
            tetrisBackground = Color.Black;

            leftKey = Keys.Left;
            rightKey = Keys.Right;
            downKey = Keys.Down;
            rotateKey = Keys.Up;
            pauseKey = Keys.P;

            squareWidth = 30;
            columns = 10;
            rows = 20;

            startLevel = 1;
        }
        
        #endregion

        #region Properties

        #region Colors Properties

        [Category("Figure Colors")]
        [DisplayName("Small Square Color")]
        [Description("The Small square figure back color")]
        public Color SmallSquareColor
        {
            get
            {
                return smallSquareColor;
            }
            set
            {
                smallSquareColor = value;
            }
        }

        [Category("Figure Colors")]
        [DisplayName("Cross Color")]
        [Description("The Cross figure back color")]
        public Color CrossColor
        {
            get
            {
                return crossColor;
            }
            set
            {
                crossColor = value;
            }
        }

        [Category("Figure Colors")]
        [DisplayName("Big Square Color")]
        [Description("The Big Square figure back color")]
        public Color BigSquareColor
        {
            get
            {
                return squareColor;
            }
            set
            {
                squareColor = value;
            }
        }

        [Category("Figure Colors")]
        [DisplayName("Line Color")]
        [Description("The Line figure back color")]
        public Color LineColor
        {
            get
            {
                return lineColor;
            }
            set
            {
                lineColor = value;
            }
        }

        [Category("Figure Colors")]
        [DisplayName("Triangle Color")]
        [Description("The Triangle figure back color")]
        public Color TriangleColor
        {
            get
            {
                return triangleColor;
            }
            set
            {
                triangleColor = value;
            }
        }

        [Category("Tetris Colors")]
        [DisplayName("Square Border Color")]
        [Description("Color of the border of tetris squares")]
        public Color TetrisBorder
        {
            get
            {
                return tetrisBorder;
            }
            set
            {
                tetrisBorder = value;
            }
        }        

        [Category("Tetris Colors")]
        [DisplayName("Tetris Background Color")]
        [Description("Color of the tetris grid background")]
        public Color TetrisBackground
        {
            get
            {
                return tetrisBackground;
            }
            set
            {
                tetrisBackground = value;
            }
        }

        #endregion

        #region Keyboard Properties

        [Category("Keyboard")]
        [DisplayName("Left Key")]
        [Description("The key value for moving figures left")]
        public Keys LeftKey
        {
            get
            {
                return leftKey;
            }
            set
            {
                leftKey = value;
            }
        }

        [Category("Keyboard")]
        [DisplayName("Right Key")]
        [Description("The key value for moving figures right")]
        public Keys RightKey
        {
            get
            {
                return rightKey;
            }
            set
            {
                rightKey = value;
            }
        }

        [Category("Keyboard")]
        [DisplayName("Down Key")]
        [Description("The key value for moving figures down")]
        public Keys DownKey
        {
            get
            {
                return downKey;
            }
            set
            {
                downKey = value;
            }
        }

        [Category("Keyboard")]
        [DisplayName("Rotate Key")]
        [Description("The key value for rotating figures")]
        public Keys RotateKey
        {
            get
            {
                return rotateKey;
            }
            set
            {
                rotateKey = value;
            }
        }

        [Category("Keyboard")]
        [DisplayName("Pause Key")]
        [Description("The key value for pausing game")]
        public Keys PauseKey
        {
            get
            {
                return pauseKey;
            }
            set
            {
                pauseKey = value;
            }
        }

        #endregion

        #region Size Properties

        [Category("Dimensions")]
        [Description("The width(height) of a single square in the tetris grid. Varies from 10 to 30")]
        [DefaultValue(20)]
        public int Size
        {
            get
            {
                return squareWidth;
            }
            set
            {
                if (value > 30 || value < 10)
                    return;
                if (squareWidth == value)
                    return;
                squareWidth = value;
            }
        }

        [Category("Dimensions")]
        [Description("The number of columns in the tetris grid. Varies from 10 to 20")]
        [DefaultValue(10)]
        public int Columns
        {
            get
            {
                return columns;
            }
            set
            {
                if (value > 20 || value < 10)
                    return;
                if (columns == value)
                    return;
                columns = value;
            }
        }

        [Category("Dimensions")]
        [Description("The number of rows in the tetris grid. Varies from 15 to 30")]
        [DefaultValue(20)]
        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                if (value > 30 || value < 15)
                    return;
                if (rows == value)
                    return;
                rows = value;
            }
        }

        #endregion

        #region Misc Properties

        [DisplayName("Start Level")]
        [Description("The start level. Varies from 1 to 12")]
        public byte StartLevel
        {
            get
            {
                return startLevel;
            }
            set
            {
                if (value > 12 || value < 1)
                    return;
                startLevel = value;
            }
        }

        #endregion

        #endregion

    }
}
