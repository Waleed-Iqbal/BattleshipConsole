using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Size = 4;
        }

        public void Place(char[] rows, char[] columns, string[,] grid)
        {
            base.Place(rows, columns, grid, Constants.PLACE_DESTROYER, Constants.LEGEND_DESTROYER);
        }
    }
}
