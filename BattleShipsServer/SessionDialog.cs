using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BattleShipsServer
{
    public partial class SessionDialog : Form
    {
        private int port;
        private string sessionName;
        
        public SessionDialog()
        {
            InitializeComponent();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (txt_Session_Name.Text == "" || txt_Session_Port.Text == "")
            {
                MessageBox.Show("Please enter data into the fields");
                return;
            }

            port = int.Parse(this.txt_Session_Port.Text);
            sessionName = txt_Session_Name.Text;
            //this.Hide();
            this.DialogResult = DialogResult.OK;
        }

	    public int Get_Port()
        {
            return port;
        }

        public string Get_Session_name()
        {
            return sessionName;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}