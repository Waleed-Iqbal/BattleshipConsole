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

        public void Place()
        {
            bool isOrientationValid = false;
            while (!isOrientationValid)
            {
                Console.WriteLine($"{Environment.NewLine} {Constants.PLACE_DESTROYER}:");
                GetOrientationText();
                char orientation = Console.ReadKey().KeyChar;
                isOrientationValid = ValidateOrientation(orientation);

                if (!isOrientationValid)
                {
                    Console.WriteLine($"{Constants.INVALID_INPUT}. {Constants.TRY_AGAIN}");
                }
                else
                {
                    Orientation = orientation == '1' ? Ship.Orientations.Vertical : Ship.Orientations.Horizontal;
                    isOrientationValid = false;
                }
            }

            Console.Write($"{Environment.NewLine} Enter start location: ");
            StartPosition.Row = Console.ReadKey().KeyChar;
            StartPosition.Column = Console.ReadKey().KeyChar;
        }
    }
}
