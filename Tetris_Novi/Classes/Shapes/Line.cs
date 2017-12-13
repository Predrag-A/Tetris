namespace Tetris.Klase
{
    public class Line:Shape
    {

        #region Constructors

        public Line(int n):base(n,Grid.Instance.Settings.LineColor)
        {
            for (var i = 0; i < n; i++)
                Matrix[i,n / 2] = true;
        }

        #endregion

    }
}
