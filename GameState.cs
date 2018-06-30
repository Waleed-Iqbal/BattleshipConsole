using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{

    public class GameState
    {
        //public Board HumanPlayerBoard { get; set; }
        //public Board ComputerPlayerBoard { get; set; }

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
           // Human.Board.PlaceAllShips();
            Human.DisplayBoard();

            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}\t {Constants.COMPUTER_STRING}");
           // Computer.Board.PlaceAllShips();
            Computer.DisplayBoard();

            Console.WriteLine($"\t{Environment.NewLine}{Environment.NewLine}{Constants.LEGENT_STRING}: {Environment.NewLine}" +
               $"DE: {Constants.DESTROYER_STRING},  BS: {Constants.BATTLESHIP_STRING},  HM: {Constants.HIT_MISSED},  HS: {Constants.HIT_SUCCESSFUL}");
        }


        public bool ValidateInput(Input input)
        {
            return Human.Board.Rows.Contains(Char.ToUpper(input.Row)) && Computer.Board.Columns.Contains(input.Column);
        }

        public void Start()
        {
            Console.Clear();
            DisplayBoards();

            //Human.PlaceShips();
            //Computer.PlaceShips();

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
