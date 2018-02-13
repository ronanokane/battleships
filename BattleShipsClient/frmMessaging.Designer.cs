namespace BattleShipsClient
{
    partial class frmMessaging
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
            this.Hide();
            /*
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChatToAdmin = new System.Windows.Forms.Button();
            this.btnChatToUser = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.gbo_Comms = new System.Windows.Forms.GroupBox();
            this.lst_BroadcastChatMessage_log = new System.Windows.Forms.ListBox();
            this.lbl_Message_Log = new System.Windows.Forms.Label();
            this.btn_BroadcastChatMsgSend = new System.Windows.Forms.Button();
            this.txt_ChatMessageToSend = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.gbo_Comms.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChatToAdmin);
            this.groupBox2.Controls.Add(this.btnChatToUser);
            this.groupBox2.Controls.Add(this.lstUsers);
            this.groupBox2.Location = new System.Drawing.Point(400, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 389);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Users";
            // 
            // btnChatToAdmin
            // 
            this.btnChatToAdmin.Location = new System.Drawing.Point(61, 360);
            this.btnChatToAdmin.Name = "btnChatToAdmin";
            this.btnChatToAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnChatToAdmin.TabIndex = 2;
            this.btnChatToAdmin.Text = "Chat admin";
            this.btnChatToAdmin.UseVisualStyleBackColor = true;
            // 
            // btnChatToUser
            // 
            this.btnChatToUser.Location = new System.Drawing.Point(6, 360);
            this.btnChatToUser.Name = "btnChatToUser";
            this.btnChatToUser.Size = new System.Drawing.Size(49, 23);
            this.btnChatToUser.TabIndex = 1;
            this.btnChatToUser.Text = "Chat";
            this.btnChatToUser.UseVisualStyleBackColor = true;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(6, 19);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(132, 329);
            this.lstUsers.TabIndex = 0;
            // 
            // gbo_Comms
            // 
            this.gbo_Comms.Controls.Add(this.groupBox1);
            this.gbo_Comms.Controls.Add(this.lst_BroadcastChatMessage_log);
            this.gbo_Comms.Controls.Add(this.lbl_Message_Log);
            this.gbo_Comms.Controls.Add(this.btn_BroadcastChatMsgSend);
            this.gbo_Comms.Controls.Add(this.txt_ChatMessageToSend);
            this.gbo_Comms.Location = new System.Drawing.Point(12, 3);
            this.gbo_Comms.Name = "gbo_Comms";
            this.gbo_Comms.Size = new System.Drawing.Size(382, 430);
            this.gbo_Comms.TabIndex = 13;
            this.gbo_Comms.TabStop = false;
            this.gbo_Comms.Text = "Communication";
            // 
            // lst_BroadcastChatMessage_log
            // 
            this.lst_BroadcastChatMessage_log.FormattingEnabled = true;
            this.lst_BroadcastChatMessage_log.Location = new System.Drawing.Point(11, 40);
            this.lst_BroadcastChatMessage_log.Name = "lst_BroadcastChatMessage_log";
            this.lst_BroadcastChatMessage_log.Size = new System.Drawing.Size(365, 251);
            this.lst_BroadcastChatMessage_log.TabIndex = 4;
            // 
            // lbl_Message_Log
            // 
            this.lbl_Message_Log.AutoSize = true;
            this.lbl_Message_Log.Location = new System.Drawing.Point(9, 24);
            this.lbl_Message_Log.Name = "lbl_Message_Log";
            this.lbl_Message_Log.Size = new System.Drawing.Size(55, 13);
            this.lbl_Message_Log.TabIndex = 3;
            this.lbl_Message_Log.Text = "Messages";
            // 
            // btn_BroadcastChatMsgSend
            // 
            this.btn_BroadcastChatMsgSend.Location = new System.Drawing.Point(330, 303);
            this.btn_BroadcastChatMsgSend.Name = "btn_BroadcastChatMsgSend";
            this.btn_BroadcastChatMsgSend.Size = new System.Drawing.Size(46, 20);
            this.btn_BroadcastChatMsgSend.TabIndex = 2;
            this.btn_BroadcastChatMsgSend.Text = "Send";
            this.btn_BroadcastChatMsgSend.UseVisualStyleBackColor = true;
            this.btn_BroadcastChatMsgSend.Click += new System.EventHandler(this.btn_BroadcastChatMsgSend_Click);
            // 
            // txt_ChatMessageToSend
            // 
            this.txt_ChatMessageToSend.Location = new System.Drawing.Point(11, 305);
            this.txt_ChatMessageToSend.Name = "txt_ChatMessageToSend";
            this.txt_ChatMessageToSend.Size = new System.Drawing.Size(313, 20);
            this.txt_ChatMessageToSend.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Team message";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(109, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Broadcast";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(11, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 46);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message type";
            // 
            // frmMessaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 445);
            this.Controls.Add(this.gbo_Comms);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmMessaging";
            this.Text = "frmMessaging";
            this.Load += new System.EventHandler(this.frmMessaging_Load);
            this.groupBox2.ResumeLayout(false);
            this.gbo_Comms.ResumeLayout(false);
            this.gbo_Comms.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChatToAdmin;
        private System.Windows.Forms.Button btnChatToUser;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.GroupBox gbo_Comms;
        private System.Windows.Forms.ListBox lst_BroadcastChatMessage_log;
        private System.Windows.Forms.Label lbl_Message_Log;
        private System.Windows.Forms.Button btn_BroadcastChatMsgSend;
        private System.Windows.Forms.TextBox txt_ChatMessageToSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}