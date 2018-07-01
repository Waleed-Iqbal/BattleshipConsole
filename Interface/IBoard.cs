using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole.Interface
{
    interface IBoard
    {
        void DisplayBoard();
        short NumberOfShips { get; set; }
    }
}
