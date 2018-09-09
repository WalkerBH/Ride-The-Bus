using System;
using RideTheBus.Strategies;

namespace RideTheBus
{
    class Program
    {
        static void Main(string[] args)
        {
            string stratName = args.Length < 1 ? "" : args[0];
            int gamesToPlay = args.Length < 2 ? 100 : int.Parse(args[1]);
            
            Strategy strat;
            switch (stratName)
            {
                case "-random":
                    strat = new RandomStrategy();
                    break;
                case "-smart":
                    strat = new SmartStrategy();
                    break;
                case "-tracking":
                    strat = new TrackingStrategy();
                    break;
                default:
                    strat = new RandomStrategy();
                    break;
            }

            PlayGames(strat, gamesToPlay);
        }

        static void PlayGames(Strategy strat, int numGames)
        {
            int gamesWon = 0;
            int totalDrinks = 0;
            for (int i = 0; i < numGames; i++)
            {
                Game game = new Game(strat);
                game.Play();
                if (game.WonGame) gamesWon++;
                totalDrinks += game.DrinksTaken;
            }

            Console.WriteLine($"Played {numGames} games... {gamesWon} games were won");
            Console.WriteLine($"Average Drinks Taken {totalDrinks / numGames}");
        }
    }
}
