using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Resources;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;
using System.Collections;

namespace BattleShipsServer
{
    enum ConnectionType { Disconnected, Hosting };

    public partial class frmMain : Form
    {
	    private Brush m_Brush; //drawing object used for drawing the hang man
	    private Pen m_pen;		//Pen is used when drawing lines
	    private Graphics m_Graphics; //Graphics object used to draw
        BattleGrid ourBttleGrid, enemyBttleGrid;


        String strSession_name;
        int iPort_Address;
        static readonly Guid m_AppGuid = new Guid("1AD4CA3B-AC68-4d9b-9522-BE59CD485276");
        Server m_Server; //DirectPlay Server object
        Address m_LocalAddress; //Local address of the server
        String m_Session_Name; //Host session name
        ConnectionType m_Connection; //Current connection state
        ApplicationDescription m_AppDesc; //An object used to describe the application

        public frmMain()
        {
            InitializeComponent();

            m_Server = new Server();
            m_LocalAddress = new Address();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitDirectPlay();

            // Set the service provider for our local address to TCP/IP
            this.m_LocalAddress.ServiceProvider = Address.ServiceProviderTcpIp;

            //Verify the computer supports our chosen service provider
            if (!CheckServiceProvider(this.m_LocalAddress.ServiceProvider))
            {
                MessageBox.Show("Warning", "You must have TCP/IP installed on your computer to run this application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //set the brush object 
            m_Brush = Brushes.Black;
            //First build a pen based on the brush
            m_pen = new Pen(m_Brush, 1);
            //Set the graphics device (used for drawing on) to that of the picture box
            m_Graphics = this.picBattleGrid.CreateGraphics();

            //picBattleGrid.Clea

            Ship []ourShips = new Ship[]{new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine)};
            Ship []enemyShips = new Ship[]{new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine)};

            Fleet ourFleet = new Fleet(ourShips);
            Fleet enemyFleet = new Fleet(enemyShips);

            Team ourTeam = new Team();
            Team enemyTeam = new Team();
           
            enemyBttleGrid = new BattleGrid(16, 16, this.picBattleGrid, 17);
            enemyBttleGrid.RandomlyInsertShips(enemyFleet);

            ourBttleGrid = new BattleGrid(16, 16, this.pictureBox1, 17);
            ourBttleGrid.RandomlyInsertShips(ourFleet);

            ourTeam.teamBattleGrid = enemyBttleGrid;
            enemyTeam.teamBattleGrid = ourBttleGrid;
            ourTeam.teamFleet = ourFleet;
            enemyTeam.teamFleet = enemyFleet;

            ourBttleGrid.DrawFleet(ourTeam.teamFleet);
            ourBttleGrid.initialiseServerMoves();

        }

        private void picBattleGrid_Click(object sender, EventArgs e)
        {
            //bttleGrid.shotFired(true,new Point(2,2) );

            Point? pt_Where_To_Draw;
            pt_Where_To_Draw=BattleGrid.ConvertPicPositionToGridCoordinate(PointToScreen(picBattleGrid.Location),System.Windows.Forms.Control.MousePosition,17);

            if (!pt_Where_To_Draw.HasValue)
            {
                MessageBox.Show("Click centre of square");
                return;
            }
            //else
              //  MessageBox.Show("" + pt_Where_To_Draw);

            try
            {
                enemyBttleGrid.shotFired(((enemyBttleGrid.FireShot(pt_Where_To_Draw.Value).Value == EnumBattleGridSquare.ShipHit) ? true : false), pt_Where_To_Draw.Value);
                ourBttleGrid.AutoMakeMove();
            }
            catch (Exception) { }

			/*//The following code will create and launch a file open dialog and draw the selected file at the mouse position
			OpenFileDialog *opfdlg=new OpenFileDialog ();
			opfdlg->Filter="JPEG files (*.jpg;*.jpeg;*.gif)|*.jpg;*.jpeg; *.gif";
			opfdlg->ShowDialog();
			Image *m_image = Image::FromFile(opfdlg->FileName);
			this->m_Graphics->DrawImage(m_image, pt_Where_To_Draw);*/
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
            Application.Exit();
        }

        private void mnu_opt_Create_Session_Click(object sender, EventArgs e)
        {
            //Show the session Dialog and get the info
            SessionDialog frmSession = new SessionDialog();
            if (frmSession.ShowDialog() == DialogResult.OK)
            { //Show the session Dialog and get the info
                //Set up the session
                this.iPort_Address = frmSession.Get_Port();
                this.strSession_name = frmSession.Get_Session_name();
                this.m_Session_Name = this.strSession_name;
                this.txt_Name.Text = this.m_Session_Name;
                this.txt_Port.Text = Convert.ToString(this.iPort_Address);
                this.Cursor = Cursors.WaitCursor; //Change the cursor style to wait whilst we perform some tasks
                this.mnu_opt_Create_Session.Enabled = false; //disable the create session menu option
                this.mnu_opt_Close_Session.Enabled = true; //enable the close session menu option
                this.txtBroadcastMessageConvo.Enabled = true;
                HostSession();
                this.txt_Status.Text = "Hosting session";
                this.Cursor = Cursors.Default; //return the cursor back to it's original state
            }//End if
        }


        private void HostSession()
        {
            //Add the port number to the DirectPlay address object
            this.m_LocalAddress.AddComponent("port", this.iPort_Address);

            //Set the details of the application description
            this.m_AppDesc.GuidApplication = m_AppGuid;
            this.m_AppDesc.SessionName = this.strSession_name;
            this.m_AppDesc.Flags = SessionFlags.ClientServer | SessionFlags.NoDpnServer;
            this.m_AppDesc.CurrentPlayers = 0;
            try
            {
                //Attempt to host the session
                this.m_Server.Host(this.m_AppDesc, this.m_LocalAddress);
                this.m_Connection = ConnectionType.Hosting;
                this.mnu_opt_Close_Session.Enabled = true;
                this.mnu_opt_Create_Session.Enabled = false;
                this.txtBroadcastMessageConvo.Enabled = true;
                this.btnBroadcastMessageSend.Enabled = true;
            }//End try
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Unknow Exception", MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
            }//End catch
        }

        private void Disconnect()
        {
            this.txt_Status.Text = "Disconnected : Not hosting a session";
            this.txtBroadcastMessageConvo.Text="";
            this.mnu_opt_Close_Session.Enabled = false;
            this.mnu_opt_Create_Session.Enabled = true;
            this.btnBroadcastMessageSend.Enabled = false;
            this.txtBroadcastMessageConvo.Enabled = false;
            this.txt_Name.Clear();
            this.txt_Port.Clear();
            m_Connection = ConnectionType.Disconnected;
        }

        private void InitDirectPlay()
        {
            // Release any exising resources
            if (this.m_Server != null)
                m_Server.Dispose();
            // Create a new DirectPlay Server object
            m_Server = new Server();
            // Add an event handler to the server object. The handler will DirectPlay events
            m_Server.Receive += new ReceiveEventHandler(ReceiveHandler);
            m_Connection = ConnectionType.Disconnected;
        }

        public void ReceiveHandler(System.Object sender, ReceiveEventArgs args)
        {
            if (m_Connection == ConnectionType.Hosting)
            {
                // Read the incoming chat message and put it into a network packet for processing
                NetworkPacket packet = args.Message.ReceiveData;
                //get the message from the packet
                String msg = packet.ReadString();
                //add the message to the list box
                this.txtBroadcastMessageConvo.Text+=msg;
            }
        }

        public void SendData()
        {
            //Create a new network packet object to which we can add our chat message
            NetworkPacket packet = new NetworkPacket();
            packet.Write(this.txtBroadcastMessageConvo.Text);

            /*Now that the outgoing text message has been encoded to a network packet, the DirectPlay method can be called. You must tell DirectPlay which Client you wish to receive the data; 
            for this sample, we'll deliver the message to all connected players (with the exception of the local player, which we exclued with the NoLoopBack flag)*/

            Microsoft.DirectX.DirectPlay.SendFlags flags;
            flags = SendFlags.Sync | SendFlags.NoLoopback;
            //Sync denotes send the message synchronously; NoLoopBack means the sender doesn't receive the message as well
            m_Server.SendTo((int)PlayerID.AllPlayers,
                    packet, //the outgoing message
                    0, //Timeout (default)
                    flags);//The flags 
            string strMsg = string.Concat("Server - ", txtBroadcastMessageConvo.Text);
            //this.lst_Message_log.Items.Add(strMsg); //Add the message sent to the log
            txtBroadcastMessageConvo.Text += strMsg;
            this.txtBroadcastMessageConvo.Text = "";
        }

        public bool CheckServiceProvider(Guid provider)
        {
            //ask DirectPlay for a list of service providers it supports. The method gets all the service providers depending on the bool parameter.

            ServiceProviderInformation[] SPInfoArray = this.m_Server.GetServiceProviders(true);

            // For each service provider in the returned list...
            foreach (ServiceProviderInformation info in SPInfoArray)
            {
                // Compare the current provider against the passed provider
                if (info.Guid == provider)
                    return true;
            } //End foreach
            return false;
        }

        private void btnBroadcastMessageSend_Click(object sender, EventArgs e)
        {
            SendData();
        }


    }
}