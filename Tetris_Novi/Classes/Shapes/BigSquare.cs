using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Klase
{
    public class BigSquare:Shape
    {

        #region Constructors

        public BigSquare(int n):base(n,Grid.Instance.Settings.BigSquareColor)
        {
            for(int i=0;i<Dim;i++)
            {
                for(int j=0;j<Dim;j++)
                {
                    Matrix[i,j] = true;
                }
            }
        }

        #endregion

    }
}
