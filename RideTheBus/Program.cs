using System;
using RideTheBus.Strategies;

namespace RideTheBus
{
    class Program
    {
        static void Main(string[] args)
        {
            string stratName = args.Length == 0 ? "" : args[0];
            
            Strategy strat;
            switch (stratName)
            {
                case "-random":
                    strat = new RandomStrategy();
                    break;
                default:
                    strat = new RandomStrategy();
                    break;
            }

            Game game = new Game (strat);
            game.Play();
            Console.WriteLine(game.WonGame ? "Player won!" : "Player lost");
            Console.WriteLine($"Drinks Taken: {game.DrinksTaken}");
        }
    }
}
