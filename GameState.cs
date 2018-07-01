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

        private void DisplayBoards()
        {
            Console.Write($"{Environment.NewLine}\t {Constants.HUMAN_STRING}");
            Human.Board.DisplayBoard();

            Console.Write($"{Environment.NewLine}{Environment.NewLine}\t {Constants.COMPUTER_STRING}");
            Computer.Board.DisplayBoard();

            Console.WriteLine($"\t{Environment.NewLine}{Environment.NewLine} {Constants.LEGEND_STRING}: {Environment.NewLine} " +
               $"{Constants.LEGEND_DESTROYER}: {Constants.DESTROYER_STRING},  " +
               $"{Constants.LEGEND_BATTLESHIP}: {Constants.BATTLESHIP_STRING},  " +
               $"{Constants.LEGEND_HIT_MISSED}: {Constants.HIT_MISSED},  " +
               $"{Constants.LEGEND_HIT_SUCCESSFUL}: {Constants.HIT_SUCCESSFUL},  " +
               $"{Constants.LEGEND_EMPTY_CELL}: {Constants.EMPTY_CELL_STRING}");
        }


        private void PlaceShips()
        {
            Console.Clear();
            Human.PlaceAllShips();
            Computer.PlaceAllShips();
            Console.Clear();
        }

        public bool ValidateInput(Input input)
        {
            return Human.Board.Rows.Contains(Char.ToUpper(input.Row)) && Computer.Board.Columns.Contains(input.Column);
        }

        public void Start()
        {
            Console.Clear();
            PlaceShips();
            DisplayBoards();
            Player currentPlayer = new Player();

            while (!IsGameOver)
            {
                Console.Clear();
                DisplayBoards();

                IsHumanTurn = true;//!IsHumanTurn;
                Human.IsCurrentTurn = IsHumanTurn;
                Computer.IsCurrentTurn = !IsHumanTurn;

                currentPlayer = Human;//IsHumanTurn ? (Player)Human : (Player)Computer;

                Console.Write($"{Environment.NewLine} {currentPlayer.Name}: ");

                if (IsHumanTurn)
                {
                    IsInputValid = false;
                    while (!IsInputValid)
                    {
                        currentPlayer.Input.Column = Char.ToUpper(Console.ReadKey().KeyChar);
                        currentPlayer.Input.Row = Console.ReadKey().KeyChar;

                        IsInputValid = ValidateInput(currentPlayer.Input);
                        if (!IsInputValid)
                        {
                            Console.Write($"{Environment.NewLine} {Human.Board.Destroyer1.GetInvalidInputText()} {Environment.NewLine} {currentPlayer.Name}: ");
                            continue;
                        }

                        Point aimPoint = new Point();
                        aimPoint.Column = Array.IndexOf(Computer.Board.Columns, currentPlayer.Input.Column);
                        aimPoint.Row = Array.IndexOf(Computer.Board.Rows, currentPlayer.Input.Row);

                        string cellContents = Computer.Board.Grid[aimPoint.Column, aimPoint.Row];

                        if (cellContents == Constants.HIT_MISSED || cellContents == Constants.HIT_SUCCESSFUL)
                        {
                            IsInputValid = false;
                            Console.Write($"{Environment.NewLine} {Human.Board.Destroyer1.GetInvalidInputText()} {Environment.NewLine} {currentPlayer.Name}: ");
                            continue;
                        }
                        else if (cellContents == Constants.LEGEND_EMPTY_CELL)
                        {
                            Computer.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_MISSED;
                            Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_MISSED}");
                        }
                        else if (cellContents == Constants.LEGEND_BATTLESHIP || cellContents == Constants.LEGEND_DESTROYER)
                        {
                            Computer.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_SUCCESSFUL;
                            Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_SUCCESSFUL}");
                            if (cellContents == Constants.LEGEND_BATTLESHIP)
                            {
                                currentPlayer.NumberOfHitsOnBS++;
                                if (currentPlayer.NumberOfHitsOnBS == currentPlayer.Board.Battleship.Size)
                                {
                                    currentPlayer.NumberOfHitsOnBS = 0;
                                    currentPlayer.NumberOfShipsDestroyed++;
                                    Console.WriteLine($" {Constants.BATTLESHIP_STRING} {Constants.ELIMINATED}");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                currentPlayer.NumberOfHitsOnDE++;
                                if (currentPlayer.NumberOfHitsOnDE == currentPlayer.Board.Destroyer1.Size)
                                {
                                    currentPlayer.NumberOfHitsOnDE = 0;
                                    currentPlayer.NumberOfShipsDestroyed++;
                                    Console.WriteLine($" {Constants.DESTROYER_STRING} {Constants.ELIMINATED}");
                                    Console.ReadKey();
                                }
                            }

                            if (currentPlayer.NumberOfShipsDestroyed == currentPlayer.Board.NumberOfShips)
                            {
                                currentPlayer.IsWinner = true;
                                IsGameOver = true;
                                break;
                            }
                        }
                    }
                }
                else // Computer's turn
                {

                }
            }
            if (currentPlayer.IsWinner)
            {
                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine} {currentPlayer.Name} {Constants.WON} !!!");
                Console.ReadKey();
            }
        }
    }
}
