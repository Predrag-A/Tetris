﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tetris_Novi.Classes;

namespace Tetris_Novi.Klase
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
            int icordinata = obj.GlavnaKoordinata.X;
            int jcordinata = obj.GlavnaKoordinata.Y;

            for(int i=0;i<obj.N;i++)
            {
                for(int j=0;j<obj.N;j++)
                {
                    if(obj.Matrica[i][j])
                    {
                        Matrix[i + icordinata,j + jcordinata].Filled = true;
                        Matrix[i + icordinata,j + jcordinata].Brush = new SolidBrush(obj.Boja);
                    }
                }
            }
        }

        //Removes the shape from the grid
        public void DeleteShape(Shape obj)
        {
            int icoordinata = obj.GlavnaKoordinata.X;
            int jcoordinata = obj.GlavnaKoordinata.Y;
            for(int i=0;i<obj.N;i++)
            {
                for(int j=0;j<obj.N;j++)
                {
                    if(obj.Matrica[i][j])
                    {
                        Matrix[i + icoordinata, j + jcoordinata].Filled = false;
                        Matrix[i + icoordinata, j + jcoordinata].Brush = new SolidBrush(Settings.TetrisBackground);
                    }
                }
            }
        }

        public bool IsTaken(Shape obj)
        {
            int icoordinata = obj.GlavnaKoordinata.X;
            int jcoordinata = obj.GlavnaKoordinata.Y;
            int proveri1 = obj.N - 1 + icoordinata;
            int proveri2 = obj.N - 1 + jcoordinata;
            int provera3 = jcoordinata;
            bool provera = false;

            for(int j=obj.N-1;j>=0;j--)
            {
                for(int i=0;i<obj.N;i++)
                {
                    if (obj.Matrica[i][j])
                    {
                        provera = true;
                    }
                }
                if (provera)
                    break;
                proveri2--;
            }

            provera = false;
            for(int j=obj.N-1;j>=0;j--)
            {
                for(int i=0;i<obj.N;i++)
                {
                    if(obj.Matrica[j][i])
                    {
                        provera = true;
                    }
                }
                if (provera)
                    break;
                proveri1--;
            }


            provera = false;
            for(int j=0;j<obj.N;j++)
            {
                for(int i=0;i<obj.N;i++)
                {
                    if(obj.Matrica[i][j])
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
            for(int i=0;i<obj.N;i++)
            {
                for(int j=0;j<obj.N;j++)
                {
                    if(obj.Matrica[i][j])
                    {
                        if (Matrix[i+icoordinata,j+jcoordinata].Filled)
                            return true;
                    }
                }
                
            }
            return false;
        }

        public int DeleteRows()
        {
            //funkcija koja trazi sve redove i brise ih 
            int red = 0;
            for(int i=Settings.Rows-1;i>=0;i--)
            {
                bool brisati = true;
                for (int j = Settings.Columns - 1; j >= 0; j--)
                    if (Matrix[i,j].Filled == false)
                        brisati = false;
                if(brisati)
                {
                    red++;
                    for(int k=i;k>0;k--)//pomera sve odozgo na dole
                    {
                        for(int l=Settings.Columns-1;l>=0;l--)
                        {
                            Matrix[k,l].Filled = Matrix[k - 1,l].Filled;
                            Matrix[k,l].Brush = Matrix[k - 1,l].Brush;
                        }
                    }
                    for(int k=Settings.Columns-1;k>=0;k--)
                    {
                        Matrix[0,k].Filled = false;
                        Matrix[0,k].Brush = new SolidBrush(Settings.TetrisBackground);
                    }
                    i++;
                }
            }
            return red;
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
