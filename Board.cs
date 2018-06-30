using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public class Board
    {
        string[,] grid;
        readonly char[] rows = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        readonly char[] columns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };

        public Board()
        {
            grid = new string[10, 10];

            for (int column = 0; column < columns.Length; ++column)
                for (int row = 0; row < rows.Length; ++row)
                    grid[column, row] = columns[column].ToString() + rows[row].ToString();
        }

        public void DisplayBoard()
        {
            for (int row = 0; row < rows.Length; ++row)
            {
                Console.WriteLine();
                for (int column = 0; column < columns.Length; ++column)
                    Console.Write(grid[column, row] + " ");
            }
        }
    }
}
