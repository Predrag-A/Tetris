using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Klase
{
    class Triangle:Shape
    {

        #region Constructors

        public Triangle(int n):base(n,Grid.Instance.Settings.TriangleColor)
        {
            for(int i=0;i<n;i++)
            {
                Matrix[n / 2,i] = true;
            }
            for(int i=0;i<n/2;i++)
            {
                Matrix[i,n / 2] = true;
            }
        }

        #endregion

    }
}
