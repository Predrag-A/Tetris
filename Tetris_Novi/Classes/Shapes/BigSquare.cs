using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Novi.Klase
{
    public class BigSquare:Shape
    {
        public BigSquare(int n):base(n,System.Drawing.Color.DarkGreen)
        {
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    Matrica[i][j] = true;
                }
            }
        }
    }
}
