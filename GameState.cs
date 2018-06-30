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

        public ComputerPlayer Computer;
        public HumanPlayer Human;

        public bool IsGameOver;
        public bool IsHumanTurn;
        public bool IsInputValid;

        public List<string> HitsLocationsSoFar;

        public StringBuilder GameHistory;

        public GameState()
        {
            HumanPlayerBoard = new Board();
            ComputerPlayerBoard = new Board();

            Computer = new ComputerPlayer();
            Human = new HumanPlayer();

            IsHumanTurn = false; // will be turned to true at the start of game loop
            IsGameOver = false;

            HitsLocationsSoFar = new List<string>();
            GameHistory = new StringBuilder("");
        }

        public void ShowBoards()
        {
            Console.WriteLine($"{Environment.NewLine}\t {Constants.HUMAN_STRING}");
            HumanPlayerBoard.DisplayBoard();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}\t {Constants.COMPUTER_STRING}");
            ComputerPlayerBoard.DisplayBoard();

            Console.WriteLine($"\t{Environment.NewLine}{Environment.NewLine}{Constants.LEGENT_STRING}: {Environment.NewLine}" +
               $"DE: {Constants.DESTROYER_STRING},  BS: {Constants.BATTLESHIP_STRING},  HM: {Constants.HIT_MISSED},  HS: {Constants.HIT_SUCCESSFUL}");
        }


        public bool ValidateInput(Input input)
        {
            bool isInputValid = true;
            isInputValid = HumanPlayerBoard.Rows.Contains(Char.ToUpper(input.Row)) && HumanPlayerBoard.Columns.Contains(input.Column);
            return isInputValid;
        }

        public void Start()
        {
            ShowBoards();
            while (!IsGameOver)
            {
                IsHumanTurn = !IsHumanTurn;
                Human.IsCurrentTurn = IsHumanTurn;
                Computer.IsCurrentTurn = !IsHumanTurn;

                Player currentPlayer = IsHumanTurn ? (Player)Human : (Player)Computer;

                GameHistory.Append("${currentPlayer.Name}: ");

                Console.Write($"{Environment.NewLine} {currentPlayer.Name}: ");

                currentPlayer.Input.Row = Console.ReadKey().KeyChar;
                currentPlayer.Input.Column = Console.ReadKey().KeyChar;

                IsInputValid = ValidateInput(currentPlayer.Input);

                if (!IsInputValid)
                {
                    Console.Write($"{Environment.NewLine} {Constants.INVALID_INPUT}. {Constants.TRY_AGAIN}. {Environment.NewLine} {currentPlayer.Name}: ");

                    currentPlayer.Input.Row = Console.ReadKey().KeyChar;
                    currentPlayer.Input.Column = Console.ReadKey().KeyChar;

                    IsInputValid = ValidateInput(currentPlayer.Input);
                }
            }

        }


    }
}
