using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BattleShipsServer;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;

namespace BattleShipsClient
{
    public partial class FrmUsers : Form
    {
        Client m_Client;
        Dictionary<string, frmUserMessage> frmUserMsgCollection;

        public FrmUsers(Client m_Client, Dictionary<string, frmUserMessage> frmUserMsgCollection)
        {
            InitializeComponent();
            this.m_Client = m_Client;
            this.frmUserMsgCollection = frmUserMsgCollection;
        }

        public ListBox lstBoxConnectedUsers { get { return lstConnectedUsers; } }

        private void btn_MessageUser_Click(object sender, EventArgs e)
        {
            string user = this.lstConnectedUsers.SelectedItem.ToString();

            if (!frmUserMsgCollection.ContainsKey(user))
                frmUserMsgCollection.Add(user, new frmUserMessage(user, m_Client));

            frmUserMsgCollection[user].Show();
        }

        private void btnChatToAdmin_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {

        }

        private void lstConnectedUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_MessageUser.Enabled = (this.lstConnectedUsers.SelectedIndex != -1);
        }
    }
}
