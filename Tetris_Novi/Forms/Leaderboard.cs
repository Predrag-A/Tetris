using System;
using System.Linq;
using System.Windows.Forms;
using Tetris.Classes;

namespace Tetris.Forms
{
    public partial class LeaderboardForm : Form
    {

        #region Fields

        PlayerList _list;

        #endregion

        #region Constructors

        public LeaderboardForm(PlayerList l)
        {
            _list = l;
            InitializeComponent();
        }

        #endregion

        #region Methods

        void LoadData()
        {
            data.DataSource = _list.List.ToList();
            data.Columns[2].HeaderText = "Date";
            data.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        #endregion

        #region Events

        private void LeaderboardForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the leaderboard?", "Confirm",
                    MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            _list.List.Clear();
            _list.Serialize("Leaderboard.xml");
            Close();
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
