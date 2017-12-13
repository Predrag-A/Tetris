using System.Drawing;
using Tetris.Classes;

namespace Tetris.Klase
{
    public class Grid
    {

        #region Fields

        #endregion

        #region Properties

        public Square[,] Matrix { get; set; }

        internal Settings Settings { get; set; }

        #endregion

        #region Constructors

        private Grid ()
        {
            Settings = new Settings();
            Initialize();
        }

        #endregion

        #region Methods

        //Initializes matrix of squares
        public void Initialize()
        {
            Matrix = new Square[Settings.Rows, Settings.Columns];

            for (var i = 0; i < Settings.Rows; i++)            
                for (var j = 0; j < Settings.Columns; j++)
                    Matrix[i, j] = new Square(new Point(j * Settings.Size, i * Settings.Size), 
                        new Size(Settings.Size, Settings.Size), new SolidBrush(Settings.TetrisBackground));                           
        }

        //Adds a new shape and colors in the corresponding squares in the grid
        public void AddShape(Shape obj)
        {
            for(var i=0;i<obj.Dim;i++)
            {
                for(var j=0;j<obj.Dim;j++)
                {
                    if(obj.Matrix[i,j])
                    {
                        Matrix[i + obj.Location.X,j + obj.Location.Y].Filled = true;
                        Matrix[i + obj.Location.X,j + obj.Location.Y].Brush = new SolidBrush(obj.Color);
                    }
                }
            }
        }

        //Removes the shape from the grid
        public void DeleteShape(Shape obj)
        {
            for(var i=0;i<obj.Dim;i++)
            {
                for(var j=0;j<obj.Dim;j++)
                {
                    if(obj.Matrix[i,j])
                    {
                        Matrix[i + obj.Location.X, j + obj.Location.Y].Filled = false;
                        Matrix[i + obj.Location.X, j + obj.Location.Y].Brush = new SolidBrush(Settings.TetrisBackground);
                    }
                }
            }
        }

        //Checks if the location of the shape is already taken
        public bool IsTaken(Shape obj)
        {
            var check1 = obj.Dim - 1 + obj.Location.X;
            var check2 = obj.Dim - 1 + obj.Location.Y;
            var check3 = obj.Location.Y;
            var status = false;

            for(var j=obj.Dim-1;j>=0;j--)
            {
                for(var i=0;i<obj.Dim;i++)
                {
                    if (obj.Matrix[i,j])
                    {
                        status = true;
                    }
                }
                if (status)
                    break;
                check2--;
            }

            status = false;
            for(var j=obj.Dim-1;j>=0;j--)
            {
                for(var i=0;i<obj.Dim;i++)
                {
                    if(obj.Matrix[j,i])
                    {
                        status = true;
                    }
                }
                if (status)
                    break;
                check1--;
            }


            status = false;
            for(var j=0;j<obj.Dim;j++)
            {
                for(var i=0;i<obj.Dim;i++)
                {
                    if(obj.Matrix[i,j])
                    {
                        status = true;
                    }
                }
                if (status)
                    break;
                check3++;
            }

            if (check1 >= Settings.Rows || check2 >= Settings.Columns || check3 < 0)
                return true;
            for(var i=0;i<obj.Dim;i++)
            {
                for(var j=0;j<obj.Dim;j++)
                {
                    if(obj.Matrix[i,j])
                    {
                        if (Matrix[i+obj.Location.X,j+obj.Location.Y].Filled)
                            return true;
                    }
                }
                
            }
            return false;
        }

        //If any rows are filled, delete them and return the number of deleted rows
        public int DeleteRows()
        {
            var count = 0;
            for(var i=Settings.Rows-1;i>=0;i--)
            {                
                var deleted = true;
                //Checks if the row is filled, if it's not deleted=false
                for (var j = Settings.Columns - 1; j >= 0; j--)
                    if (Matrix[i,j].Filled == false)
                        deleted = false;
                if(deleted)
                {
                    //If the entire row is filled, move all the rows above the deleted row lower and increase the counter
                    count++;
                    for(var k=i;k>0;k--)
                    {
                        for(var l=Settings.Columns-1;l>=0;l--)
                        {
                            Matrix[k,l].Filled = Matrix[k - 1,l].Filled;
                            Matrix[k,l].Brush = Matrix[k - 1,l].Brush;
                        }
                    }
                    //Because all rows have been shifted, fill in the first row as if it were empty
                    for(var k=Settings.Columns-1;k>=0;k--)
                    {
                        Matrix[0,k].Filled = false;
                        Matrix[0,k].Brush = new SolidBrush(Settings.TetrisBackground);
                    }
                    i++;
                }
            }
            return count;
        }

        #endregion

        #region Singleton

        private static Grid _instance;

        public static Grid Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Grid();
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        #endregion

    }
}
