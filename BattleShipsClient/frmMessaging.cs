using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BattleShipsClient
{
    public partial class frmMessaging : Form
    {
        public frmMessaging()
        {
            InitializeComponent();
        }

        private void frmMessaging_Load(object sender, EventArgs e)
        {

        }

        public ListBox broadcastMsgChatBoxLog
        {
            get
            {
                return lst_BroadcastChatMessage_log;
            }
        }

        public TextBox broadcastMsgChatTxtToSend
        {
            get
            {
                return txt_ChatMessageToSend;
            }
        }

        public Button broadcastChatToSendButton
        {
            get
            {
                return this.btn_BroadcastChatMsgSend;
            }
        }

        private void btn_BroadcastChatMsgSend_Click(object sender, EventArgs e)
        {

        }

       // private void btn_BroadcastChatMsgSend_Click()
       // {

     //   }
    }
}