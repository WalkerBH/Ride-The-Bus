using System;

namespace RideTheBus.Cards
{
    public class Card
    {
        public const int
            CLUBS = 0,
            DIAMONDS = 1,
            SPADES = 2,
            HEARTS = 3,
            RED = 0,
            BLACK = 1;

        public Card(int index)
        {
            Suit = index / 13;
            Rank = (index % 13) + 1;
        }

        public int Suit { get; }
        public int Rank { get; }

        public int Colour
        {
            get
            {
                if (Suit == CLUBS || Suit == SPADES) return BLACK;
                else if (Suit == DIAMONDS || Suit == HEARTS) return RED;
                else throw new Exception();
            }
        }

        public bool IsFace
        {
            get
            {
                if (Rank > 10) return true;
                else return false;
            }
        }

        public bool IsHigherThan(Card card)
        {
            return Rank > card.Rank;
        }

        public bool IsLowerThan(Card card)
        {
            return Rank < card.Rank;
        }

        public bool HasSameRankAs(Card card)
        {
            return Rank == card.Rank;
        }

        public bool IsInside(Card card1, Card card2)
        {
            return (card1.Rank < Rank && Rank < card2.Rank) || (card2.Rank < Rank && Rank < card1.Rank);
        }

        public bool IsOutside(Card card1, Card card2)
        {
            return (Rank > card1.Rank && Rank > card2.Rank) || (Rank < card1.Rank && Rank < card2.Rank);
        }

        public bool IsOnTopOf(Card card1, Card card2)
        {
            return Rank == card1.Rank || Rank == card2.Rank;
        }
    }
}