using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public struct Input
    {
        public char Row;
        public char Column;
    };

    public class Player
    {
        public string Name { get; set; }
        public bool IsCurrentTurn;
        public bool IsWinner;
        public Input Input;

        public Player()
        {
            Input.Row = ' ';
            Input.Column = ' ';
        }
    }
}
