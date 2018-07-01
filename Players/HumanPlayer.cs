using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            Name = Constants.HUMAN_NAME;
        }

        private void PlaceShip(Ship ship, char[] rows, char[] columns, string[,] grid)
        {
            bool isOrientationValid = false;
            while (!isOrientationValid)
            {
                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine} {ship.PlacingString}:");
                Console.Write(ship.GetOrientationText());

                char orientation = Console.ReadKey().KeyChar;
                isOrientationValid = ship.ValidateOrientation(orientation);

                if (!isOrientationValid)
                    Console.WriteLine(ship.GetInvalidInputText());
                else
                {
                    ship.Orientation = orientation == '1' ? Ship.Orientations.Horizontal : Ship.Orientations.Vertical;
                }
            }

            bool isStartPositionValid = false;
            while (!isStartPositionValid)
            {
                Console.Write($"{Environment.NewLine} Enter start location: (A0 to J9) ");
                ship.StartPosition.Column = Char.ToUpper(Console.ReadKey().KeyChar);
                ship.StartPosition.Row = Console.ReadKey().KeyChar;

                isStartPositionValid = ship.ValidateStartPosition(ship.StartPosition, rows, columns, grid);
            }

            bool isEndPositionValid = false;
            while (!isEndPositionValid)
            {
                Console.Write($"{Environment.NewLine} Enter end location: ");
                ship.EndPosition.Column = Char.ToUpper(Console.ReadKey().KeyChar);
                ship.EndPosition.Row = Console.ReadKey().KeyChar;
                isEndPositionValid = ship.ValidateEndPosition(ship.EndPosition, ship.StartPosition, ship.Size, rows, columns, grid);
            }

            if (isStartPositionValid && isEndPositionValid)
            {
                Point startPoint = new Point() { Row = Array.IndexOf(rows, ship.StartPosition.Row), Column = Array.IndexOf(columns, ship.StartPosition.Column) };
                Point endPoint = new Point() { Row = Array.IndexOf(rows, ship.EndPosition.Row), Column = Array.IndexOf(columns, ship.EndPosition.Column) };

                if (ship.Orientation == Ship.Orientations.Vertical)
                {
                    if (startPoint.Row - endPoint.Row < 0)
                    {
                        for (var i = startPoint.Row; i <= endPoint.Row; i++)
                            grid[startPoint.Column, i] = ship.Legend;
                    }
                    else
                    {
                        for (var i = endPoint.Row; i <= startPoint.Row; i++)
                            grid[startPoint.Column, i] = ship.Legend;
                    }
                }
                else
                {
                    if (startPoint.Column - endPoint.Column < 0)
                    {
                        for (var i = startPoint.Column; i <= endPoint.Column; i++)
                            grid[i, startPoint.Row] = ship.Legend;
                    }
                    else
                    {
                        for (var i = endPoint.Column; i <= startPoint.Column; i++)
                            grid[i, startPoint.Row] = ship.Legend;
                    }
                }
            }
        }


        public void PlaceAllShips()
        {
            PlaceShip(Board.Destroyer1, Board.Rows, Board.Columns, Board.Grid);
            Board.DisplayBoard();
            PlaceShip(Board.Destroyer2, Board.Rows, Board.Columns, Board.Grid);
            Board.DisplayBoard();
            PlaceShip(Board.Battleship, Board.Rows, Board.Columns, Board.Grid);
        }
    }
}
