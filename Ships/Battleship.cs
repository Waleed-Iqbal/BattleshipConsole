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
        }

        public void Place(char[] rows, char[] columns, string[,] grid)
        {
            base.Place(rows, columns, grid, Constants.PLACE_BATTLESHIP, Constants.LEGEND_BATTLESHIP);
        }
    }
}
