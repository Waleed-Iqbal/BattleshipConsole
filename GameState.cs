using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{

    public class GameState
    {
        public Board HumanPlayerBoard;
        public Board ComputerPlayerBoard;

        public bool IsGameOver;
        public bool IsHumanTurn;

        public StringBuilder GameHistory;

        public GameState()
        {
            HumanPlayerBoard = new Board();
            ComputerPlayerBoard = new Board();
            IsHumanTurn = true;
            IsGameOver = false;
            GameHistory = new StringBuilder("");
        }

        public void ShowBoards () 
        {
            Console.WriteLine($"{Environment.NewLine}\t {Constants.HUMAN_STRING}");
            HumanPlayerBoard.DisplayBoard();

            Console.WriteLine($"{Environment.NewLine}\t {Constants.COMPUTER_STRING}");
            ComputerPlayerBoard.DisplayBoard();
        }


        public void Start()
        {
            ShowBoards();
        }

       
    }
}
