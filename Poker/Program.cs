using Poker.Classes;
using System;

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
            results[0] = 1; // StraightFlush
            results[1] = 0; // FourOfAKind
            results[2] = 0; // FullHouse
            results[3] = 0; // Flush
            results[4] = 1; // Straight
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

            Console.WriteLine("Welcome to Poker++");
            Console.WriteLine("Would you like to score a random hand or custom hand? (1 for custom, 2 for random)");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine($"Enter value of card {i + 1}: (a, 2 - 10, j, q, k)");
                    string userValue = Console.ReadLine().ToUpper();
                    Console.WriteLine($"Enter suit of card {i + 1}: (c, d, h, s)");
                    string userSuit = Console.ReadLine().ToUpper();

                    myHand.Add(HandBuilder(userValue, userSuit));
                }
                CheckHand(myHand, results);
            }
            else if (choice == "2")
            {
                // adds cards to hand
                Random rng = new Random();
                int counter = 52;
                for (int j = 7; j > 0; j--)
                {
                    Card card = null;
                    while (card == null)
                    {
                        card = myDeck.FindCardInDeckByIndex(rng.Next(0, counter--));
                    }
                    myHand.Add(card);
                    myDeck.Remove(card);
                }
                CheckHand(myHand, results);
            }

            Console.WriteLine("=================================================");
            Console.WriteLine("Your hand:");
            foreach (Card item in myHand)
            {
                Console.WriteLine($"{item.Value} of {item.Suit}");
            }

            //// Used for testing purposes
            //Card card1 = new Card(Suit.Spades, Value.Seven);
            //Card card2 = new Card(Suit.Hearts, Value.Nine);
            //Card card3 = new Card(Suit.Clubs, Value.Ten);
            //Card card4 = new Card(Suit.Diamonds, Value.Jack);
            //Card card5 = new Card(Suit.Hearts, Value.Queen);
            //Card card6 = new Card(Suit.Hearts, Value.Queen);
            //Card card7 = new Card(Suit.Spades, Value.Ace);

            //Deck<Card> fakeHand = new Deck<Card>();
            //fakeHand.Add(card1);
            //fakeHand.Add(card2);
            //fakeHand.Add(card3);
            //fakeHand.Add(card4);
            //fakeHand.Add(card5);
            //fakeHand.Add(card6);
            //fakeHand.Add(card7);

            //CheckHand(fakeHand, results);

            for (int i = 0; i < results.Length; i++)
            {
                if (results[i] == 1)
                {
                    result = i;
                    break;
                }
            }
            Console.WriteLine("=================================================");
            Console.WriteLine(possibleHands[result]);

            Console.ReadLine();
        }

        /// <summary>
        /// Translates user input into specific card
        /// </summary>
        /// <param name="userValue">Value of user card</param>
        /// <param name="userSuit">Suit of user card</param>
        /// <returns>Card created from user input</returns>
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
        public static void Sort(Deck<Card> hand)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (hand[j].Value > hand[j + 1].Value)
                        Swap(hand, j, j + 1);
                }
            }
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
            Sort(hand);  
                       
            Tuple<Value?, int> match1 = new Tuple<Value?, int>(hand[0].Value, 0);
            Tuple<Value?, int> match2 = new Tuple<Value?, int>(null, 0);
            Tuple<Value?, int> match3 = new Tuple<Value?, int>(null, 0);
            Tuple<Value?, int> sequence = new Tuple<Value?, int>(hand[0].Value, 0);
            Tuple<Value?, int> checkStraightFlush = new Tuple<Value?, int>(hand[0].Value, 0);

            int clubs = 0;
            int diamonds = 0;
            int hearts = 0;
            int spades = 0;

            Suit maxSuit = Suit.Clubs;

            foreach (Card card in hand)
            {
                // Count cards of each Suit
                if (card.Suit == Suit.Clubs)
                    clubs++;
                else if (card.Suit == Suit.Diamonds)
                    diamonds++;
                else if (card.Suit == Suit.Hearts)
                    hearts++;
                else
                    spades++;
            }

            // Setting maxSuit to most prevalent suit
            if (clubs >= 5 || diamonds >= 5 || hearts >= 5 || spades >= 5)
            {
                if (clubs > diamonds && clubs > hearts && clubs > spades)
                    maxSuit = Suit.Clubs;
                else if (diamonds > clubs && diamonds > hearts && diamonds > spades)
                    maxSuit = Suit.Diamonds;
                else if (hearts > clubs && hearts > diamonds && hearts > spades)
                    maxSuit = Suit.Hearts;
                else
                    maxSuit = Suit.Spades;
            }

            for (int i = 1; i < 7; i++)
            {
                if (checkStraightFlush.Item2 < 4) // while a StraightFlush hasn't been found
                {
                    // StraightFlush
                    if (hand[i].Value == (checkStraightFlush.Item1.Value + 1) && hand[i].Suit == maxSuit)
                        checkStraightFlush = new Tuple<Value?, int>(hand[i].Value, checkStraightFlush.Item2 + 1);
                    else if (hand[i].Value == checkStraightFlush.Item1.Value)
                        checkStraightFlush = new Tuple<Value?, int>(checkStraightFlush.Item1, checkStraightFlush.Item2);
                    else
                        checkStraightFlush = new Tuple<Value?, int>(hand[i].Value, 0);
                }

                if (sequence.Item2 < 4) // while a Straight hasn't been found
                {
                    // Sequence
                    if (hand[i].Value == (sequence.Item1 + 1))
                        sequence = new Tuple<Value?, int>(hand[i].Value, sequence.Item2 + 1);
                    else if (hand[i].Value == sequence.Item1)
                        sequence = new Tuple<Value?, int>(hand[i].Value, sequence.Item2);
                    else
                        sequence = new Tuple<Value?, int>(hand[i].Value, 0);
                }

                // Matches
                if (hand[i].Value == match1.Item1 || hand[i].Value == match2.Item1 || hand[i].Value == match3.Item1)
                {
                    if (hand[i].Value == match1.Item1)
                        match1 = new Tuple<Value?, int>(match1.Item1, match1.Item2 + 1);
                    if (hand[i].Value == match2.Item1)
                        match2 = new Tuple<Value?, int>(match2.Item1, match2.Item2 + 1);
                    if (hand[i].Value == match3.Item1)
                        match3 = new Tuple<Value?, int>(match3.Item1, match3.Item2 + 1);
                }
                else
                {
                    if (match1.Item2 == 0)
                        match1 = new Tuple<Value?, int>(hand[i].Value, 0);
                    else if (match2.Item2 == 0)
                        match2 = new Tuple<Value?, int>(hand[i].Value, 0);
                    else if (match3.Item2 == 0)
                        match3 = new Tuple<Value?, int>(hand[i].Value, 0);
                }
            }

            // Check for StraightFlush
            if (checkStraightFlush.Item2 < 4)
                results[0] = 0; // StraightFlush

            // Check for StraightFlush with Ace exception
            if (hand.FindCardInDeckWithSuit(hand, maxSuit, Value.Ace) && hand.FindCardInDeckWithSuit(hand, maxSuit, Value.Two) && hand.FindCardInDeckWithSuit(hand, maxSuit, Value.Three) && hand.FindCardInDeckWithSuit(hand, maxSuit, Value.Four) && hand.FindCardInDeckWithSuit(hand, maxSuit, Value.Five))
                results[0] = 1; // StraightFlush

            // Check for FourOfAKind
            if (match1.Item2 == 3 || match2.Item2 == 3 || match3.Item2 == 3)
                results[1] = 1; // FourOfAKind

            // Check for FullHouse
            if ((match1.Item2 == 2 && match2.Item2 == 2) || (match1.Item2 == 2 && match3.Item2 == 2) || (match2.Item2 == 2 && match3.Item2 == 2))
                results[2] = 1; // Fullhouse
            if (((match1.Item2 == 2) && (match2.Item2 == 1 || match3.Item2 == 1)) || ((match2.Item2 == 2) && (match1.Item2 == 1 || match3.Item2 == 1)) || ((match3.Item2 == 2) && (match1.Item2 == 1 || match2.Item2 == 1)))
                results[2] = 1; // Fullhouse

            // Check for Flush
            if (clubs >= 5 || diamonds >= 5 || hearts >= 5 || spades >= 5)
                results[3] = 1; // Flush

            // Check for Straight
            if (sequence.Item2 < 4)
                results[4] = 0; // Straight

            // Check for Straight with Ace exception
            if (hand.FindCardInDeck(hand, Value.Ace) && hand.FindCardInDeck(hand, Value.Two) && hand.FindCardInDeck(hand, Value.Three) && hand.FindCardInDeck(hand, Value.Four) && hand.FindCardInDeck(hand, Value.Five))
                results[4] = 1; // Straight

            // Check for ThreeOfAKind
            if (match1.Item2 == 2 || match2.Item2 == 2 || match3.Item2 == 2)
                results[5] = 1; // ThreeOfAKind

            // Check for TwoPair
            if ((match1.Item2 == 1 && match2.Item2 == 1) || (match1.Item2 == 1 && match3.Item2 == 1) || (match2.Item2 == 1 && match3.Item2 == 1))
                results[6] = 1; // TwoPair

            // Check for Pair
            if (match1.Item2 == 1 || match2.Item2 == 1 || match3.Item2 == 1)
                results[7] = 1; // Pair
        }
    }
}
