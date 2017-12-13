using System;
using System.Windows.Forms;

namespace Tetris.Forms
{
    public partial class NameForm : Form
    {

        #region Fields

        #endregion

        #region Properties

        public string PlayerName { get; set; }

        #endregion

        #region Constructors
        
        public NameForm()
        {
            InitializeComponent();
            PlayerName = txtName.Text;
        }

        #endregion

        #region Events

        private void ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            PlayerName = txtName.Text;
            Close();
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        #endregion

    }
}
