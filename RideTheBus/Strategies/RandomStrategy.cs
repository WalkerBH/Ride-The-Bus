using System;
using RideTheBus.Cards;

namespace RideTheBus.Strategies
{
    public class RandomStrategy : Strategy
    {
        public override int ChooseColour(Deck deck)
        {
            return PickRandom(
                new int[] { COLOUR_BLACK, COLOUR_RED }
            );
        }

        public override int ChooseHighLow(Deck deck)
        {
            return PickRandom(
                new int[] { HL_HIGH, HL_LOW, HL_EQUAL }
            );
        }

        public override int ChooseInOut(Deck deck)
        {
            return PickRandom(
                new int[] { IO_IN, IO_ON, IO_OUT }
            );
        }

        public override bool ChooseHasFace(Deck deck)
        {
            return PickRandom(
                new bool[] { true, false }
            );
        }

        public override int ChooseSuit(Deck deck)
        {
            return PickRandom(
                new int[] { SUIT_CLUBS, SUIT_DIAMONDS, SUIT_HEARTS, SUIT_SPADES }
            );
        }

        private T PickRandom<T>(T[] objects)
        {
            int index = new Random().Next(objects.Length);
            return objects[index];
        }
    }
}