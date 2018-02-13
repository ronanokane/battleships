using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BattleShipsServer
{
    [Serializable]
    public class Team
    {
        private List<Player> players;
        private Fleet fleet;
        private const int MaxPlayerCount = 6;
        private const int MaxShipCount = 6;
        private BattleGrid battlegrid;
        private string teamName;

        public Team(BattleGrid bttlegrid, Fleet fleet)
        {
            battlegrid = bttlegrid;
            this.fleet = fleet;
            players = new List<Player>();
        }

        public void SendMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        public void AddPlayer(Player TeamMember)
        {
            if (players.Count >= MaxPlayerCount)
                throw new Exception("Max player count reached");

            players.Add(TeamMember);
        }

        public void RemovePlayer(Player player)
        {
            if (players.Count == 0)
                throw new Exception("cannot remove a empty players collection");

            players.Remove(player);
        }

        public Player GetPlayerByPlayerId(int playerId)
        {
            foreach (Player player in players)
                if (player.GetPlayerID() == playerId)
                    return player;

            return null;
        }

        public Fleet teamFleet
        {
            get
            {
                return fleet;
            }
            set
            {
                fleet = value;
            }
        }

        public BattleGrid teamBattleGrid
        {
            get
            {
                return battlegrid;
            }
            set
            {
                battlegrid = value;
            }
        }

        public void setTeamName(string teamName)
        {
            this.teamName = teamName;
        }

        public string getTeamName()
        {
            return teamName;
        }

        public List<Player> teamPlayers
        {
            get
            {
                return players;
            }
            set
            {
            }
        }

    }
}
