namespace BattleShipsClient
{
    partial class FrmGames
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
                //components.Dispose();
            }
            //base.Dispose(disposing);
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboActiveGames = new System.Windows.Forms.GroupBox();
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.btn_GameView = new System.Windows.Forms.Button();
            this.lstActiveGames = new System.Windows.Forms.ListBox();
            this.gboActiveGames.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboActiveGames
            // 
            this.gboActiveGames.Controls.Add(this.btnJoinGame);
            this.gboActiveGames.Controls.Add(this.btn_GameView);
            this.gboActiveGames.Controls.Add(this.lstActiveGames);
            this.gboActiveGames.Location = new System.Drawing.Point(12, 12);
            this.gboActiveGames.Name = "gboActiveGames";
            this.gboActiveGames.Size = new System.Drawing.Size(235, 243);
            this.gboActiveGames.TabIndex = 12;
            this.gboActiveGames.TabStop = false;
            this.gboActiveGames.Text = "Games (by Game ID)";
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Location = new System.Drawing.Point(123, 48);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(92, 23);
            this.btnJoinGame.TabIndex = 2;
            this.btnJoinGame.Text = "Join Game";
            this.btnJoinGame.UseVisualStyleBackColor = true;
            this.btnJoinGame.Click += new System.EventHandler(this.btnJoinGame_Click);
            // 
            // btn_GameView
            // 
            this.btn_GameView.Location = new System.Drawing.Point(123, 19);
            this.btn_GameView.Name = "btn_GameView";
            this.btn_GameView.Size = new System.Drawing.Size(92, 23);
            this.btn_GameView.TabIndex = 1;
            this.btn_GameView.Text = "View Game";
            this.btn_GameView.UseVisualStyleBackColor = true;
            this.btn_GameView.Click += new System.EventHandler(this.btn_GameView_Click);
            // 
            // lstActiveGames
            // 
            this.lstActiveGames.FormattingEnabled = true;
            this.lstActiveGames.Location = new System.Drawing.Point(11, 19);
            this.lstActiveGames.Name = "lstActiveGames";
            this.lstActiveGames.Size = new System.Drawing.Size(106, 212);
            this.lstActiveGames.TabIndex = 0;
            this.lstActiveGames.SelectedIndexChanged += new System.EventHandler(this.lstActiveGames_SelectedIndexChanged);
            // 
            // FrmGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 266);
            this.Controls.Add(this.gboActiveGames);
            this.Name = "FrmGames";
            this.Text = "Games";
            this.Load += new System.EventHandler(this.FrmGames_Load);
            this.gboActiveGames.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboActiveGames;
        private System.Windows.Forms.Button btnJoinGame;
        private System.Windows.Forms.Button btn_GameView;
        private System.Windows.Forms.ListBox lstActiveGames;
    }
}