using System;
using RideTheBus.Cards;

namespace RideTheBus.Strategies
{
    public class SmartStrategy : Strategy
    {
        public override int ChooseColour(Deck deck)
        {
            return PickRandom(
                new int[] { COLOUR_BLACK, COLOUR_RED }
            );
        }

        public override int ChooseHighLow(Card firstCard, Deck deck)
        {
            if (firstCard.Rank > 7) return HL_LOW;
            if (firstCard.Rank < 7) return HL_HIGH;
            return PickRandom( new int[] { HL_LOW, HL_HIGH });
        }

        public override int ChooseInOut(Card firstCard, Card secondCard, Deck deck)
        {
            int diff = Math.Abs(firstCard.Rank - secondCard.Rank);

            if (diff >= 7) return IO_IN;
            else return IO_OUT;
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
    }
}