using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_Novi.Klase;

namespace Tetris_Novi.Classes
{
    internal class Settings:ICloneable
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

        private Settings()
        {
            Default();
        }


        #endregion

        #region ICloneable Members

        public object Clone()
        {
            //get the type of this instance
            Type type = GetType();

            //create binding flags object
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic |
                                    BindingFlags.Public;

            //get all the fields of this instance
            FieldInfo[] fields = type.GetFields(flags);

            //create new settings object
            Settings sett = new Settings();

            //now copy all the fields to the new object
            foreach (FieldInfo fi in fields)
            {
                fi.SetValue(sett, fi.GetValue(this));
            }

            return sett;
        }

        #endregion

        #region Methods       

        public void Default()
        {
            crossColor = Color.Purple;
            lineColor = Color.Blue;
            squareColor = Color.DarkGreen;
            triangleColor = Color.Red;
            smallSquareColor = Color.Orange;

            tetrisBorder = Color.Crimson;
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
        [Description("Small square figure back color")]
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
        [Description("Cross figure back color")]
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
        [Description("The Square figure back color")]
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
        [Description("Border of tetris squares")]
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
        [Description("Tetris grid background")]
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
        protected bool ShouldSerializeLeftKey()
        {
            return leftKey != Keys.Left;
        }

        [Category("Keyboard")]
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
        protected bool ShouldSerializeRightKey()
        {
            return rightKey != Keys.Right;
        }


        [Category("Keyboard")]
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
        protected bool ShouldSerializeDownKey()
        {
            return downKey != Keys.Down;
        }


        [Category("Keyboard")]
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
        protected bool ShouldSerializeRotateKey()
        {
            return rotateKey != Keys.Up;
        }

        [Category("Keyboard")]
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
        protected bool ShouldSerializePauseKey()
        {
            return pauseKey != Keys.P;
        }



        #endregion

        #region Size Properties

        [Category("Dimensions")]
        [Description("The width(height) of a single square in the tetris grid. Varies from 10 to 30")]
        [DefaultValue(20)]
        public int SingleSquareWidth
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
        [Description("The number of rows in the tetris grid. Varies from 20 to 30")]
        [DefaultValue(20)]
        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                if (value > 30 || value < 20)
                    return;
                if (rows == value)
                    return;
                rows = value;
            }
        }

        #endregion

        #region Misc Properties

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
        protected bool ShouldSerializeStartLevel()
        {
            return startLevel != 1;
        }

        #endregion

        #endregion

        #region Singleton

        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Settings();
                return _instance;
            }
        }

        #endregion

    }
}
