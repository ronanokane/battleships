using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BattleShipsServer
{
    [Serializable]
    public class Game
    {
        private Team Team1;
        private Team Team2;
        private bool againstServerMode;
        private int maxPlayersAllowed;
        private Team WinnerTeam;
        private int GameId;

        private List<Player> ViewersCollection = new List<Player>();

        // needed for challenging winner, accepting challenger
        private Player playerThatChallengesWinner;
        private bool winnerAcceptsChallenger, playerChallengesWinner;

        public Game(Team team1, Team team2, int maxPlayersAllowed, bool againstServerMode)
        {
            Team1 = team1;
            Team2 = team2;
            this.maxPlayersAllowed = maxPlayersAllowed;
            this.againstServerMode=againstServerMode;
            GameId = GetHashCode();
        }

        // unsafe, because we dont wanna be able to add same viewer twice
        // taken out but put back in because too much code refacturing required
        // to make change
        public List<Player> Viewers
        {
            get { return ViewersCollection; }
        }

        public Team team1
        {
            get
            {
                return Team1;
            }
        }

        public Team team2
        {
            get
            {
                return Team2;
            }
        }

        public Player PlayerThatChallengesWinner
        {
            get
            {
                return playerThatChallengesWinner;
            }
        }

        public bool challengerChallengesWinner
        {
            get
            {
                return playerChallengesWinner;
            }
        }

        public bool winnerAcceptsChallengerChallenge
        {
            get
            {
                return winnerAcceptsChallenger;
            }
        }

        public void SetUserChallengesWinner(Player playerChallenger)
        {
            playerThatChallengesWinner = playerChallenger;
            playerChallengesWinner = true;
        }

        public void SetWinnerAcceptChallenger()
        {
            winnerAcceptsChallenger = true;
        }

        public Team getTeamWon()
        {
            if (Team1.teamFleet.IsDestroyed())
                return Team1;
            else if (Team2.teamFleet.IsDestroyed())
                return Team2;

            return null; // no winner ?
        }

        // use this to determine if the user is already connected
        // some team, useage of this is to help ensure a player is
        // not allowed to join 2 seperate teams and cheat !
        public bool PlayerExists(int playerId)
        {
            foreach(Player player in Team1.teamPlayers)
            {
                if(player.GetPlayerID() == playerId)
                    return true;
            }

            foreach(Player player in Team2.teamPlayers)
            {
                if (player.GetPlayerID() == playerId)
                    return true;
            }

            return false;
        }

        public Player getViewerById(int playerId)
        {
            foreach (Player player in ViewersCollection)
                if (player.GetPlayerID() == playerId)
                    return player;

            return null;
        }

        // added this to ensure same playerId dont get added twice to viwers collection
        public void addViewingUser(Player player)
        {
            if (!ViewersCollection.Contains(player))
                ViewersCollection.Add(player);
        }

        public void removeViewer(Player viewer)
        {
            ViewersCollection.Remove(viewer);
        }

        public void clearViewers()
        {
            ViewersCollection.Clear();
        }

        public bool viewerExists(Player player)
        {
            return ViewersCollection.Contains(player);
        }

        // get the team object the particular playerId is associated with
        public Team getPlayersTeam(int playerId)
        {
            foreach (Player player in Team1.teamPlayers)
            {
                if (player.GetPlayerID() == playerId)
                    return Team1;
            }

            foreach (Player player in Team2.teamPlayers)
            {
                if (player.GetPlayerID() == playerId)
                    return Team2;
            }

            return null;
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public bool playingServerMode
        {
            set
            {
                againstServerMode = value;
            }
            get
            {
                return againstServerMode;
            }
        }

        public int gameId
        {
            get
            {
                return GameId;
            }
        }

        public void setNewGameId(int gameId)
        {
            GameId = gameId;
        }
    }
}
