using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState Game = new GameState();

            Game.Start();

            Console.WriteLine($"\t{Environment.NewLine}{Environment.NewLine}{Constants.LEGENT_STRING}: {Environment.NewLine}" +
                $"DE: {Constants.DESTROYER_STRING},  BS: {Constants.BATTLESHIP_STRING},  HM: {Constants.HIT_MISSED},  HS: {Constants.HIT_SUCCESSFUL}");


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
        }
    }
}
