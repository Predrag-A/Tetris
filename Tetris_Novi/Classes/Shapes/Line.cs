using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Novi.Klase
{
    public class Line:Shape
    {
        public Line(int n):base(n,System.Drawing.Color.RoyalBlue)
        {
            for (int i = 0; i < n; i++)
                Matrica[i][n / 2] = true;
        }
    }
}
