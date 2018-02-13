using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;
using System.Collections;
using BattleShipsServer;
using System.IO;

//using System.Runtime.Serialization.Formatters.Soap;

namespace BattleShipsClient
{
    public partial class ConnectionDialog : Form
    {
        private HostInfo m_SelectedHost;         // Host (server) selected for connection
        private ArrayList m_FoundSessions; // Enumerated sessions
        private Client m_Client = new Client();				//temporary client object used for enumeration
        static Guid m_AppGuid = new System.Guid("1AD4CA3B-AC68-4d9b-9522-BE59CD485276"); //Guid of the server
        private Address m_LocalAddress;		//Local address of the client app
       // private ClientMain mainClientFrm;


        public ConnectionDialog()
        {
            //mainClientFrm = frmMain;
            this.m_SelectedHost = new HostInfo();
            this.m_FoundSessions = new ArrayList();
            InitializeComponent();

            this.btn_Connect.Enabled = false;
            this.lst_Sessions.Enabled = false;
            this.lst_Sessions.Items.Clear();
            this.lst_Sessions.Items.Add("Click \"Search\" to find hosts.");
            this.m_Client = new Client();
            //Add a new event handler to the client object
            m_Client.FindHostResponse += new FindHostResponseEventHandler(FindHostResponseHandler);

        }

        public void FindHostResponseHandler(object sender, FindHostResponseEventArgs args)
        {
            //This event handler is invoked when the client object finds a host matching the 
            //criteria entered by the user 
            HostInfo Node = new HostInfo();

            Node.SetGuid(args.Message.ApplicationDescription.GuidInstance);
            //get the address of the host matching our criteria
            //note we have to dynamically cast the object in the EventArgs to our required type (Address)
            Node.SetAddress((Address)args.Message.AddressSender.Clone());
            //Get the name of the session running on the server
            Node.SetSessionName(args.Message.ApplicationDescription.SessionName);

            //Check to see if we have already added this host to our list, if not do so!
            if (!this.m_FoundSessions.Contains(Node))
                this.m_FoundSessions.Add(Node);
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            this.Btn_Search.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            //Clear the current session list
            this.lst_Sessions.Enabled = false;
            this.lst_Sessions.Items.Clear();
            EnumerateSessions(this.txt_Host_Address.Text, this.RemotePort());
            //Add detected hosts to the list
            for (int i = 0; i < this.m_FoundSessions.Count; i++)
            {
                HostInfo host = (HostInfo)this.m_FoundSessions[i];
                Address ServerAddress = host.GetAddress();
                String ServerIP = ServerAddress.GetComponentString("hostname");
                String name = host.GetSessionName();
                String strHostInfo = String.Concat(name, " : ", ServerIP);
                lst_Sessions.Items.Add(strHostInfo);
                this.lst_Sessions.Enabled = true;
            }
            //Give a default message for no hosts
            if (this.m_FoundSessions.Count == 0)
                this.lst_Sessions.Items.Add("No hosts found matching the criteria found.");
            this.Cursor = Cursors.Default;
            this.Btn_Search.Enabled = true;

        }

        private int RemotePort()
        {
            try
            {
                return Int32.Parse(this.txt_Session_Port.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error parsing port number, incorrect format ?");
                return 0;
            }
        }

        private void EnumerateSessions(string hostname, int port)
        {
            //Set the desired search options
            Address HostAddress = new Address();
            HostAddress.ServiceProvider = Address.ServiceProviderTcpIp;
            if (hostname.Length > 0)
                HostAddress.AddComponent("hostname", hostname);

            if (port > 0)
                HostAddress.AddComponent("port", port);

            ApplicationDescription AppDesc = new ApplicationDescription();
            AppDesc.GuidApplication = m_AppGuid;

            /* Find all sessions hosted at the given address. When a session is found, DirectPlay calls our FindHostResponse callback. Since we're passing in the "Sync" flag, Connect will block until the search timeout has expired.*/

            try
            {
                m_Client.FindHosts(AppDesc,               // Application description
                        HostAddress,           // Host address
                            m_LocalAddress,        // Local device address
                            null,                  // Enumeration data
                            0,                     // Enumeration count (using default)
                            0,                     // Retry interval (using default)
                            0,                     // Timeout (using default)
                        FindHostsFlags.Sync); // Flags
            }//End try
            catch (Exception)
            {
                MessageBox.Show("Could not find any active hosts matching your criteria. Try again later or change your search criteria", "No activesessions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            //get the index of the list box to determine which host we need to get
            int iIndex = this.lst_Sessions.SelectedIndex;
            //get the appropriate host from the ArrayList containing the enumerated hosts
            m_SelectedHost = (HostInfo)this.m_FoundSessions[iIndex];
            //return ok as we have found a appropriate session and the user has selected one
            this.DialogResult = DialogResult.OK;

        }



        public void SetAddress(Address addr)
        {
            /*This method is used by the main form and passes the address of the client application The local address is used to enumerate the sessions running on the server */
            this.m_LocalAddress = addr;

        }

        public HostInfo GetSelectedHost()
        {
            //This method is used by the main form to get the host/session selected //by the user
            return this.m_SelectedHost;
        }

        private void lst_Sessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_Connect.Enabled = (this.lst_Sessions.SelectedIndex != -1);
        }

        private void ConnectionDialog_Load(object sender, EventArgs e)
        {

        }

        public string username
        {
            get
            {
                return this.txtUsername.Text;
            }

        }

        public string password
        {
            get
            {
                return this.txtPasswd.Text;
            }
        }

        private void btn_RegisterNewUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To register a new account first connect to session and then click \"Register new user\" in the main program's menu bar");
            //mainClientFrm.registerNewUserToolStripMenuItem_Click(this, null);
        }

        private void txtUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Ronan")
                txtPasswd.Text = "Ronan";
            else if (txtUsername.Text == "User2")
                txtPasswd.Text = "User2";
            else if (txtUsername.Text == "Test")
                txtPasswd.Text = "Test";
            else if (txtUsername.Text == "Micky")
                txtPasswd.Text = "Micky";
        }
    }
}