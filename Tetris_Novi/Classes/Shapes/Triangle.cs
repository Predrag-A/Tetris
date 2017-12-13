namespace Tetris.Klase
{
    class Triangle:Shape
    {

        #region Constructors

        public Triangle(int n):base(n,Grid.Instance.Settings.TriangleColor)
        {
            for(var i=0;i<n;i++)
            {
                Matrix[n / 2,i] = true;
            }
            for(var i=0;i<n/2;i++)
            {
                Matrix[i,n / 2] = true;
            }
        }

        #endregion

    }
}
