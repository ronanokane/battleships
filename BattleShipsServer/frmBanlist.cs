using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BattleShipsServer
{
    public partial class frmBanlist : Form
    {
        public frmBanlist()
        {
            InitializeComponent();
        }

        public battleshipsDataSet1TableAdapters.ProfilesTableAdapter profilesTableAdapterOb
        {
            get
            {
                return profilesTableAdapter;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            // refresh lists again
            button1_Click(this, null);
        }

        private void profilesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.profilesBindingSource.EndEdit();
            this.profilesTableAdapter.Update(this.battleshipsDataSet1.Profiles);
        }

        private void profilesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.profilesBindingSource.EndEdit();
            this.profilesTableAdapter.Update(this.battleshipsDataSet1.Profiles);

        }

        private void frmBanlist_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'battleshipsDataSetNotBannedUsers.Profiles' table. You can move, or remove it, as needed.
        //    this.profilesTableAdapter2.Fill(this.battleshipsDataSetNotBannedUsers.Profiles);
            // TODO: This line of code loads data into the 'battleshipsDataSetBannedUsers.Profiles' table. You can move, or remove it, as needed.
       //     this.profilesTableAdapter1.Fill(this.battleshipsDataSetBannedUsers.Profiles);
            // TODO: This line of code loads data into the 'battleshipsDataSet1.Profiles' table. You can move, or remove it, as needed.
        //    this.profilesTableAdapter.Fill(this.battleshipsDataSet1.Profiles);

        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.profilesTableAdapter1.GetBannedUsers(this.battleshipsDataSetBannedUsers.Profiles);
            this.profilesTableAdapter2.GetNotBannedUsers(this.battleshipsDataSetNotBannedUsers.Profiles);
            this.btn_UnbanUser.Enabled = false;
            this.btnAddUserToBanned.Enabled = false;
        }

        public void BanUser(string user)
        {
            this.profilesTableAdapter.BanByUsername(user);
        }

        private void lst_UsersNotBanned_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnAddUserToBanned.Enabled = (this.lst_UsersNotBanned.SelectedIndex != -1);
        }

        private void lst_UsersBanned_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_UnbanUser.Enabled = (this.lst_UsersBanned.SelectedIndex != -1);
        }

        private void btnAddUserToBanned_Click(object sender, EventArgs e)
        {
            String SelectedItemName=((System.Data.DataRowView)lst_UsersNotBanned.SelectedItem).Row[0].ToString().Trim();
            BanUser(SelectedItemName);
            button1_Click(this, null);
        }

        private void btn_UnbanUser_Click(object sender, EventArgs e)
        {
            String SelectedItemName = ((System.Data.DataRowView)this.lst_UsersBanned.SelectedItem).Row[0].ToString().Trim();
            this.profilesTableAdapter.UnbanByUsername(SelectedItemName);
            button1_Click(this, null);
        }
    }
}