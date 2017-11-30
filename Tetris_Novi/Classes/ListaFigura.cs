using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris_Novi.Classes;

namespace Tetris_Novi.Klase
{
    public class ListaFigura
    {
        private static ListaFigura _instance = null;
        private List<Shape> _listaF;
        

        public ListaFigura()
        {
            _listaF = new List<Shape>();
        }
        public static ListaFigura Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ListaFigura();
                return _instance;
            }
        }

        public Shape vratiFiguru(int i)
        {
            if (i < 0 || i >= _listaF.Count)
                return _listaF[0];
            return _listaF[i];
        }

        public void dodajFiguru(Shape obj)
        {
            if (obj != null)
                _listaF.Add(obj);
        }
        public void dodajOblike(int n1)
        {
            _listaF.Clear();
            
            //Linemo i dodajemo u listu plavi pravugaonik
            Shape line = new Shape(n1, Grid.ObjekatKlaseGrid.Settings.LineColor);
            for(int i=0;i<n1;i++)
            {
                line.Matrica[i][line.GlavnaKordinataInt] = true;
            }

            //Linemo kocku popunjenu celu,veliku
            Shape bigSquare = new Shape(n1, Grid.ObjekatKlaseGrid.Settings.BigSquareColor);
            for(int i=0;i<n1;i++)
            {
                for(int j=0;j<n1;j++)
                {
                    bigSquare.Matrica[i][j] = true;
                }
            }

            //Linemo malu kockicu
            Shape smallSquare = new Shape(n1, Grid.ObjekatKlaseGrid.Settings.SmallSquareColor);
            smallSquare.Matrica[smallSquare.GlavnaKordinataInt][smallSquare.GlavnaKordinataInt] = true;

            //Linemo Cross mali
            Shape cross = new Shape(n1, Grid.ObjekatKlaseGrid.Settings.CrossColor);
            for (int i = 0; i < n1; i++)
                cross.Matrica[i][cross.GlavnaKordinataInt] = true;
            for (int j = 0; j < n1; j++)
                cross.Matrica[cross.GlavnaKordinataInt][j] = true;

            //Linemo crvenu figuru
            Shape triangle = new Shape(n1, Grid.ObjekatKlaseGrid.Settings.TriangleColor);
            for(int i=0;i<n1;i++)
            {
                triangle.Matrica[triangle.GlavnaKordinataInt][i] = true;
            }
            for(int i=0;i<triangle.GlavnaKordinataInt;i++)
            {
                triangle.Matrica[i][triangle.GlavnaKordinataInt] = true;
            }

            //dodajemo u listu figura
            _listaF.Add(line);
            _listaF.Add(bigSquare);
            _listaF.Add(smallSquare);
            _listaF.Add(cross);
            _listaF.Add(triangle);
        }

        public double vratiBrojFiguraUlisti()
        {
            return _listaF.Count;
        }


    }
}
