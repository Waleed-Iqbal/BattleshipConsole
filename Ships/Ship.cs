using System;
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

    public class Ship
    {
        public int Size { get; set; }
        public bool IsDestroyed { get; set; }
        public Position EndPosition { get; set; }
        public Orientations Orientation { get; set; }

        public Position StartPosition;

        public Ship()
        {
            Orientation = Orientations.Horizontal;
        }

        public enum Orientations
        {
            Horizontal,
            Vertical
        }

        public bool ValidateOrientation(char orientation)
        {
            return orientation == '1' || orientation == '2';
        }


        public virtual void Place(char[] rows, char[] columns, char[] validRows, char[] validColumns, string[,] Grid)
        {

        }


        public string GetInvalidInputText()
        {
            return $"{Constants.INVALID_INPUT}. {Constants.TRY_AGAIN}";
        }


        public void GetOrientationText()
        {
            Console.Write($"{Environment.NewLine} Set Orientation (enter 1 or 2): {Environment.NewLine} " +
                $"1. {Constants.VETICAL} {Environment.NewLine}" +
                $"2. {Constants.HORIZONTAL} {Environment.NewLine}" +
                $"==> ");
        }

        public virtual bool ValidateStartPosition(Position position, char[] rows, char[] columns, string[,] grid)
        {
            return false;
        }

        public virtual bool ValidateEndPosition(Position position, char[] rows, char[] columns, string[,] grid)
        {
            return false;
        }

    }
}
