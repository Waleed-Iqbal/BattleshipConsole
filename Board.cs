using BattleshipConsole.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public class Board
    {
        string[,] Grid { get; set; }

        public readonly char[] Rows = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public readonly char[] Columns = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        public readonly char[] ValidRows = { '+', '+', '+', '+', '+', '+', '+', '+', '+', '+' };
        public readonly char[] ValidColumns = { '+', '+', '+', '+', '+', '+', '+', '+', '+', '+' };

        public int NumberOfShips { get; set; }

        public Destroyer Destroyer1 { get; set; }
        public Destroyer Destroyer2 { get; set; }
        public Battleship Battleship { get; set; }

        public Board()
        {
            NumberOfShips = Constants.NUMBER_OF_BATTLESHIPS + Constants.NUMBER_OF_DESTROYERS;
            Destroyer1 = new Destroyer();
            Destroyer2 = new Destroyer();
            Battleship = new Battleship();

            Grid = new string[Constants.BOARD_ROWS_COUNT, Constants.BOARD_COLUMNS_COUNT];

            for (int column = 0; column < Constants.BOARD_ROWS_COUNT; ++column)
                for (int row = 0; row < Constants.BOARD_COLUMNS_COUNT; ++row)
                    Grid[column, row] = ValidColumns[column].ToString() + ValidRows[row].ToString();
        }

        // this should set all the data of the ships and here the ships will be rendered
        public void PlaceAllShips()
        {
            Destroyer1.Place(Rows, Columns, Grid);
            Destroyer2.Place(Rows, Columns, Grid);
            Battleship.Place(Rows, Columns, Grid);
        }

        public void DisplayBoard()
        {
            Console.Write($"{Environment.NewLine}    ");
            foreach (char c in Columns)
                Console.Write($" {c} ");

            Console.WriteLine();

            for (int row = 0; row < Constants.BOARD_ROWS_COUNT; ++row)
            {
                Console.WriteLine();
                Console.Write($" {Rows[row]}   ");
                for (int column = 0; column < Constants.BOARD_COLUMNS_COUNT; ++column)
                    Console.Write($"{Grid[column, row]} ");
            }
        }
    }
}
