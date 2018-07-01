using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{

    public class GameState
    {
        public HumanPlayer Human { get; set; }
        public ComputerPlayer Computer { get; set; }

        public bool IsGameOver { get; set; }
        public bool IsHumanTurn { get; set; }
        public bool IsInputValid { get; set; }
        public bool IsShipPlacementComplete { get; set; }

        public GameState()
        {
            Human = new HumanPlayer();
            Computer = new ComputerPlayer();

            IsGameOver = false;
            IsHumanTurn = false; // will be turned to true at the start of game loop
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

                IsHumanTurn = !IsHumanTurn;
                Human.IsCurrentTurn = IsHumanTurn;
                Computer.IsCurrentTurn = !IsHumanTurn;

                currentPlayer = IsHumanTurn ? (Player)Human : (Player)Computer;


                if (IsHumanTurn)
                {
                    // TODO: Should be handled in HumanPlayer class

                    Console.Write($"{Environment.NewLine} {Human.Name}: ");
                    IsInputValid = false;
                    while (!IsInputValid)
                    {
                        Human.Input.Column = Char.ToUpper(Console.ReadKey().KeyChar);
                        Human.Input.Row = Console.ReadKey().KeyChar;

                        IsInputValid = ValidateInput(Human.Input);
                        if (!IsInputValid)
                        {
                            Console.Write($"{Environment.NewLine} {Human.Board.Destroyer1.GetInvalidInputText()} {Environment.NewLine} {Human.Name}: ");
                            continue;
                        }

                        Point aimPoint = new Point
                        {
                            Column = Array.IndexOf(Computer.Board.Columns, Human.Input.Column),
                            Row = Array.IndexOf(Computer.Board.Rows, Human.Input.Row)
                        };

                        string cellContents = Computer.Board.Grid[aimPoint.Column, aimPoint.Row];

                        if (cellContents == Constants.HIT_MISSED || cellContents == Constants.HIT_SUCCESSFUL)
                        {
                            IsInputValid = false;
                            Console.Write($"{Environment.NewLine} {Human.Board.Destroyer1.GetInvalidInputText()} {Environment.NewLine} {Human.Name}: ");
                            continue;
                        }
                        else if (cellContents == Constants.LEGEND_EMPTY_CELL)
                        {
                            Computer.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_MISSED;
                            Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_MISSED}");
                        }
                        else if (cellContents == Constants.LEGEND_BATTLESHIP)
                        {
                            Computer.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_SUCCESSFUL;
                            Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_SUCCESSFUL}");

                            int bsLocationColIndex = Array.IndexOf(Computer.Board.Battleship.LocationColumns, Human.Input.Column);
                            int bsLocationRowIndex = Array.IndexOf(Computer.Board.Battleship.LocationRows, Human.Input.Row);

                            if (bsLocationColIndex > -1 && bsLocationRowIndex > -1)
                            {
                                Computer.Board.Battleship.LocationColumns[bsLocationColIndex] = 'x';
                                Computer.Board.Battleship.LocationRows[bsLocationRowIndex] = 'x';

                                if (Computer.Board.Battleship.LocationRows.Where(num => num == 'x').Count() == Computer.Board.Battleship.Size)
                                {
                                    Console.WriteLine($" {Constants.BATTLESHIP_STRING} {Constants.ELIMINATED} {Environment.NewLine} {Environment.NewLine} {Constants.PRESS_ANY_KEY_CONT} ");
                                    Computer.NumberOfShipsDestroyed++;
                                    Console.ReadKey();
                                }
                            }
                        }
                        else if (cellContents == Constants.LEGEND_DESTROYER) // hit on Destroyer
                        {
                            // bad coding here. Need to improve this. Dynamic number of ships will cause trouble

                            Computer.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_SUCCESSFUL;
                            Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_SUCCESSFUL}");

                            int de1LocationColIndex = Array.IndexOf(Computer.Board.Destroyer1.LocationColumns, Human.Input.Column);
                            int de1LocationRowIndex = Array.IndexOf(Computer.Board.Destroyer1.LocationRows, Human.Input.Row);

                            int de2LocationColIndex = Array.IndexOf(Computer.Board.Destroyer2.LocationColumns, Human.Input.Column);
                            int de2LocationRowIndex = Array.IndexOf(Computer.Board.Destroyer2.LocationRows, Human.Input.Row);

                            if (de1LocationColIndex > -1 && de1LocationRowIndex > -1)
                            {
                                Computer.Board.Destroyer1.LocationColumns[de1LocationColIndex] = 'x';
                                Computer.Board.Destroyer1.LocationRows[de1LocationRowIndex] = 'x';

                                if (Computer.Board.Destroyer1.LocationRows.Where(num => num == 'x').Count() == Computer.Board.Destroyer1.Size)
                                {
                                    Console.WriteLine($" {Constants.DESTROYER_STRING} {Constants.ELIMINATED} {Environment.NewLine} {Environment.NewLine} {Constants.PRESS_ANY_KEY_CONT} ");
                                    Computer.NumberOfShipsDestroyed++;
                                    Console.ReadKey();
                                }
                            }
                            else if (de2LocationColIndex > -1 && de2LocationRowIndex > -1)
                            {
                                Computer.Board.Destroyer2.LocationColumns[de2LocationColIndex] = 'x';
                                Computer.Board.Destroyer2.LocationRows[de2LocationRowIndex] = 'x';

                                if (Computer.Board.Destroyer2.LocationRows.Where(num => num == 'x').Count() == Computer.Board.Destroyer2.Size)
                                {
                                    Console.WriteLine($" {Constants.DESTROYER_STRING} {Constants.ELIMINATED} {Environment.NewLine} {Environment.NewLine} {Constants.PRESS_ANY_KEY_CONT} ");
                                    Computer.NumberOfShipsDestroyed++;
                                    Console.ReadKey();
                                }
                            }
                        }

                        if (Computer.NumberOfShipsDestroyed == Computer.Board.NumberOfShips)
                        {
                            Human.IsWinner = true;
                            IsGameOver = true;
                            break;
                        }
                    }
                }
                else // Computer's turn
                {
                    // TODO: Should be handled in ComputerPlayer class
                    Position hitPosition = Computer.GetRandomHitPosition(Human.Board);
                    Computer.Input.Row = hitPosition.Row; 
                    Computer.Input.Column = hitPosition.Column;


                    Point aimPoint = new Point
                    {
                        Column = Array.IndexOf(Human.Board.Columns, Computer.Input.Column),
                        Row = Array.IndexOf(Human.Board.Rows, Computer.Input.Row)
                    };

                    string cellContents = Human.Board.Grid[aimPoint.Column, aimPoint.Row];

                    if (cellContents == Constants.HIT_MISSED || cellContents == Constants.HIT_SUCCESSFUL)
                    {
                        IsInputValid = false;
                        Console.Write($"{Environment.NewLine} {Human.Board.Destroyer1.GetInvalidInputText()} {Environment.NewLine} {Human.Name}: ");
                        continue;
                    }
                    else if (cellContents == Constants.LEGEND_EMPTY_CELL)
                    {
                        Human.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_MISSED;
                        Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_MISSED}");
                    }
                    else if (cellContents == Constants.LEGEND_BATTLESHIP)
                    {
                        Human.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_SUCCESSFUL;
                        Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_SUCCESSFUL}");

                        int bsLocationColIndex = Array.IndexOf(Human.Board.Battleship.LocationColumns, Computer.Input.Column);
                        int bsLocationRowIndex = Array.IndexOf(Human.Board.Battleship.LocationRows, Computer.Input.Row);

                        if (bsLocationColIndex > -1 && bsLocationRowIndex > -1)
                        {
                            Human.Board.Battleship.LocationColumns[bsLocationColIndex] = 'x';
                            Human.Board.Battleship.LocationRows[bsLocationRowIndex] = 'x';

                            if (Human.Board.Battleship.LocationRows.Where(num => num == 'x').Count() == Human.Board.Battleship.Size)
                            {
                                Console.WriteLine($" {Constants.BATTLESHIP_STRING} {Constants.ELIMINATED} {Environment.NewLine} {Environment.NewLine} {Constants.PRESS_ANY_KEY_CONT} ");
                                Human.NumberOfShipsDestroyed++;
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (cellContents == Constants.LEGEND_DESTROYER) // hit on Destroyer
                    {
                        // bad coding here. Need to improve this. Dynamic number of ships will cause trouble

                        Human.Board.Grid[aimPoint.Column, aimPoint.Row] = Constants.LEGEND_HIT_SUCCESSFUL;
                        Console.WriteLine($"{Environment.NewLine} {Constants.HUMAN_NAME}: {Constants.HIT_SUCCESSFUL}");

                        int de1LocationColIndex = Array.IndexOf(Human.Board.Destroyer1.LocationColumns, Computer.Input.Column);
                        int de1LocationRowIndex = Array.IndexOf(Human.Board.Destroyer1.LocationRows, Computer.Input.Row);

                        int de2LocationColIndex = Array.IndexOf(Human.Board.Destroyer2.LocationColumns, Computer.Input.Column);
                        int de2LocationRowIndex = Array.IndexOf(Human.Board.Destroyer2.LocationRows, Computer.Input.Row);

                        if (de1LocationColIndex > -1 && de1LocationRowIndex > -1)
                        {
                            Human.Board.Destroyer1.LocationColumns[de1LocationColIndex] = 'x';
                            Human.Board.Destroyer1.LocationRows[de1LocationRowIndex] = 'x';

                            if (Human.Board.Destroyer1.LocationRows.Where(num => num == 'x').Count() == Human.Board.Destroyer1.Size)
                            {
                                Console.WriteLine($" {Constants.DESTROYER_STRING} {Constants.ELIMINATED} {Environment.NewLine} {Environment.NewLine} {Constants.PRESS_ANY_KEY_CONT} ");
                                Human.NumberOfShipsDestroyed++;
                                Console.ReadKey();
                            }
                        }
                        else if (de2LocationColIndex > -1 && de2LocationRowIndex > -1)
                        {
                            Human.Board.Destroyer2.LocationColumns[de2LocationColIndex] = 'x';
                            Human.Board.Destroyer2.LocationRows[de2LocationRowIndex] = 'x';

                            if (Human.Board.Destroyer2.LocationRows.Where(num => num == 'x').Count() == Human.Board.Destroyer2.Size)
                            {
                                Console.WriteLine($" {Constants.DESTROYER_STRING} {Constants.ELIMINATED} {Environment.NewLine} {Environment.NewLine} {Constants.PRESS_ANY_KEY_CONT} ");
                                Human.NumberOfShipsDestroyed++;
                                Console.ReadKey();
                            }
                        }
                    }

                    if (Human.NumberOfShipsDestroyed == Human.Board.NumberOfShips)
                    {
                        Computer.IsWinner = true;
                        IsGameOver = true;
                        break;
                    }
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
