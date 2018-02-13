using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsServer
{
    [Serializable]
    public enum EnumBattleGridSquare
    {
        ShipHit,
        WaterHit,
        WaterUnhit,
        Ship,
    }
}
