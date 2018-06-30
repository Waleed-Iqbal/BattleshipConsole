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
        readonly char[] columns = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        readonly char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };

        public Board()
        {
            grid = new string[10, 10];

            for (int j = 0; j < rows.Length; ++j)
            for (int i = 0; i < columns.Length; ++i)
                    grid[i,j] = rows[j].ToString() + columns[i].ToString();
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < rows.Length; ++i)
            {
                Console.WriteLine();
                for (int j = 0; j < columns.Length; ++j)
                    Console.Write(grid[i, j] + " ");
            }
        }
    }
}
