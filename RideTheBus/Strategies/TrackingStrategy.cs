using System;
using RideTheBus.Cards;

namespace RideTheBus.Strategies
{
    public class TrackingStrategy : Strategy
    {
        public override int ChooseColour(Deck deck)
        {
            return (deck.NumBlackCardsLeft > deck.NumRedCardsLeft) ? Card.BLACK : Card.RED;
        }

        public override int ChooseHighLow(Card firstCard, Deck deck)
        {
            int numCardsLower = 0, numCardsHigher = 0, numCardsEqual = 0;

            for (int i = 1; i <= 13; i++)
            {
                if (i < firstCard.Rank)
                {
                    numCardsLower += deck.NumOfRankXLeft(i);
                }
                else if (i > firstCard.Rank)
                {
                    numCardsHigher += deck.NumOfRankXLeft(i);
                }
                else
                {
                    numCardsEqual += deck.NumOfRankXLeft(i);
                }
            }
            
            if (numCardsLower > numCardsEqual && numCardsLower > numCardsHigher) return HL_LOW;
            if (numCardsHigher > numCardsLower && numCardsHigher > numCardsEqual) return HL_HIGH;
            else return HL_EQUAL;
        }

        public override int ChooseInOut(Card firstCard, Card secondCard, Deck deck)
        {
            int numCardsInside = 0, numCardsOutside = 0, numCardsOn = 0;

            for (int i = 1; i <= 13; i++)
            {
                if (firstCard.Rank < i && i < secondCard.Rank || secondCard.Rank < i && i < firstCard.Rank)
                {
                    numCardsInside += deck.NumOfRankXLeft(i);
                }
                else if (i == firstCard.Rank || i == secondCard.Rank)
                {
                    numCardsOn += deck.NumOfRankXLeft(i);
                }
                else
                {
                    numCardsOutside += deck.NumOfRankXLeft(i);
                }
            }
            
            if (numCardsInside > numCardsOn && numCardsInside > numCardsOutside) return IO_IN;
            if (numCardsOutside > numCardsInside && numCardsOutside > numCardsOn) return IO_OUT;
            else return IO_ON;
        }

        public override bool ChooseHasFace(Deck deck)
        {
            int numFaceCards = 0, numNonFaceCards = 0;
            for (int i = 1; i <= 13; i++)
            {
                if (i >= 11)
                {
                    numFaceCards += deck.NumOfRankXLeft(i);
                }
                else
                {
                    numNonFaceCards += deck.NumOfRankXLeft(i);
                }
            }

            return numFaceCards > numNonFaceCards;
        }

        public override int ChooseSuit(Deck deck)
        {
            int suit = Card.CLUBS;
            int mostSoFar = deck.NumClubsLeft;

            if (deck.NumDiamondsLeft > mostSoFar)
            {
                suit = Card.DIAMONDS;
                mostSoFar = deck.NumDiamondsLeft;
            }

            if (deck.NumSpadesLeft > mostSoFar)
            {
                suit = Card.SPADES;
                mostSoFar = deck.NumSpadesLeft;
            }

            if (deck.NumHeartsLeft > mostSoFar)
            {
                suit = Card.HEARTS;
            }

            return suit;
        }
    }
}