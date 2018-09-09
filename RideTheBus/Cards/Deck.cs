using System;
using System.Collections.Generic;

namespace RideTheBus.Cards
{
    public class Deck
    {
        public int NumCards
        {
            get
            {
                return Cards.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Cards.Count == 0;
            }
        }

        public int NumClubsLeft
        {
            get
            {
                return NumCardsLeftBySuit[Card.CLUBS];
            }
        }

        public int NumDiamondsLeft
        {
            get
            {
                return NumCardsLeftBySuit[Card.DIAMONDS];
            }
        }

        public int NumSpadesLeft
        {
            get
            {
                return NumCardsLeftBySuit[Card.SPADES];
            }
        }

        public int NumHeartsLeft
        {
            get
            {
                return NumCardsLeftBySuit[Card.HEARTS];
            }
        }

        public int NumRedCardsLeft
        {
            get
            {
                return NumHeartsLeft + NumDiamondsLeft;
            }
        }

        public int NumBlackCardsLeft
        {
            get
            {
                return NumClubsLeft + NumSpadesLeft;
            }
        }

        private List<Card> Cards { get; set; }
        private int[] NumCardsLeftByRank { get; set; }
        private int[] NumCardsLeftBySuit { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                Cards.Add(new Card(i));
            }

            NumCardsLeftByRank = new int[13];
            for (int i = 0; i < NumCardsLeftByRank.Length; i++)
            {
                NumCardsLeftByRank[i] = 4;
            }

            NumCardsLeftBySuit = new int[4];
            for (int i = 0; i < NumCardsLeftBySuit.Length; i++)
            {
                NumCardsLeftBySuit[i] = 13;
            }
        }

        public Card DealRandomCard()
        {
            Random rng = new Random();
            
            int index = rng.Next(Cards.Count);
            Card chosen = Cards[index];
            RemoveCardAt(index);
            return chosen;
        }

        public int NumOfRankXLeft(int rank)
        {
            if (rank < 1 || rank > 13) throw new Exception();
            return NumCardsLeftByRank[rank-1];
        }

        private void RemoveCardAt(int index)
        {
            Card card = Cards[index];
            NumCardsLeftBySuit[card.Suit]--;
            NumCardsLeftByRank[card.Rank-1]--;
            Cards.RemoveAt(index);
        }
    }
}