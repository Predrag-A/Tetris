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
