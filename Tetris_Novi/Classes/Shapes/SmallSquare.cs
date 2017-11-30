using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Novi.Klase
{
    public class SmallSquare:Shape
    {
        public SmallSquare(int n):base(n,System.Drawing.Color.Yellow)
        {
            Matrica[N / 2][N / 2] = true;
        }

    }
}
