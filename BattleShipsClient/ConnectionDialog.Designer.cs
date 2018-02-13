namespace BattleShipsClient
{
    partial class ConnectionDialog
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
              //  components.Dispose();
            }
        //    base.Dispose(disposing);
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lst_Sessions = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbo_Session_Info = new System.Windows.Forms.GroupBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.txt_Session_Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Host_Address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.ComboBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.btn_RegisterNewUser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gbo_Session_Info.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(97, 334);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(16, 334);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 6;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lst_Sessions);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 131);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sessions";
            // 
            // lst_Sessions
            // 
            this.lst_Sessions.Enabled = false;
            this.lst_Sessions.FormattingEnabled = true;
            this.lst_Sessions.Location = new System.Drawing.Point(13, 41);
            this.lst_Sessions.Name = "lst_Sessions";
            this.lst_Sessions.Size = new System.Drawing.Size(279, 82);
            this.lst_Sessions.TabIndex = 1;
            this.lst_Sessions.SelectedIndexChanged += new System.EventHandler(this.lst_Sessions_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Active sessions";
            // 
            // gbo_Session_Info
            // 
            this.gbo_Session_Info.Controls.Add(this.Btn_Search);
            this.gbo_Session_Info.Controls.Add(this.txt_Session_Port);
            this.gbo_Session_Info.Controls.Add(this.label2);
            this.gbo_Session_Info.Controls.Add(this.txt_Host_Address);
            this.gbo_Session_Info.Controls.Add(this.label1);
            this.gbo_Session_Info.Location = new System.Drawing.Point(12, 101);
            this.gbo_Session_Info.Name = "gbo_Session_Info";
            this.gbo_Session_Info.Size = new System.Drawing.Size(305, 90);
            this.gbo_Session_Info.TabIndex = 4;
            this.gbo_Session_Info.TabStop = false;
            this.gbo_Session_Info.Text = "Session information";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(205, 55);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 23);
            this.Btn_Search.TabIndex = 4;
            this.Btn_Search.Text = "Search";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // txt_Session_Port
            // 
            this.txt_Session_Port.Location = new System.Drawing.Point(88, 57);
            this.txt_Session_Port.Name = "txt_Session_Port";
            this.txt_Session_Port.Size = new System.Drawing.Size(100, 20);
            this.txt_Session_Port.TabIndex = 3;
            this.txt_Session_Port.Text = "8000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Session port";
            // 
            // txt_Host_Address
            // 
            this.txt_Host_Address.Location = new System.Drawing.Point(89, 31);
            this.txt_Host_Address.Name = "txt_Host_Address";
            this.txt_Host_Address.Size = new System.Drawing.Size(99, 20);
            this.txt_Host_Address.TabIndex = 1;
            this.txt_Host_Address.Text = "localhost";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.txtPasswd);
            this.groupBox1.Controls.Add(this.btn_RegisterNewUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account info";
            // 
            // txtUsername
            // 
            this.txtUsername.FormattingEnabled = true;
            this.txtUsername.Items.AddRange(new object[] {
            "Ronan",
            "User2",
            "Test",
            "Micky"});
            this.txtUsername.Location = new System.Drawing.Point(88, 29);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(122, 21);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Text = "Ronan";
            this.txtUsername.SelectedIndexChanged += new System.EventHandler(this.txtUsername_SelectedIndexChanged);
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(88, 55);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(100, 20);
            this.txtPasswd.TabIndex = 4;
            this.txtPasswd.Text = "Ronan";
            // 
            // btn_RegisterNewUser
            // 
            this.btn_RegisterNewUser.Location = new System.Drawing.Point(205, 54);
            this.btn_RegisterNewUser.Name = "btn_RegisterNewUser";
            this.btn_RegisterNewUser.Size = new System.Drawing.Size(76, 23);
            this.btn_RegisterNewUser.TabIndex = 2;
            this.btn_RegisterNewUser.Text = "New user";
            this.btn_RegisterNewUser.UseVisualStyleBackColor = true;
            this.btn_RegisterNewUser.Click += new System.EventHandler(this.btn_RegisterNewUser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Username";
            // 
            // ConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 363);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbo_Session_Info);
            this.Name = "ConnectionDialog";
            this.Text = "ConnectionDialog";
            this.Load += new System.EventHandler(this.ConnectionDialog_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbo_Session_Info.ResumeLayout(false);
            this.gbo_Session_Info.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lst_Sessions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbo_Session_Info;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.TextBox txt_Session_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Host_Address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Button btn_RegisterNewUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtUsername;
    }
}