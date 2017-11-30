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
    public partial class FormIgrac : Form
    {
        public Igrac trenutniIgrac;

        public FormIgrac()
        {
            InitializeComponent();
        }

        public FormIgrac(string text)
        {
            InitializeComponent();
            tbBrojPoena.Text = text;
        }
        public bool Validacija()
        {
            if (String.IsNullOrEmpty(tbImeIgraca.Text))
            {
                DialogResult dlg = MessageBox.Show("Informacija", "Da li zelite da budete sacuvani kao 'Nepoznat'", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlg == DialogResult.Yes)
                {
                    tbImeIgraca.Text = "Nepoznat";
                    return true;
                }
                else
                {
                    tbImeIgraca.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if(Validacija())
            {
                trenutniIgrac = new Igrac(tbImeIgraca.Text, int.Parse(tbBrojPoena.Text));
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
