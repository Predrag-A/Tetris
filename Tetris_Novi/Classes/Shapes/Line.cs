using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Klase
{
    public class Line:Shape
    {

        #region Constructors

        public Line(int n):base(n,Grid.Instance.Settings.LineColor)
        {
            for (int i = 0; i < n; i++)
                Matrix[i,n / 2] = true;
        }

        #endregion

    }
}
