using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public class Ship
    {
        public int Size { get; set; }
        public bool IsDestroyed { get; set; }

        enum Orientation
        {
            Horizontal,
            Vertical
        }
    }
}
