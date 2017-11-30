using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris.Forms
{
    public partial class NameForm : Form
    {

        #region Attributes

        string _name;

        #endregion

        #region Properties

        public string PlayerName { get { return _name; } set { _name = value; } }

        #endregion

        #region Constructors
        
        public NameForm()
        {
            InitializeComponent();
            _name = txtName.Text;
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
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        #endregion

    }
}
