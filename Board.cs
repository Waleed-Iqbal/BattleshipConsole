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

        public Board()
        {
            Grid = new string[10, 10];

            for (int column = 0; column < Columns.Length; ++column)
                for (int row = 0; row < Rows.Length; ++row)
                    Grid[column, row] = Columns[column].ToString() + Rows[row].ToString();
        }

        public void DisplayBoard()
        {
            for (int row = 0; row < Rows.Length; ++row)
            {
                Console.WriteLine();
                for (int column = 0; column < Columns.Length; ++column)
                    Console.Write(Grid[column, row] + " ");
            }
        }
    }
}
