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
            int icordinata = obj.MainPoint.X;
            int jcordinata = obj.MainPoint.Y;

            for(int i=0;i<obj.Dim;i++)
            {
                for(int j=0;j<obj.Dim;j++)
                {
                    if(obj.Matrix[i,j])
                    {
                        Matrix[i + icordinata,j + jcordinata].Filled = true;
                        Matrix[i + icordinata,j + jcordinata].Brush = new SolidBrush(obj.Color);
                    }
                }
            }
        }

        //Removes the shape from the grid
        public void DeleteShape(Shape obj)
        {
            int icoordinata = obj.MainPoint.X;
            int jcoordinata = obj.MainPoint.Y;
            for(int i=0;i<obj.Dim;i++)
            {
                for(int j=0;j<obj.Dim;j++)
                {
                    if(obj.Matrix[i,j])
                    {
                        Matrix[i + icoordinata, j + jcoordinata].Filled = false;
                        Matrix[i + icoordinata, j + jcoordinata].Brush = new SolidBrush(Settings.TetrisBackground);
                    }
                }
            }
        }

        //Checks if the location of the shape is already taken
        public bool IsTaken(Shape obj)
        {
            int icoordinata = obj.MainPoint.X;
            int jcoordinata = obj.MainPoint.Y;
            int proveri1 = obj.Dim - 1 + icoordinata;
            int proveri2 = obj.Dim - 1 + jcoordinata;
            int provera3 = jcoordinata;
            bool provera = false;

            for(int j=obj.Dim-1;j>=0;j--)
            {
                for(int i=0;i<obj.Dim;i++)
                {
                    if (obj.Matrix[i,j])
                    {
                        provera = true;
                    }
                }
                if (provera)
                    break;
                proveri2--;
            }

            provera = false;
            for(int j=obj.Dim-1;j>=0;j--)
            {
                for(int i=0;i<obj.Dim;i++)
                {
                    if(obj.Matrix[j,i])
                    {
                        provera = true;
                    }
                }
                if (provera)
                    break;
                proveri1--;
            }


            provera = false;
            for(int j=0;j<obj.Dim;j++)
            {
                for(int i=0;i<obj.Dim;i++)
                {
                    if(obj.Matrix[i,j])
                    {
                        provera = true;
                    }
                }
                if (provera)
                    break;
                provera3++;
            }

            if (proveri1 >= Settings.Rows || proveri2 >= Settings.Columns || provera3 < 0)
                return true;
            for(int i=0;i<obj.Dim;i++)
            {
                for(int j=0;j<obj.Dim;j++)
                {
                    if(obj.Matrix[i,j])
                    {
                        if (Matrix[i+icoordinata,j+jcoordinata].Filled)
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
