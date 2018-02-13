using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;


namespace BattleShipsServer
{
    public partial class frmUserMessage : Form
    {
        Client mClient;
        Server mServer;
        bool clientMode;
        int userId;

        public frmUserMessage(string userTo, Client mClient)
        {
            InitializeComponent();
            this.Text = userTo;
            this.mClient = mClient;
        }

        public frmUserMessage(int userId, Server mServer, string userTo)
        {
            InitializeComponent();
            this.Text = userTo;
            this.mServer = mServer;
            this.userId = userId;
        }

        public void appendMessage(string user, string chatMsg)
        {
            txtConversationBox.Text += "<" + user + "> " + chatMsg + "\r\n";
        }

        private void frmUserMessage_Load(object sender, EventArgs e)
        {

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            NetworkPacket packet = new NetworkPacket();

            SendFlags flags = (SendFlags.Sync | SendFlags.NoLoopback);

            if (mServer == null)
            {
                packet.Write("PrivChatMsg " + this.Text + " #" + txtMessageToSend.Text);

                try
                {
                    mClient.Send(packet,  // Outgoing data
                                    0,       // Timeout
                                    flags);
                }
                catch (Exception)
                { MessageBox.Show("Failed to send message");
                    return;
                }
            }
            else if (mClient == null)
            {
                string msg = "PrivChatMsg " + "Admin" + " #" + txtMessageToSend.Text;
                packet.Write(msg);

                try
                {
                    mServer.SendTo(userId,
                          packet,	//the outgoing message
                          0,			//Timeout (default)
                          flags);		//The flags 
                }
                catch (Exception)
                { MessageBox.Show("Failed to send"); return; }
            }
            else
            {
                MessageBox.Show("Serious error");
                return;
            }

            appendMessage("You", txtMessageToSend.Text);
            txtMessageToSend.Text = "";

        //    Microsoft.DirectX.DirectPlay.SendFlags flags;
          //  flags = SendFlags.NoLoopback | SendFlags.Sync;
        }

        private void txtMessageToSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btnSendMessage_Click(sender, e);
        }
    }
}