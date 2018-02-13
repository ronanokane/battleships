using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;

namespace BattleShipsServer
{
    [Serializable]
    public class HostInfo
    {
        #region Class data members
        private Guid GuidInstance;    // Instance Guid for the session
        private Address HostAddress;  // DirectPlay address of host  
        private string SessionName;   // Display name for the session
        #endregion

        #region Class methods
        //Default Constructor 
        public HostInfo()
        {
        }//End default constructor

        //Additional Constructor
        public HostInfo(Guid gu, Address addr, string SessionName)
        {
            this.GuidInstance = gu;
            this.HostAddress = addr;
            this.SessionName = SessionName;
        }//End Non default HostInfo constructor


        /// Used by the system collection class
        public override bool Equals(System.Object obj)
        {
            //Dynamically cast the object passed in to a new object of type HostInfo
            HostInfo node = (HostInfo)obj;
            //use the Guid Equality Operator to determine of the two Guids hold the same value
            return GuidInstance.Equals(node.GuidInstance);
        }//End Equals method

        public override int GetHashCode()
        {
            return GuidInstance.GetHashCode();
        }//End GetHashCode

        //This method takes the data in the HostInfo object and converts it to a string
        public override string ToString()
        {
            if (this.SessionName.Length == 0) //check to see if we have a session at all?
            {
                string displayString = "<unnamed>";
                return displayString;
            }//End if
            else
            {
                string displayString = this.SessionName;
                displayString += " (" + HostAddress.GetComponentString("hostname");
                displayString += ":" + HostAddress.GetComponentInteger("port").ToString() + ")";
                return displayString;
            }//End else

        }//End ToString method


        //Set the data members of the HostInfo object
        public bool SetHostInfoData(Guid gu, Address addr, string SessName)
        {
            try
            {
                this.GuidInstance = gu;
                this.HostAddress = addr;
                this.SessionName = SessName;
                return true;
            }//End try
            catch (Exception)
            {
                return false;
            }//End catch
        }

        public void SetGuid(Guid guidInst)
        {
            GuidInstance = guidInst;
        }

        public void SetAddress(Address addr)
        {
            HostAddress = addr;
        }

        public Address GetAddress()
        {
            return HostAddress;
        }

        public void SetSessionName(string strSessionName)
        {
            SessionName = strSessionName;
        }

        public string GetSessionName()
        {
            return SessionName;
        }

        public Guid GetGuid()
        {
            return GuidInstance;
        }

        #endregion
    }
}
