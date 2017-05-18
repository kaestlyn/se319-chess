namespace ChessGame
{
    partial class Options
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
            this.chkHighlight = new System.Windows.Forms.CheckBox();
            this.btnPlayer1 = new System.Windows.Forms.Button();
            this.btnPlayer2 = new System.Windows.Forms.Button();
            this.picPlayer2 = new System.Windows.Forms.PictureBox();
            this.picPlayer1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHighlight
            // 
            this.chkHighlight.AutoSize = true;
            this.chkHighlight.Checked = true;
            this.chkHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlight.Location = new System.Drawing.Point(12, 93);
            this.chkHighlight.Name = "chkHighlight";
            this.chkHighlight.Size = new System.Drawing.Size(144, 17);
            this.chkHighlight.TabIndex = 0;
            this.chkHighlight.Text = "Highlight Possible Moves";
            this.chkHighlight.UseVisualStyleBackColor = true;
            this.chkHighlight.CheckedChanged += new System.EventHandler(this.chkHighlight_CheckedChanged);
            // 
            // btnPlayer1
            // 
            this.btnPlayer1.Location = new System.Drawing.Point(12, 35);
            this.btnPlayer1.Name = "btnPlayer1";
            this.btnPlayer1.Size = new System.Drawing.Size(144, 23);
            this.btnPlayer1.TabIndex = 1;
            this.btnPlayer1.Text = "Change Player One Color";
            this.btnPlayer1.UseVisualStyleBackColor = true;
            this.btnPlayer1.Click += new System.EventHandler(this.btnPlayer1_Click);
            // 
            // btnPlayer2
            // 
            this.btnPlayer2.Location = new System.Drawing.Point(12, 64);
            this.btnPlayer2.Name = "btnPlayer2";
            this.btnPlayer2.Size = new System.Drawing.Size(144, 23);
            this.btnPlayer2.TabIndex = 2;
            this.btnPlayer2.Text = "Change Player Two Color";
            this.btnPlayer2.UseVisualStyleBackColor = true;
            this.btnPlayer2.Click += new System.EventHandler(this.btnPlayer2_Click);
            // 
            // picPlayer2
            // 
            this.picPlayer2.BackColor = System.Drawing.Color.Gray;
            this.picPlayer2.Location = new System.Drawing.Point(162, 64);
            this.picPlayer2.Name = "picPlayer2";
            this.picPlayer2.Size = new System.Drawing.Size(23, 23);
            this.picPlayer2.TabIndex = 3;
            this.picPlayer2.TabStop = false;
            // 
            // picPlayer1
            // 
            this.picPlayer1.BackColor = System.Drawing.Color.White;
            this.picPlayer1.Location = new System.Drawing.Point(162, 35);
            this.picPlayer1.Name = "picPlayer1";
            this.picPlayer1.Size = new System.Drawing.Size(23, 23);
            this.picPlayer1.TabIndex = 4;
            this.picPlayer1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(88, 113);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 144);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picPlayer1);
            this.Controls.Add(this.picPlayer2);
            this.Controls.Add(this.btnPlayer2);
            this.Controls.Add(this.btnPlayer1);
            this.Controls.Add(this.chkHighlight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chess 319 Options";
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHighlight;
        private System.Windows.Forms.Button btnPlayer1;
        private System.Windows.Forms.Button btnPlayer2;
        private System.Windows.Forms.PictureBox picPlayer2;
        private System.Windows.Forms.PictureBox picPlayer1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}

