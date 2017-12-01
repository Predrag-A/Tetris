using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Classes;

namespace Tetris.Forms
{
    public partial class OptionsForm : Form
    {

        #region Attributes

        Settings _settings;
        bool _changed;

        #endregion

        #region Constructors

        public OptionsForm(Settings s)
        {
            InitializeComponent();
            _settings = s;
            _changed = false;
        }

        #endregion

        #region Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Default_Click(object sender, EventArgs e)
        {
            _settings.Default();
            _changed = true;
            propertyGrid.Refresh();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = _settings;
        }        

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!_changed)
                _changed = true;
        }        

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changed)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
