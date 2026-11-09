using System;
using System.Collections.Generic;

namespace _202293_抽卡
{
    class Card
    {
        public string card;
        public int power;

        public Card(string card,int power)
        {
            this.card = card;
            this.power = power;
        }
    }
    class Cards
    {
        private static int powersum;
        private static List<Card> cards = new List<Card>();

        public static void PrintCard(Card card)
        {
            Console.WriteLine($"你抽到了{card.card}卡,概率为{card.power}/{powersum}");
        }

        public void AddNewCards(string card, int power)
        {
            Card ncard = new Card(card,power);
            cards.Add(ncard);
            powersum += power;
        }

        public Card Draw()
        {
            Random random = new Random();
            int seed = random.Next(0,powersum);
            for(int i=0;i<cards.Count;i++)
            {
                seed -= cards[i].power;
                if (seed <= 0) return cards[i];
            }
            return cards[0];
        }

    }
    class MainClass
    {
        static void Main()
        {
            Cards cards = new Cards();
            cards.AddNewCards("S", 1);
            cards.AddNewCards("A", 2);
            cards.AddNewCards("B", 2);
            cards.AddNewCards("C", 4);
            for (int i = 0; i < 10; i++)
            {
                Cards.PrintCard(cards.Draw());
            }
        }
    }
}
