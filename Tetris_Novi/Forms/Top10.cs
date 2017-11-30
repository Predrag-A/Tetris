using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris_Novi.Klase;

namespace Tetris_Novi
{
    public partial class Top10 : Form
    {
        ListaIgraca _lista;

        public Top10()
        {
            InitializeComponent();
            _lista = new ListaIgraca();
        }

        public void LoadPodaci()
        {
            //dataGridView1.RowCount = 10;
            dataGridView1.DataSource = _lista.Lista.ToList();
            dataGridView1.Columns[0].HeaderText = "Ime igraca";
            dataGridView1.Columns[1].HeaderText = "Broj poena";
        }

        private void Top10_Load(object sender, EventArgs e)
        {
            _lista = _lista.DeSerialize("Top10.xml");
            _lista.Sort();
            LoadPodaci();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
