using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BattleShipsServer
{
    public partial class frmSearchPlayerInfo : Form
    {
        public frmSearchPlayerInfo()
        {
            InitializeComponent();
        }

        //public

        public void retrieveUserInfo(string user)
        {
            txtUsername.Text = user;
            btn_playerInfoSearch_Click(this, null);
        }

        private void frmSearchPlayerInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'battleshipsDataSet1.Profiles' table. You can move, or remove it, as needed.
           // this.profilesTableAdapter.Fill(this.battleshipsDataSet1.Profiles);
            // TODO: This line of code loads data into the 'battleshipsDataSet1.Profiles' table. You can move, or remove it, as needed.
           // this.profilesTableAdapter.Fill(this.battleshipsDataSet1.Profiles);

        }

        public string DirectPlayClientIdSet
        {
            set { this.txtDirectClientId.Text = value; }
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

        private void btn_playerInfoSearch_Click(object sender, EventArgs e)
        {
            DirectPlayClientIdSet = "";
            //this.profilesTableAdapter.getAccountDetails(this.txtUsername.Text);
            //this.profilesTableAdapter.Fill(this.battleshipsDataSet1.Profiles);

            this.profilesTableAdapter.searchUserAccts(this.battleshipsDataSet1.Profiles, this.txtUsername.Text);

            //this.profilesTableAdapter.getUserAcctDetails(
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}