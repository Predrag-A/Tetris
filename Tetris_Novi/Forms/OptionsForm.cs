using System;
using System.Windows.Forms;
using Tetris.Classes;

namespace Tetris.Forms
{
    public partial class OptionsForm : Form
    {

        #region Fields

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
            DialogResult = _changed ? DialogResult.OK : DialogResult.Cancel;
        }

        #endregion

    }
}
