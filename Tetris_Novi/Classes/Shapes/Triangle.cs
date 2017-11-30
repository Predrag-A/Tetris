using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Novi.Klase
{
    class Triangle:Shape
    {
        public Triangle(int n):base(n,System.Drawing.Color.Red)
        {
            for(int i=0;i<n;i++)
            {
                Matrica[n / 2][i] = true;
            }
            for(int i=0;i<n/2;i++)
            {
                Matrica[i][n / 2] = true;
            }
        }
    }
}
