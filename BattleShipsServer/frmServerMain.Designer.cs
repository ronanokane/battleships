namespace BattleShipsServer
{
    partial class frmServerMain
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_opt_Create_Session = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_opt_Close_Session = new System.Windows.Forms.ToolStripMenuItem();
            this.restartSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchByUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupUsersConnected = new System.Windows.Forms.GroupBox();
            this.btn_ViewUserInfo = new System.Windows.Forms.Button();
            this.btnBanUser = new System.Windows.Forms.Button();
            this.btnChatToUser = new System.Windows.Forms.Button();
            this.lst_Users = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBroadcastMessageSend = new System.Windows.Forms.Button();
            this.txtBroadcastMessageConvo = new System.Windows.Forms.TextBox();
            this.txtBroadcastMessageSend = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtUser_count = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.GroupActiveGames = new System.Windows.Forms.GroupBox();
            this.lstActiveGames = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.GroupUsersConnected.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GroupActiveGames.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 369);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(695, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "Connect client count:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.userDetailsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(695, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_opt_Create_Session,
            this.mnu_opt_Close_Session,
            this.restartSessionToolStripMenuItem});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "&Session";
            // 
            // mnu_opt_Create_Session
            // 
            this.mnu_opt_Create_Session.Name = "mnu_opt_Create_Session";
            this.mnu_opt_Create_Session.Size = new System.Drawing.Size(151, 22);
            this.mnu_opt_Create_Session.Text = "Create session";
            this.mnu_opt_Create_Session.Click += new System.EventHandler(this.mnu_opt_Create_Session_Click);
            // 
            // mnu_opt_Close_Session
            // 
            this.mnu_opt_Close_Session.Name = "mnu_opt_Close_Session";
            this.mnu_opt_Close_Session.Size = new System.Drawing.Size(151, 22);
            this.mnu_opt_Close_Session.Text = "Close session";
            this.mnu_opt_Close_Session.Click += new System.EventHandler(this.mnu_opt_Close_Session_Click);
            // 
            // restartSessionToolStripMenuItem
            // 
            this.restartSessionToolStripMenuItem.Name = "restartSessionToolStripMenuItem";
            this.restartSessionToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.restartSessionToolStripMenuItem.Text = "Restart session";
            this.restartSessionToolStripMenuItem.Click += new System.EventHandler(this.restartSessionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.aboutToolStripMenuItem.Text = "&Banlists";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // userDetailsToolStripMenuItem
            // 
            this.userDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchByUserToolStripMenuItem});
            this.userDetailsToolStripMenuItem.Name = "userDetailsToolStripMenuItem";
            this.userDetailsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.userDetailsToolStripMenuItem.Text = "&User details";
            // 
            // searchByUserToolStripMenuItem
            // 
            this.searchByUserToolStripMenuItem.Name = "searchByUserToolStripMenuItem";
            this.searchByUserToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.searchByUserToolStripMenuItem.Text = "&Search by user";
            this.searchByUserToolStripMenuItem.Click += new System.EventHandler(this.searchByUserToolStripMenuItem_Click);
            // 
            // GroupUsersConnected
            // 
            this.GroupUsersConnected.Controls.Add(this.btn_ViewUserInfo);
            this.GroupUsersConnected.Controls.Add(this.btnBanUser);
            this.GroupUsersConnected.Controls.Add(this.btnChatToUser);
            this.GroupUsersConnected.Controls.Add(this.lst_Users);
            this.GroupUsersConnected.Location = new System.Drawing.Point(533, 31);
            this.GroupUsersConnected.Name = "GroupUsersConnected";
            this.GroupUsersConnected.Size = new System.Drawing.Size(163, 328);
            this.GroupUsersConnected.TabIndex = 4;
            this.GroupUsersConnected.TabStop = false;
            this.GroupUsersConnected.Text = "Users";
            // 
            // btn_ViewUserInfo
            // 
            this.btn_ViewUserInfo.Enabled = false;
            this.btn_ViewUserInfo.Location = new System.Drawing.Point(96, 295);
            this.btn_ViewUserInfo.Name = "btn_ViewUserInfo";
            this.btn_ViewUserInfo.Size = new System.Drawing.Size(61, 23);
            this.btn_ViewUserInfo.TabIndex = 3;
            this.btn_ViewUserInfo.Text = "View info";
            this.btn_ViewUserInfo.UseVisualStyleBackColor = true;
            this.btn_ViewUserInfo.Click += new System.EventHandler(this.btn_ViewUserInfo_Click);
            // 
            // btnBanUser
            // 
            this.btnBanUser.Enabled = false;
            this.btnBanUser.Location = new System.Drawing.Point(56, 295);
            this.btnBanUser.Name = "btnBanUser";
            this.btnBanUser.Size = new System.Drawing.Size(34, 23);
            this.btnBanUser.TabIndex = 2;
            this.btnBanUser.Text = "Ban";
            this.btnBanUser.UseVisualStyleBackColor = true;
            this.btnBanUser.Click += new System.EventHandler(this.btnBanUser_Click);
            // 
            // btnChatToUser
            // 
            this.btnChatToUser.Enabled = false;
            this.btnChatToUser.Location = new System.Drawing.Point(10, 296);
            this.btnChatToUser.Name = "btnChatToUser";
            this.btnChatToUser.Size = new System.Drawing.Size(40, 23);
            this.btnChatToUser.TabIndex = 1;
            this.btnChatToUser.Text = "Msg";
            this.btnChatToUser.UseVisualStyleBackColor = true;
            this.btnChatToUser.Click += new System.EventHandler(this.btnChatToUser_Click);
            // 
            // lst_Users
            // 
            this.lst_Users.FormattingEnabled = true;
            this.lst_Users.Location = new System.Drawing.Point(10, 26);
            this.lst_Users.Name = "lst_Users";
            this.lst_Users.Size = new System.Drawing.Size(135, 264);
            this.lst_Users.TabIndex = 0;
            this.lst_Users.SelectedIndexChanged += new System.EventHandler(this.lst_Users_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBroadcastMessageSend);
            this.groupBox2.Controls.Add(this.txtBroadcastMessageConvo);
            this.groupBox2.Controls.Add(this.txtBroadcastMessageSend);
            this.groupBox2.Location = new System.Drawing.Point(12, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 267);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Broadcast messaging";
            // 
            // btnBroadcastMessageSend
            // 
            this.btnBroadcastMessageSend.Location = new System.Drawing.Point(464, 236);
            this.btnBroadcastMessageSend.Name = "btnBroadcastMessageSend";
            this.btnBroadcastMessageSend.Size = new System.Drawing.Size(45, 21);
            this.btnBroadcastMessageSend.TabIndex = 3;
            this.btnBroadcastMessageSend.Text = "Send";
            this.btnBroadcastMessageSend.UseVisualStyleBackColor = true;
            this.btnBroadcastMessageSend.Click += new System.EventHandler(this.btnBroadcastMessageSend_Click);
            // 
            // txtBroadcastMessageConvo
            // 
            this.txtBroadcastMessageConvo.Location = new System.Drawing.Point(9, 30);
            this.txtBroadcastMessageConvo.Multiline = true;
            this.txtBroadcastMessageConvo.Name = "txtBroadcastMessageConvo";
            this.txtBroadcastMessageConvo.Size = new System.Drawing.Size(500, 200);
            this.txtBroadcastMessageConvo.TabIndex = 2;
            // 
            // txtBroadcastMessageSend
            // 
            this.txtBroadcastMessageSend.Location = new System.Drawing.Point(9, 237);
            this.txtBroadcastMessageSend.Name = "txtBroadcastMessageSend";
            this.txtBroadcastMessageSend.Size = new System.Drawing.Size(449, 20);
            this.txtBroadcastMessageSend.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtUser_count);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txt_Port);
            this.groupBox4.Controls.Add(this.txt_Name);
            this.groupBox4.Controls.Add(this.txt_Status);
            this.groupBox4.Location = new System.Drawing.Point(12, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(515, 55);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Server information";
            // 
            // txtUser_count
            // 
            this.txtUser_count.Location = new System.Drawing.Point(458, 26);
            this.txtUser_count.Name = "txtUser_count";
            this.txtUser_count.ReadOnly = true;
            this.txtUser_count.Size = new System.Drawing.Size(38, 20);
            this.txtUser_count.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "User count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Session name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Status";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(336, 26);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.ReadOnly = true;
            this.txt_Port.Size = new System.Drawing.Size(48, 20);
            this.txt_Port.TabIndex = 2;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(223, 26);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(75, 20);
            this.txt_Name.TabIndex = 1;
            // 
            // txt_Status
            // 
            this.txt_Status.Location = new System.Drawing.Point(51, 26);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            this.txt_Status.Size = new System.Drawing.Size(91, 20);
            this.txt_Status.TabIndex = 0;
            // 
            // GroupActiveGames
            // 
            this.GroupActiveGames.Controls.Add(this.lstActiveGames);
            this.GroupActiveGames.Location = new System.Drawing.Point(696, 31);
            this.GroupActiveGames.Name = "GroupActiveGames";
            this.GroupActiveGames.Size = new System.Drawing.Size(143, 328);
            this.GroupActiveGames.TabIndex = 8;
            this.GroupActiveGames.TabStop = false;
            this.GroupActiveGames.Text = "Active games";
            // 
            // lstActiveGames
            // 
            this.lstActiveGames.FormattingEnabled = true;
            this.lstActiveGames.Location = new System.Drawing.Point(9, 26);
            this.lstActiveGames.Name = "lstActiveGames";
            this.lstActiveGames.Size = new System.Drawing.Size(128, 264);
            this.lstActiveGames.TabIndex = 0;
            this.lstActiveGames.SelectedIndexChanged += new System.EventHandler(this.lstActiveGames_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 391);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.GroupActiveGames);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupUsersConnected);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmServerMain";
            this.Text = "Battleships Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GroupUsersConnected.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GroupActiveGames.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.GroupBox GroupUsersConnected;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBanUser;
        private System.Windows.Forms.Button btnChatToUser;
        private System.Windows.Forms.ListBox lst_Users;
        private System.Windows.Forms.Button btnBroadcastMessageSend;
        private System.Windows.Forms.TextBox txtBroadcastMessageConvo;
        private System.Windows.Forms.TextBox txtBroadcastMessageSend;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnu_opt_Create_Session;
        private System.Windows.Forms.ToolStripMenuItem mnu_opt_Close_Session;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUser_count;
        private System.Windows.Forms.GroupBox GroupActiveGames;
        private System.Windows.Forms.ListBox lstActiveGames;
        private System.Windows.Forms.Button btn_ViewUserInfo;
        private System.Windows.Forms.ToolStripMenuItem userDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchByUserToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem restartSessionToolStripMenuItem;
    }
}

