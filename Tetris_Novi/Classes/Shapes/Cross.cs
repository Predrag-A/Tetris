namespace Tetris.Klase
{
    public class Cross:Shape
    {

        #region Constructors

        public Cross(int n):base(n,Grid.Instance.Settings.CrossColor)
        {
            for (var i = 0; i < Dim; i++)
                Matrix[i,n / 2] = true;
            for(var i=0;i<n;i++)
            {
                Matrix[n / 2,i] = true;
            }
        }

        #endregion

    }
}
