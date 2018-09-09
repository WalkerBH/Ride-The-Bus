using System;

namespace RideTheBus.Cards
{
    public class Deck
    {
        public Card[] Cards { get; set; }
        public bool IsEmpty
        {
            get
            {
                foreach (Card card in Cards)
                {
                    if (card.IsLive) return false;
                }

                return true;
            }
        }

        public Deck()
        {
            Cards = new Card[52];
            for (int i = 0; i < Cards.Length; i++)
            {
                Cards[i] = new Card(i);
            }
        }

        public Card DealRandomCard()
        {
            Random rng = new Random();

            while (true)
            {
                Card chosen = Cards[rng.Next(Cards.Length)];
                
                if (chosen.IsLive)
                {
                    chosen.IsLive = false;
                    return chosen;
                }
            }
        }
    }
}