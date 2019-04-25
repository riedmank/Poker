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

            Deck<Card> playerOneHand = new Deck<Card>();
            Deck<Card> playerTwoHand = new Deck<Card>();

            byte[] playerOneResults = new byte[9];
            playerOneResults[0] = 0; // StraightFlush
            playerOneResults[1] = 0; // FourOfAKind
            playerOneResults[2] = 0; // FullHouse
            playerOneResults[3] = 0; // Flush
            playerOneResults[4] = 1; // Straight
            playerOneResults[5] = 0; // ThreeOfAKind
            playerOneResults[6] = 0; // TwoPair
            playerOneResults[7] = 0; // Pair
            playerOneResults[8] = 1; // HighCard
            int playerOneResult = 0;

            byte[] playerTwoResults = new byte[9];
            playerTwoResults[0] = 0; // StraightFlush
            playerTwoResults[1] = 0; // FourOfAKind
            playerTwoResults[2] = 0; // FullHouse
            playerTwoResults[3] = 0; // Flush
            playerTwoResults[4] = 1; // Straight
            playerTwoResults[5] = 0; // ThreeOfAKind
            playerTwoResults[6] = 0; // TwoPair
            playerTwoResults[7] = 0; // Pair
            playerTwoResults[8] = 1; // HighCard
            int playerTwoResult = 0;

            int winner = 0;

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

            Console.WriteLine("Welcome to Poker");
            Console.WriteLine("Would you like to score a random hand or custom hand? (1 for custom, 2 for random)");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("PlayerOne hand:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Enter value of card {i + 1}: (a, 2 - 10, j, q, k)");
                    string userValue = Console.ReadLine().ToUpper();
                    Console.WriteLine($"Enter suit of card {i + 1}: (c, d, h, s)");
                    string userSuit = Console.ReadLine().ToUpper();

                    playerOneHand.Add(HandBuilder(userValue, userSuit));
                }
                Console.WriteLine("==============================================");
                Console.WriteLine("PlayerTwo hand:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Enter value of card {i + 1}: (a, 2 - 10, j, q, k)");
                    string userValue = Console.ReadLine().ToUpper();
                    Console.WriteLine($"Enter suit of card {i + 1}: (c, d, h, s)");
                    string userSuit = Console.ReadLine().ToUpper();

                    playerTwoHand.Add(HandBuilder(userValue, userSuit));
                }
                CheckHandFiveCards(playerOneHand, playerOneResults);
                CheckHandFiveCards(playerTwoHand, playerTwoResults);
            }
            else if (choice == "2")
            {
                // adds cards to hand
                Random rng = new Random();
                int counter = 52;
                for (int j = 5; j > 0; j--)
                {
                    Card card = null;
                    while (card == null)
                    {
                        card = myDeck.FindCardInDeckByIndex(rng.Next(0, counter--));
                    }
                    playerOneHand.Add(card);
                    myDeck.Remove(card);
                }

                for (int j = 5; j > 0; j--)
                {
                    Card card = null;
                    while (card == null)
                    {
                        card = myDeck.FindCardInDeckByIndex(rng.Next(0, counter--));
                    }
                    playerTwoHand.Add(card);
                    myDeck.Remove(card);
                }
                CheckHandFiveCards(playerOneHand, playerOneResults);
                CheckHandFiveCards(playerTwoHand, playerTwoResults);
            }

            Console.WriteLine("=================================================");
            Console.WriteLine("PlayerOne hand:");
            foreach (Card item in playerOneHand)
            {
                Console.WriteLine($"{item.Value} of {item.Suit}");
            }
            Console.WriteLine("=================================================");
            Console.WriteLine("PlayerTwo hand:");
            foreach (Card item in playerTwoHand)
            {
                Console.WriteLine($"{item.Value} of {item.Suit}");
            }

            winner = GetWinner(playerOneHand, playerOneResults, playerTwoHand, playerTwoResults);

            //// Used for testing purposes
            //Card card0 = new Card(Suit.Clubs, Value.Two);
            //Card card1 = new Card(Suit.Clubs, Value.Three);
            //Card card2 = new Card(Suit.Clubs, Value.Four);
            //Card card3 = new Card(Suit.Clubs, Value.Seven);
            //Card card4 = new Card(Suit.Hearts, Value.Seven);

            //Card card5 = new Card(Suit.Spades, Value.Two);
            //Card card6 = new Card(Suit.Spades, Value.Three);
            //Card card7 = new Card(Suit.Spades, Value.Four);
            //Card card8 = new Card(Suit.Diamonds, Value.Seven);
            //Card card9 = new Card(Suit.Spades, Value.Seven);

            //Deck<Card> fakeHandPlayerOne = new Deck<Card>();
            //fakeHandPlayerOne.Add(card0);
            //fakeHandPlayerOne.Add(card1);
            //fakeHandPlayerOne.Add(card2);
            //fakeHandPlayerOne.Add(card3);
            //fakeHandPlayerOne.Add(card4);

            //Deck<Card> fakeHandPlayerTwo = new Deck<Card>();
            //fakeHandPlayerTwo.Add(card5);
            //fakeHandPlayerTwo.Add(card6);
            //fakeHandPlayerTwo.Add(card7);
            //fakeHandPlayerTwo.Add(card8);
            //fakeHandPlayerTwo.Add(card9);

            //CheckHandFiveCards(fakeHandPlayerOne, playerOneResults);
            //CheckHandFiveCards(fakeHandPlayerTwo, playerTwoResults);

            //winner = GetWinner(fakeHandPlayerOne, playerOneResults, fakeHandPlayerTwo, playerTwoResults);

            for (int i = 0; i < playerOneResults.Length; i++)
            {
                if (playerOneResults[i] == 1)
                {
                    playerOneResult = i;
                    break;
                }
            }

            for (int i = 0; i < playerTwoResults.Length; i++)
            {
                if (playerTwoResults[i] == 1)
                {
                    playerTwoResult = i;
                    break;
                }
            }

            Console.WriteLine("=================================================");
            if (winner == 1)
            {
                Console.WriteLine("PlayerOne wins with:");
                Console.WriteLine(possibleHands[playerOneResult]);
            }
            else if (winner == 2)
            {
                Console.WriteLine("PlayerTwo wins with:");
                Console.WriteLine(possibleHands[playerTwoResult]);
            }
            else
                Console.WriteLine("Players tie. Split pot");

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
        /// Finds the winner between two hands of cards
        /// </summary>
        /// <param name="playerOneHand">PlayerOne hand of cards</param>
        /// <param name="playerOneResults">PlayerOne results from checkHand</param>
        /// <param name="playerTwoHand">PlayerTwo hand of cards</param>
        /// <param name="playerTwoResults">PlayerTwo results from checkHand</param>
        public static int GetWinner(Deck<Card> playerOneHand, byte[] playerOneResults, Deck<Card> playerTwoHand, byte[] playerTwoResults)
        {
            int winner = 0;
            for (int i = 0; i < playerOneResults.Length; i++)
            {
                if (playerOneResults[i] == 1 && playerTwoResults[i] == 0)
                {
                    winner = 1;
                    break;
                }
                else if (playerOneResults[i] == 0 && playerTwoResults[i] == 1)
                {
                    winner = 2;
                    break;
                }
                else if (playerOneResults[i] == 1 && playerTwoResults[i] == 1)
                {
                    if (i == 0 || i == 3 || i == 4 || i == 8)
                    {
                        for (int j = 4; j >= 0; j--)
                        {
                            if (playerOneHand[j].Value > playerTwoHand[j].Value)
                            {
                                winner = 1;
                                break;
                            }
                            if (playerOneHand[j].Value < playerTwoHand[j].Value)
                            {
                                winner = 2;
                                break;
                            }
                        }
                        break;
                    }
                    else if (i == 1 || i == 2 || i == 5)
                    {
                        if (playerOneHand[2].Value > playerTwoHand[2].Value)
                        {
                            winner = 1;
                            break;
                        }
                        if (playerOneHand[2].Value < playerTwoHand[2].Value)
                        {
                            winner = 2;
                            break;
                        }
                    }
                    else if (i == 6 || i == 7)
                    {
                        Tuple<Value?, int> match1PlayerOne = new Tuple<Value?, int>(playerOneHand[0].Value, 0);
                        Tuple<Value?, int> match2PlayerOne = new Tuple<Value?, int>(null, 0);
                        Value? highCardPlayerOne = playerOneHand[0].Value;
                        Tuple<Value?, int> match1PlayerTwo = new Tuple<Value?, int>(playerTwoHand[0].Value, 0);
                        Tuple<Value?, int> match2PlayerTwo = new Tuple<Value?, int>(null, 0);
                        Value? highCardPlayerTwo = playerTwoHand[0].Value;
                        for (int k = 1; k < 5; k++)
                        {
                            // Get playerOne matches
                            if (playerOneHand[k].Value == match1PlayerOne.Item1 || playerOneHand[k].Value == match2PlayerOne.Item1)
                            {
                                if (playerOneHand[k].Value == match1PlayerOne.Item1)
                                    match1PlayerOne = new Tuple<Value?, int>(playerOneHand[k].Value, (match1PlayerOne.Item2 + 1));
                                if (playerOneHand[k].Value == match2PlayerOne.Item1)
                                    match2PlayerOne = new Tuple<Value?, int>(playerOneHand[k].Value, (match2PlayerOne.Item2 + 1));
                            }
                            else
                            {
                                if (match1PlayerOne.Item2 == 0)
                                    match1PlayerOne = new Tuple<Value?, int>(playerOneHand[k].Value, 0);

                                if (match2PlayerOne.Item2 == 0)
                                    match2PlayerOne = new Tuple<Value?, int>(playerOneHand[k].Value, 0);
                            }
                            // Get playerTwo matches
                            if (playerTwoHand[k].Value == match1PlayerTwo.Item1 || playerTwoHand[k].Value == match2PlayerTwo.Item1)
                            {
                                if (playerTwoHand[k].Value == match1PlayerTwo.Item1)
                                    match1PlayerTwo = new Tuple<Value?, int>(playerTwoHand[k].Value, (match1PlayerTwo.Item2 + 1));
                                if (playerTwoHand[k].Value == match2PlayerTwo.Item1)
                                    match2PlayerTwo = new Tuple<Value?, int>(playerTwoHand[k].Value, (match2PlayerTwo.Item2 + 1));
                            }
                            else
                            {
                                if (match1PlayerTwo.Item2 == 0)
                                    match1PlayerTwo = new Tuple<Value?, int>(playerTwoHand[k].Value, 0);
                                if (match2PlayerTwo.Item2 == 0)
                                    match2PlayerTwo = new Tuple<Value?, int>(playerTwoHand[k].Value, 0);
                            }

                            // Find HighCard
                            if (playerOneHand[k].Value > highCardPlayerOne && playerOneHand[k].Value != match1PlayerOne.Item1 && playerOneHand[k].Value != match2PlayerOne.Item1)
                                highCardPlayerOne = playerOneHand[k].Value;
                            if (playerTwoHand[k].Value > highCardPlayerTwo && playerTwoHand[k].Value != match1PlayerTwo.Item1 && playerTwoHand[k].Value != match2PlayerTwo.Item1)
                                highCardPlayerTwo = playerTwoHand[k].Value;
                        }

                        if (i == 6)
                        {
                            if (match2PlayerOne.Item1 > match2PlayerTwo.Item1)
                            {
                                winner = 1;
                                break;
                            }
                            else if (match2PlayerOne.Item1 < match2PlayerTwo.Item1)
                            {
                                winner = 2;
                                break;
                            }
                            else
                            {
                                if (match1PlayerOne.Item1 > match1PlayerTwo.Item1)
                                {
                                    winner = 1;
                                    break;
                                }
                                else if (match1PlayerOne.Item1 < match1PlayerTwo.Item1)
                                {
                                    winner = 2;
                                    break;
                                }
                                else
                                {
                                    if (highCardPlayerOne > highCardPlayerTwo)
                                    {
                                        winner = 1;
                                        break;
                                    }
                                    else if (highCardPlayerOne < highCardPlayerTwo)
                                    {
                                        winner = 2;
                                        break;
                                    }
                                }
                            }
                        }

                        if (i == 7)
                        {
                            if (match1PlayerOne.Item1 > match1PlayerTwo.Item1)
                            {
                                winner = 1;
                                break;
                            }
                            else if (match1PlayerOne.Item1 < match1PlayerTwo.Item1)
                            {
                                winner = 2;
                                break;
                            }
                            else
                            {
                                for (int l = 4; l >= 0; l--)
                                {
                                    if (playerOneHand[l].Value != match1PlayerOne.Item1 && playerTwoHand[l].Value == match1PlayerTwo.Item1)
                                    {
                                        winner = 1;
                                        break;
                                    }
                                    if (playerOneHand[l].Value == match1PlayerOne.Item1 && playerTwoHand[l].Value != match1PlayerTwo.Item1)
                                    {
                                        winner = 2;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return winner;
        }

        /// <summary>
        /// Sorts the cards in the hand by value
        /// </summary>
        /// <param name="hand">Hand that was dealt</param>
        public static void Sort(Deck<Card> hand)
        {
            for (int i = 0; i < 5; i++)
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
        /// Finds the best Poker hand in the seven cards provided
        /// </summary>
        /// <param name="hand">Hand of seven cards</param>
        /// <param name="results">Array of hand results</param>
        public static void CheckHandSevenCards(Deck<Card> hand, byte[] results)
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

        /// <summary>
        /// Finds the best Poker hand in the five cards provided
        /// </summary>
        /// <param name="hand">Hand of five cards</param>
        /// <param name="results">Array of hand results</param>
        public static void CheckHandFiveCards(Deck<Card> hand, byte[] results)
        {
            Sort(hand);

            Tuple<Value?, int> match1 = new Tuple<Value?, int>(hand[0].Value, 0);
            Tuple<Value?, int> match2 = new Tuple<Value?, int>(null, 0);
            Tuple<Suit?, int> suitMatch = new Tuple<Suit?, int>(hand[0].Suit, 0);
            Tuple<Value?, int> sequence = new Tuple<Value?, int>(hand[0].Value, 0);

            for (int i = 1; i < 5; i++)
            {
                // Sequence checks
                if (hand[i].Value == (sequence.Item1 + 1))
                    sequence = new Tuple<Value?, int>(hand[i].Value, (sequence.Item2 + 1));
                else
                    sequence = new Tuple<Value?, int>(hand[i].Value, 0);

                // Suit checks
                if (hand[i].Suit == suitMatch.Item1)
                    suitMatch = new Tuple<Suit?, int>(hand[i].Suit, (suitMatch.Item2 + 1));
                else
                    suitMatch = new Tuple<Suit?, int>(hand[i].Suit, 0);

                // Match checks
                if (hand[i].Value == match1.Item1 || hand[i].Value == match2.Item1)
                {
                    if (hand[i].Value == match1.Item1)
                        match1 = new Tuple<Value?, int>(hand[i].Value, (match1.Item2 + 1));
                    if (hand[i].Value == match2.Item1)
                        match2 = new Tuple<Value?, int>(hand[i].Value, (match2.Item2 + 1));
                }
                else
                {
                    if (match1.Item2 == 0)
                        match1 = new Tuple<Value?, int>(hand[i].Value, 0);
                    else if (match2.Item2 == 0)
                        match2 = new Tuple<Value?, int>(hand[i].Value, 0);
                }
            }

            // Check for StraightFlush
            if (sequence.Item2 == 4 && suitMatch.Item2 == 4)
                results[0] = 1; // StraightFlush

            // Check for StraightFlush with Ace Exception
            if (hand.FindCardInDeck(hand, Value.Ace) && hand.FindCardInDeck(hand, Value.Two) && hand.FindCardInDeck(hand, Value.Three) && hand.FindCardInDeck(hand, Value.Four) && hand.FindCardInDeck(hand, Value.Five) && suitMatch.Item2 == 4)
                results[0] = 1; // StraightFlush

            // Check for FourOfAKind
            if (match1.Item2 == 3 || match2.Item2 == 3)
                results[1] = 1; // FourOfAKind

            // Check for FullHouse
            if ((match1.Item2 == 2 && match2.Item2 == 1) || (match1.Item2 == 1 && match2.Item2 == 2))
                results[2] = 1; // FullHouse

            // Check for Flush
            if (suitMatch.Item2 == 4)
                results[3] = 1; // Flush

            // Check for Straight
            if (sequence.Item2 < 4)
                results[4] = 0; // Straight

            // Check for Straight with Ace Exception
            if (hand.FindCardInDeck(hand, Value.Ace) && hand.FindCardInDeck(hand, Value.Two) && hand.FindCardInDeck(hand, Value.Three) && hand.FindCardInDeck(hand, Value.Four) && hand.FindCardInDeck(hand, Value.Five))
                results[4] = 1; // Straight

            // Check for ThreeOfAKind
            if (match1.Item2 == 2 || match2.Item2 == 2)
                results[5] = 1; // ThreeOfAKind

            // Check for TwoPair
            if (match1.Item2 == 1 && match2.Item2 == 1)
                results[6] = 1; // TwoPair

            // Check for Pair
            if (match1.Item2 == 1 || match2.Item2 == 1)
                results[7] = 1; // Pair
        }
    }
}
