using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{

    public class GameState
    {
        public Board HumanPlayerBoard = new Board();
        public Board ComputerPlayerBoard = new Board();

        public bool IsGameOver;

        public void Initialize()
        {

        }
    }
}
