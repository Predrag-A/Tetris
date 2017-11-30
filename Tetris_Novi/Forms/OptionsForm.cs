using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_Novi.Classes;

namespace Tetris_Novi.Forms
{
    public partial class OptionsForm : Form
    {
        Settings _settings;

        public OptionsForm(Settings s)
        {
            InitializeComponent();
            _settings = s;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Default_Click(object sender, EventArgs e)
        {
            _settings.Default();
            propertyGrid.Refresh();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = _settings;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
