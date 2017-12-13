namespace Tetris.Klase
{
    public class BigSquare:Shape
    {

        #region Constructors

        public BigSquare(int n):base(n,Grid.Instance.Settings.BigSquareColor)
        {
            for(var i=0;i<Dim;i++)
            {
                for(var j=0;j<Dim;j++)
                {
                    Matrix[i,j] = true;
                }
            }
        }

        #endregion

    }
}
