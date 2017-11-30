using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Klase
{
    public class SmallSquare:Shape
    {
        #region Constructors

        public SmallSquare(int n):base(n,Grid.Instance.Settings.SmallSquareColor)
        {
            Matrix[Dim / 2,Dim / 2] = true;
        }

        #endregion

    }
}
