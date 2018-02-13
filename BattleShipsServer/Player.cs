using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsServer
{
    [Serializable]
    public class Player
    {
        #region Class data members
        string m_PlayerName; //The name of the player
        int m_PlayerID; //An unique ID (issued by DirectPlay) to identify players
        #endregion

        #region Class methods
        public Player()
        {
        }//End the player constructor

        public void SetPlayerID(int ID)
        {
            this.m_PlayerID = ID;
        }//End SetPlayerID method

        public void SetPlayerName(string name)
        {
            this.m_PlayerName = name;
        }//End SetPlayerName method

        public int GetPlayerID()
        {
            return this.m_PlayerID;
        }//End GetPlayerID method

        public string GetPlayerName()
        {
            return this.m_PlayerName;
        }//End GetPlayerName method

        #endregion
    }
}
