namespace Othello
{
    partial class GameSettings
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
            this.btn_PlayVSComputer = new System.Windows.Forms.Button();
            this.btn_PlayVSPlayer = new System.Windows.Forms.Button();
            this.btn_BoardSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PlayVSComputer
            // 
            this.btn_PlayVSComputer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_PlayVSComputer.AutoSize = true;
            this.btn_PlayVSComputer.Location = new System.Drawing.Point(43, 113);
            this.btn_PlayVSComputer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_PlayVSComputer.Name = "btn_PlayVSComputer";
            this.btn_PlayVSComputer.Size = new System.Drawing.Size(185, 71);
            this.btn_PlayVSComputer.TabIndex = 0;
            this.btn_PlayVSComputer.Text = "Play against the computer";
            this.btn_PlayVSComputer.UseVisualStyleBackColor = true;
            this.btn_PlayVSComputer.Click += new System.EventHandler(this.btn_PlayVSComputer_Click);
            // 
            // btn_PlayVSPlayer
            // 
            this.btn_PlayVSPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PlayVSPlayer.AutoSize = true;
            this.btn_PlayVSPlayer.Location = new System.Drawing.Point(300, 113);
            this.btn_PlayVSPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_PlayVSPlayer.Name = "btn_PlayVSPlayer";
            this.btn_PlayVSPlayer.Size = new System.Drawing.Size(192, 71);
            this.btn_PlayVSPlayer.TabIndex = 1;
            this.btn_PlayVSPlayer.Text = "Play against another player";
            this.btn_PlayVSPlayer.UseVisualStyleBackColor = true;
            this.btn_PlayVSPlayer.Click += new System.EventHandler(this.btn_PlayVSPlayer_Click);
            // 
            // btn_BoardSize
            // 
            this.btn_BoardSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_BoardSize.AutoSize = true;
            this.btn_BoardSize.Location = new System.Drawing.Point(148, 15);
            this.btn_BoardSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_BoardSize.Name = "btn_BoardSize";
            this.btn_BoardSize.Size = new System.Drawing.Size(240, 68);
            this.btn_BoardSize.TabIndex = 2;
            this.btn_BoardSize.Text = "Board size : 6X6 (click to increase)";
            this.btn_BoardSize.UseVisualStyleBackColor = true;
            this.btn_BoardSize.Click += new System.EventHandler(this.btn_BoardSize_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 199);
            this.Controls.Add(this.btn_BoardSize);
            this.Controls.Add(this.btn_PlayVSPlayer);
            this.Controls.Add(this.btn_PlayVSComputer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GameSettings";
            this.Text = "Othello - Game Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PlayVSComputer;
        private System.Windows.Forms.Button btn_PlayVSPlayer;
        private System.Windows.Forms.Button btn_BoardSize;
    }
}

