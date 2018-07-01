using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer()
        {
            Name = Constants.COMPUTER_NAME;
        }


        private int GetRandomNumberInExludedRange(int start, int end, HashSet<int> exclude)
        {
            end++;
            var range = Enumerable.Range(start, end).Where(i => !exclude.Contains(i));
            Random rand = new System.Random();
            int index = rand.Next(start, end - exclude.Count);
            return range.ElementAt(index);
        }


        private int GetRandomNumberInRange(int start, int end)
        {
            end++; // as the end is exclusive
            Random rand = new System.Random();
            int number = rand.Next(start, end);
            return number;
        }

        private int GetRandomOrientation()
        {
            return GetRandomNumberInRange(1, 2);
        }


        private Position GetRandomGridPosition(Ship ship)
        {
            Position randPosition = new Position();
            Point randPoint = new Point();
            Random rand = new Random();

            randPoint.Column = rand.Next(Board.Grid.GetLength(0));
            randPoint.Row = rand.Next(Board.Grid.GetLength(1));

            string cellContents = Board.Grid[randPoint.Column, randPoint.Row];
            randPosition.Column = cellContents[0];
            randPosition.Row = cellContents[1];

            bool isValid = ship.ValidateStartPosition(randPosition, Board.Rows, Board.Columns, Board.Grid);

            return randPosition;
        }


        private void PlaceShip(Ship ship)
        {
            ship.Orientation = GetRandomOrientation() == 1 ?
                Ship.Orientations.Horizontal :
                Ship.Orientations.Vertical;



        }

        public void PlaceAllShips()
        {
            PlaceShip(Board.Destroyer1);
            Board.DisplayBoard();
            PlaceShip(Board.Destroyer2);
            Board.DisplayBoard();
            PlaceShip(Board.Battleship);
        }
    }
}
