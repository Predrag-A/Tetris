using System;
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
        Square[,] _matrix;
        Rectangle[][] _matrica;
        int _n;
        int _m;
        Size _size; //velicina SmallSquare
        bool[][] _matricaProvera; //matrica koja nam sluzi koja su polja popunjena
        SolidBrush[][] _matricaBoja;//kako treva da boji
        SolidBrush _primarnaCetka;//boja za neobojena

        private static Grid _objekatKlaseGrid;
        

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

        public int M
        {
            get
            {
                return _m;
            }

            set
            {
                _m = value;
            }
        }

        public Size VelicinaSmallSquare
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        public bool[][] MatricaProvera
        {
            get
            {
                return _matricaProvera;
            }

            set
            {
                _matricaProvera = value;
            }
        }

        public SolidBrush[][] MatricaBoja
        {
            get
            {
                return _matricaBoja;
            }

            set
            {
                _matricaBoja = value;
            }
        }

        public SolidBrush PrimarnaCetka
        {
            get
            {
                return _primarnaCetka;
            }

            set
            {
                _primarnaCetka = value;
            }
        }

        public static Grid ObjekatKlaseGrid
        {
            get
            {
                if (_objekatKlaseGrid == null)
                    _objekatKlaseGrid = new Grid();
                return _objekatKlaseGrid;
            }

            set
            {
                _objekatKlaseGrid = value;
            }
        }

        public Rectangle[][] Matrica { get { return _matrica; } set { _matrica = value; } }

        public Square[,] Matrix { get { return _matrix; } set { _matrix = value; } }

        private Grid ()
        {
            _size = new Size(Settings.Instance.SingleSquareWidth, Settings.Instance.SingleSquareWidth);
            PrimarnaCetka = new SolidBrush(Settings.Instance.TetrisBackground);
            N = Settings.Instance.Rows;
            M = Settings.Instance.Columns;
            Matrica = new Rectangle[N][];
            MatricaProvera = new bool[N][];
            MatricaBoja = new SolidBrush[N][];
            Matrix = new Square[N, M];
            for(int i=0;i<N;i++)
            {
                Matrica[i] = new Rectangle[M];
                MatricaBoja[i] = new SolidBrush[M];
                MatricaProvera[i] = new bool[M];
            }
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<M;j++)
                {
                    Matrica[i][j] = new Rectangle(new Point(j * _size.Height, i * _size.Width),_size);
                    MatricaProvera[i][j] = false;
                    MatricaBoja[i][j] = PrimarnaCetka;

                    Matrix[i, j] = new Square(new Point(j * _size.Height, i * _size.Width), _size, PrimarnaCetka);
                }
            }
        }
        public void dodajFiguru(Shape obj)
        {
            //funkcija koja dodaje novu figuru i dodaje boju gde treba u matrici boja
            int icordinata = obj.GlavnaKoordinata.X;
            int jcordinata = obj.GlavnaKoordinata.Y;
            for(int i=0;i<obj.N;i++)
            {
                for(int j=0;j<obj.N;j++)
                {
                    if(obj.Matrica[i][j])
                    {
                        MatricaProvera[i + icordinata][j + jcordinata] = true;
                        MatricaBoja[i + icordinata][j + jcordinata] = new SolidBrush(obj.Boja);

                        Matrix[i + icordinata,j + jcordinata].Filled = true;
                        Matrix[i + icordinata,j + jcordinata].Brush = new SolidBrush(obj.Boja);
                    }
                }
            }
        }

        public void obrisiFiguru(Shape obj)
        {
            int icoordinata = obj.GlavnaKoordinata.X;
            int jcoordinata = obj.GlavnaKoordinata.Y;
            for(int i=0;i<obj.N;i++)
            {
                for(int j=0;j<obj.N;j++)
                {
                    if(obj.Matrica[i][j])
                    {
                        MatricaProvera[i + icoordinata][j + jcoordinata] = false;
                        MatricaBoja[i + icoordinata][j + jcoordinata] = PrimarnaCetka;

                        Matrix[i + icoordinata, j + jcoordinata].Filled = false;
                        Matrix[i + icoordinata, j + jcoordinata].Brush = PrimarnaCetka;
                    }
                }
            }
        }

        public bool ZauzetoJe(Shape obj)
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

            if (proveri1 >= N || proveri2 >= M || provera3 < 0)
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

        public int obrisiRedove()
        {
            //funkcija koja trazi sve redove i brise ih 
            int red = 0;
            for(int i=N-1;i>=0;i--)
            {
                bool brisati = true;
                for (int j = M - 1; j >= 0; j--)
                    if (Matrix[i,j].Filled == false)
                        brisati = false;
                if(brisati)
                {
                    red++;
                    for(int k=i;k>0;k--)//pomera sve odozgo na dole
                    {
                        for(int l=M-1;l>=0;l--)
                        {
                            Matrix[k,l].Filled = Matrix[k - 1,l].Filled;
                            Matrix[k,l].Brush = Matrix[k - 1,l].Brush;
                        }
                    }
                    for(int k=M-1;k>=0;k--)
                    {
                        Matrix[0,k].Filled = false;
                        Matrix[0,k].Brush = PrimarnaCetka;
                    }
                    i++;
                }
            }
            return red;
        }
    }
}
