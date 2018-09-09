using RideTheBus.Strategies;
using RideTheBus.Cards;
using System;

namespace RideTheBus
{
    public class Game
    {
        public bool WonGame { get; private set; }
        public int DrinksTaken { get; private set; }
        private Strategy Strat { get; set; }
        private Deck Deck { get; set; }

        public Game(Strategy strat)
        {
            DrinksTaken = 0;
            WonGame = false;
            Strat = strat;
            Deck = new Deck();
        }

        public void Play()
        {
            while (!WonGame)
            {
                if (Deck.IsEmpty) return;
                PlayTurn();
            }
        }

        private void PlayTurn()
        {
            if (Deck.IsEmpty) return;
            int colourGuess = Strat.ChooseColour(Deck);
            Card dealtCard1 = Deck.DealRandomCard();
            if (colourGuess != dealtCard1.Colour)
            {
                DrinksTaken++;
                return;
            }

            if (Deck.IsEmpty) return;
            int highLowGuess = Strat.ChooseHighLow(dealtCard1, Deck);
            Card dealtCard2 = Deck.DealRandomCard();
            if ((highLowGuess == Strategy.HL_HIGH  && !dealtCard2.IsHigherThan(dealtCard1)) ||
                (highLowGuess == Strategy.HL_LOW   && !dealtCard2.IsLowerThan(dealtCard1)) ||
                (highLowGuess == Strategy.HL_EQUAL && !dealtCard2.HasSameRankAs(dealtCard1)))
            {
                DrinksTaken++;
                return;
            }

            if (Deck.IsEmpty) return;
            int inOutGuess = Strat.ChooseInOut(dealtCard1, dealtCard2, Deck);
            Card dealtCard3 = Deck.DealRandomCard();
            if ((highLowGuess == Strategy.IO_IN  && !dealtCard3.IsInside(dealtCard1, dealtCard2)) ||
                (highLowGuess == Strategy.IO_OUT && !dealtCard3.IsOutside(dealtCard1, dealtCard2)) ||
                (highLowGuess == Strategy.IO_ON  && dealtCard3.IsOnTopOf(dealtCard1, dealtCard2)))
            {
                DrinksTaken++;
                return;
            }

            if (Deck.IsEmpty) return;
            bool faceGuess = Strat.ChooseHasFace(Deck);
            if (Deck.DealRandomCard().IsFace != faceGuess)
            {
                DrinksTaken++;
                return;
            }

            if (Deck.IsEmpty) return;
            int suitGuess = Strat.ChooseSuit(Deck);
            if (Deck.DealRandomCard().Suit != suitGuess)
            {
                DrinksTaken++;
                return;
            }

            WonGame = true;
            return;
        }
    }
}