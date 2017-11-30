using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris_Novi.Classes;

namespace Tetris_Novi.Klase
{
    public class ShapeList
    {

        #region Attributes

        List<Shape> _list;

        #endregion


        #region Constructors

        private ShapeList()
        {
            _list = new List<Shape>();
        }

        #endregion

        #region Methods

        //Returns a shape with the index i from the list
        public Shape GetShape(int i)
        {            
            if (i < 0 || i >= _list.Count)
                return _list[0];
            return _list[i];
        }

        //Adds a shape to the list
        public void AddShape(Shape obj)
        {
            if (obj != null)
                _list.Add(obj);
        }

        //Wipes the list and adds all existing shapes to the list
        public void AddAllShapes(int n1)
        {
            _list.Clear();
            
            //Linemo i dodajemo u listu plavi pravugaonik
            Shape line = new Shape(n1, Grid.Instance.Settings.LineColor);
            for(int i=0;i<n1;i++)
            {
                line.Matrica[i][line.GlavnaKordinataInt] = true;
            }

            //Linemo kocku popunjenu celu,veliku
            Shape bigSquare = new Shape(n1, Grid.Instance.Settings.BigSquareColor);
            for(int i=0;i<n1;i++)
            {
                for(int j=0;j<n1;j++)
                {
                    bigSquare.Matrica[i][j] = true;
                }
            }

            //Linemo malu kockicu
            Shape smallSquare = new Shape(n1, Grid.Instance.Settings.SmallSquareColor);
            smallSquare.Matrica[smallSquare.GlavnaKordinataInt][smallSquare.GlavnaKordinataInt] = true;

            //Linemo Cross mali
            Shape cross = new Shape(n1, Grid.Instance.Settings.CrossColor);
            for (int i = 0; i < n1; i++)
                cross.Matrica[i][cross.GlavnaKordinataInt] = true;
            for (int j = 0; j < n1; j++)
                cross.Matrica[cross.GlavnaKordinataInt][j] = true;

            //Linemo crvenu figuru
            Shape triangle = new Shape(n1, Grid.Instance.Settings.TriangleColor);
            for(int i=0;i<n1;i++)
            {
                triangle.Matrica[triangle.GlavnaKordinataInt][i] = true;
            }
            for(int i=0;i<triangle.GlavnaKordinataInt;i++)
            {
                triangle.Matrica[i][triangle.GlavnaKordinataInt] = true;
            }

            //dodajemo u listu figura
            _list.Add(line);
            _list.Add(bigSquare);
            _list.Add(smallSquare);
            _list.Add(cross);
            _list.Add(triangle);
        }

        //Returns the number of shapes in the list
        public int GetCount()
        {
            return _list.Count;
        }

        #endregion

        #region Singleton

        static ShapeList _instance;

        public static ShapeList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ShapeList();
                return _instance;
            }
        }

        #endregion

    }
}
