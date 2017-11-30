using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris_Novi.Klase
{
    public class Shape
    {
        private bool[][] _matrica;
        private int _n;
        private Color _boja;
        private Point _glavnaKoordinata;

        public bool[][] Matrica
        {
            get
            {
                return _matrica;
            }

            set
            {
                _matrica = value;
            }
        }

        public int N
        {
            get
            {
                return _n;
            }

            set
            {
                _n = value;
            }
        }

        public Color Boja
        {
            get
            {
                return _boja;
            }

            set
            {
                _boja = value;
            }
        }

        public Point GlavnaKoordinata
        {
            get
            {
                return _glavnaKoordinata;
            }

            set
            {
                _glavnaKoordinata = value;
            }
        }

        public int GlavnaKordinataInt
        {
            get { return N / 2; }
        }

        public Shape(int n,Color boja)
        {
            Boja = boja;
            N = n;
            Matrica = new bool[n][];
            for(int i=0;i<N;i++)
            {
                Matrica[i] = new bool[N];
            }
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    Matrica[i][j] = false;
                }
            }
            GlavnaKoordinata = new Point();
        }

        public Shape(Shape obj)
        {
            Boja = obj.Boja;
            N = obj.N;
            Matrica = new bool[N][];
            for(int i=0;i<N;i++)
            {
                Matrica[i] = new bool[N];
            }
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    Matrica[i][j] = obj.Matrica[i][j];
                }
            }
            GlavnaKoordinata = new Point();
        }

        //rotacija matrice u levo
        public void RotacijaLevo()
        {
            //pravimo pomocnu matricu 
            bool[][] pom = new bool[N][];
            for(int i=0;i<N;i++)
            {
                pom[i] = new bool[N];
            }
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    pom[i][j] = Matrica[j][N - i - 1];
                }
            }

            //vracamo elemente u glavnu matricu 
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    Matrica[i][j] = pom[i][j];
                }
            }
        }

        //rotacija matrice u desno
        public void RotacijaDesno()
        {
            bool[][] pom = new bool[N][];
            for (int i = 0; i < N; i++)
                pom[i] = new bool[N];
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    pom[j][N - 1 - i] = Matrica[i][j];
                }
            }

            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    Matrica[i][j] = pom[i][j];
                }
            }
        }

        public void PodesiLokaciju(Point lokacija)
        {
            _glavnaKoordinata = lokacija;
        }

        
    }
}
