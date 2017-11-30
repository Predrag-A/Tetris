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
            this.preview = new System.Windows.Forms.PictureBox();
            this.msMeniIgrice = new System.Windows.Forms.MenuStrip();
            this.igraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaIgraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaderboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerDrop = new System.Windows.Forms.Timer(this.components);
            this.TC = new Tetris_Novi.User_control.TetrisControl();
            this.panel = new System.Windows.Forms.Panel();
            this.lblPause = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.msMeniIgrice.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // preview
            // 
            this.preview.BackColor = System.Drawing.Color.Transparent;
            this.preview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.preview.Location = new System.Drawing.Point(25, 65);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(152, 151);
            this.preview.TabIndex = 0;
            this.preview.TabStop = false;
            this.preview.Visible = false;
            this.preview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
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
            this.endGameToolStripMenuItem,
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
            this.novaIgraToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.novaIgraToolStripMenuItem.Text = "New Game";
            this.novaIgraToolStripMenuItem.Click += new System.EventHandler(this.novaIgraToolStripMenuItem_Click);
            // 
            // pauzaToolStripMenuItem
            // 
            this.pauzaToolStripMenuItem.Name = "pauzaToolStripMenuItem";
            this.pauzaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.pauzaToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.pauzaToolStripMenuItem.Text = "Pause";
            this.pauzaToolStripMenuItem.Click += new System.EventHandler(this.pauzaToolStripMenuItem_Click);
            // 
            // endGameToolStripMenuItem
            // 
            this.endGameToolStripMenuItem.Name = "endGameToolStripMenuItem";
            this.endGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.endGameToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.endGameToolStripMenuItem.Text = "End Game";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.izlazToolStripMenuItem.Text = "Exit";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
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
            // timerDrop
            // 
            this.timerDrop.Interval = 1000;
            this.timerDrop.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TC
            // 
            this.TC.BackColor = System.Drawing.Color.Transparent;
            this.TC.Location = new System.Drawing.Point(0, 27);
            this.TC.Name = "TC";
            this.TC.Size = new System.Drawing.Size(311, 614);
            this.TC.TabIndex = 9;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lblPause);
            this.panel.Controls.Add(this.lblNext);
            this.panel.Controls.Add(this.lblScore);
            this.panel.Controls.Add(this.lblTime);
            this.panel.Controls.Add(this.lblLevel);
            this.panel.Controls.Add(this.preview);
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Location = new System.Drawing.Point(317, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(200, 617);
            this.panel.TabIndex = 12;
            // 
            // lblPause
            // 
            this.lblPause.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPause.ForeColor = System.Drawing.Color.Crimson;
            this.lblPause.Location = new System.Drawing.Point(0, 548);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(200, 23);
            this.lblPause.TabIndex = 16;
            this.lblPause.Text = "Paused";
            this.lblPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNext
            // 
            this.lblNext.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNext.ForeColor = System.Drawing.Color.Crimson;
            this.lblNext.Location = new System.Drawing.Point(0, 23);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(200, 23);
            this.lblNext.TabIndex = 15;
            this.lblNext.Text = "Next Figure:";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScore.ForeColor = System.Drawing.Color.Crimson;
            this.lblScore.Location = new System.Drawing.Point(0, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(200, 23);
            this.lblScore.TabIndex = 14;
            this.lblScore.Text = "Score:";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.ForeColor = System.Drawing.Color.Crimson;
            this.lblTime.Location = new System.Drawing.Point(0, 571);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(200, 23);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "Time:";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLevel
            // 
            this.lblLevel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLevel.ForeColor = System.Drawing.Color.Crimson;
            this.lblLevel.Location = new System.Drawing.Point(0, 594);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(200, 23);
            this.lblLevel.TabIndex = 12;
            this.lblLevel.Text = "Level:";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerGame
            // 
            this.timerGame.Interval = 1000;
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 641);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.TC);
            this.Controls.Add(this.msMeniIgrice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.msMeniIgrice.ResumeLayout(false);
            this.msMeniIgrice.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.MenuStrip msMeniIgrice;
        private System.Windows.Forms.ToolStripMenuItem igraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaIgraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
        private System.Windows.Forms.Timer timerDrop;
        private User_control.TetrisControl TC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem leaderboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.ToolStripMenuItem endGameToolStripMenuItem;
    }
}

