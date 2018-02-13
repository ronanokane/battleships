using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace BattleShipsServer
{
    [Serializable]
    public class Ship
    {
        private bool isSunk;
        private EnumShipType shipType;
        private EnumShipOrientation shipOrientation;
        private int hitsTaken=0;
        private int maxHitsRequired;
        private System.Drawing.Point startCoord;

        public Ship(EnumShipType shipType)
        {
            // set the ship as its type of ship

            if (shipType == null) throw new Exception("Invalid usage");

            this.shipType = shipType;

            if (shipType == EnumShipType.BattleShip)
                maxHitsRequired = 6;
            else if (shipType == EnumShipType.Cruiser)
                maxHitsRequired = 4;
            else if (shipType == EnumShipType.Submarine)
                maxHitsRequired = 2;
            else if (shipType == EnumShipType.MineSweeper)
                maxHitsRequired = 3;
        }

        public EnumShipType ShipType
        {
            get
            {
                return shipType;
            }
        }

        public EnumShipOrientation ShipOrientation
        {
            get
            {
                return shipOrientation;
            }
            set
            {
                shipOrientation = value;
            }
        }

        public System.Drawing.Point StartCoordinate
        {
            get
            {
                return startCoord;
            }
            set
            {
                startCoord = value;
            }
        }

        public int MaxHitsRequired
        {
            get
            {
                return maxHitsRequired;
            }
        }

        public bool IsSunk()
        {
            return hitsTaken >= maxHitsRequired;
        }

        public void setShipHit()
        {
            hitsTaken++;

            if (hitsTaken >= maxHitsRequired)
                isSunk = true;
        }
    }
}
