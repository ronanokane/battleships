namespace BattleShipsClient
{
    partial class frmGameCountdown
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
            this.btn_QuitGame = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_skipCountdown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_QuitGame
            // 
            this.btn_QuitGame.Location = new System.Drawing.Point(12, 208);
            this.btn_QuitGame.Name = "btn_QuitGame";
            this.btn_QuitGame.Size = new System.Drawing.Size(249, 23);
            this.btn_QuitGame.TabIndex = 0;
            this.btn_QuitGame.Text = "Quit";
            this.btn_QuitGame.UseVisualStyleBackColor = true;
            this.btn_QuitGame.Click += new System.EventHandler(this.btn_QuitGame_Click);
            // 
            // btn_skipCountdown
            // 
            this.btn_skipCountdown.Location = new System.Drawing.Point(13, 230);
            this.btn_skipCountdown.Name = "btn_skipCountdown";
            this.btn_skipCountdown.Size = new System.Drawing.Size(248, 23);
            this.btn_skipCountdown.TabIndex = 1;
            this.btn_skipCountdown.Text = "Start immediately";
            this.btn_skipCountdown.UseVisualStyleBackColor = true;
            this.btn_skipCountdown.Click += new System.EventHandler(this.btn_skipCountdown_Click);
            // 
            // frmGameCountdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(273, 265);
            this.Controls.Add(this.btn_skipCountdown);
            this.Controls.Add(this.btn_QuitGame);
            this.Name = "frmGameCountdown";
            this.Text = "Game countdown";
            this.Load += new System.EventHandler(this.frmGameCountdown_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_QuitGame;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_skipCountdown;
    }
}