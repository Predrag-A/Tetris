using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Novi.Klase
{
    public class Cross:Shape
    {
        public Cross(int n):base(n,System.Drawing.Color.Pink)
        {
            for (int i = 0; i < N; i++)
                Matrica[i][n / 2] = true;
            for(int i=0;i<n;i++)
            {
                Matrica[n / 2][i] = true;
            }
        }
    }
}
