using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Size = 4;
        }


        public override bool ValidateStartPosition(Position position, char[] rows, char[] columns, string[,] grid)
        {
            bool isValid = false;
            isValid = rows.Contains(Char.ToUpper(position.Row)) && columns.Contains(position.Column);
            if (isValid)
            {
            }


            return isValid;
        }


        /// <summary>
        /// Will be used to place first destroyer/ship
        /// </summary>
        public override void Place(char[] rows, char[] columns, char[] validRows, char[] validColumns, string[,] grid)
        {
            bool isOrientationValid = false;
            while (!isOrientationValid)
            {
                Console.WriteLine($"{Environment.NewLine} {Constants.PLACE_DESTROYER}:");
                GetOrientationText();
                char orientation = Console.ReadKey().KeyChar;
                isOrientationValid = ValidateOrientation(orientation);

                if (!isOrientationValid)
                    Console.WriteLine(GetInvalidInputText());
                else
                {
                    Orientation = orientation == '1' ? Ship.Orientations.Vertical : Ship.Orientations.Horizontal;
                    isOrientationValid = false;
                }
            }

            bool isPositionValid = false;
            while (!isPositionValid)
            {
                Console.Write($"{Environment.NewLine} Enter start location: ");
                StartPosition.Row = Console.ReadKey().KeyChar;
                StartPosition.Column = Console.ReadKey().KeyChar;

                isPositionValid = ValidateStartPosition(StartPosition, rows, columns, grid);
                if (!isPositionValid) continue;
                isPositionValid = ValidateEndPosition(StartPosition, rows, columns, grid);
            }

        }

        /// <summary>
        /// Will be used to place a destroyer/ship after the first one
        /// </summary>
        public void Place(string[,] ValidPositions)
        {

        }
    }
}
