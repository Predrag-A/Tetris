using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tetris.Classes;

namespace Tetris.Klase
{
    public class Grid
    {

        #region Attributes

        Square[,] _matrix;
        Settings _settings;

        #endregion

        #region Properties

        public Square[,] Matrix { get { return _matrix; } set { _matrix = value; } }
        internal Settings Settings { get { return _settings; } set { _settings = value; } }

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

            for (int i = 0; i < Settings.Rows; i++)            
                for (int j = 0; j < Settings.Columns; j++)
                    Matrix[i, j] = new Square(new Point(j * Settings.Size, i * Settings.Size), 
                        new Size(Settings.Size, Settings.Size), new SolidBrush(Settings.TetrisBackground));                           
        }

        //Adds a new shape and colors in the corresponding squares in the grid
        public void AddShape(Shape obj)
        {
            for(int i=0;i<obj.Dim;i++)
            {
                for(int j=0;j<obj.Dim;j++)
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
            for(int i=0;i<obj.Dim;i++)
            {
                for(int j=0;j<obj.Dim;j++)
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
            int check1 = obj.Dim - 1 + obj.Location.X;
            int check2 = obj.Dim - 1 + obj.Location.Y;
            int check3 = obj.Location.Y;
            bool status = false;

            for(int j=obj.Dim-1;j>=0;j--)
            {
                for(int i=0;i<obj.Dim;i++)
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
            for(int j=obj.Dim-1;j>=0;j--)
            {
                for(int i=0;i<obj.Dim;i++)
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
            for(int j=0;j<obj.Dim;j++)
            {
                for(int i=0;i<obj.Dim;i++)
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
            for(int i=0;i<obj.Dim;i++)
            {
                for(int j=0;j<obj.Dim;j++)
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
            int count = 0;
            for(int i=Settings.Rows-1;i>=0;i--)
            {                
                bool deleted = true;
                //Checks if the row is filled, if it's not deleted=false
                for (int j = Settings.Columns - 1; j >= 0; j--)
                    if (Matrix[i,j].Filled == false)
                        deleted = false;
                if(deleted)
                {
                    //If the entire row is filled, move all the rows above the deleted row lower and increase the counter
                    count++;
                    for(int k=i;k>0;k--)
                    {
                        for(int l=Settings.Columns-1;l>=0;l--)
                        {
                            Matrix[k,l].Filled = Matrix[k - 1,l].Filled;
                            Matrix[k,l].Brush = Matrix[k - 1,l].Brush;
                        }
                    }
                    //Because all rows have been shifted, fill in the first row as if it were empty
                    for(int k=Settings.Columns-1;k>=0;k--)
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
