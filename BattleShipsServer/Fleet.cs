using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;

namespace BattleShipsServer
{
    [Serializable]
    public class Fleet
    {
        private List<Ship> ShipsCollection;

        public List<Ship> Ships
        {
            get
            {
                return ShipsCollection;
            }
        }

        public Fleet(Ship[] ships)
        {
            ShipsCollection = new List<Ship>(ships);
        }

        public void AddShip(Ship ship)
        {
            ShipsCollection.Add(ship);
        }

        // use this to return ship object based on start coordinate so
        // we know which ship it is
        public Ship GetShip(System.Drawing.Point coord)
        {
            foreach (Ship ship in ShipsCollection)
            {
                if (ship.ShipOrientation == EnumShipOrientation.Vertical)
                {
                    if (coord.Y >= ship.StartCoordinate.Y && coord.Y < ship.StartCoordinate.Y + ship.MaxHitsRequired && coord.X == ship.StartCoordinate.X)
                        return ship;
                }
                else
                {
                    if (coord.X >= ship.StartCoordinate.X && coord.X < ship.StartCoordinate.X + ship.MaxHitsRequired && coord.Y==ship.StartCoordinate.Y)
                        return ship;
                }
            }

            return null;
        }

        public void AddShips(Ship [] ships)
        {
            ShipsCollection = new List<Ship>(ships);            
        }

        public bool IsDestroyed()
        {
            foreach (Ship ship in ShipsCollection)
            {
                if (!ship.IsSunk())
                    return false;
            }

            return true;
        }
    }
}
