namespace Tetris_Novi.User_control
{
    partial class TetrisControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbTetris = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTetris)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTetris
            // 
            this.pbTetris.BackColor = System.Drawing.Color.Transparent;
            this.pbTetris.Location = new System.Drawing.Point(3, 3);
            this.pbTetris.Name = "pbTetris";
            this.pbTetris.Size = new System.Drawing.Size(365, 602);
            this.pbTetris.TabIndex = 0;
            this.pbTetris.TabStop = false;
            this.pbTetris.Paint += new System.Windows.Forms.PaintEventHandler(this.pbTetris_Paint_1);
            // 
            // TetrisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbTetris);
            this.Name = "TetrisControl";
            this.Size = new System.Drawing.Size(371, 608);
            ((System.ComponentModel.ISupportInitialize)(this.pbTetris)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTetris;
    }
}
