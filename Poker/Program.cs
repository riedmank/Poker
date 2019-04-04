using Poker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Builds a normal playing card deck
            Deck<Card> myDeck = new Deck<Card>();
            Enum[] suits = new Enum[4];
            suits[0] = Suit.Clubs;
            suits[1] = Suit.Diamonds;
            suits[2] = Suit.Hearts;
            suits[3] = Suit.Spades;
            Enum[] values = new Enum[13];
            values[0] = Value.Ace;
            values[1] = Value.Two;
            values[2] = Value.Three;
            values[3] = Value.Four;
            values[4] = Value.Five;
            values[5] = Value.Six;
            values[6] = Value.Seven;
            values[7] = Value.Eight;
            values[8] = Value.Nine;
            values[9] = Value.Ten;
            values[10] = Value.Jack;
            values[11] = Value.Queen;
            values[12] = Value.King;
            foreach (Suit suit in suits)
            {
                foreach (Value value in values)
                {
                    Card card = new Card(suit, value);
                    myDeck.Add(card);
                }
            }
            // displays all cards loaded into the deck
            //foreach (Card card in myDeck)
            //{
            //    Console.WriteLine($"{card.Value} of {card.Suit}");
            //}

            Deck<Card> myHand = new Deck<Card>();

            byte[] results = new byte[9];
            results[0] = 0; // StraightFlush
            results[1] = 0; // FourOfAKind
            results[2] = 0; // FullHouse
            results[3] = 0; // Flush
            results[4] = 0; // Straight
            results[5] = 0; // ThreeOfAKind
            results[6] = 0; // TwoPair
            results[7] = 0; // Pair
            results[8] = 1; // HighCard   

            string[] possibleHands = new string[9];
            possibleHands[0] = "StraightFlush";
            possibleHands[1] = "FourOfAKind";
            possibleHands[2] = "FullHouse";
            possibleHands[3] = "Flush";
            possibleHands[4] = "Straight";
            possibleHands[5] = "ThreeOfAKind";
            possibleHands[6] = "TwoPair";
            possibleHands[7] = "Pair";
            possibleHands[8] = "HighCard";

            int result = 0;

            //Console.WriteLine("Welcome to Poker++");
            //Console.WriteLine("Would you like to score a random hand or custom hand? (1 for custom, 2 for random)");

            //string choice = Console.ReadLine();

            //if (choice == "1")
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine($"Enter value of card {i + 1}: (a, 2 - 10, j, q, k)");
            //        string userValue = Console.ReadLine().ToUpper();
            //        Console.WriteLine($"Enter suit of card {i + 1}: (c, d, h, s)");
            //        string userSuit = Console.ReadLine().ToUpper();

            //        myHand.Add(HandBuilder(userValue, userSuit));
            //    }
            //    ImprovedCheckHandPlus(myHand, results);
            //}
            //else if (choice == "2")
            //{
            //    // adds cards to hand
            //    Random rng = new Random();
            //    int counter = 52;
            //    for (int j = 5; j > 0; j--)
            //    {
            //        Card card = null;
            //        while (card == null)
            //        {
            //            card = myDeck.FindCardInDeck(rng.Next(0, counter--));
            //        }
            //        myHand.Add(card);
            //        myDeck.Remove(card);
            //    }
            //    ImprovedCheckHandPlus(myHand, results);
            //}

            //Console.WriteLine("=================================================");
            //Console.WriteLine("Your hand:");
            //foreach (Card item in myHand)
            //{
            //    Console.WriteLine($"{item.Value} of {item.Suit}");
            //}

            // Used for testing purposes
            Card card1 = new Card(Suit.Spades, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Two);
            Card card3 = new Card(Suit.Hearts, Value.Two);
            Card card4 = new Card(Suit.Hearts, Value.Three);
            Card card5 = new Card(Suit.Hearts, Value.Four);
            Card card6 = new Card(Suit.Hearts, Value.Five);
            Card card7 = new Card(Suit.Hearts, Value.Six);

            Deck<Card> fakeHand = new Deck<Card>();
            fakeHand.Add(card1);
            fakeHand.Add(card2);
            fakeHand.Add(card3);
            fakeHand.Add(card4);
            fakeHand.Add(card5);
            fakeHand.Add(card6);
            fakeHand.Add(card7);

            CheckHand(fakeHand, results);

            for (int i = 0; i < results.Length; i++)
            {
                if (results[i] == 1)
                {
                    result = i;
                    break;
                }
            }
            //Console.WriteLine("=================================================");
            Console.WriteLine(possibleHands[result]);

            Console.ReadLine();
        }

        public static Card HandBuilder(string userValue, string userSuit)
        {            
            Value value = new Value();
            Suit suit = new Suit();

            switch(userValue)
            {
                case "A":
                    value = Value.Ace;
                    break;
                case "2":
                    value = Value.Two;
                    break;
                case "3":
                    value = Value.Three;
                    break;
                case "4":
                    value = Value.Four;
                    break;
                case "5":
                    value = Value.Five;
                    break;
                case "6":
                    value = Value.Six;
                    break;
                case "7":
                    value = Value.Seven;
                    break;
                case "8":
                    value = Value.Eight;
                    break;
                case "9":
                    value = Value.Nine;
                    break;
                case "10":
                    value = Value.Ten;
                    break;
                case "J":
                    value = Value.Jack;
                    break;
                case "Q":
                    value = Value.Queen;
                    break;
                case "K":
                    value = Value.King;
                    break;
                default:
                    Console.WriteLine("You didn't pick a correct value. Goodbye.");
                    break;
            }

            switch (userSuit)
            {
                case "C":
                    suit = Suit.Clubs;
                    break;
                case "D":
                    suit = Suit.Diamonds;
                    break;
                case "H":
                    suit = Suit.Hearts;
                    break;
                case "S":
                    suit = Suit.Spades;
                    break;
                default:
                    Console.WriteLine("You didn't pick a correct suit. Goodbye.");
                    break;
            }

            Card card = new Card(suit, value);
            return card;
        }

        /// <summary>
        /// Sorts the cards in the hand by value
        /// </summary>
        /// <param name="hand">Hand that was dealt</param>
        public static Deck<Card> SortByValue(Deck<Card> hand)
        {
            Deck<Card> SortedDeck = hand;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (SortedDeck[j].Value > SortedDeck[j + 1].Value)
                        Swap(SortedDeck, j, j + 1);
                }
            }
            return SortedDeck;
        }

        /// <summary>
        /// Swaps 2 cards in the hand
        /// </summary>
        /// <param name="hand">Hand where cards reside</param>
        /// <param name="x">Card</param>
        /// <param name="y">Card</param>
        public static void Swap(Deck<Card> hand, int x, int y)
        {
            Card temp = hand[x];
            hand[x] = hand[y];
            hand[y] = temp;
        }

        /// <summary>
        /// Finds the best Poker hand in the cards provided
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        public static void CheckHand(Deck<Card> hand, byte[] results)
        {
            Deck<Card> ValueSorted = SortByValue(hand);

            Deck<Card> clubsOnlyDeck = hand.ShowSuit(Suit.Clubs);
            Deck<Card> diamondsOnlyDeck = hand.ShowSuit(Suit.Diamonds);
            Deck<Card> heartsOnlyDeck = hand.ShowSuit(Suit.Hearts);
            Deck<Card> spadesOnlyDeck = hand.ShowSuit(Suit.Spades);

            Deck<Card> SuitSorted = new Deck<Card>();
            if (clubsOnlyDeck.Length == 5)
            {
                foreach (Card card in clubsOnlyDeck)
                    SuitSorted.Add(card);
            }
            else if (diamondsOnlyDeck.Length == 5)
            {
                foreach (Card card in diamondsOnlyDeck)
                    SuitSorted.Add(card);
            }
            else if (heartsOnlyDeck.Length == 5)
            {
                foreach (Card card in heartsOnlyDeck)
                    SuitSorted.Add(card);
            }
            else if (spadesOnlyDeck.Length == 5)
            {
                foreach (Card card in spadesOnlyDeck)
                    SuitSorted.Add(card);
            }         
                       
            Tuple<Value?, int> match1 = new Tuple<Value?, int>(ValueSorted[0].Value, 0);
            Tuple<Value?, int> match2 = new Tuple<Value?, int>(null, 0);
            Tuple<Value?, int> match3 = new Tuple<Value?, int>(null, 0);
            Tuple<Value?, int> sequence = new Tuple<Value?, int>(ValueSorted[0].Value, 0);
            Tuple<Card, int> straightFlush = new Tuple<Card, int>(SuitSorted[0], 0);
            int clubs = 0;
            int diamonds = 0;
            int hearts = 0;
            int spades = 0;

            foreach (Card card in ValueSorted)
            {
                // Suits
                if (card.Suit == Suit.Clubs)
                    clubs++;
                else if (card.Suit == Suit.Diamonds)
                    diamonds++;
                else if (card.Suit == Suit.Hearts)
                    hearts++;
                else
                    spades++;
            }

            for (int i = 1; i < 7; i++)
            {
                // StraightFlush
                if (SuitSorted[i].Value == (straightFlush.Item1.Value + 1) && SuitSorted[i].Suit == straightFlush.Item1.Suit)
                    straightFlush = new Tuple<Card, int>(SuitSorted[i], straightFlush.Item2 + 1);
                else
                    straightFlush = new Tuple<Card, int>(SuitSorted[i], 0);

                // Sequence
                if (ValueSorted[i].Value == (sequence.Item1 + 1))
                    sequence = new Tuple<Value?, int>(ValueSorted[i].Value, sequence.Item2 + 1);
                else
                    sequence = new Tuple<Value?, int>(ValueSorted[i].Value, 0);

                // Matches
                if (ValueSorted[i].Value == match1.Item1 || ValueSorted[i].Value == match2.Item1 || ValueSorted[i].Value == match3.Item1)
                {
                    if (ValueSorted[i].Value == match1.Item1)
                        match1 = new Tuple<Value?, int>(match1.Item1, match1.Item2 + 1);
                    if (ValueSorted[i].Value == match2.Item1)
                        match2 = new Tuple<Value?, int>(match2.Item1, match2.Item2 + 1);
                    if (ValueSorted[i].Value == match3.Item1)
                        match3 = new Tuple<Value?, int>(match3.Item1, match3.Item2 + 1);
                }
                else
                {
                    if (match1.Item2 == 0)
                        match1 = new Tuple<Value?, int>(ValueSorted[i].Value, 0);
                    else if (match2.Item2 == 0)
                        match2 = new Tuple<Value?, int>(ValueSorted[i].Value, 0);
                    else if (match3.Item2 == 0)
                        match3 = new Tuple<Value?, int>(ValueSorted[i].Value, 0);
                }
            }

            // Check for StraightFlush
            if (straightFlush.Item2 >= 4)
                results[0] = 1; // StraightFlush

            // Check for FourOfAKind
            if (match1.Item2 == 3 || match2.Item2 == 3 || match3.Item2 == 3)
                results[1] = 1; // FourOfAKind

            // Check for FullHouse
            if ((match1.Item2 == 2 && match2.Item2 == 2) || (match1.Item2 == 2 && match3.Item2 == 2) || (match2.Item2 == 2 && match3.Item2 == 2))
                results[2] = 1; // Fullhouse

            // Check for flush
            if (clubs >= 5 || diamonds >= 5 || hearts >= 5 || spades >= 5)
                results[3] = 1; // Flush

            // Check for straight
            if (sequence.Item2 >= 5)
                results[4] = 1; // Straight

            if (((match1.Item2 == 2) && (match2.Item2 == 1 || match3.Item2 == 1)) || ((match2.Item2 == 2) && (match1.Item2 == 1 || match3.Item2 == 1)) || ((match3.Item2 == 2) && (match1.Item2 == 1 || match2.Item2 == 1)))
                results[2] = 1; // Fullhouse
            if (match1.Item2 == 2 || match2.Item2 == 2 || match3.Item2 == 2)
                results[5] = 1; // ThreeOfAKind
            if ((match1.Item2 == 1 && match2.Item2 == 1) || (match1.Item2 == 1 && match3.Item2 == 1) || (match2.Item2 == 1 && match3.Item2 == 1))
                results[6] = 1; // TwoPair
            if (match1.Item2 == 1 || match2.Item2 == 1 || match3.Item2 == 1)
                results[7] = 1; // Pair

            // Ace exception
            if (hand.FindCardInDeck(hand, Value.Ace) && hand.FindCardInDeck(hand, Value.Two) && hand.FindCardInDeck(hand, Value.Three) && hand.FindCardInDeck(hand, Value.Four) && hand.FindCardInDeck(hand, Value.Five))
            {
                if (results[3] == 1)
                    results[0] = 1; // StraightFlush
                else
                    results[4] = 1; // Straight
            }
        }
    }
}
