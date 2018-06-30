using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole.Ships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Size = 5;
        }

        /// <summary>
        /// Will be used to place first battleship/ship
        /// </summary>
        public override void Place(char[] rows, char[] columns, string[,] grid)
        {
            bool isOrientationValid = false;
            while (!isOrientationValid)
            {
                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine} {Constants.PLACE_BATTLESHIP}:");
                Console.Write(GetOrientationText());

                char orientation = Console.ReadKey().KeyChar;
                isOrientationValid = ValidateOrientation(orientation);

                if (!isOrientationValid)
                    Console.WriteLine(GetInvalidInputText());
                else
                {
                    Orientation = orientation == '1' ? Ship.Orientations.Horizontal : Ship.Orientations.Vertical;
                }
            }

            bool isStartPositionValid = false;
            while (!isStartPositionValid)
            {
                Console.Write($"{Environment.NewLine} Enter start location: (A0 to J9) ");
                StartPosition.Column = Char.ToUpper(Console.ReadKey().KeyChar);
                StartPosition.Row = Console.ReadKey().KeyChar;

                isStartPositionValid = ValidateStartPosition(StartPosition, rows, columns, grid);
            }

            bool isEndPositionValid = false;
            while (!isEndPositionValid)
            {
                Console.Write($"{Environment.NewLine} Enter end location: ");
                EndPosition.Column = Char.ToUpper(Console.ReadKey().KeyChar);
                EndPosition.Row = Console.ReadKey().KeyChar;

                isEndPositionValid = ValidateEndPosition(EndPosition, StartPosition, Size, rows, columns, grid);
            }


            if (isStartPositionValid && isEndPositionValid)
            {
                Point startPoint = new Point() { Row = Array.IndexOf(rows, StartPosition.Row), Column = Array.IndexOf(columns, StartPosition.Column) };
                Point endPoint = new Point() { Row = Array.IndexOf(rows, EndPosition.Row), Column = Array.IndexOf(columns, EndPosition.Column) };

                if (Orientation == Orientations.Vertical)
                {
                    if (startPoint.Row - endPoint.Row < 0)
                        for (var i = startPoint.Row; i <= endPoint.Row; i++)
                            grid[startPoint.Column, i] = Constants.LEGEND_BATTLESHIP;
                }
                else
                {
                    if (startPoint.Column - endPoint.Column < 0)
                        for (var i = startPoint.Column; i <= endPoint.Column; i++)
                            grid[i, startPoint.Row] = Constants.LEGEND_BATTLESHIP;
                }
            }

        }
    }
}
