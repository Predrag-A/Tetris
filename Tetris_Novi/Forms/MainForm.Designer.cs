namespace Tetris_Novi
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNivo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVreme = new System.Windows.Forms.Label();
            this.lblTrenutniRezultat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrenutniBrojPoena = new System.Windows.Forms.Label();
            this.msMeniIgrice = new System.Windows.Forms.MenuStrip();
            this.igraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaIgraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblPauzirano = new System.Windows.Forms.Label();
            this.TetrisControl1 = new Tetris_Novi.User_control.TetrisControl();
            this.leaderboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.msMeniIgrice.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(353, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 151);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // lblNivo
            // 
            this.lblNivo.AutoSize = true;
            this.lblNivo.BackColor = System.Drawing.Color.Transparent;
            this.lblNivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNivo.ForeColor = System.Drawing.Color.Crimson;
            this.lblNivo.Location = new System.Drawing.Point(395, 490);
            this.lblNivo.Name = "lblNivo";
            this.lblNivo.Size = new System.Drawing.Size(0, 20);
            this.lblNivo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(349, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nivo";
            // 
            // lblVreme
            // 
            this.lblVreme.AutoSize = true;
            this.lblVreme.BackColor = System.Drawing.Color.Transparent;
            this.lblVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVreme.ForeColor = System.Drawing.Color.Crimson;
            this.lblVreme.Location = new System.Drawing.Point(414, 519);
            this.lblVreme.Name = "lblVreme";
            this.lblVreme.Size = new System.Drawing.Size(0, 20);
            this.lblVreme.TabIndex = 4;
            // 
            // lblTrenutniRezultat
            // 
            this.lblTrenutniRezultat.AutoSize = true;
            this.lblTrenutniRezultat.BackColor = System.Drawing.Color.Transparent;
            this.lblTrenutniRezultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTrenutniRezultat.ForeColor = System.Drawing.Color.Crimson;
            this.lblTrenutniRezultat.Location = new System.Drawing.Point(414, 52);
            this.lblTrenutniRezultat.Name = "lblTrenutniRezultat";
            this.lblTrenutniRezultat.Size = new System.Drawing.Size(0, 20);
            this.lblTrenutniRezultat.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(351, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vreme:";
            // 
            // lblTrenutniBrojPoena
            // 
            this.lblTrenutniBrojPoena.AutoSize = true;
            this.lblTrenutniBrojPoena.BackColor = System.Drawing.Color.Transparent;
            this.lblTrenutniBrojPoena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTrenutniBrojPoena.ForeColor = System.Drawing.Color.Crimson;
            this.lblTrenutniBrojPoena.Location = new System.Drawing.Point(349, 52);
            this.lblTrenutniBrojPoena.Name = "lblTrenutniBrojPoena";
            this.lblTrenutniBrojPoena.Size = new System.Drawing.Size(59, 20);
            this.lblTrenutniBrojPoena.TabIndex = 0;
            this.lblTrenutniBrojPoena.Text = "Poeni:";
            // 
            // msMeniIgrice
            // 
            this.msMeniIgrice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.igraToolStripMenuItem,
            this.leaderboardToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.msMeniIgrice.Location = new System.Drawing.Point(0, 0);
            this.msMeniIgrice.Name = "msMeniIgrice";
            this.msMeniIgrice.Size = new System.Drawing.Size(517, 24);
            this.msMeniIgrice.TabIndex = 5;
            this.msMeniIgrice.Text = "menuStrip1";
            // 
            // igraToolStripMenuItem
            // 
            this.igraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaIgraToolStripMenuItem,
            this.pauzaToolStripMenuItem,
            this.toolStripSeparator1,
            this.izlazToolStripMenuItem});
            this.igraToolStripMenuItem.Name = "igraToolStripMenuItem";
            this.igraToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.igraToolStripMenuItem.Text = "File";
            // 
            // novaIgraToolStripMenuItem
            // 
            this.novaIgraToolStripMenuItem.Name = "novaIgraToolStripMenuItem";
            this.novaIgraToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.novaIgraToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.novaIgraToolStripMenuItem.Text = "New Game";
            this.novaIgraToolStripMenuItem.Click += new System.EventHandler(this.novaIgraToolStripMenuItem_Click);
            // 
            // pauzaToolStripMenuItem
            // 
            this.pauzaToolStripMenuItem.Name = "pauzaToolStripMenuItem";
            this.pauzaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.pauzaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pauzaToolStripMenuItem.Text = "Pause";
            this.pauzaToolStripMenuItem.Click += new System.EventHandler(this.pauzaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(349, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sledeca figura:";
            // 
            // lblPauzirano
            // 
            this.lblPauzirano.AutoSize = true;
            this.lblPauzirano.BackColor = System.Drawing.Color.Transparent;
            this.lblPauzirano.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPauzirano.ForeColor = System.Drawing.Color.Crimson;
            this.lblPauzirano.Location = new System.Drawing.Point(355, 339);
            this.lblPauzirano.Name = "lblPauzirano";
            this.lblPauzirano.Size = new System.Drawing.Size(118, 25);
            this.lblPauzirano.TabIndex = 11;
            this.lblPauzirano.Text = "Pauzirano";
            this.lblPauzirano.Visible = false;
            // 
            // TetrisControl1
            // 
            this.TetrisControl1.BackColor = System.Drawing.Color.Transparent;
            this.TetrisControl1.Location = new System.Drawing.Point(12, 27);
            this.TetrisControl1.Name = "TetrisControl1";
            this.TetrisControl1.Size = new System.Drawing.Size(314, 534);
            this.TetrisControl1.TabIndex = 9;
            // 
            // leaderboardToolStripMenuItem
            // 
            this.leaderboardToolStripMenuItem.Name = "leaderboardToolStripMenuItem";
            this.leaderboardToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.leaderboardToolStripMenuItem.Text = "Leaderboard";
            this.leaderboardToolStripMenuItem.Click += new System.EventHandler(this.najboljiRezultatiToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 569);
            this.Controls.Add(this.lblPauzirano);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNivo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblVreme);
            this.Controls.Add(this.TetrisControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTrenutniRezultat);
            this.Controls.Add(this.msMeniIgrice);
            this.Controls.Add(this.lblTrenutniBrojPoena);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.msMeniIgrice.ResumeLayout(false);
            this.msMeniIgrice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVreme;
        private System.Windows.Forms.Label lblTrenutniRezultat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrenutniBrojPoena;
        private System.Windows.Forms.MenuStrip msMeniIgrice;
        private System.Windows.Forms.ToolStripMenuItem igraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaIgraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private User_control.TetrisControl TetrisControl1;
        private System.Windows.Forms.Label lblNivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPauzirano;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem leaderboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

