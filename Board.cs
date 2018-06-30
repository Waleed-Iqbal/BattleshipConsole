using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public class Board
    {
        string[,] Grid;

        readonly char[] Rows = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        readonly char[] Columns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };

        public int NumberOfShipsRemaining;

        public Board()
        {
            NumberOfShipsRemaining = Constants.NUMBER_OF_BATTLESHIPS + Constants.NUMBER_OF_DESTROYERS;

            Grid = new string[Constants.BOARD_ROWS_COUNT, Constants.BOARD_COLUMNS_COUNT];

            for (int column = 0; column < Constants.BOARD_ROWS_COUNT; ++column)
                for (int row = 0; row < Constants.BOARD_COLUMNS_COUNT; ++row)
                    Grid[column, row] = Columns[column].ToString() + Rows[row].ToString();
        }

        public void DisplayBoard()
        {
            for (int row = 0; row < Constants.BOARD_ROWS_COUNT; ++row)
            {
                Console.WriteLine();
                for (int column = 0; column < Constants.BOARD_COLUMNS_COUNT; ++column)
                    Console.Write(Grid[column, row] + " ");
            }
        }
    }
}
