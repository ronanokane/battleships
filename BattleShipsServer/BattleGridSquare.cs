using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BattleShipsServer
{
    [Serializable]
    public class BattleGridSquare
    {
        private Image imageSquareState;
        private EnumBattleGridSquare squareState;

        private static string shipHitFile="shiphit";
        private static string shipHorizFrontFile="horizShipFront";
        private static string shipHorizBackFile="horizShipBack";
        private static string shipHorizBodyFile="horizShipBody";
        private static string shipVertFrontFile="vertShipFront";
        private static string shipVertBackFile="vertShipBack";
        private static string shipVertBodyFile="vertShipBody";
        private static string waterHitFile="waterhit";

        // default to unhit water state
        public BattleGridSquare()
        {
            squareState = EnumBattleGridSquare.WaterUnhit;
        }

        public EnumBattleGridSquare SquareState
        {
            set
            {
                squareState=value;
            }
            get
            {
                return squareState;
            }
        }

        public void setSquareImage(EnumBattleGridSquare squareState, EnumShipOrientation orientation)
        {
            ; ;
        }
    }
}
