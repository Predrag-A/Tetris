using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_Novi.Forms
{
    public partial class NameForm : Form
    {

        string _name;

        public string PlayerName { get { return _name; } set { _name = value; } }

        public NameForm()
        {
            InitializeComponent();
            _name = txtName.Text;
        }

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
    }
}
