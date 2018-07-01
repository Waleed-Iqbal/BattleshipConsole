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

        private void PlaceShip(Ship ship, char[] rows, char[] columns, string[,] grid)
        {

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
