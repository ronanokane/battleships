namespace BattleShipsServer
{
    partial class frmBanlist
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
            this.Hide();
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_UsersBanned = new System.Windows.Forms.ListBox();
            this.profilesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.battleshipsDataSetBannedUsers = new BattleShipsServer.battleshipsDataSetBannedUsers();
            this.profilesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.battleshipsDataSet1 = new BattleShipsServer.battleshipsDataSet1();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lst_UsersNotBanned = new System.Windows.Forms.ListBox();
            this.profilesBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.battleshipsDataSetNotBannedUsers = new BattleShipsServer.battleshipsDataSetNotBannedUsers();
            this.profilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddUserToBanned = new System.Windows.Forms.Button();
            this.btn_UnbanUser = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_RefreshBanLists = new System.Windows.Forms.Button();
            this.profilesTableAdapter = new BattleShipsServer.battleshipsDataSet1TableAdapters.ProfilesTableAdapter();
            this.profilesTableAdapter1 = new BattleShipsServer.battleshipsDataSetBannedUsersTableAdapters.ProfilesTableAdapter();
            this.profilesTableAdapter2 = new BattleShipsServer.battleshipsDataSetNotBannedUsersTableAdapters.ProfilesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSetBannedUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSetNotBannedUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst_UsersBanned);
            this.groupBox1.Location = new System.Drawing.Point(253, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 388);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Banned";
            // 
            // lst_UsersBanned
            // 
            this.lst_UsersBanned.DataSource = this.profilesBindingSource2;
            this.lst_UsersBanned.DisplayMember = "Nick";
            this.lst_UsersBanned.Location = new System.Drawing.Point(6, 19);
            this.lst_UsersBanned.Name = "lst_UsersBanned";
            this.lst_UsersBanned.Size = new System.Drawing.Size(151, 355);
            this.lst_UsersBanned.TabIndex = 7;
            this.lst_UsersBanned.ValueMember = "Nick";
            this.lst_UsersBanned.SelectedIndexChanged += new System.EventHandler(this.lst_UsersBanned_SelectedIndexChanged);
            // 
            // profilesBindingSource2
            // 
            this.profilesBindingSource2.DataMember = "Profiles";
            this.profilesBindingSource2.DataSource = this.battleshipsDataSetBannedUsers;
            // 
            // battleshipsDataSetBannedUsers
            // 
            this.battleshipsDataSetBannedUsers.DataSetName = "battleshipsDataSetBannedUsers";
            this.battleshipsDataSetBannedUsers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // profilesBindingSource1
            // 
            this.profilesBindingSource1.DataMember = "Profiles";
            this.profilesBindingSource1.DataSource = this.battleshipsDataSet1;
            // 
            // battleshipsDataSet1
            // 
            this.battleshipsDataSet1.DataSetName = "battleshipsDataSet1";
            this.battleshipsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lst_UsersNotBanned);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 387);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Not banned";
            // 
            // lst_UsersNotBanned
            // 
            this.lst_UsersNotBanned.DataSource = this.profilesBindingSource3;
            this.lst_UsersNotBanned.DisplayMember = "Nick";
            this.lst_UsersNotBanned.Location = new System.Drawing.Point(6, 18);
            this.lst_UsersNotBanned.Name = "lst_UsersNotBanned";
            this.lst_UsersNotBanned.Size = new System.Drawing.Size(159, 355);
            this.lst_UsersNotBanned.TabIndex = 8;
            this.lst_UsersNotBanned.ValueMember = "Nick";
            this.lst_UsersNotBanned.SelectedIndexChanged += new System.EventHandler(this.lst_UsersNotBanned_SelectedIndexChanged);
            // 
            // profilesBindingSource3
            // 
            this.profilesBindingSource3.DataMember = "Profiles";
            this.profilesBindingSource3.DataSource = this.battleshipsDataSetNotBannedUsers;
            // 
            // battleshipsDataSetNotBannedUsers
            // 
            this.battleshipsDataSetNotBannedUsers.DataSetName = "battleshipsDataSetNotBannedUsers";
            this.battleshipsDataSetNotBannedUsers.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // profilesBindingSource
            // 
            this.profilesBindingSource.DataMember = "Profiles";
            this.profilesBindingSource.DataSource = this.battleshipsDataSet1;
            // 
            // btnAddUserToBanned
            // 
            this.btnAddUserToBanned.Enabled = false;
            this.btnAddUserToBanned.Location = new System.Drawing.Point(190, 24);
            this.btnAddUserToBanned.Name = "btnAddUserToBanned";
            this.btnAddUserToBanned.Size = new System.Drawing.Size(57, 23);
            this.btnAddUserToBanned.TabIndex = 2;
            this.btnAddUserToBanned.Text = ">>";
            this.btnAddUserToBanned.UseVisualStyleBackColor = true;
            this.btnAddUserToBanned.Click += new System.EventHandler(this.btnAddUserToBanned_Click);
            // 
            // btn_UnbanUser
            // 
            this.btn_UnbanUser.Enabled = false;
            this.btn_UnbanUser.Location = new System.Drawing.Point(191, 53);
            this.btn_UnbanUser.Name = "btn_UnbanUser";
            this.btn_UnbanUser.Size = new System.Drawing.Size(56, 23);
            this.btn_UnbanUser.TabIndex = 3;
            this.btn_UnbanUser.Text = "<<";
            this.btn_UnbanUser.UseVisualStyleBackColor = true;
            this.btn_UnbanUser.Click += new System.EventHandler(this.btn_UnbanUser_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(16, 406);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_RefreshBanLists
            // 
            this.btn_RefreshBanLists.Location = new System.Drawing.Point(190, 82);
            this.btn_RefreshBanLists.Name = "btn_RefreshBanLists";
            this.btn_RefreshBanLists.Size = new System.Drawing.Size(57, 23);
            this.btn_RefreshBanLists.TabIndex = 6;
            this.btn_RefreshBanLists.Text = "Refresh";
            this.btn_RefreshBanLists.UseVisualStyleBackColor = true;
            this.btn_RefreshBanLists.Click += new System.EventHandler(this.button1_Click);
            // 
            // profilesTableAdapter
            // 
            this.profilesTableAdapter.ClearBeforeFill = true;
            // 
            // profilesTableAdapter1
            // 
            this.profilesTableAdapter1.ClearBeforeFill = true;
            // 
            // profilesTableAdapter2
            // 
            this.profilesTableAdapter2.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Changes made here are done in real time so be carefull";
            // 
            // frmBanlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_RefreshBanLists);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_UnbanUser);
            this.Controls.Add(this.btnAddUserToBanned);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBanlist";
            this.Text = "Banning settings";
            this.Load += new System.EventHandler(this.frmBanlist_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSetBannedUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSet1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.battleshipsDataSetNotBannedUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddUserToBanned;
        private System.Windows.Forms.Button btn_UnbanUser;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_RefreshBanLists;
        private System.Windows.Forms.BindingSource profilesBindingSource1;
        private battleshipsDataSet1 battleshipsDataSet1;
        private System.Windows.Forms.BindingSource profilesBindingSource;
        private BattleShipsServer.battleshipsDataSet1TableAdapters.ProfilesTableAdapter profilesTableAdapter;
        private battleshipsDataSetBannedUsers battleshipsDataSetBannedUsers;
        private System.Windows.Forms.BindingSource profilesBindingSource2;
        private BattleShipsServer.battleshipsDataSetBannedUsersTableAdapters.ProfilesTableAdapter profilesTableAdapter1;
        private System.Windows.Forms.ListBox lst_UsersBanned;
        private battleshipsDataSetNotBannedUsers battleshipsDataSetNotBannedUsers;
        private System.Windows.Forms.BindingSource profilesBindingSource3;
        private BattleShipsServer.battleshipsDataSetNotBannedUsersTableAdapters.ProfilesTableAdapter profilesTableAdapter2;
        private System.Windows.Forms.ListBox lst_UsersNotBanned;
        private System.Windows.Forms.Label label1;
    }
}