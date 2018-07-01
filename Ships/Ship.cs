﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    public struct Position
    {
        public char Row;
        public char Column;
    };

    public struct Point
    {
        public int Row;
        public int Column;
    }

    public class Ship
    {
        public int Size { get; set; }
        public bool IsDestroyed { get; set; }
        public Orientations Orientation { get; set; }

        public Position StartPosition;
        public Position EndPosition;

        public Ship()
        {
            Orientation = Orientations.Horizontal;
        }

        public enum Orientations
        {
            Vertical,
            Horizontal
        }

        public bool ValidateOrientation(char orientation)
        {
            return orientation == '1' || orientation == '2';
        }


        public virtual void Place(char[] rows, char[] columns, string[,] grid, string placeShip, string shipLegend)
        {
            bool isOrientationValid = false;
            while (!isOrientationValid)
            {
                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine} {placeShip}:");
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
                    {
                        for (var i = startPoint.Row; i <= endPoint.Row; i++)
                            grid[startPoint.Column, i] = shipLegend;
                    }
                    else
                    {
                        for (var i = endPoint.Row; i <= startPoint.Row; i++)
                            grid[startPoint.Column, i] = shipLegend;
                    }
                }
                else
                {
                    if (startPoint.Column - endPoint.Column < 0)
                    {
                        for (var i = startPoint.Column; i <= endPoint.Column; i++)
                            grid[i, startPoint.Row] = shipLegend;
                    }
                    else
                    {
                        for (var i = endPoint.Column; i <= startPoint.Column; i++)
                            grid[i, startPoint.Row] = shipLegend;
                    }
                }
            }
        }


        public string GetInvalidInputText()
        {
            return $"{Constants.INVALID_INPUT}. {Constants.TRY_AGAIN}";
        }


        public string GetOrientationText()
        {
            return $"{Environment.NewLine} Set Orientation (enter 1 or 2): {Environment.NewLine} " +
                $"1. {Constants.HORIZONTAL } {Environment.NewLine} " +
                $"2. {Constants.VETICAL} {Environment.NewLine} " +
                $"==> ";
        }

        public bool ValidateStartPosition(Position position, char[] rows, char[] columns, string[,] grid)
        {
            bool isValid = false;
            isValid = rows.Contains(position.Row) && columns.Contains(position.Column);
            if (isValid)
            {
                int rowIndex = Array.IndexOf(rows, position.Row);
                int columnIndex = Array.IndexOf(columns, position.Column);
                string candidateCellContents = grid[columnIndex, rowIndex];

                isValid = !(candidateCellContents == Constants.LEGEND_BATTLESHIP || candidateCellContents == Constants.LEGEND_DESTROYER);
            }
            return isValid;
        }

        public bool ValidateEndPosition(Position endPosition, Position startPosition, int size, char[] rows, char[] columns, string[,] grid)
        {
            bool isValid = false;

            // second point must be an empty cell, this scenario is covered in ValidateStartPosition method
            isValid = ValidateStartPosition(endPosition, rows, columns, grid);

            if (isValid)
            {
                Point startPoint = new Point() { Row = Array.IndexOf(rows, startPosition.Row), Column = Array.IndexOf(columns, startPosition.Column) };
                Point endPoint = new Point() { Row = Array.IndexOf(rows, endPosition.Row), Column = Array.IndexOf(columns, endPosition.Column) };

                if (Orientation == Orientations.Horizontal)
                {
                    isValid = Math.Abs(startPoint.Row - endPoint.Row) == 0 && Math.Abs(startPoint.Column - endPoint.Column) == Size - 1;
                }
                else
                {
                    isValid = Math.Abs(startPoint.Row - endPoint.Row) == Size - 1 && Math.Abs(startPoint.Column - endPoint.Column) == 0;
                }
            }

            return isValid;
        }

    }
}
