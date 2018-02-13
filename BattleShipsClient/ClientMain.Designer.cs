namespace BattleShipsClient
{
    partial class ClientMain
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
            if (m_Connection == ConnectionType.Connected)
            {
                    if (gameInProgress)
                        sendPacketToServer("QuitGame " + gameIdentifier);

                    sendPacketToServer("Logout");
            }

            System.Windows.Forms.Application.Exit();

                    /*
            if (disposing && (components != null))
            {
                //   components.Dispose();
            }
            base.Dispose(disposing);*/
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.teamBBattleGridPic = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playTeamModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMessaging = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MessageAdminToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_opt_Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_opt_Close_Session = new System.Windows.Forms.ToolStripMenuItem();
            this.registerNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusSessionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnMessageTeamAUser = new System.Windows.Forms.Button();
            this.gbo_Comms = new System.Windows.Forms.GroupBox();
            this.lst_BroadcastChatMessage_log = new System.Windows.Forms.ListBox();
            this.btn_BroadcastChatMsgSend = new System.Windows.Forms.Button();
            this.txt_BroadcastChatMessageToSend = new System.Windows.Forms.TextBox();
            this.teamABattleGridPic = new System.Windows.Forms.PictureBox();
            this.btnChallengeWinner = new System.Windows.Forms.Button();
            this.grpBoxTeamB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMessageTeamBUser = new System.Windows.Forms.Button();
            this.lstTeamB = new System.Windows.Forms.ListBox();
            this.grpBoxTeamA = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTeamA = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamBBattleGridPic)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbo_Comms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamABattleGridPic)).BeginInit();
            this.grpBoxTeamB.SuspendLayout();
            this.grpBoxTeamA.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.teamBBattleGridPic);
            this.groupBox3.Location = new System.Drawing.Point(7, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(569, 313);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Active game";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Enemy targetting us";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Our target";
            // 
            // teamBBattleGridPic
            // 
            this.teamBBattleGridPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.teamBBattleGridPic.Location = new System.Drawing.Point(287, 35);
            this.teamBBattleGridPic.Name = "teamBBattleGridPic";
            this.teamBBattleGridPic.Size = new System.Drawing.Size(272, 272);
            this.teamBBattleGridPic.TabIndex = 25;
            this.teamBBattleGridPic.TabStop = false;
            this.teamBBattleGridPic.Paint += new System.Windows.Forms.PaintEventHandler(this.teamBBattleGridPic_Paint_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameToolStripMenuItem,
            this.toolStripMessaging,
            this.sessionToolStripMenuItem,
            this.registerNewUserToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GameToolStripMenuItem
            // 
            this.GameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewGameToolStripMenuItem,
            this.GamesToolStripMenuItem,
            this.EndGameToolStripMenuItem});
            this.GameToolStripMenuItem.Enabled = false;
            this.GameToolStripMenuItem.Name = "GameToolStripMenuItem";
            this.GameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.GameToolStripMenuItem.Text = "&Game";
            // 
            // startNewGameToolStripMenuItem
            // 
            this.startNewGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playServerToolStripMenuItem,
            this.playTeamModeToolStripMenuItem});
            this.startNewGameToolStripMenuItem.Name = "startNewGameToolStripMenuItem";
            this.startNewGameToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.startNewGameToolStripMenuItem.Text = "Start new game";
            // 
            // playServerToolStripMenuItem
            // 
            this.playServerToolStripMenuItem.Name = "playServerToolStripMenuItem";
            this.playServerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.playServerToolStripMenuItem.Text = "Against server";
            this.playServerToolStripMenuItem.Click += new System.EventHandler(this.playServerToolStripMenuItem_Click_1);
            // 
            // playTeamModeToolStripMenuItem
            // 
            this.playTeamModeToolStripMenuItem.Name = "playTeamModeToolStripMenuItem";
            this.playTeamModeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.playTeamModeToolStripMenuItem.Text = "New team game";
            this.playTeamModeToolStripMenuItem.Click += new System.EventHandler(this.playTeamModeToolStripMenuItem_Click_1);
            // 
            // GamesToolStripMenuItem
            // 
            this.GamesToolStripMenuItem.Name = "GamesToolStripMenuItem";
            this.GamesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.GamesToolStripMenuItem.Text = "Active Games";
            this.GamesToolStripMenuItem.Click += new System.EventHandler(this.GamesToolStripMenuItem_Click);
            // 
            // EndGameToolStripMenuItem
            // 
            this.EndGameToolStripMenuItem.Name = "EndGameToolStripMenuItem";
            this.EndGameToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.EndGameToolStripMenuItem.Text = "&Exit";
            this.EndGameToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMessaging
            // 
            this.toolStripMessaging.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.MessageAdminToolStrip});
            this.toolStripMessaging.Enabled = false;
            this.toolStripMessaging.Name = "toolStripMessaging";
            this.toolStripMessaging.Size = new System.Drawing.Size(76, 20);
            this.toolStripMessaging.Text = "Messaging";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // MessageAdminToolStrip
            // 
            this.MessageAdminToolStrip.Name = "MessageAdminToolStrip";
            this.MessageAdminToolStrip.Size = new System.Drawing.Size(110, 22);
            this.MessageAdminToolStrip.Text = "Admin";
            this.MessageAdminToolStrip.Click += new System.EventHandler(this.MessageAdminToolStrip_Click);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_opt_Connect,
            this.mnu_opt_Close_Session});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "&Session";
            // 
            // mnu_opt_Connect
            // 
            this.mnu_opt_Connect.Name = "mnu_opt_Connect";
            this.mnu_opt_Connect.Size = new System.Drawing.Size(174, 22);
            this.mnu_opt_Connect.Text = "Connect to session";
            this.mnu_opt_Connect.Click += new System.EventHandler(this.mnu_Connect_Click);
            // 
            // mnu_opt_Close_Session
            // 
            this.mnu_opt_Close_Session.Name = "mnu_opt_Close_Session";
            this.mnu_opt_Close_Session.Size = new System.Drawing.Size(174, 22);
            this.mnu_opt_Close_Session.Text = "Disconnect";
            this.mnu_opt_Close_Session.Click += new System.EventHandler(this.mnu_opt_Disconnect_Click);
            // 
            // registerNewUserToolStripMenuItem
            // 
            this.registerNewUserToolStripMenuItem.Enabled = false;
            this.registerNewUserToolStripMenuItem.Name = "registerNewUserToolStripMenuItem";
            this.registerNewUserToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.registerNewUserToolStripMenuItem.Text = "&Register new user";
            this.registerNewUserToolStripMenuItem.Click += new System.EventHandler(this.registerNewUserToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusSessionInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(780, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusSessionInfo
            // 
            this.toolStripStatusSessionInfo.Name = "toolStripStatusSessionInfo";
            this.toolStripStatusSessionInfo.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusSessionInfo.Text = ".";
            // 
            // btnMessageTeamAUser
            // 
            this.btnMessageTeamAUser.Enabled = false;
            this.btnMessageTeamAUser.Location = new System.Drawing.Point(6, 282);
            this.btnMessageTeamAUser.Name = "btnMessageTeamAUser";
            this.btnMessageTeamAUser.Size = new System.Drawing.Size(37, 23);
            this.btnMessageTeamAUser.TabIndex = 3;
            this.btnMessageTeamAUser.Text = "Msg";
            this.btnMessageTeamAUser.UseVisualStyleBackColor = true;
            this.btnMessageTeamAUser.Click += new System.EventHandler(this.btnMessageTeamAUser_Click);
            // 
            // gbo_Comms
            // 
            this.gbo_Comms.Controls.Add(this.lst_BroadcastChatMessage_log);
            this.gbo_Comms.Controls.Add(this.btn_BroadcastChatMsgSend);
            this.gbo_Comms.Controls.Add(this.txt_BroadcastChatMessageToSend);
            this.gbo_Comms.Enabled = false;
            this.gbo_Comms.Location = new System.Drawing.Point(7, 340);
            this.gbo_Comms.Name = "gbo_Comms";
            this.gbo_Comms.Size = new System.Drawing.Size(767, 185);
            this.gbo_Comms.TabIndex = 15;
            this.gbo_Comms.TabStop = false;
            // 
            // lst_BroadcastChatMessage_log
            // 
            this.lst_BroadcastChatMessage_log.FormattingEnabled = true;
            this.lst_BroadcastChatMessage_log.Location = new System.Drawing.Point(6, 14);
            this.lst_BroadcastChatMessage_log.Name = "lst_BroadcastChatMessage_log";
            this.lst_BroadcastChatMessage_log.Size = new System.Drawing.Size(755, 134);
            this.lst_BroadcastChatMessage_log.TabIndex = 4;
            // 
            // btn_BroadcastChatMsgSend
            // 
            this.btn_BroadcastChatMsgSend.Location = new System.Drawing.Point(698, 155);
            this.btn_BroadcastChatMsgSend.Name = "btn_BroadcastChatMsgSend";
            this.btn_BroadcastChatMsgSend.Size = new System.Drawing.Size(63, 20);
            this.btn_BroadcastChatMsgSend.TabIndex = 2;
            this.btn_BroadcastChatMsgSend.Text = "Send";
            this.btn_BroadcastChatMsgSend.UseVisualStyleBackColor = true;
            this.btn_BroadcastChatMsgSend.Click += new System.EventHandler(this.btn_BroadcastChatMsgSend_Click);
            // 
            // txt_BroadcastChatMessageToSend
            // 
            this.txt_BroadcastChatMessageToSend.Location = new System.Drawing.Point(6, 155);
            this.txt_BroadcastChatMessageToSend.Name = "txt_BroadcastChatMessageToSend";
            this.txt_BroadcastChatMessageToSend.Size = new System.Drawing.Size(686, 20);
            this.txt_BroadcastChatMessageToSend.TabIndex = 1;
            this.txt_BroadcastChatMessageToSend.TextChanged += new System.EventHandler(this.txt_BroadcastChatMessageToSend_TextChanged);
            this.txt_BroadcastChatMessageToSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_BroadcastChatMessageToSend_KeyPress);
            // 
            // teamABattleGridPic
            // 
            this.teamABattleGridPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.teamABattleGridPic.Location = new System.Drawing.Point(15, 62);
            this.teamABattleGridPic.Name = "teamABattleGridPic";
            this.teamABattleGridPic.Size = new System.Drawing.Size(272, 272);
            this.teamABattleGridPic.TabIndex = 24;
            this.teamABattleGridPic.TabStop = false;
            this.teamABattleGridPic.Click += new System.EventHandler(this.teamABattleGridPic_Click);
            this.teamABattleGridPic.Paint += new System.Windows.Forms.PaintEventHandler(this.teamABattleGridPic_Paint_1);
            // 
            // btnChallengeWinner
            // 
            this.btnChallengeWinner.Enabled = false;
            this.btnChallengeWinner.Location = new System.Drawing.Point(1082, 56);
            this.btnChallengeWinner.Name = "btnChallengeWinner";
            this.btnChallengeWinner.Size = new System.Drawing.Size(96, 23);
            this.btnChallengeWinner.TabIndex = 18;
            this.btnChallengeWinner.Text = "Challenge winner";
            this.btnChallengeWinner.UseVisualStyleBackColor = true;
            this.btnChallengeWinner.Click += new System.EventHandler(this.btnChallengeWinner_Click);
            // 
            // grpBoxTeamB
            // 
            this.grpBoxTeamB.Controls.Add(this.label2);
            this.grpBoxTeamB.Controls.Add(this.btnMessageTeamBUser);
            this.grpBoxTeamB.Controls.Add(this.lstTeamB);
            this.grpBoxTeamB.Location = new System.Drawing.Point(681, 29);
            this.grpBoxTeamB.Name = "grpBoxTeamB";
            this.grpBoxTeamB.Size = new System.Drawing.Size(93, 311);
            this.grpBoxTeamB.TabIndex = 28;
            this.grpBoxTeamB.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Team B";
            // 
            // btnMessageTeamBUser
            // 
            this.btnMessageTeamBUser.Enabled = false;
            this.btnMessageTeamBUser.Location = new System.Drawing.Point(6, 282);
            this.btnMessageTeamBUser.Name = "btnMessageTeamBUser";
            this.btnMessageTeamBUser.Size = new System.Drawing.Size(38, 23);
            this.btnMessageTeamBUser.TabIndex = 3;
            this.btnMessageTeamBUser.Text = "Msg";
            this.btnMessageTeamBUser.UseVisualStyleBackColor = true;
            this.btnMessageTeamBUser.Click += new System.EventHandler(this.btnMessageTeamBUser_Click);
            // 
            // lstTeamB
            // 
            this.lstTeamB.FormattingEnabled = true;
            this.lstTeamB.Location = new System.Drawing.Point(6, 33);
            this.lstTeamB.Name = "lstTeamB";
            this.lstTeamB.Size = new System.Drawing.Size(81, 238);
            this.lstTeamB.TabIndex = 2;
            this.lstTeamB.SelectedIndexChanged += new System.EventHandler(this.lstTeamB_SelectedIndexChanged);
            // 
            // grpBoxTeamA
            // 
            this.grpBoxTeamA.Controls.Add(this.label1);
            this.grpBoxTeamA.Controls.Add(this.lstTeamA);
            this.grpBoxTeamA.Controls.Add(this.btnMessageTeamAUser);
            this.grpBoxTeamA.Location = new System.Drawing.Point(582, 29);
            this.grpBoxTeamA.Name = "grpBoxTeamA";
            this.grpBoxTeamA.Size = new System.Drawing.Size(93, 311);
            this.grpBoxTeamA.TabIndex = 27;
            this.grpBoxTeamA.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Team A";
            // 
            // lstTeamA
            // 
            this.lstTeamA.FormattingEnabled = true;
            this.lstTeamA.Location = new System.Drawing.Point(6, 33);
            this.lstTeamA.Name = "lstTeamA";
            this.lstTeamA.Size = new System.Drawing.Size(81, 238);
            this.lstTeamA.TabIndex = 1;
            this.lstTeamA.SelectedIndexChanged += new System.EventHandler(this.lstTeamA_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1082, 87);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 341);
            this.textBox1.TabIndex = 29;
            // 
            // ClientMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 547);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnChallengeWinner);
            this.Controls.Add(this.grpBoxTeamB);
            this.Controls.Add(this.grpBoxTeamA);
            this.Controls.Add(this.teamABattleGridPic);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbo_Comms);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ClientMain";
            this.Text = "Battleships game client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamBBattleGridPic)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbo_Comms.ResumeLayout(false);
            this.gbo_Comms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamABattleGridPic)).EndInit();
            this.grpBoxTeamB.ResumeLayout(false);
            this.grpBoxTeamB.PerformLayout();
            this.grpBoxTeamA.ResumeLayout(false);
            this.grpBoxTeamA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EndGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_opt_Connect;
        private System.Windows.Forms.ToolStripMenuItem mnu_opt_Close_Session;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSessionInfo;
        private System.Windows.Forms.Button btnMessageTeamAUser;
        private System.Windows.Forms.GroupBox gbo_Comms;
        private System.Windows.Forms.ListBox lst_BroadcastChatMessage_log;
        private System.Windows.Forms.Button btn_BroadcastChatMsgSend;
        private System.Windows.Forms.TextBox txt_BroadcastChatMessageToSend;
        private System.Windows.Forms.ToolStripMenuItem registerNewUserToolStripMenuItem;
        private System.Windows.Forms.PictureBox teamBBattleGridPic;
        private System.Windows.Forms.PictureBox teamABattleGridPic;
        private System.Windows.Forms.Button btnChallengeWinner;
        private System.Windows.Forms.GroupBox grpBoxTeamB;
        private System.Windows.Forms.ListBox lstTeamB;
        private System.Windows.Forms.GroupBox grpBoxTeamA;
        private System.Windows.Forms.ListBox lstTeamA;
        private System.Windows.Forms.Button btnMessageTeamBUser;
        private System.Windows.Forms.ToolStripMenuItem startNewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playTeamModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMessaging;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MessageAdminToolStrip;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

