namespace Tetris_Novi
{
    partial class FormIgrac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.tbBrojPoena = new System.Windows.Forms.TextBox();
            this.tbImeIgraca = new System.Windows.Forms.TextBox();
            this.lblBrojPoena = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(127, 109);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 9;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // tbBrojPoena
            // 
            this.tbBrojPoena.Location = new System.Drawing.Point(158, 66);
            this.tbBrojPoena.Name = "tbBrojPoena";
            this.tbBrojPoena.Size = new System.Drawing.Size(100, 20);
            this.tbBrojPoena.TabIndex = 8;
            // 
            // tbImeIgraca
            // 
            this.tbImeIgraca.Location = new System.Drawing.Point(158, 26);
            this.tbImeIgraca.Name = "tbImeIgraca";
            this.tbImeIgraca.Size = new System.Drawing.Size(100, 20);
            this.tbImeIgraca.TabIndex = 7;
            // 
            // lblBrojPoena
            // 
            this.lblBrojPoena.AutoSize = true;
            this.lblBrojPoena.Location = new System.Drawing.Point(52, 66);
            this.lblBrojPoena.Name = "lblBrojPoena";
            this.lblBrojPoena.Size = new System.Drawing.Size(61, 13);
            this.lblBrojPoena.TabIndex = 6;
            this.lblBrojPoena.Text = "Broj poena:";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(52, 29);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(59, 13);
            this.lblIme.TabIndex = 5;
            this.lblIme.Text = "Ime igraca:";
            // 
            // FormIgrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 162);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.tbBrojPoena);
            this.Controls.Add(this.tbImeIgraca);
            this.Controls.Add(this.lblBrojPoena);
            this.Controls.Add(this.lblIme);
            this.Name = "FormIgrac";
            this.Text = "FormIgrac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.TextBox tbBrojPoena;
        private System.Windows.Forms.TextBox tbImeIgraca;
        private System.Windows.Forms.Label lblBrojPoena;
        private System.Windows.Forms.Label lblIme;
    }
}