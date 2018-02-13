using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BattleShipsServer;

namespace BattleShipsClient
{
    public partial class frmNewAccount : Form
    {
        public frmNewAccount()
        {
            InitializeComponent();
        }

        public ProfileInfo formProfileData
        {
            get
            {
                return new ProfileInfo(txtDescription.Text, Int32.Parse(txtAge.Text), txtFirstname.Text, txtSurname.Text, txtUser.Text, txtPass.Text);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int test;
            if (!Int32.TryParse(txtAge.Text, out test))
            {
                txtAge.Text = "";
                MessageBox.Show("Re-enter a valid age before proceeding");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}