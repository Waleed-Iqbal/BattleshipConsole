using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{

    public class GameState
    {
        public ComputerPlayer Computer { get; set; }
        public HumanPlayer Human { get; set; }

        public bool IsGameOver { get; set; }
        public bool IsHumanTurn { get; set; }
        public bool IsInputValid { get; set; }
        public bool IsShipPlacementComplete { get; set; }

        public GameState()
        {
            Computer = new ComputerPlayer();
            Human = new HumanPlayer();

            IsHumanTurn = false; // will be turned to true at the start of game loop
            IsGameOver = false;
            IsShipPlacementComplete = false;

        }

        public void DisplayBoards()
        {
            Console.WriteLine($"{Environment.NewLine}\t {Constants.HUMAN_STRING}");
            Human.Board.DisplayBoard();
            Human.PlaceAllShips();
            Human.Board.DisplayBoard();

            Console.Clear();
            
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}\t {Constants.COMPUTER_STRING}");
            Computer.Board.DisplayBoard();
            Computer.PlaceAllShips();
            Computer.Board.DisplayBoard();

            Console.WriteLine($"\t{Environment.NewLine}{Environment.NewLine} {Constants.LEGEND_STRING}: {Environment.NewLine} " +
               $"{Constants.LEGEND_DESTROYER}: {Constants.DESTROYER_STRING},  " +
               $"{Constants.LEGEND_BATTLESHIP}: {Constants.BATTLESHIP_STRING},  " +
               $"{Constants.LEGEND_HIT_MISSED}: {Constants.HIT_MISSED},  " +
               $"{Constants.LEGEND_HIT_SUCCESSFUL}: {Constants.HIT_SUCCESSFUL}");
        }


        public bool ValidateInput(Input input)
        {
            return Human.Board.Rows.Contains(Char.ToUpper(input.Row)) && Computer.Board.Columns.Contains(input.Column);
        }

        public void Start()
        {
            Console.Clear();
            DisplayBoards();

            while (!IsGameOver)
            {
                IsHumanTurn = !IsHumanTurn;
                Human.IsCurrentTurn = IsHumanTurn;
                Computer.IsCurrentTurn = !IsHumanTurn;

                Player currentPlayer = new Player();
                currentPlayer = IsHumanTurn ? (Player)Human : (Player)Computer;

                Console.Write($"{Environment.NewLine} {currentPlayer.Name}: ");

                currentPlayer.Input.Row = Console.ReadKey().KeyChar;
                currentPlayer.Input.Column = Console.ReadKey().KeyChar;

                IsInputValid = ValidateInput(currentPlayer.Input);

                if (!IsInputValid)
                {
                    Console.Write($"{Environment.NewLine} {Human.Board.Destroyer1.GetInvalidInputText()} {Environment.NewLine} {currentPlayer.Name}: ");

                    currentPlayer.Input.Row = Console.ReadKey().KeyChar;
                    currentPlayer.Input.Column = Console.ReadKey().KeyChar;

                    IsInputValid = ValidateInput(currentPlayer.Input);
                }
            }

        }


    }
}
