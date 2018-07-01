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
        public bool IsCurrentTurn { get; set; }
        public bool IsWinner { get; set; }
        public Input Input;
        public Board Board;

        public Player()
        {
            Board = new Board();
            Input.Row = ' ';
            Input.Column = ' ';
        }
    }
}
