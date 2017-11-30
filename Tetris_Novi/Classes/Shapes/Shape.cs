using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris.Klase
{
    public class Shape
    {

        #region Attributes

        bool[,] _matrix;
        int _dim;
        Color _color;
        Point _location;

        #endregion

        #region Properties

        public bool[,] Matrix { get { return _matrix; } set { _matrix = value; } }
        public int Dim { get { return _dim; } set { _dim = value; } }
        public Color Color { get { return _color; } set { _color = value; } }
        public Point Location { get { return _location; } set { _location = value; } }
        
        #endregion

        #region Constructors

        public Shape(int n,Color c)
        {
            Color = c;
            Dim = n;

            Matrix = new bool[Dim, Dim];
            for(int i=0;i<Dim;i++)
            {
                for(int j=0;j<Dim;j++)
                {
                    Matrix[i,j] = false;
                }
            }
            Location = new Point(0, Grid.Instance.Settings.Columns / 2 - 1);
        }

        public Shape(Shape obj)
        {
            Color = obj.Color;
            Dim = obj.Dim;
            Matrix = new bool[Dim,Dim];
            for(int i=0;i<Dim;i++)
            {
                for(int j=0;j<Dim;j++)
                {
                    Matrix[i,j] = obj.Matrix[i,j];
                }
            }
            Location = new Point(0, Grid.Instance.Settings.Columns / 2 - 1);
        }

        #endregion

        #region Methods

        /*
         * Rotation:
         * When rotating right, for a N=3 matrix the indexes are transferred as such:
         *      i=0:         i=1:        i=2:               010     010
         * j=0  0,0->0,2     1,0->0,1    0,2->2,2           111  => 011
         * j=1  0,1->1,2     1,1->1,1    1,2->2,1           000     010
         * j=2  0,2->2,2     1,2->2,1    2,2->2,0
         * As such we can conclude that the relation is i,j->j,N-1-i. When rotating left it's the opposite.
        */

        public void RotateR()
        {            
            bool[,] pom = new bool[Dim,Dim];

            for(int i=0;i<Dim;i++)
            {
                for(int j=0;j<Dim;j++)
                {
                    pom[j,Dim - 1 - i] = Matrix[i,j];
                }
            }

            for(int i=0;i<Dim;i++)
            {
                for(int j=0;j<Dim;j++)
                {
                    Matrix[i,j] = pom[i,j];
                }
            }
        }

        public void RotateL()
        {
            bool[,] pom = new bool[Dim, Dim];

            for (int i = 0; i < Dim; i++)
            {
                for (int j = 0; j < Dim; j++)
                {
                    pom[i, j] = Matrix[j, Dim - i - 1];
                }
            }

            for (int i = 0; i < Dim; i++)
            {
                for (int j = 0; j < Dim; j++)
                {
                    Matrix[i, j] = pom[i, j];
                }
            }
        }

        public void SetLocation(Point loc)
        {
            _location = loc;
        }

        #endregion

    }
}
