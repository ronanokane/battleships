using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;
using BattleShipsServer;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Threading;

namespace BattleShipsClient
{
    enum ConnectionType { Disconnected, Connected };

    public partial class ClientMain : Form
    {
        static readonly Guid m_AppGuid = new Guid("1AD4CA3B-AC68-4d9b-9522-BE59CD485276");  // The guid for the session
        Client m_Client;	// DirectPlay Client object
        Address m_LocalAddress; // Local address
        String m_SessionName; // Hosted session name 
        ConnectionType m_Connection = new ConnectionType(); //An enumeration for maintaining the state of the client
        public string gameIdentifier { get; private set; }

        FrmGames frmGames;

        frmScoreboard frmScoreBoard;
        Dictionary<string, frmUserMessage> frmUserMsgCollection= new Dictionary<string, frmUserMessage> ();

        bool loggedOn;

        public bool gameInProgress { get; private set; }

        Game currentGame;
        Graphics m_Graphics;

        Point lastShotCoord;

        string strUsername;
        FrmUsers FrmMessageServerUsers;

        public int gameIdOfView { get; set; }

        public delegate void randomAnonMethod();

        public ClientMain()
        {
            frmGames= new FrmGames(this);

            InitializeComponent();
            frmScoreBoard = new frmScoreboard();
            InitDirectPlay();

            FrmMessageServerUsers = new FrmUsers(m_Client, frmUserMsgCollection);
        }

        private void InitDirectPlay()
        {
            try
            {
                m_LocalAddress = new Address();
                m_SessionName = "New Host";
                m_Connection = ConnectionType.Disconnected;

                currentGame = null;
                loggedOn = false;
                gameInProgress = false;
                frmUserMsgCollection = new Dictionary<string, frmUserMessage>();

                // for some reason causes the machine to freeze so commented out
                // Release any exising resources
                //            if (m_Client != null)
                //              m_Client.Dispose();

                // Create a new DirectPlay Client object
                m_Client = new Client();

                // Add handlers for DirectPlay events
                m_Client.Receive += new ReceiveEventHandler(ReceiveHandler);
                m_Client.SessionTerminated += new SessionTerminatedEventHandler(SessionTerminatedHandler);

                //Set the service provider for our local address
                this.m_LocalAddress.ServiceProvider = Address.ServiceProviderTcpIp;

                //verify the computer supports our chosen service provider
                if (!CheckServiceProvider(this.m_LocalAddress.ServiceProvider))
                    MessageBox.Show("Warning", "You must have TCP/IP and DirectX installed on your computer to run this application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ReceiveHandler(Object sender, ReceiveEventArgs args)
        {
            //The first thing we need to do is to determine what type of message we jusr received
            using (NetworkPacket packet = args.Message.ReceiveData) //Read the message from the ReceiveEvent arguments 
            {
                string packetContent = packet.ReadString();
                string[] msgArgs = packetContent.Split(' ');
                string msgType = msgArgs[0];

                textBox1.Text += packetContent + "\r\n\r\n";

                switch (msgType)
                {
                    //CMD <username> <gameId> 
                    case "AcceptGameChallenge":
                        {
                            string UserWhoInvitedYou = msgArgs[1];

                            if (gameInProgress)
                            {
                                if (MessageBox.Show("User " + UserWhoInvitedYou + " has invited you to a game challenge. Do you accept challenge and quit your current game ?", "User game invite", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    sendPacketToServer("JoinGame " + msgArgs[2]);
                                    //resetGuiFields();
                                }
                            }
                            else
                                sendPacketToServer("JoinGame " + msgArgs[2]);

                            break;
                        }
                    // CMD <userName>
                    case "InviteToPlayGame":
                        {
                            string UserWhoInvitedYou = msgArgs[1];

                            if (MessageBox.Show("User " + UserWhoInvitedYou + " has invited you to a game challenge. Do you accept challenge?", "User game invite", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                sendPacketToServer("AcceptGameChallenge " + UserWhoInvitedYou);
                                //resetGuiFields();
                            }

                            break;
                        }
                    // CMD <gameId> <teamName> <teamPlayersSerializedCollection>
                    case "TeamPlayers":
                        {
                            if (msgArgs[1] == gameIdentifier)
                            {
                                string teamPlayersData = packetContent.Substring(packetContent.IndexOf(msgArgs[2]) + 5);

                                DataContractSerializer teamPlayersFormatter = new DataContractSerializer(typeof(List<Player>));

                                using (MemoryStream rcvStrmTeamPlayersData = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(teamPlayersData.ToCharArray())))
                                {
                                    rcvStrmTeamPlayersData.Position = 0;
                                    List<Player> reconstructedTeamPlayersOb = (List<Player>)teamPlayersFormatter.ReadObject(rcvStrmTeamPlayersData);

                                    ListBox lstBoxTeam = null;

                                    if (msgArgs[2] == "team1")
                                        lstBoxTeam = lstTeamA;
                                    else
                                        lstBoxTeam = lstTeamB;

                                    lstBoxTeam.Items.Clear();

                                    foreach (Player player in reconstructedTeamPlayersOb)
                                        lstBoxTeam.Items.Add(player.GetPlayerName());

                                    rcvStrmTeamPlayersData.Close();
                                }
                            }

                            break;
                        }

                    // CMD <response no> <gameId>
                    case "JoinGame":
                        {

                            if (msgArgs[1] == "2")
                            {
                                MessageBox.Show("Not allowed to join in on Player v Server games");
                                return;
                            }
                            else if (msgArgs[1] == "1")
                            {
                                gameInProgress = true;

                                int gameId = Int32.Parse(msgArgs[2]);

                               // txt_GameId.Text = "" + gameId;
                                this.Text = "Game " + gameId;
                                gameIdentifier = "" + gameId;

                                lst_BroadcastChatMessage_log.Items.Add("*You have joined this game*");

                                process_StartGame(gameId);

                              //  Invoke((randomAnonMethod)delegate()
                             //   {
                                    // lstTeamA.Items.Clear();
                                    // lstTeamB.Items.Clear();
                                    //lstTeamA.Items.Add(strUsername);
                                    //lstTeamB.Items.Add(strUsername);

                                    /*
                                    txtTeam.Text = "TeamB";
                                    txtOpponentTeam.Text = "TeamA";
                                    txtGameOutcome.Text = "";*/
                              //  });

                                sendPacketToServer("TeamFleet " + currentGame.gameId);
                            }
                            else
                                MessageBox.Show("No vacancies left in game");

                            break;
                        }


                    case "RemoveGame":
                        {

                            string tmpGameId = msgArgs[1];

                            Invoke((Action<string>)delegate(string arg)
                            {
                                // for(int x=0; x < lstActiveGames.Items.Count; x++)
                                // {
                                // if(tmpGameId==lstActiveGames.Items[x])
                                frmGames.lstActiveGamesBox.Items.Remove(arg);
                                //}
                            }, tmpGameId);

                            break;
                        }

                    case "PlayerBanned":
                        {

                            MessageBox.Show("You are banned from the server");
                            //sendPacketToServer("Logout");
                            this.m_Connection = ConnectionType.Disconnected;
                            Application.Exit();
                            break;
                        }

                    case "GameOver":
                        {
                            //<CMD> <no> 
                            // (no=1 for u were part of the winning team, 0 for part of losing team

                            string outcome;

                            if (msgArgs[1] == "1")
                            {
                                outcome = "Your team won";
                                // txtGameOutcome.Text = "Your team won";
                                //MessageBox.Show("Game over, you win");
                            }
                            else if (msgArgs[1] == "0")
                            {
                                outcome = "Your team lost";
                                // txtGameOutcome.Text = "Your team lost";
                                //MessageBox.Show("Game over, you loss");
                            }
                            else
                                outcome = msgArgs[1] + " wins";

                            /*
                            Invoke((Action<string>)delegate(string gameOutcome)
                            {
                                txtGameOutcome.Text = gameOutcome;
                                MessageBox.Show(gameOutcome);

                            }, outcome);

                            txtGameOutcome.Text = outcome;*/

                            MessageBox.Show(outcome);

                            lstTeamA.Items.Clear();
                            lstTeamB.Items.Clear();

                            btnMessageTeamAUser.Enabled = false;
                            btnMessageTeamBUser.Enabled = false;

                            Graphics gf = teamBBattleGridPic.CreateGraphics();
                            gf.Clear(Color.FromArgb(128, 128, 255));
                            gf = teamABattleGridPic.CreateGraphics();
                            gf.Clear(Color.FromArgb(128, 128, 255));

                            gameInProgress = false;

                            break;
                        }

                    case "ShotFired":
                        {

                            // confirmation of our last shot placed
                            // <CMD> <#> <x,y> <shitHit?>
                            if (msgArgs[1] == "#")
                            {
                                Point coordShotAt = new Point();

                                // coordinate of shot
                                string[] coordArgs = msgArgs[2].Split(',');
                                coordShotAt.X = Int32.Parse(coordArgs[0]);
                                coordShotAt.Y = Int32.Parse(coordArgs[1]);

                                // msgArgs[2] = 1 (ship hit) or 0 (water hit)

                                bool shipHit = msgArgs[3] == "1" ? true : false;

                                currentGame.team1.teamBattleGrid.shotFired(shipHit, coordShotAt);
                                teamABattleGridPic.Invalidate();

                            }
                            // enemy fired shot at us
                            // <CMD> <$> <x,y> <shipHit?>
                            else if (msgArgs[1] == "$")
                            {
                                Point coordShotAt = new Point();

                                // coordinate of shot
                                string[] coordArgs = msgArgs[2].Split(',');
                                coordShotAt.X = Int32.Parse(coordArgs[0]);
                                coordShotAt.Y = Int32.Parse(coordArgs[1]);

                                bool shipHit = msgArgs[3] == "1" ? true : false;
                                currentGame.team2.teamBattleGrid.shotFired(shipHit, coordShotAt);
                                teamBBattleGridPic.Invalidate();

                                //lst_BroadcastChatMessage_log.Items.Add("*Enemy fired a shot*");
                            }

                            break;
                        }

                    case "BroadcastChatMsg":
                        {
                            // CMD <userFrom> #<chatMsg>

                            string userFrom = msgArgs[1];
                            string chatMessage = string.Join(" ", msgArgs);

                            chatMessage = chatMessage.Substring(chatMessage.IndexOf('#') + 1);

                            lst_BroadcastChatMessage_log.Items.Add("<" + userFrom + ">" + chatMessage);

                            break;
                        }

                    case "PrivChatMsg":
                        {
                            // CMD <userFrom> #<chatMsg>

                            string userFromm = msgArgs[1];
                            string chatMessagee = string.Join(" ", msgArgs);

                            chatMessagee = chatMessagee.Substring(chatMessagee.IndexOf('#') + 1);

                            if (!frmUserMsgCollection.ContainsKey(userFromm))
                                frmUserMsgCollection.Add(userFromm, new frmUserMessage(userFromm, m_Client));

                            string[] Argss = { userFromm, chatMessagee };
                            Invoke((Action<string[]>)delegate(string[] Args)
                            {
                                frmUserMsgCollection[Args[0]].appendMessage(Args[0], Args[1]);
                                frmUserMsgCollection[Args[0]].Show();
                            }, new object[] { Argss });

                            break;
                        }

                    case "Login":
                        {

                            if (msgArgs[1] == "0")
                            {
                                toolStripStatusSessionInfo.Text += " although not logged in";
                                MessageBox.Show("Login unsuccessfull");
                            }
                            else if (msgArgs[1] == "1")
                            {
                                //MessageBox.Show("Login successfull");
                                toolStripStatusSessionInfo.Text += " and logged in as " + this.strUsername;
                                loggedOn = true;

                                Invoke((Action<string[]>)delegate(string[] msgArgss)
                                {
                                    startNewGameToolStripMenuItem.Enabled = true;
                                    playTeamModeToolStripMenuItem.Enabled = true;

                                }, new object[] { msgArgs });

                            }
                            else
                                MessageBox.Show("Cannot login to same server twice with same username");

                            break;
                        }

                    case "UsersListing":
                        {

                            Invoke((Action<string[]>)delegate(string[] msgArgss)
                            {
                                for (int x = 1; x < msgArgss.Length; x++)
                                {
                                    // try
                                    // {
                                    if (!frmUserMsgCollection.ContainsKey(msgArgss[x]))
                                    {
                                        frmUserMsgCollection.Add(msgArgss[x], new frmUserMessage(msgArgss[x], m_Client));
                                       // lstConnectedUsers.Items.Add(msgArgss[x]);
                                    }

                                    if (!FrmMessageServerUsers.lstBoxConnectedUsers.Items.Contains(msgArgss[x]))
                                        FrmMessageServerUsers.lstBoxConnectedUsers.Items.Add(msgArgss[x]);
                                    // }
                                    // catch (Exception) { }
                                }
                            }, new object[] { msgArgs });

                            break;
                        }

                    case "GamesListing":
                        {

                            Invoke((Action<string[]>)delegate(string[] msgArgss)
                            {
                                for (int x = 1; x < msgArgss.Length; x++)
                                    this.frmGames.lstActiveGamesBox.Items.Add(msgArgss[x]);
                            }, new object[] { msgArgs });

                            break;
                        }

                    case "StartGame":
                        {
                            //lstTeamA.Items.Add(txtUIs

                            gameIdentifier = msgArgs[2];

                            process_StartGame(Int32.Parse(gameIdentifier));

                            gameInProgress = true;

                            Invoke((randomAnonMethod)delegate()
                            {
                                //txtOpponentTeam.Text = "Team B";
                                //txtTeam.Text = "TeamA";
                                //txtOpponentTeam.Text = "TeamB";
                                //txtGameOutcome.Text = "";

                                //txt_GameId.Text = "" + gameIdentifier;

                                this.Text = "Game " + gameIdentifier;
                            });

                            sendPacketToServer("TeamFleet " + currentGame.gameId);

                            break;
                        }

                    case "RegisterUser":
                        {

                            Invoke((Action<string>)delegate(string registerAckNo)
                            {
                                if (registerAckNo == "0")
                                    MessageBox.Show("Registration of new profile failed");
                                else
                                    MessageBox.Show("Registration of new profile succeeded");

                            }, msgArgs[1]);

                            break;
                        }

                    case "NewUserConnected":
                        {

                            Invoke((Action<string>)delegate(string strNewUser)
                            {
                                if (FrmMessageServerUsers.lstBoxConnectedUsers.Items.Contains(strNewUser))
                                    return;

                                this.FrmMessageServerUsers.lstBoxConnectedUsers.Items.Add(strNewUser);

                                try
                                {
                                    frmUserMsgCollection.Add(strNewUser, new frmUserMessage(strNewUser, m_Client));
                                }
                                catch (Exception)
                                { }

                            }, msgArgs[1]);

                            break;
                        }

                    case "NewGameAdded":
                        {

                            Invoke((Action<string>)delegate(string strGameAdded)
                            {
                                if (frmGames.lstActiveGamesBox.Items.Contains(strGameAdded))
                                    return;

                                try
                                {
                                    frmGames.lstActiveGamesBox.Items.Add(strGameAdded);
                                }
                                catch (Exception)
                                { }

                            }, msgArgs[1]);

                            break;
                        }

                    case "UserLeft":
                        {

                            //msgArgs
                            try
                            {
                                Invoke((Action<string>)delegate(string strUser)
                                {
                                    try
                                    {
                                        FrmMessageServerUsers.lstBoxConnectedUsers.Items.Remove(strUser);
                                    }
                                    catch (Exception) { }
                                }, msgArgs[1]);
                            }
                            catch (Exception) { }

                            break;
                        }

                    case "TeamFleet":
                        {

                            string data = packetContent.Substring(packetContent.IndexOf(' ') + 1);
                            DataContractSerializer formatter = new DataContractSerializer(typeof(BattleShipsServer.Fleet));

                            MemoryStream rcvStrm = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(data.ToCharArray()));

                            string blah = new StreamReader(rcvStrm).ReadToEnd().Trim();

                            rcvStrm.Position = 0;
                            Fleet reconstructedFleetOb = (Fleet)formatter.ReadObject(rcvStrm);

                            currentGame.team2.teamBattleGrid.DrawFleet(reconstructedFleetOb);

                            teamBBattleGridPic.Invalidate();

                            break;
                        }

                    case "ServerGoingOffline":
                        {

                            this.m_Connection = ConnectionType.Disconnected;
                            MessageBox.Show("Server has went offline for maintenance");
                            UpdateUI();

                            break;
                        }

                    case "ViewGameFleet":
                        {

                            int len = packetContent.Length - packetContent.IndexOf("####");

                            string fleet1Data = packetContent.Substring(14, packetContent.IndexOf("####") - 14);
                            string fleet2Data = packetContent.Substring(packetContent.IndexOf("####") + 4);
                            DataContractSerializer fleetFormatter = new DataContractSerializer(typeof(Fleet));

                            MemoryStream rcvStrmFleet1 = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fleet1Data.ToCharArray()));
                            MemoryStream rcvStrmFleet2 = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(fleet2Data.ToCharArray()));

                            rcvStrmFleet1.Position = 0;
                            Fleet reconstructedFleet1Ob = (Fleet)fleetFormatter.ReadObject(rcvStrmFleet1);
                            rcvStrmFleet2.Position = 0;
                            Fleet reconstructedFleet2Ob = (Fleet)fleetFormatter.ReadObject(rcvStrmFleet2);

                            currentGame.team2.teamBattleGrid.DrawFleet(reconstructedFleet1Ob);
                            currentGame.team1.teamBattleGrid.DrawFleet(reconstructedFleet2Ob);

                            currentGame.team2.teamBattleGrid.DrawIt();
                            currentGame.team1.teamBattleGrid.DrawIt();

                            teamABattleGridPic.Invalidate();
                            teamBBattleGridPic.Invalidate();

                            break;
                        }

                    case "ViewGrids":
                        {
                           // txt_GameId.Text = "" + gameIdOfView;
                            this.Text = "Game " + gameIdOfView;
                            gameIdentifier = "" + gameIdOfView;



                            string grid1Data = packetContent.Substring(10, packetContent.IndexOf("####") - 10);
                            string grid2Data = packetContent.Substring(packetContent.IndexOf("####") + 4);
                            SoapFormatter gridFormatter = new SoapFormatter();

                            MemoryStream rcvStrmGrid1 = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(grid1Data.ToCharArray()));
                            MemoryStream rcvStrmGrid2 = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(grid2Data.ToCharArray()));

                            rcvStrmGrid1.Position = 0;
                            BattleGrid reconstructedGrid1Ob = (BattleGrid)gridFormatter.Deserialize(rcvStrmGrid1);
                            rcvStrmGrid2.Position = 0;
                            BattleGrid reconstructedGrid2Ob = (BattleGrid)gridFormatter.Deserialize(rcvStrmGrid2);


                            Bitmap team1GridBmap = new Bitmap(
                                              16 * 17,
                                              16 * 17,
                                              System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                            Bitmap team2GridBmap = new Bitmap(
                                              16 * 17,
                                              16 * 17,
                                              System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                            //m_Graphics = this.teamABattleGridPic.CreateGraphics();

                            Ship[] team1Ships = new Ship[] { new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine) };
                            Ship[] team2Ships = new Ship[] { new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine) };

                            Fleet team1Fleet = new Fleet(team1Ships);
                            Fleet team2Fleet = new Fleet(team2Ships);

                            Team team1Team = new Team(reconstructedGrid1Ob, team1Fleet);
                            Team team2Team = new Team(reconstructedGrid2Ob, team2Fleet);

                            //team1Fleet.

                            int gameId = Int32.Parse(frmGames.lstActiveGamesBox.Items[frmGames.lstActiveGamesBox.SelectedIndex].ToString());

                            currentGame = new Game(team1Team, team2Team, 2, true);
                            currentGame.setNewGameId(gameId);
                            //activeGames[lastGame.gameId] = lastGame;*/

                            // only need to call initGridResources because deserialized method
                            // contains nonserialized resource fields that need reinitialized for client
                            reconstructedGrid1Ob.initGridResources(team1GridBmap);
                            reconstructedGrid2Ob.initGridResources(team2GridBmap);

                            //txtGameOutcome.Text = "";
                            sendPacketToServer("ViewGameFleet " + currentGame.gameId);

                            break;
                        }
                }

            }
                   
        }

        public void SessionTerminatedHandler(object sender, SessionTerminatedEventArgs args)
        {
            MessageBox.Show("Connect lost or host terminated session", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.m_Connection = ConnectionType.Disconnected;
            UpdateUI();

        }

        private void UpdateUI()
        {

            switch (this.m_Connection)
            {
                case ConnectionType.Connected:
                    {
                        String status = String.Concat("Connected to session <", this.m_SessionName, ">" + (loggedOn ? " and logged in as " + this.strUsername : ""));

                        this.toolStripStatusSessionInfo.Text = status;
                        this.mnu_opt_Connect.Enabled = false;
                        this.mnu_opt_Close_Session.Enabled = true;
                        gbo_Comms.Enabled = true;
                        registerNewUserToolStripMenuItem.Enabled = true;
                        btnChallengeWinner.Enabled = true;
                        grpBoxTeamA.Enabled = true;
                        grpBoxTeamB.Enabled = true;
                        toolStripMessaging.Enabled = true;
                        GameToolStripMenuItem.Enabled = true;
                        
                        break;
                    }
                case ConnectionType.Disconnected:
                    {
                        string status;
                        try
                        {
                            status = String.Concat("Not connected to a session");

                            this.toolStripStatusSessionInfo.Text = status;

                            Graphics gf = teamBBattleGridPic.CreateGraphics();
                            gf.Clear(Color.FromArgb(128, 128, 255));
                            gf = teamABattleGridPic.CreateGraphics();
                            gf.Clear(Color.FromArgb(128, 128, 255));
                        }
                        catch (Exception)
                        { }

                        mnu_opt_Connect.Enabled = true;

                        this.Text = "";
                        gameIdentifier = "";
                        this.mnu_opt_Connect.Enabled = true;
                        this.mnu_opt_Close_Session.Enabled = false;
                        registerNewUserToolStripMenuItem.Enabled = false;
                        loggedOn = false;
                        startNewGameToolStripMenuItem.Enabled = false;
                        FrmMessageServerUsers.lstBoxConnectedUsers.Items.Clear();
                        frmGames.lstActiveGamesBox.Items.Clear();
                        btnMessageTeamAUser.Enabled = false;
                        mnu_opt_Close_Session.Enabled = false;

                        lstTeamA.Items.Clear();
                        lstTeamB.Items.Clear();

                        grpBoxTeamA.Enabled = false;
                        grpBoxTeamB.Enabled = false;
                        toolStripMessaging.Enabled = false;
                        txt_BroadcastChatMessageToSend.Text = "";
                        lst_BroadcastChatMessage_log.Items.Clear();
                        FrmMessageServerUsers.lstBoxConnectedUsers.Items.Clear();
                        gbo_Comms.Enabled = false;
                        gameInProgress = false;
                        currentGame = null;
                        btnChallengeWinner.Enabled = false;
                        GameToolStripMenuItem.Enabled = false;

                        break;
                    }
            }
        }

        private bool CheckServiceProvider(Guid provider)
        {
            ServiceProviderInformation[] SPInfoArray = m_Client.GetServiceProviders(true);
            int iSize = SPInfoArray.Length; //Get the lenght of the returned array

            //For each service provider in the returned list
            for (int i = 0; i < iSize; i++)
            {
                //compare the current provider in the list with the one passed
                if (SPInfoArray[i].Guid == provider)
                    return true;
            }//End for
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void process_StartGame(int gameId)
        {
            Bitmap team1GridBmap = new Bitmap(
                              16 * 17,
                              16 * 17,
                              System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            Bitmap team2GridBmap = new Bitmap(
                              16 * 17,
                              16 * 17,
                              System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            m_Graphics = this.teamABattleGridPic.CreateGraphics();

            Ship[] clientShips = new Ship[] { new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine) };
            Ship[] serverShips = new Ship[] { new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine) };

            Fleet clientFleet = new Fleet(clientShips);
            Fleet serverFleet = new Fleet(serverShips);

            BattleGrid clientBttleGrid = new BattleGrid(16, 16, team1GridBmap, 17);
           // clientBttleGrid.RandomlyInsertShips(serverFleet);

            BattleGrid serverBttleGrid = new BattleGrid(16, 16, team2GridBmap, 17);
           // serverBttleGrid.RandomlyInsertShips(clientFleet);

            Team clientTeam = new Team(clientBttleGrid, clientFleet);
            Team serverTeam = new Team(serverBttleGrid, serverFleet);

            currentGame = new Game(clientTeam, serverTeam, 2, true);
            currentGame.setNewGameId(gameId);
            //activeGames[lastGame.gameId] = lastGame;

            //serverTeam.teamBattleGrid.DrawFleet(clientFleet);

            teamABattleGridPic.Invalidate();
            teamBBattleGridPic.Invalidate();
        }

        private void mnu_opt_Disconnect_Click(object sender, EventArgs e)
        {
            if (this.m_Connection == ConnectionType.Connected)
            {
                // newly added - check no bugs
                if (gameInProgress)
                    sendPacketToServer("QuitGame " + gameIdentifier);

                sendPacketToServer("Logout");
            }

            this.m_Connection = ConnectionType.Disconnected;
            gameInProgress = false;
            this.UpdateUI();
            InitDirectPlay();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameInProgress)
            {
                if (m_Connection == ConnectionType.Connected)
                    sendPacketToServer("QuitGame " + gameIdentifier);
                //InitDirectPlay();
                //UpdateUI();
                gameInProgress = false;
            }
           // else
           //     MessageBox.Show("Cannot leave game because we are not playing in it");

            UpdateUI();
        }

        private void mnu_Connect_Click(object sender, EventArgs e)
        {
            this.UpdateUI();
            frmGames.lstActiveGamesBox.Items.Clear();
            FrmMessageServerUsers.lstBoxConnectedUsers.Items.Clear();
            //m_LocalAddress = new Address();
            ConnectionDialog frmConnect = new ConnectionDialog();
            frmConnect.SetAddress(this.m_LocalAddress);

            Thread.Sleep(500);

            if (frmConnect.ShowDialog() == DialogResult.Cancel)
            {
                //If the result of the connection dialog was cancel the just quit out of the method
                return;
            }

            this.toolStripStatusSessionInfo.Text = "Connecting...";
            //Get the host from the connection dialog
            HostInfo SelectedHost = frmConnect.GetSelectedHost();
            if (SelectedHost == null)
                return;

            // Create an application description object to hold the desired
            // host's instance guid.
            ApplicationDescription appDesc = new ApplicationDescription(); appDesc.GuidInstance = SelectedHost.GetGuid();

            // Attempt to connect to the selected DirectPlay session. Once we
            // are connected to the session, we will receive DirectPlay messages
            // about session events (like players joining/exiting and received game 
            // data). Since we're passing in the "Sync" flag, the Connect call will
            // block until the session is connected or the timeout expires.

            try
            {
                m_Client.Connect(appDesc,  // Application description
                SelectedHost.GetAddress(), // Host address
                    this.m_LocalAddress,           // Local device address
                    null,                     // User connection data (none)  
                    ConnectFlags.Sync);      // Flags

                m_SessionName = SelectedHost.GetSessionName();
                m_Connection = ConnectionType.Connected;

                sendLoginRequest(frmConnect.username, frmConnect.password);
                strUsername = frmConnect.username;

                UpdateUI();
            }
            catch (Exception)
            {
                // MessageBox.Show("Could not connect to the session ", "Connection failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }

        private void scoreboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScoreBoard.Show();
        }

        private void sendLoginRequest(string user, string pass)
        {
            sendPacketToServer("Login " + user + " " + pass);
        }

        private void sendStartNewGameRequest(bool teamMode)
        {
            sendPacketToServer("StartGame " + (teamMode == true ? "1" : "0"));
        }

        public void sendPacketToServer(string msg)
        {
            try
            {

                using (NetworkPacket packet = new NetworkPacket())
                {

                    packet.Write(msg);

                    SendFlags flags = (SendFlags.Sync | SendFlags.NoLoopback);
                    m_Client.Send(packet,  // Outgoing data
                                        0,       // Timeout
                                        flags);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void registerNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewAccount newUser = new frmNewAccount();

            if (newUser.ShowDialog() == DialogResult.OK)
            {
                ProfileInfo profileContent = newUser.formProfileData;
                //ProfileInfo profileContent = new ProfileInfo();

                try
                {
                        string msgBody= profileContent.Username + "#" + profileContent.Firstname + "#" + profileContent.Surname + "#" + profileContent.Password + "#" + profileContent.Age + "#" + profileContent.Description;

                        sendPacketToServer("RegisterUser " + msgBody);
                }
                catch (Exception x)
                {
                    MessageBox.Show("An exception occured while registration\n\n" + x.Message);
                }
            }
        }

        private void btn_BroadcastChatMsgSend_Click(object sender, EventArgs e)
        {
            sendPacketToServer("BroadcastChatMsg " + "#" + txt_BroadcastChatMessageToSend.Text);

            txt_BroadcastChatMessageToSend.Text = "";
        }

        private void teamABattleGridPic_Paint_1(object sender, PaintEventArgs e)
        {
            if (currentGame != null)
                e.Graphics.DrawImage(currentGame.team1.teamBattleGrid.gridBmapImage, 0, 0, currentGame.team1.teamBattleGrid.gridBmapImage.Width, currentGame.team1.teamBattleGrid.gridBmapImage.Height);
                //e.Graphics.DrawImage(team1GridBmap, 0, 0, this.team1GridBmap.Width, this.team1GridBmap.Height);
        }

        private void teamBBattleGridPic_Paint_1(object sender, PaintEventArgs e)
        {
            if (currentGame != null)
                e.Graphics.DrawImage(currentGame.team2.teamBattleGrid.gridBmapImage, 0, 0, currentGame.team2.teamBattleGrid.gridBmapImage.Width, currentGame.team2.teamBattleGrid.gridBmapImage.Height);
                //e.Graphics.DrawImage(team2GridBmap, 0, 0, this.team2GridBmap.Width, this.team2GridBmap.Height);
        }

        private void sendShotFiredPacket(Point coord, int gameId)
        {
            NetworkPacket packet = new NetworkPacket();

            packet.Write("ShotFired " +  gameId + " " + coord.X + "," + coord.Y);

            try
            {

                SendFlags flags = (SendFlags.Sync | SendFlags.NoLoopback);
                m_Client.Send(packet,  // Outgoing data
                                    0,       // Timeout
                                    flags);
            }
            catch (Exception)
            { }
        }

        private void teamABattleGridPic_Click(object sender, EventArgs e)
        {
            if (!gameInProgress)return;

            Point? pt_Where_To_Draw;
            pt_Where_To_Draw = BattleGrid.ConvertPicPositionToGridCoordinate(PointToScreen(this.teamABattleGridPic.Location), System.Windows.Forms.Control.MousePosition, 17);

            // centre of square not clicked ?
            if (!pt_Where_To_Draw.HasValue)return;

            //MessageBox.Show(pt_Where_To_Draw.Value.ToString());
            lastShotCoord = pt_Where_To_Draw.Value;

            // fire shot at server
            sendShotFiredPacket(pt_Where_To_Draw.Value, currentGame.gameId);

            return;
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void btnChatToAdmin_Click(object sender, EventArgs e)
        {
            if (!frmUserMsgCollection.ContainsKey("Admin"))
                frmUserMsgCollection.Add("Admin", new frmUserMessage("Admin", m_Client));

            frmUserMsgCollection["Admin"].Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unimplemented yet");
        }

        public void resetGuiFields()
        {
                this.Text = "";

                lstTeamA.Items.Clear();
                lstTeamB.Items.Clear();
        }

        private void btnChallengeWinner_Click(object sender, EventArgs e)
        {
            if (gameInProgress)
            {
                MessageBox.Show("You cannot perform this operation while in an active game");
                return;
            }

            sendPacketToServer("ChallengeWinner " + gameIdentifier);
        }

        private void playServerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (m_Connection == ConnectionType.Disconnected) return;

            // newly added - check no bugs
            if (gameInProgress)
            {
                if (MessageBox.Show("Are you sure you wish to abandon current game and let your opponent win ?", "Game " + gameIdentifier, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    sendPacketToServer("QuitGame " + gameIdentifier);
                else
                    return;
            }

            frmGameCountdown frmCountDown = new frmGameCountdown();

            if (frmCountDown.ShowDialog() == DialogResult.Abort)
                return;

            // request to play against server
            sendStartNewGameRequest(false);
        }

        private void playTeamModeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (m_Connection == ConnectionType.Disconnected) return;

            // newly added - check no bugs
            if (gameInProgress)
            {
                if (MessageBox.Show("Are you sure you wish to abandon current game and let your opponent win ?", "Game " + gameIdentifier, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    sendPacketToServer("QuitGame " + gameIdentifier);
                else
                    return;
            }

            frmGameCountdown frmCountDown = new frmGameCountdown();

            if (frmCountDown.ShowDialog() == DialogResult.Abort)
                return;

            lst_BroadcastChatMessage_log.Items.Add("*Waiting on users to join game...*");

            sendStartNewGameRequest(true);
        }

        private void GamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGames.Show();
        }

        private void btnMessageTeamBUser_Click(object sender, EventArgs e)
        {
            string user = lstTeamB.SelectedItem.ToString();

            if (!frmUserMsgCollection.ContainsKey(user))
                frmUserMsgCollection.Add(user, new frmUserMessage(user, m_Client));

            this.frmUserMsgCollection[user].Show();
        }

        private void lstTeamA_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnMessageTeamAUser.Enabled = (this.lstTeamA.SelectedIndex != -1);
        }

        private void lstTeamB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnMessageTeamBUser.Enabled = (this.lstTeamB.SelectedIndex != -1);
        }

        private void MessageAdminToolStrip_Click(object sender, EventArgs e)
        {
            if (!frmUserMsgCollection.ContainsKey("Admin"))
                frmUserMsgCollection.Add("Admin", new frmUserMessage("Admin", m_Client));

            frmUserMsgCollection["Admin"].Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMessageServerUsers.Show();
        }

        private void btnMessageTeamAUser_Click(object sender, EventArgs e)
        {
            string user = lstTeamA.SelectedItem.ToString();

            if (!frmUserMsgCollection.ContainsKey(user))
                frmUserMsgCollection.Add(user, new frmUserMessage(user, m_Client));

            this.frmUserMsgCollection[user].Show();
        }

        private void txt_BroadcastChatMessageToSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btn_BroadcastChatMsgSend_Click(sender, e);

        }

        private void txt_BroadcastChatMessageToSend_TextChanged(object sender, EventArgs e)
        {

        }

    }
}