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

        public Orientations Orientation;
        public enum Orientations
        {
            Horizontal,
            Vertical
        }

        public Ship()
        {
            Orientation = Orientations.Horizontal;
        }
    }
}
