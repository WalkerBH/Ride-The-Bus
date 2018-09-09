using System;
using RideTheBus.Cards;

namespace RideTheBus.Strategies
{
    public abstract class Strategy
    {
        public const int
            COLOUR_RED = Card.RED,
            COLOUR_BLACK = Card.BLACK,
            HL_LOW = 0,
            HL_HIGH = 1,
            HL_EQUAL = 2,
            IO_IN = 0,
            IO_OUT = 1,
            IO_ON = 2,
            SUIT_CLUBS = Card.CLUBS,
            SUIT_DIAMONDS = Card.DIAMONDS,
            SUIT_SPADES = Card.SPADES,
            SUIT_HEARTS = Card.HEARTS;

        protected T PickRandom<T>(T[] objects)
        {
            int index = new Random().Next(objects.Length);
            return objects[index];
        }

        public abstract int ChooseColour(Deck deck);

        public abstract int ChooseHighLow(Card firstCard, Deck deck);

        public abstract int ChooseInOut(Card firstCard, Card secondCard, Deck deck);

        public abstract bool ChooseHasFace(Deck deck);

        public abstract int ChooseSuit(Deck deck);
    }
}