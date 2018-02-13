namespace BattleShipsServer
{
    partial class frmSearchPlayerInfo
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
            System.Windows.Forms.Label nickLabel;
            System.Windows.Forms.Label firstnameLabel;
            System.Windows.Forms.Label surnameLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label ageLabel;
            System.Windows.Forms.Label games_wonLabel;
            System.Windows.Forms.Label bannedLabel;
            System.Windows.Forms.Label games_playedLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nickTextBox = new System.Windows.Forms.TextBox();
            this.profilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.battleshipsDataSet1 = new BattleShipsServer.battleshipsDataSet1();
            this.firstnameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.games_wonTextBox = new System.Windows.Forms.TextBox();
            this.bannedCheckBox = new System.Windows.Forms.CheckBox();
            this.games_playedTextBox = new System.Windows.Forms.TextBox();
            this.txtDirectClientId = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_playerInfoSearch = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.profilesTableAdapter = new BattleShipsServer.battleshipsDataSet1TableAdapters.ProfilesTableAdapter();
            nickLabel = new System.Windows.Forms.Label();
            firstnameLabel = new System.Windows.Forms.Label();
            surnameLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            ageLabel = new System.Windows.Forms.Label();
            games_wonLabel = new System.Windows.Forms.Label();
            bannedLabel = new System.Windows.Forms.Label();
            games_playedLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSet1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nickLabel
            // 
            nickLabel.AutoSize = true;
            nickLabel.Location = new System.Drawing.Point(19, 27);
            nickLabel.Name = "nickLabel";
            nickLabel.Size = new System.Drawing.Size(32, 13);
            nickLabel.TabIndex = 21;
            nickLabel.Text = "Nick:";
            // 
            // firstnameLabel
            // 
            firstnameLabel.AutoSize = true;
            firstnameLabel.Location = new System.Drawing.Point(19, 53);
            firstnameLabel.Name = "firstnameLabel";
            firstnameLabel.Size = new System.Drawing.Size(55, 13);
            firstnameLabel.TabIndex = 23;
            firstnameLabel.Text = "Firstname:";
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new System.Drawing.Point(19, 79);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new System.Drawing.Size(52, 13);
            surnameLabel.TabIndex = 25;
            surnameLabel.Text = "Surname:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(19, 105);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 27;
            descriptionLabel.Text = "Description:";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new System.Drawing.Point(19, 168);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new System.Drawing.Size(29, 13);
            ageLabel.TabIndex = 29;
            ageLabel.Text = "Age:";
            // 
            // games_wonLabel
            // 
            games_wonLabel.AutoSize = true;
            games_wonLabel.Location = new System.Drawing.Point(19, 197);
            games_wonLabel.Name = "games_wonLabel";
            games_wonLabel.Size = new System.Drawing.Size(66, 13);
            games_wonLabel.TabIndex = 31;
            games_wonLabel.Text = "Games won:";
            // 
            // bannedLabel
            // 
            bannedLabel.AutoSize = true;
            bannedLabel.Location = new System.Drawing.Point(19, 228);
            bannedLabel.Name = "bannedLabel";
            bannedLabel.Size = new System.Drawing.Size(47, 13);
            bannedLabel.TabIndex = 33;
            bannedLabel.Text = "Banned:";
            // 
            // games_playedLabel
            // 
            games_playedLabel.AutoSize = true;
            games_playedLabel.Location = new System.Drawing.Point(19, 257);
            games_playedLabel.Name = "games_playedLabel";
            games_playedLabel.Size = new System.Drawing.Size(77, 13);
            games_playedLabel.TabIndex = 35;
            games_playedLabel.Text = "Games played:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSurname);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.txtFirstname);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 277);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player info";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 245);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Player ID";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(79, 91);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(100, 20);
            this.txtSurname.TabIndex = 9;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(78, 121);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(50, 20);
            this.txtAge.TabIndex = 8;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(79, 62);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(100, 20);
            this.txtFirstname.TabIndex = 7;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(79, 31);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(87, 20);
            this.txtUser.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(78, 153);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(199, 82);
            this.txtDescription.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Firstname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nick";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Username";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(118, 20);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 63);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search criteria";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(nickLabel);
            this.groupBox3.Controls.Add(this.nickTextBox);
            this.groupBox3.Controls.Add(firstnameLabel);
            this.groupBox3.Controls.Add(this.firstnameTextBox);
            this.groupBox3.Controls.Add(surnameLabel);
            this.groupBox3.Controls.Add(this.surnameTextBox);
            this.groupBox3.Controls.Add(descriptionLabel);
            this.groupBox3.Controls.Add(this.descriptionTextBox);
            this.groupBox3.Controls.Add(ageLabel);
            this.groupBox3.Controls.Add(this.ageTextBox);
            this.groupBox3.Controls.Add(games_wonLabel);
            this.groupBox3.Controls.Add(this.games_wonTextBox);
            this.groupBox3.Controls.Add(bannedLabel);
            this.groupBox3.Controls.Add(this.bannedCheckBox);
            this.groupBox3.Controls.Add(games_playedLabel);
            this.groupBox3.Controls.Add(this.games_playedTextBox);
            this.groupBox3.Controls.Add(this.txtDirectClientId);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(12, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 319);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player profile info";
            // 
            // nickTextBox
            // 
            this.nickTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profilesBindingSource, "Nick", true));
            this.nickTextBox.Location = new System.Drawing.Point(101, 24);
            this.nickTextBox.Name = "nickTextBox";
            this.nickTextBox.Size = new System.Drawing.Size(104, 20);
            this.nickTextBox.TabIndex = 22;
            // 
            // profilesBindingSource
            // 
            this.profilesBindingSource.DataMember = "Profiles";
            this.profilesBindingSource.DataSource = this.battleshipsDataSet1;
            // 
            // battleshipsDataSet1
            // 
            this.battleshipsDataSet1.DataSetName = "battleshipsDataSet1";
            this.battleshipsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profilesBindingSource, "Firstname", true));
            this.firstnameTextBox.Location = new System.Drawing.Point(101, 50);
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(104, 20);
            this.firstnameTextBox.TabIndex = 24;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profilesBindingSource, "Surname", true));
            this.surnameTextBox.Location = new System.Drawing.Point(101, 76);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(104, 20);
            this.surnameTextBox.TabIndex = 26;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profilesBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(101, 102);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(168, 57);
            this.descriptionTextBox.TabIndex = 28;
            // 
            // ageTextBox
            // 
            this.ageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profilesBindingSource, "Age", true));
            this.ageTextBox.Location = new System.Drawing.Point(101, 165);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(104, 20);
            this.ageTextBox.TabIndex = 30;
            // 
            // games_wonTextBox
            // 
            this.games_wonTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profilesBindingSource, "Games_won", true));
            this.games_wonTextBox.Location = new System.Drawing.Point(101, 197);
            this.games_wonTextBox.Name = "games_wonTextBox";
            this.games_wonTextBox.Size = new System.Drawing.Size(104, 20);
            this.games_wonTextBox.TabIndex = 32;
            // 
            // bannedCheckBox
            // 
            this.bannedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.profilesBindingSource, "Banned", true));
            this.bannedCheckBox.Location = new System.Drawing.Point(101, 223);
            this.bannedCheckBox.Name = "bannedCheckBox";
            this.bannedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.bannedCheckBox.TabIndex = 34;
            // 
            // games_playedTextBox
            // 
            this.games_playedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profilesBindingSource, "Games_played", true));
            this.games_playedTextBox.Location = new System.Drawing.Point(101, 257);
            this.games_playedTextBox.Name = "games_playedTextBox";
            this.games_playedTextBox.Size = new System.Drawing.Size(104, 20);
            this.games_playedTextBox.TabIndex = 36;
            // 
            // txtDirectClientId
            // 
            this.txtDirectClientId.Location = new System.Drawing.Point(101, 283);
            this.txtDirectClientId.Name = "txtDirectClientId";
            this.txtDirectClientId.Size = new System.Drawing.Size(100, 20);
            this.txtDirectClientId.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 286);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Direct play ID:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_playerInfoSearch);
            this.groupBox4.Controls.Add(this.txtUsername);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(12, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(308, 54);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Searcher";
            // 
            // btn_playerInfoSearch
            // 
            this.btn_playerInfoSearch.Location = new System.Drawing.Point(222, 17);
            this.btn_playerInfoSearch.Name = "btn_playerInfoSearch";
            this.btn_playerInfoSearch.Size = new System.Drawing.Size(60, 23);
            this.btn_playerInfoSearch.TabIndex = 2;
            this.btn_playerInfoSearch.Text = "Find";
            this.btn_playerInfoSearch.UseVisualStyleBackColor = true;
            this.btn_playerInfoSearch.Click += new System.EventHandler(this.btn_playerInfoSearch_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(70, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(146, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Ronan";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "User:";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 398);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(93, 398);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // profilesTableAdapter
            // 
            this.profilesTableAdapter.ClearBeforeFill = true;
            // 
            // frmSearchPlayerInfo
            // 
            this.ClientSize = new System.Drawing.Size(332, 428);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmSearchPlayerInfo";
            this.Text = "Player info search";
            this.Load += new System.EventHandler(this.frmSearchPlayerInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSet1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDirectClientId;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_playerInfoSearch;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_Cancel;
        private battleshipsDataSet1 battleshipsDataSet1;
        private System.Windows.Forms.BindingSource profilesBindingSource;
        private BattleShipsServer.battleshipsDataSet1TableAdapters.ProfilesTableAdapter profilesTableAdapter;
        private System.Windows.Forms.TextBox nickTextBox;
        private System.Windows.Forms.TextBox firstnameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.TextBox games_wonTextBox;
        private System.Windows.Forms.CheckBox bannedCheckBox;
        private System.Windows.Forms.TextBox games_playedTextBox;
    }
}