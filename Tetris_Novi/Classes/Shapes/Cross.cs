using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Klase
{
    public class Cross:Shape
    {

        #region Constructors

        public Cross(int n):base(n,Grid.Instance.Settings.CrossColor)
        {
            for (int i = 0; i < Dim; i++)
                Matrix[i,n / 2] = true;
            for(int i=0;i<n;i++)
            {
                Matrix[n / 2,i] = true;
            }
        }

        #endregion

    }
}
