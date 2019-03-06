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
            foreach (Card card in myDeck)
            {
                //Console.WriteLine($"{card.Value} of {card.Suit}");
            }

            /// adds cards to hand
            Random rng = new Random();
            Deck<Card> myHand = new Deck<Card>();
            int counter = 52;
            for (int j = 5; j > 0; j--)
            {
                Card card = null;
                while (card == null)
                {
                    card = myDeck.FindCardInDeck(rng.Next(0, counter--));
                }
                myHand.Add(card);
                myDeck.Remove(card);
            }
            CheckHand(myHand);
            Console.WriteLine("Your hand:");
            foreach (Card item in myHand)
            {
                Console.WriteLine($"{item.Value} of {item.Suit}");
            }

            // Used for testing purposes
            Card card1 = new Card(Suit.Diamonds, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Four);
            Card card3 = new Card(Suit.Diamonds, Value.Seven);
            Card card4 = new Card(Suit.Hearts, Value.Eight);
            Card card5 = new Card(Suit.Hearts, Value.Ace);
            Deck<Card> fakeHand = new Deck<Card>();
            fakeHand.Add(card1);
            fakeHand.Add(card2);
            fakeHand.Add(card3);
            fakeHand.Add(card4);
            fakeHand.Add(card5);
            //CheckHand(fakeHand);

            Console.ReadLine();
        }

        /// <summary>
        /// Checks cards for best hand and displays result
        /// </summary>
        /// <param name="hand">Hand</param>
        public static void CheckHand(Deck<Card> hand)
        {
            SortByValue(hand);

            bool onePair = CheckPair(hand); //works
            bool twoPair = CheckTwoPair(hand); //works
            bool threeOfAKind = CheckThreeOfAKind(hand); //works
            bool straight = CheckStraight(hand); //works; Ace exception brute force
            bool flush = CheckFlush(hand); //works
            bool fullHouse = CheckFullHouse(hand); //works
            bool fourOfAKind = CheckFourOfAKind(hand); //works
            bool straightFlush = CheckStraightFlush(hand); //works
            bool royalFlush = CheckRoyalFlush(hand); //works

            if (royalFlush)
                Console.WriteLine("You got a royal flush");
            else if (straightFlush)
                Console.WriteLine("You got a straight flush");
            else if (fourOfAKind)
                Console.WriteLine("You got four of a kind");
            else if (fullHouse)
                Console.WriteLine("You got a full house");
            else if (flush)
                Console.WriteLine("You got a flush");
            else if (straight)
                Console.WriteLine("You got a straight");
            else if (threeOfAKind)
                Console.WriteLine("You got three of a kind");
            else if (twoPair)
                Console.WriteLine("You got two pair");
            else if (onePair)
                Console.WriteLine("You got a pair");
            else
                Console.WriteLine($"Your high card is a {hand[4].Value} of {hand[4].Suit}");
        }

        /// <summary>
        /// Sorts the cards in the hand by value
        /// </summary>
        /// <param name="hand">Hand that was dealt</param>
        public static void SortByValue(Deck<Card> hand)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
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
        /// Checks for a pair
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckPair(Deck<Card> hand)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (hand[i].Value == hand[j].Value && i != j)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks for two pair
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckTwoPair(Deck<Card> hand)
        {
            if (!CheckPair(hand))
                return false;
            if (hand[0].Value == hand[1].Value && hand[2].Value == hand[3].Value && hand[0].Value != hand[2].Value && hand[0].Value != hand[4].Value && hand[2].Value != hand[4].Value)
                return true;
            else if (hand[0].Value == hand[1].Value && hand[3].Value == hand[4].Value && hand[0].Value != hand[3].Value && hand[0].Value != hand[2].Value && hand[3].Value != hand[2].Value)
                return true;
            else if (hand[1].Value == hand[2].Value && hand[3].Value == hand[4].Value && hand[1].Value != hand[3].Value && hand[0].Value != hand[1].Value && hand[0].Value != hand[3].Value)
                return true;
            return false;
        }

        /// <summary>
        /// Checks for three of a kind
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckThreeOfAKind(Deck<Card> hand)
        {
            if (!CheckPair(hand))
                return false;
            if (hand[0].Value == hand[1].Value && hand[0].Value == hand[2].Value && hand[0].Value != hand[3].Value && hand[0].Value != hand[4].Value)
                return true;
            else if (hand[1].Value == hand[2].Value && hand[1].Value == hand[3].Value && hand[1].Value != hand[0].Value && hand[1].Value != hand[4].Value)
                return true;
            else if (hand[2].Value == hand[3].Value && hand[2].Value == hand[4].Value && hand[2].Value != hand[0].Value && hand[2].Value != hand[1].Value)
                return true;
            return false;
        }

        /// <summary>
        /// Checks for a straight
        /// </summary>
        /// <param name="hand">Hand of cards</param>
        /// <returns>True or false</returns>
        public static bool CheckStraight(Deck<Card> hand)
        {
            for (int i = 0; i < 4; i++)
            {
                if (hand[0].Value == Value.Two && hand[1].Value == Value.Three && hand[2].Value == Value.Four && hand[3].Value == Value.Five && hand[4].Value == Value.Ace)
                    return true;
                if (hand[i].Value + 1 != hand[i + 1].Value)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks for flush
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckFlush(Deck<Card> hand)
        {
            for (int i = 0; i < 4; i++)
            {
                if (hand[i].Suit != hand[i + 1].Suit)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks for full house
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckFullHouse(Deck<Card> hand)
        {
            if (!CheckThreeOfAKind(hand))
                return false;
            if (hand[0].Value == hand[1].Value && hand[0].Value == hand[2].Value && hand[3].Value == hand[4].Value && hand[0].Value != hand[3].Value)
                return true;
            else if (hand[2].Value == hand[3].Value && hand[2].Value == hand[4].Value && hand[0].Value == hand[1].Value && hand[2].Value != hand[0].Value)
                return true;
            return false;
        }

        /// <summary>
        /// Checks for four of a kind
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckFourOfAKind(Deck<Card> hand)
        {
            if (!CheckPair(hand))
                return false;
            if (hand[0].Value == hand[1].Value && hand[0].Value == hand[2].Value && hand[0].Value == hand[3].Value)
                return true;
            else if (hand[4].Value == hand[3].Value && hand[4].Value == hand[2].Value && hand[4].Value == hand[1].Value)
                return true;
            return false;
        }

        /// <summary>
        /// Checks for straight flush
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckStraightFlush(Deck<Card> hand)
        {
            if (!CheckFlush(hand) || !CheckStraight(hand))
                return false;
            return true;
        }

        /// <summary>
        /// Checks for royal flush
        /// </summary>
        /// <param name="hand">Hand</param>
        /// <returns>True or false</returns>
        public static bool CheckRoyalFlush(Deck<Card> hand)
        {
            if (hand[0].Value != Value.Ten)
                return false;
            else if (CheckStraightFlush(hand))
                return true;
            return false;
        }
    }
}
