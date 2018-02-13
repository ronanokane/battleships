namespace BattleShipsClient
{
    partial class FrmUsers
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
               // components.Dispose();
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
            this.gboUsers = new System.Windows.Forms.GroupBox();
            this.btn_MessageUser = new System.Windows.Forms.Button();
            this.lstConnectedUsers = new System.Windows.Forms.ListBox();
            this.gboUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboUsers
            // 
            this.gboUsers.Controls.Add(this.btn_MessageUser);
            this.gboUsers.Controls.Add(this.lstConnectedUsers);
            this.gboUsers.Location = new System.Drawing.Point(12, 12);
            this.gboUsers.Name = "gboUsers";
            this.gboUsers.Size = new System.Drawing.Size(142, 307);
            this.gboUsers.TabIndex = 15;
            this.gboUsers.TabStop = false;
            this.gboUsers.Text = "Users";
            // 
            // btn_MessageUser
            // 
            this.btn_MessageUser.Enabled = false;
            this.btn_MessageUser.Location = new System.Drawing.Point(7, 276);
            this.btn_MessageUser.Name = "btn_MessageUser";
            this.btn_MessageUser.Size = new System.Drawing.Size(128, 23);
            this.btn_MessageUser.TabIndex = 5;
            this.btn_MessageUser.Text = "Message";
            this.btn_MessageUser.UseVisualStyleBackColor = true;
            this.btn_MessageUser.Click += new System.EventHandler(this.btn_MessageUser_Click);
            // 
            // lstConnectedUsers
            // 
            this.lstConnectedUsers.FormattingEnabled = true;
            this.lstConnectedUsers.Location = new System.Drawing.Point(7, 19);
            this.lstConnectedUsers.Name = "lstConnectedUsers";
            this.lstConnectedUsers.Size = new System.Drawing.Size(128, 251);
            this.lstConnectedUsers.TabIndex = 0;
            this.lstConnectedUsers.SelectedIndexChanged += new System.EventHandler(this.lstConnectedUsers_SelectedIndexChanged);
            // 
            // FrmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 331);
            this.Controls.Add(this.gboUsers);
            this.Name = "FrmUsers";
            this.Text = "Online users";
            this.Load += new System.EventHandler(this.FrmUsers_Load);
            this.gboUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboUsers;
        private System.Windows.Forms.Button btn_MessageUser;
        private System.Windows.Forms.ListBox lstConnectedUsers;
    }
}