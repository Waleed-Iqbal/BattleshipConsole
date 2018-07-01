using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole.Ships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Size = 5;
            Legend = Constants.LEGEND_BATTLESHIP;
            PlacingString = Constants.PLACE_BATTLESHIP;
        }

    }
}
