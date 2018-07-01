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
            Legend = Constants.LEGEND_DESTROYER;
            PlacingString = Constants.PLACE_DESTROYER;
            LocationRows = new char[Size];
            LocationColumns = new char[Size];
        }
    }
}
