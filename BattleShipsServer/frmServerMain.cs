using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;
using System.Collections;
using System.Collections.Specialized;

using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;

using System.IO;

namespace BattleShipsServer
{
    enum ConnectionType { Disconnected, Hosting };

    public partial class frmServerMain : Form
    {
	    private Graphics m_Graphics; //Graphics object used to draw

        String strSession_name;
        int iPort_Address;
        static readonly Guid m_AppGuid = new Guid("1AD4CA3B-AC68-4d9b-9522-BE59CD485276");
        Server m_Server; //DirectPlay Server object
        Address m_LocalAddress; //Local address of the server
        String m_Session_Name; //Host session name
        ConnectionType m_Connection; //Current connection state
        ApplicationDescription m_AppDesc; //An object used to describe the application

        Dictionary<string,Player> connectedPlayers;
        Dictionary<int, Game> activeGames;
     //   Game lastGame;
       // Bitmap team1GridBmap;
      //  Bitmap team2GridBmap;

        frmBanlist frmBanUsersList;
        frmSearchPlayerInfo playerInfoSearchFrm;
        Dictionary<string, frmUserMessage> frmUserMsgCollection;
        //int CurrentGameBeingViewed;

        public frmServerMain()
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

        private void picBattleGrid_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_Connection == ConnectionType.Hosting && this.connectedPlayers.Count > 0)
                {
                    broadcastSendMessage("ServerGoingOffline");
                    Disconnect();
                    //m_Server.Dispose();
                }
            }
            catch (Exception)
            { }
            Application.Exit();
        }

        private void mnu_opt_Create_Session_Click(object sender, EventArgs e)
        {
            InitDirectPlay();
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
            this.lst_Users.Items.Clear();
            this.lstActiveGames.Items.Clear();
            m_Connection = ConnectionType.Disconnected;
        }

        private void InitDirectPlay()
        {
            frmBanUsersList = new frmBanlist();
            frmUserMsgCollection = new Dictionary<string, frmUserMessage>();
            playerInfoSearchFrm = new frmSearchPlayerInfo();


            connectedPlayers = new Dictionary<string, Player>();
            activeGames = new Dictionary<int, Game>();

            lst_Users.Items.Clear();
            lstActiveGames.Items.Clear();

            // Release any exising resources
            if (this.m_Server != null)
                m_Server.Dispose();
            // Create a new DirectPlay Server object
            m_Server = new Server();
            // Add an event handler to the server object. The handler will DirectPlay events
            m_Server.Receive += new ReceiveEventHandler(ReceiveHandler);
            m_Connection = ConnectionType.Disconnected;

            m_Server.PlayerDestroyed+= new PlayerDestroyedEventHandler(m_Server_PlayerDestroyed);

        }

        private void m_Server_PlayerDestroyed(object o, PlayerDestroyedEventArgs args)
        {
            try
            {
                removePlayerFromAllGamesViewingLists(args.Message.PlayerID);

                Player player = getConnectedPlayerByClientId(args.Message.PlayerID, connectedPlayers);

                Invoke((Action<string>)delegate(string playerName)
                {
                    lst_Users.Items.Remove(playerName);
                }, player.GetPlayerName());

                broadcastSendMessage("UserLeft " + player.GetPlayerName());

                foreach (Game game in getGamesUserIsPartOf(args.Message.PlayerID))
                {
                    Team playersTeam = game.getPlayersTeam(args.Message.PlayerID);
                    Team enemyTeam = playersTeam == game.team1 ? game.team2 : game.team1;

                    bool playersTeamIsTeam1 = playersTeam == game.team1;
                    string opponentsTeamNameStr = playersTeamIsTeam1 == true ? "teamB" : "teamA";

                    // send msg to own team to indicate game over and we lost
                    sendCommandToAllTeamPlayers(playersTeam, "GameOver 0");
                    // send msg to opposing team to indicate game over and they won
                    if (!game.playingServerMode)
                        sendCommandToAllTeamPlayers(enemyTeam, "GameOver 1");
                    // send indicator to all viewers of the winning team
                    sendCommandToAllGameViewers(game, "GameOver " + opponentsTeamNameStr);

                    Invoke((Action<int>)delegate(int gameId)
                    {
                        lstActiveGames.Items.Remove(gameId);
                    }, game.gameId);

                    broadcastSendMessage("RemoveGame " + game.gameId);
                    activeGames.Remove(game.gameId);
                }

                connectedPlayers.Remove(player.GetPlayerName());
                frmUserMsgCollection.Remove(player.GetPlayerName());
            }
            catch (Exception) { }
        }

        public void ReceiveHandler(System.Object sender, ReceiveEventArgs args)
        {
            using (NetworkPacket packet = args.Message.ReceiveData)
            {

                string msgContent = packet.ReadString();
                string[] msgArgs = msgContent.Split(' ');
                string msgType = msgArgs[0];

                switch (msgType)
                {
                        // CMD <gameId>
                    case "ChallengeWinner":
                        {
                            Player player = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                            // not logged in
                            if (player==null)
                                return;

                            int gameId = Int32.Parse(msgArgs[1]);

                            if(activeGames.ContainsKey(gameId))
                                activeGames[gameId].SetUserChallengesWinner(player);

                            break;
                        }
                        // CMD <no> <ackNo> <username>
                        // no=1 means winner of game has accepted players request of game
                        // no=2 is the client who requested game, replying whether he is able to take game or not
                    case "AcceptGameChallenge":
                        {
                            string username=msgArgs[1];

                            Player playerToPlay =connectedPlayers[username];
                            Player player = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                            if (playerToPlay != null && player != null)
                                // quick hack to avoid having to duplicate code
                                goto case "StartGame";

                            break;
                        }

                    case "StopViewingGame":
                        {

                            int gameId = Int32.Parse(msgArgs[1]);

                            if (!activeGames.ContainsKey(gameId))
                                return;

                            Player tmpPlayer = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                            if (activeGames[gameId].viewerExists(tmpPlayer))
                                activeGames[gameId].removeViewer(tmpPlayer);

                            break;
                        }

                    case "PrivChatMsg":
                        // CMD <userTo> #<chatMsg>
                        {
                            // user sending to is connected
                            //if (connectedPlayers.ContainsKey(msgArgs[1]) && msgArgs[1]!="Admin")
                            //{
                            try
                            {
                                string userTo = msgArgs[1];
                                string chatMessage = string.Join(" ", msgArgs);

                                chatMessage = chatMessage.Substring(chatMessage.IndexOf('#') + 1);

                                //MessageBox.Show(userTo);
                                if (userTo == "Admin")
                                {
                                    //MessageBox.Show("Admin");

                                    string usr = ((Player)getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers)).GetPlayerName();

                                    if (!frmUserMsgCollection.ContainsKey(usr))
                                        frmUserMsgCollection.Add(usr, new frmUserMessage(args.Message.SenderID, m_Server, usr));


                                    //frmUserMsgCollection[usr].Show

                                    string[] Argss = new string[] { usr, chatMessage };

                                    Invoke((Action<string[]>)delegate(string[] Args)
                                    {

                                        frmUserMsgCollection[Argss[0]].appendMessage(Argss[0], Argss[1]);
                                        //if(frmUserMsgCollection[usr].Visible
                                        frmUserMsgCollection[Argss[0]].Show();

                                    }, new object[] { Argss });


                                    return;
                                }

                                int destinClientId = this.connectedPlayers[userTo].GetPlayerID();

                                Player playerFrom = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                                if (playerFrom != null)
                                    sendPrivateChatMessage(destinClientId, playerFrom.GetPlayerName(), chatMessage);
                                //}
                            }
                            catch (Exception)
                            { }


                            break;
                        }
                    case "BroadcastChatMsg":
                        {
                            // CMD #<message>
                            Player playerFrom = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);
                            string chatMessage = string.Join(" ", msgArgs);

                            chatMessage = chatMessage.Substring(chatMessage.IndexOf('#') + 1);

                            this.sendBroadcastChatMsg(playerFrom.GetPlayerName(), chatMessage);
                            break;
                        }
                    case "TeamChatMsg": break;
                    // CMD <team> <message>

                    // CMD <gameId>
                    case "JoinGame":
                        {
                            Player potentialTeam2Player = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                            if (potentialTeam2Player == null) return;

                            //if (!isUserLoggedIn(potentialTeam2Player.GetPlayerName()))
                            //    return;

                            int gameId = int.Parse(msgArgs[1]);
                            if (activeGames.ContainsKey(gameId))
                            {
                                Game game = activeGames[gameId];

                                if (game.playingServerMode)
                                {
                                    // send message indicating cannot join cos incorrect game mode ie server v player
                                    sendIndividualMsg(args.Message.SenderID, "JoinGame 2 " + gameId);
                                    return;
                                }

                                if (game.team2.teamPlayers.Count == 0)
                                {
                                    game.team2.AddPlayer(potentialTeam2Player);

                                    // indicate successfull join to client requesting to join game
                                    sendIndividualMsg(args.Message.SenderID, "JoinGame 1 " + gameId);

                                    // indicate user joined this game
                                    //broadcastSendMessage("JoinGame 11 " + gameId + potentialTeam2Player.GetPlayerName());

                                    //check user is not viewing somewhere, if he is, remove from viewers collection of that game
                                    removePlayerFromAllGamesViewingLists(args.Message.SenderID);

                                    // maybe also add remove player from all other games too ?

                                }
                                else
                                    // unable to join
                                    sendIndividualMsg(args.Message.SenderID, "JoinGame 0 " + gameId);
                                //broadcastSendMessage("JoinGame 0 " + gameId);


                                // IMPORTANT, ADD ANOTHER broadcast one to indicate to all clients the user joined that game

                                // if(game.team2.teamPlayers.Count==0)
                            }
                            break;
                        }
                    case "StartGame":
                        {
                            // CMD <gameMode> <----- server
                            // CMD <gameMode> <opposite teams grid> <----- client end

                            // get player object associated with client
                            Player team1Player = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                            // effectivelly same as isUserLoggedIn()
                            if (team1Player == null) return;

                            //if (!isUserLoggedIn(team1Player.GetPlayerName()))
                            //    return;

                            // initialise our game data

                            Bitmap team1GridBmap = new Bitmap(
                                              16 * 17,
                                              16 * 17,
                                              System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                            Bitmap team2GridBmap = new Bitmap(
                                              16 * 17,
                                              16 * 17,
                                              System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                            Ship[] team1Ships = new Ship[] { new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine) };
                            Ship[] team2Ships = new Ship[] { new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.BattleShip), new Ship(EnumShipType.Cruiser), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.MineSweeper), new Ship(EnumShipType.Submarine), new Ship(EnumShipType.Submarine) };

                            Fleet team1Fleet = new Fleet(team1Ships);
                            Fleet team2Fleet = new Fleet(team2Ships);

                            BattleGrid team1BttleGrid = new BattleGrid(16, 16, team1GridBmap, 17);
                            team1BttleGrid.RandomlyInsertShips(team2Fleet);

                            BattleGrid team2BttleGrid = new BattleGrid(16, 16, team2GridBmap, 17);
                            team2BttleGrid.RandomlyInsertShips(team1Fleet);

                            Team team1Team = new Team(team1BttleGrid, team1Fleet);
                            Team team2Team = new Team(team2BttleGrid, team2Fleet);

                            Player team2Player = new Player();
                            // was here set player name
                            team1Team.AddPlayer(team1Player);


                            Game game = new Game(team1Team, team2Team, 2, true);
                            activeGames.Add(game.gameId, game);

                            if (msgArgs[1] == "0")
                            {
                                // play server
                                game.playingServerMode = true;
                                team2Player.SetPlayerName("Server");
                                team2Team.AddPlayer(team2Player);
                                sendIndividualMsg(args.Message.SenderID, "StartGame 0 " + game.gameId);
                            }
                            else
                            {
                                // else play in team
                                game.playingServerMode = false;
                                sendIndividualMsg(args.Message.SenderID, "StartGame 1 " + game.gameId);
                            }

                            removePlayerFromAllGamesViewingLists(args.Message.SenderID);

                            // maybe should remove player from playing other games at same time too ?
                            // unadded, maybe decide to do this later

                            team2Team.teamBattleGrid.DrawFleet(team1Fleet);

                            team1Team.teamBattleGrid.DrawFleet(team2Fleet);

                            Invoke((Action<int>)delegate(int currentGameId)
                            {

                                lstActiveGames.Items.Add(currentGameId);

                            }, game.gameId);

                            broadcastSendMessage("NewGameAdded " + game.gameId);

                            if (msgArgs[0]!="StartGame")
                            {
                                string username = msgArgs[1];

                                Player playerToPlay = connectedPlayers[username];
                                Player player = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                                try
                                {

                                    int gameId = getGamesUserIsPartOf(args.Message.SenderID)[0].gameId;

                                    sendIndividualMsg(playerToPlay.GetPlayerID(), "AcceptGameChallenge " + player.GetPlayerName() + " " + gameId);
                                }
                                catch //(Exception e)
                                { MessageBox.Show("Error in AcceptGameChallenge logic"); }
                            }

                            break;
                        }

                    case "QuitGame":
                        // CMD <gameId>
                        {
                            int gameId = Int32.Parse(msgArgs[1]);

                            if (activeGames.ContainsKey(gameId))
                            {
                                // make sure player id member of game first
                                if (activeGames[gameId].PlayerExists(args.Message.SenderID))
                                {
                                    Team playersTeam = activeGames[gameId].getPlayersTeam(args.Message.SenderID);
                                    Team enemyTeam = playersTeam == activeGames[gameId].team1 ? activeGames[gameId].team2 : activeGames[gameId].team1;

                                    bool playersTeamIsTeam1 = playersTeam == activeGames[gameId].team1;
                                    string opponentsTeamNameStr = playersTeamIsTeam1 == true ? "teamB" : "teamA";

                                    foreach (Player player in playersTeam.teamPlayers)
                                        sendGameOverRequest(0, player.GetPlayerID());

                                    // only do this if not in serverMode, otherwise a bug occurs
                                    // in the userWin Lose sending logic
                                    if (!activeGames[gameId].playingServerMode)
                                    {
                                        foreach (Player player in enemyTeam.teamPlayers)
                                            sendGameOverRequest(1, player.GetPlayerID());
                                    }

                                    sendCommandToAllGameViewers(activeGames[gameId], "GameOver " + opponentsTeamNameStr);

                                    broadcastSendMessage("RemoveGame " + gameId);

                                    Invoke((Action<int>)delegate(int GameId)
                                    {
                                        try
                                        {
                                            lstActiveGames.Items.Remove(GameId);
                                        }
                                        catch (Exception) { }

                                    }, gameId);

                                    activeGames[gameId].clearViewers();

                                    activeGames.Remove(gameId);
                                }
                            }

                            break;

                        }
                    case "ShotFired":
                        {
                            // CMD <gameId> <coordinate>

                            int gameId = Int32.Parse(msgArgs[1]);

                            // check specified game exists first
                            if (activeGames.ContainsKey(gameId))
                            {
                                // make sure player id member of game first
                                if (activeGames[gameId].PlayerExists(args.Message.SenderID))
                                {
                                    Team playersTeam = activeGames[gameId].getPlayersTeam(args.Message.SenderID);
                                    Team enemyTeam = playersTeam == activeGames[gameId].team1 ? activeGames[gameId].team2 : activeGames[gameId].team1;

                                    if (playersTeam != null)
                                    {
                                        string[] coordArgs = msgArgs[2].Split(',');

                                        Point coord = new Point(Int32.Parse(coordArgs[0]), Int32.Parse(coordArgs[1]));
                                        EnumBattleGridSquare? squareState = playersTeam.teamBattleGrid.FireShot(coord);

                                        if (!squareState.HasValue) return;

                                        playersTeam.teamBattleGrid.shotFired((squareState.Value == EnumBattleGridSquare.ShipHit ? true : false), coord);

                                        //if(!activeGames[gameId].playingServerMode)
                                        //sendUserFireRequestAcked(connectedPlayers., (squareState.Value == EnumBattleGridSquare.ShipHit ? true : false), coord);

                                        bool enemyShipHit = squareState.Value == EnumBattleGridSquare.ShipHit ? true : false;

                                        foreach (Player player in playersTeam.teamPlayers)
                                            sendUserFireRequestAcked(player.GetPlayerID(), enemyShipHit, coord);

                                        BattleGrid ourbattleGrid = activeGames[gameId].team2.teamBattleGrid;

                                        Point? ServerMove = null;
                                        bool shipHit = false;
                                        if (activeGames[gameId].playingServerMode == true)
                                        {
                                            ServerMove = ourbattleGrid.AutoGenerateMove();

                                            if (!ServerMove.HasValue) return;

                                            shipHit = ourbattleGrid.FireShot(ServerMove.Value).Value == EnumBattleGridSquare.ShipHit ? true : false;
                                            ourbattleGrid.shotFired(shipHit, ServerMove.Value);

                                            // inform client of server move made and result
                                            sendOpponentsMove(shipHit, ServerMove.Value, args.Message.SenderID);
                                        }
                                        else
                                        {
                                            foreach (Player player in enemyTeam.teamPlayers)
                                                sendOpponentsMove(enemyShipHit, coord, player.GetPlayerID());
                                        }

                                        bool playersTeamIsTeam1 = playersTeam == activeGames[gameId].team1;

                                        foreach (Player viewingPlayers in activeGames[gameId].Viewers)
                                        {
                                            if (playersTeamIsTeam1)
                                                sendUserFireRequestAcked(viewingPlayers.GetPlayerID(), enemyShipHit, coord);
                                            else
                                                sendOpponentsMove(enemyShipHit, coord, viewingPlayers.GetPlayerID());

                                            if (activeGames[gameId].playingServerMode)
                                                sendOpponentsMove(shipHit, ServerMove.Value, viewingPlayers.GetPlayerID());
                                        }

                                        bool gameOver = false;

                                        string teamNameStr = playersTeamIsTeam1 == true ? "teamA" : "teamB";

                                        if (playersTeam.teamFleet.IsDestroyed())
                                        {
                                            gameOver = true;

                                            foreach (Player player in enemyTeam.teamPlayers)
                                                sendGameOverRequest(0, player.GetPlayerID());

                                            sendCommandToAllGameViewers(activeGames[gameId], "GameOver " + "teamB");

                                            //    foreach (Player player in playersTeam.teamPlayers)
                                            //      sendGameOverRequest(1, player.GetPlayerID());
                                        }
                                        else if (enemyTeam.teamFleet.IsDestroyed())
                                        {
                                            gameOver = true;

                                            foreach (Player player in playersTeam.teamPlayers)
                                                sendGameOverRequest(1, player.GetPlayerID());

                                            // only do this if not in serverMode, otherwise a bug occurs
                                            // in the userWin Lose sending logic
                                            if (!activeGames[gameId].playingServerMode)
                                            {
                                                foreach (Player player in enemyTeam.teamPlayers)
                                                    sendGameOverRequest(0, player.GetPlayerID());
                                            }

                                            sendCommandToAllGameViewers(activeGames[gameId], "GameOver " + teamNameStr);

                                            // user challenges winner logic code
                                            if(activeGames[gameId].challengerChallengesWinner)
                                            {
                                                string playerName=activeGames[gameId].PlayerThatChallengesWinner.GetPlayerName();
                                                // check player is still connected to server
                                                if (connectedPlayers.ContainsKey(playerName))
                                                {
                                                    // send command asking winner user to accept challenge
                                                    //sendIndividualMsg(connectedPlayers[playerName].GetPlayerID(),"InviteToPlayGame " + playerName);
                                                    sendIndividualMsg(args.Message.SenderID, "InviteToPlayGame " + playerName);
                                                }

                                             }
                                        }

                                        //if (CurrentGameBeingViewed != 0)
                                        //{
                                        //    if (activeGames.ContainsKey(gameId))
                                        //    {
                                        //        // make sure the game Id is actually
                                        //        // the one selected as being viewed
                                        //        if (CurrentGameBeingViewed == gameId)
                                        //        {
                                        //            //team2PicBattleGrid.Invalidate();
                                        //            //team1PicBattleGrid.Invalidate();
                                        //        }
                                        //    }
                                        //}

                                        if (gameOver)
                                        {
                                            broadcastSendMessage("RemoveGame " + gameId);

                                            Invoke((Action<int>)delegate(int GameId)
                                            {
                                                try
                                                {
                                                    lstActiveGames.Items.Remove(GameId);
                                                }
                                                catch (Exception) { }

                                            }, gameId);

                                            activeGames[gameId].clearViewers();

                                            activeGames.Remove(gameId);
                                        }
                                    }

                                }

                            }
                            break;
                        }
                    case "Login":
                        {
                            // LOGIN username pass

                            if (msgArgs.Length != 3)
                            {
                                sendLoginRequestAcknowledgement(0, args.Message.SenderID);
                                return;
                            }

                            string username = msgArgs[1];
                            string pass = msgArgs[2];

                            if (!authenticateUser(username, pass))
                            {
                                sendLoginRequestAcknowledgement(0, args.Message.SenderID);
                                return;
                            }

                            if (((int)frmBanUsersList.profilesTableAdapterOb.CheckIfUserBanned(username)) > 0)
                            {
                                sendBanUserPacket(args.Message.SenderID);
                                return;
                            }

                            // is he already logged in ?
                            if (isUserLoggedIn(username))
                            {
                                sendLoginRequestAcknowledgement(-1, args.Message.SenderID);
                                return;
                            }

                            // login successfull message
                            sendLoginRequestAcknowledgement(1, args.Message.SenderID);
                            Player player = new Player();
                            player.SetPlayerName(username);
                            player.SetPlayerID(args.Message.SenderID);
                            connectedPlayers.Add(username, player);

                            // send list of players connected
                            sendPlayersConnected(args.Message.SenderID);
                            sendActiveGames(args.Message.SenderID);

                            // broadcast new user connected message
                            sendNewUserConnected(username);

                            // we must check if it already exists because if it does
                            // and we dont remove it and use it, the remoteClientId will
                            // not be consistent
                            if (!frmUserMsgCollection.ContainsKey(username))
                                frmUserMsgCollection.Remove(username);

                            frmUserMsgCollection.Add(username, new frmUserMessage(args.Message.SenderID, m_Server, username));

                            Invoke((Action<string[]>)delegate(string[] msgArgss)
                            {
                                try
                                {
                                    this.lst_Users.Items.Add(msgArgss[1]);
                                }
                                catch (Exception)
                                { }

                            }, new object[] { msgArgs });


                            break;
                        }
                    case "Logout":
                        {

                            Player fromUser = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                            if (fromUser == null) return;

                            if (activeGames.Count > 0)
                            {
                                int gameIdToRemove = 0;
                                bool playerPartOfGame = false;

                                foreach (Game tmpGame in activeGames.Values)
                                {
                                    if (tmpGame.PlayerExists(args.Message.SenderID))
                                    {
                                        Invoke((Action<int>)delegate(int tmpCurrentGameId)
                                        {
                                            lstActiveGames.Items.Remove(tmpCurrentGameId);
                                            //lst_Users.Items.Remove(playername);
                                        }, tmpGame.gameId);

                                        tmpGame.getPlayersTeam(args.Message.SenderID).RemovePlayer(fromUser);
                                        playerPartOfGame = true;
                                        gameIdToRemove = tmpGame.gameId;

                                    }

                                    if (tmpGame.viewerExists(fromUser))
                                        tmpGame.removeViewer(fromUser);
                                }

                                if (playerPartOfGame)
                                    activeGames.Remove(gameIdToRemove);

                                broadcastSendMessage("RemoveGame " + gameIdToRemove);
                            }

                            broadcastSendMessage("UserLeft " + fromUser.GetPlayerName());

                            Invoke((Action<string>)delegate(string playername)
                            {
                                lst_Users.Items.Remove(playername);
                            }, fromUser.GetPlayerName());

                            connectedPlayers.Remove(fromUser.GetPlayerName());
                            frmUserMsgCollection.Remove(fromUser.GetPlayerName());

                            //broadcastSendMessage("UserLeft "+fromUser.GetPlayerName());

                            break;
                        }

                    case "RegisterUser":
                        {

                            string msgBody = String.Join(" ", msgArgs);
                            msgBody = msgBody.Substring(13);

                            string[] msgBodyFields = msgBody.Split('#');

                            ProfileInfo registerNewAcctInfo = new ProfileInfo(msgBodyFields[5], Int32.Parse(msgBodyFields[4]), msgBodyFields[1], msgBodyFields[2], msgBodyFields[0], msgBodyFields[3]);

                            if (((int)frmBanUsersList.profilesTableAdapterOb.CheckUserExists(registerNewAcctInfo.Username)) > 0)
                                sendRegisterNewAccountAck(0, args.Message.SenderID);
                            else
                            {
                                frmBanUsersList.profilesTableAdapterOb.CreateNewUserAccount(registerNewAcctInfo.Username, registerNewAcctInfo.Password, registerNewAcctInfo.Firstname, registerNewAcctInfo.Surname, registerNewAcctInfo.Description, registerNewAcctInfo.Age);

                                sendRegisterNewAccountAck(1, args.Message.SenderID);
                            }

                            break;
                        }

                    case "TeamFleet":
                        {

                            Fleet requestedFleet = null;

                            int teamsGameId = Int32.Parse(msgArgs[1]);

                            try
                            {
                                if (activeGames[teamsGameId].team1 == activeGames[teamsGameId].getPlayersTeam(args.Message.SenderID))
                                    requestedFleet = activeGames[teamsGameId].team1.teamFleet;
                                else if (activeGames[teamsGameId].team2 == activeGames[teamsGameId].getPlayersTeam(args.Message.SenderID))
                                    requestedFleet = activeGames[teamsGameId].team2.teamFleet;

                            }
                            catch (Exception e)
                            {
                                //MessageBox.Show("Exception during teamfleet command");
                                return;
                            }

                            byte[] bytes;
                            int length = 0;

                            using (MemoryStream ws = new MemoryStream())
                            {
                                DataContractSerializer formatter = new DataContractSerializer(typeof(Fleet));

                                formatter.WriteObject(ws, requestedFleet);
                                length = (int)ws.Length;

                                bytes = ws.ToArray();

                                string data = System.Text.Encoding.UTF8.GetString(bytes);

                                sendIndividualMsg(args.Message.SenderID, "TeamFleet " + data);
                            }

                            sendTeamPlayersCommand(activeGames[teamsGameId].team1, "team1", activeGames[teamsGameId].team1.teamPlayers, teamsGameId);
                            sendTeamPlayersCommand(activeGames[teamsGameId].team1, "team2", activeGames[teamsGameId].team2.teamPlayers, teamsGameId);
                            sendTeamPlayersCommand(activeGames[teamsGameId].team2, "team1", activeGames[teamsGameId].team1.teamPlayers, teamsGameId);
                            sendTeamPlayersCommand(activeGames[teamsGameId].team2, "team2", activeGames[teamsGameId].team2.teamPlayers, teamsGameId);

                            break;
                        }

                    case "ViewGameFleet":
                        {

                            int gamesId = Int32.Parse(msgArgs[1]);

                            Fleet team1Fleet, team2Fleet;

                            if (!activeGames.ContainsKey(gamesId))
                                return;

                            team1Fleet = activeGames[gamesId].team1.teamFleet;
                            team2Fleet = activeGames[gamesId].team2.teamFleet;

                            byte[] bytesTeam1Fleet, bytesTeam2Fleet;

                            MemoryStream team1FleetStream = new MemoryStream();
                            MemoryStream team2FleetStream = new MemoryStream();

                            DataContractSerializer formatterTeam1Fleet = new DataContractSerializer(typeof(Fleet));
                            DataContractSerializer formatterTeam2Fleet = new DataContractSerializer(typeof(Fleet));

                            formatterTeam1Fleet.WriteObject(team1FleetStream, team1Fleet);
                            formatterTeam2Fleet.WriteObject(team2FleetStream, team2Fleet);

                            bytesTeam1Fleet = team1FleetStream.ToArray();
                            bytesTeam2Fleet = team2FleetStream.ToArray();

                            string serialisedData = System.Text.Encoding.UTF8.GetString(bytesTeam1Fleet) + "####" + System.Text.Encoding.UTF8.GetString(bytesTeam2Fleet);

                            sendIndividualMsg(args.Message.SenderID, "ViewGameFleet " + serialisedData);

                            removePlayerFromAllGamesViewingLists(args.Message.SenderID);

                            Player tmppPlayer = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);

                            if (!activeGames[gamesId].viewerExists(tmppPlayer))
                                activeGames[gamesId].addViewingUser(tmppPlayer);

                            break;
                        }

                    case "ViewGrids":
                        {

                            int gamessId = Int32.Parse(msgArgs[1]);

                            BattleGrid team1Grid, team2Grid;

                            if (!activeGames.ContainsKey(gamessId))
                                return;

                            team1Grid = activeGames[gamessId].team1.teamBattleGrid;
                            team2Grid = activeGames[gamessId].team2.teamBattleGrid;

                            byte[] bytesTeam1Grid, bytesTeam2Grid;

                            MemoryStream team1GridStream = new MemoryStream();
                            MemoryStream team2GridStream = new MemoryStream();

                            SoapFormatter formatterTeam1Grid = new SoapFormatter();
                            SoapFormatter formatterTeam2Grid = new SoapFormatter();

                            formatterTeam1Grid.Serialize(team1GridStream, team1Grid);
                            formatterTeam2Grid.Serialize(team2GridStream, team2Grid);

                            bytesTeam1Grid = team1GridStream.ToArray();
                            bytesTeam2Grid = team2GridStream.ToArray();

                            string serialisedDataa = System.Text.Encoding.UTF8.GetString(bytesTeam1Grid) + "####" + System.Text.Encoding.UTF8.GetString(bytesTeam2Grid);

                            sendIndividualMsg(args.Message.SenderID, "ViewGrids " + serialisedDataa);

                            Player tmppPlayer = getConnectedPlayerByClientId(args.Message.SenderID, connectedPlayers);
                            Game game = activeGames[gamessId];

                            foreach (Game tmpGame in activeGames.Values)
                            {
                                if (game != tmpGame)
                                    if (tmpGame.viewerExists(tmppPlayer))
                                        tmpGame.removeViewer(tmppPlayer);
                            }

                            if (!game.viewerExists(tmppPlayer))
                                activeGames[gamessId].addViewingUser(tmppPlayer);

                            sendTeamPlayersCommand(args.Message.SenderID, "team1", activeGames[gamessId].team1.teamPlayers, gamessId);
                            sendTeamPlayersCommand(args.Message.SenderID, "team2", activeGames[gamessId].team2.teamPlayers, gamessId);

                            break;
                        }
                }
            }
        }

        private Team getOppositeTeam(Team playersTeam, Game game)
        {
            return playersTeam == game.team1 ? game.team2 : game.team1;
        }

        private string TeamStr(Team team, Game game)
        {
            bool playersTeamIsTeam1 = getOppositeTeam(team, game) == game.team1;
            string teamNameStr = playersTeamIsTeam1 == true ? "teamA" : "teamB";
            return teamNameStr;
        }

        private void sendTeamPlayersCommand(Team teamToSendTo, string teamName, List<Player> teamPlayers, int gameId)
        {
            foreach (Player player in teamToSendTo.teamPlayers)
            {
                sendTeamPlayersCommand(player.GetPlayerID(), teamName, teamPlayers, gameId);

            }
        }

        private void sendTeamPlayersCommand(int clientId, string teamName, List<Player> teamPlayers, int gameId)
        {
            byte[] bytesTeamPlayers;

            using(MemoryStream teamPlayersStream = new MemoryStream())
            {
                DataContractSerializer formatterTeamPlayers = new DataContractSerializer(typeof(List<Player>));

                formatterTeamPlayers.WriteObject(teamPlayersStream, teamPlayers);
                bytesTeamPlayers = teamPlayersStream.ToArray();

                string serialisedDataa = System.Text.Encoding.UTF8.GetString(bytesTeamPlayers);

                sendIndividualMsg(clientId, "TeamPlayers " + gameId + " " + teamName + " " + serialisedDataa);
                teamPlayersStream.Close();
            }
        }

        private void sendCommandToAllGameViewers(Game game, string msg)
        {
            foreach (Player viewingPlayers in game.Viewers)
                sendIndividualMsg(viewingPlayers.GetPlayerID(), msg);
        }

        private void sendCommandToAllTeamPlayers(Team team, string msg)
        {
            foreach(Player player in team.teamPlayers)
                sendIndividualMsg(player.GetPlayerID(), msg);
        }

        private void removePlayerFromAllGamesViewingLists(int senderId)
        {
            try
            {
                foreach (Game game in getGamesUserIsViewing(senderId))
                    game.removeViewer(game.getViewerById(senderId));
            }
            catch (Exception e)
            {
                MessageBox.Show("removePlayerFromAllGamesViewingLists() failed");
            }
        }

        private void removePlayerFromAnyActiveGames(int playerId)
        {
            try
            {
                foreach (Game game in getGamesUserIsPartOf(playerId))
                {
                    Team playersTeam = game.getPlayersTeam(playerId);
                    playersTeam.RemovePlayer(playersTeam.GetPlayerByPlayerId(playerId));

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception in removePlayerFromActiveGames()");
            }
        }

        private List<Game> getGamesUserIsPartOf(int senderId)
        {
            List<Game> listGames = new List<Game>();

            foreach (Game game in activeGames.Values)
                if (game.PlayerExists(senderId))
                    listGames.Add(game);

            return listGames;
        }

        private List<Game> getGamesUserIsViewing(int senderId)
        {
            List<Game> listGames= new List<Game>();

            Player user= getConnectedPlayerByClientId(senderId, connectedPlayers);

            foreach (Game game in activeGames.Values)
                if (game.viewerExists(user))
                    listGames.Add(game);

            return listGames;
        }

        private void sendGameOverRequest(int ackNo, int clientId)
        {
            sendIndividualMsg(clientId, "GameOver " + ackNo);
        }

        // <CMD> <$> <x,y> <shipHit?>
        private void sendOpponentsMove(bool shipHit, Point coord, int clientId)
        {
            sendIndividualMsg(clientId, "ShotFired " + "$ " + coord.X + "," + coord.Y + " " + (shipHit == true ? "1" : "0"));
        }

        private void sendUserFireRequestAcked(int clientId, bool shipHit, Point coord)
        {
            sendIndividualMsg(clientId, "ShotFired " + "# " + coord.X + "," + coord.Y + " " + (shipHit == true ? "1" : "0"));
        }

        private Player getConnectedPlayerByClientId(int clientId, Dictionary<string, Player> connectedPlayers)
        {
            //MessageBox.Show("" + clientId + " " + connectedPlayers["Ronan"].GetPlayerID());

            foreach(KeyValuePair<string, Player> player in connectedPlayers)
                if(player.Value.GetPlayerID()==clientId)
                    return player.Value ;

            return null;
        }

        private void sendPrivateChatMessage(int clientIdTo, string userFrom, string message)
        {
            sendIndividualMsg(clientIdTo, "PrivChatMsg " + userFrom + " #" + message);
        }

        private void sendLoginRequestAcknowledgement(int ackNo, int playerId)
        {
            sendIndividualMsg(playerId, "Login " + ackNo);
        }

        private void sendRegisterNewAccountAck(int ackNo, int playerId)
        {
            sendIndividualMsg(playerId, "RegisterUser " + ackNo);
        }

        private void sendBroadcastChatMsg(string fromUser, string chatMsg)
        {
            broadcastSendMessage("BroadcastChatMsg " + fromUser + " #" + chatMsg);

            Invoke((Action<string>)delegate
            {
                txtBroadcastMessageConvo.Text += "<" + fromUser + ">" + chatMsg + "\r\n";
            }, chatMsg);
        }

        private void sendNewUserConnected(string user)
        {
            broadcastSendMessage("NewUserConnected " + user);
        }

        private void sendNewGameAdded(string gameName)
        {
            broadcastSendMessage("NewGameAdded " + gameName);
        }

        private void sendUserQuit(string user)
        {
            broadcastSendMessage("UserLeft " + user);
        }

        private void sendActiveGames(int playerId)
        {
            // no active games, no need to send a games listing
            if (this.activeGames.Count == 0)
                return;

            string strActiveGamesListing = null;

            foreach (Game game in this.activeGames.Values)
                strActiveGamesListing += " " + game.gameId;

            sendIndividualMsg(playerId, "GamesListing" + strActiveGamesListing);
        }

        private void sendPlayersConnected(int playerId)
        {
            // no players connected, no need to send a player listing
            if (connectedPlayers.Count == 0)
                return;

            string strPlayersListing=null;

            foreach (Player player in connectedPlayers.Values)
                strPlayersListing += " " + player.GetPlayerName();

            sendIndividualMsg(playerId, "UsersListing" + strPlayersListing);
        }

        // check if user already logged in
        private bool isUserLoggedIn(string username)
        {
            if (connectedPlayers.ContainsKey(username))
                return true;

            return false;
        }

        private bool authenticateUser(string user, string pass)
        {
            return ((int)frmBanUsersList.profilesTableAdapterOb.AttemptLogin(user, pass)) > 0;
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
            sendBroadcastChatMsg("Server", txtBroadcastMessageSend.Text);

            txtBroadcastMessageSend.Text = "";
        }

        // send broadcast to all clients connected
        private void broadcastSendMessage(string msg)
        {
            using (NetworkPacket packet = new NetworkPacket())
            {
                packet.Write(msg);

                /*Now that the outgoing text message has been encoded to a network packet, the DirectPlay method can be called. You must tell DirectPlay which Client you wish to receive the data; 
                for this sample, we'll deliver the message to all connected players (with the exception of the local player, which we exclued with the NoLoopBack flag)*/

                Microsoft.DirectX.DirectPlay.SendFlags flags;
                flags = SendFlags.Sync | SendFlags.NoLoopback;
                //Sync denotes send the message synchronously; NoLoopBack means the sender doesn't receive the message as well

                try
                {
                    m_Server.SendTo((int)PlayerID.AllPlayers,
                            packet, //the outgoing message
                            0, //Timeout (default)
                            flags);//The flags 
                }
                catch (Exception e)
                { MessageBox.Show(e.Message); }
            }
        }

        //private void team1PicBattleGrid_Paint(object sender, PaintEventArgs e)
        //{
        //    if (CurrentGameBeingViewed!=0)
        //        if (activeGames.ContainsKey(CurrentGameBeingViewed))
        //            e.Graphics.DrawImage(activeGames[CurrentGameBeingViewed].team1.teamBattleGrid.gridBmapImage, 0, 0,activeGames[CurrentGameBeingViewed].team1.teamBattleGrid.gridBmapImage.Width, activeGames[CurrentGameBeingViewed].team1.teamBattleGrid.gridBmapImage.Height);
        //}

        //private void team2PicBattleGrid_Paint(object sender, PaintEventArgs e)
        //{
        //    if (CurrentGameBeingViewed != 0)
        //        if(activeGames.ContainsKey(CurrentGameBeingViewed))
        //            e.Graphics.DrawImage(activeGames[CurrentGameBeingViewed].team2.teamBattleGrid.gridBmapImage, 0, 0, activeGames[CurrentGameBeingViewed].team2.teamBattleGrid.gridBmapImage.Width, activeGames[CurrentGameBeingViewed].team2.teamBattleGrid.gridBmapImage.Height);
        //}

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanUsersList.button1_Click(this, null);
            frmBanUsersList.Show();
        }

        private void lst_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnBanUser.Enabled=this.btnChatToUser.Enabled =this.btn_ViewUserInfo.Enabled= (this.lst_Users.SelectedIndex != -1);
            // = (this.lst_Users.SelectedIndex != -1);
        }

        private void searchByUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playerInfoSearchFrm.ShowDialog();
        }

        // send a message to individual client

        private void sendIndividualMsg(int clientId, string msg)
        {
            try
            {
                using (NetworkPacket packet = new NetworkPacket())
                {

                    packet.Write(msg);

                    Microsoft.DirectX.DirectPlay.SendFlags flags;
                    flags = SendFlags.NoLoopback | SendFlags.Sync;

                    m_Server.SendTo(clientId,
                          packet,	//the outgoing message
                          0,			//Timeout (default)
                          flags);		//The flags 
                }
            }
            catch (Exception e){
                //MessageBox.Show(e.Message);
            }
        }

        private void btn_ViewUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string username = lst_Users.Items[lst_Users.SelectedIndex].ToString();
                playerInfoSearchFrm.retrieveUserInfo(username);
                playerInfoSearchFrm.DirectPlayClientIdSet = "" + connectedPlayers[username].GetPlayerID();
                playerInfoSearchFrm.ShowDialog();
            }
            catch (Exception)
            { }
        }

        private void btnBanUser_Click(object sender, EventArgs e)
        {
            string selectedUser=lst_Users.Items[lst_Users.SelectedIndex].ToString();
            frmBanUsersList.BanUser(selectedUser);
            try
            {
                sendBanUserPacket(connectedPlayers[selectedUser].GetPlayerID());
                connectedPlayers.Remove(selectedUser);
                frmUserMsgCollection.Remove(selectedUser);
                lst_Users.Items.Remove(selectedUser);
                broadcastSendMessage("UserLeft " + selectedUser);
                MessageBox.Show("User successfully banned");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ban user error");
            }
        }

        private void mnu_opt_Close_Session_Click(object sender, EventArgs e)
        {
            broadcastSendMessage("ServerGoingOffline");
            //m_Server.Dispose();
            Disconnect();
            //this.InitDirectPlay();
        }

        private void btnChatToUser_Click(object sender, EventArgs e)
        {
            this.frmUserMsgCollection[this.lst_Users.SelectedItem.ToString()].Show();
        }

        private void sendBanUserPacket(int clientId)
        {
            sendIndividualMsg(clientId, "PlayerBanned");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.txtUser_count.Text="" +connectedPlayers.Count;
            this.toolStripStatusLabel1.Text = "Connect client count: " + connectedPlayers.Count;
        }

        private void restartSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mnu_opt_Close_Session_Click(this, null);
            mnu_opt_Create_Session_Click(this, null);
        }

        private void lstActiveGames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}