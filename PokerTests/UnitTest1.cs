using System;
using Xunit;
using Poker.Classes;
using static Poker.Program;

namespace PokerTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests for StraightFlush Ace Exception
        /// </summary>
        [Fact]
        public void StraightFlushAceException()
        {
            Card card1 = new Card(Suit.Clubs, Value.Ace);
            Card card2 = new Card(Suit.Clubs, Value.Two);
            Card card3 = new Card(Suit.Clubs, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Four);
            Card card5 = new Card(Suit.Clubs, Value.Five);
            Card card6 = new Card(Suit.Diamonds, Value.Queen);
            Card card7 = new Card(Suit.Diamonds, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[0]);
        }

        /// <summary>
        /// Tests for StraightFlush with no gaps
        /// </summary>
        [Fact]
        public void StraightFlushTestNoGaps()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Three);
            Card card3 = new Card(Suit.Clubs, Value.Four);
            Card card4 = new Card(Suit.Clubs, Value.Five);
            Card card5 = new Card(Suit.Clubs, Value.Six);
            Card card6 = new Card(Suit.Diamonds, Value.Queen);
            Card card7 = new Card(Suit.Diamonds, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[0]);
        }

        /// <summary>
        /// Tests for StraightFlush with gaps
        /// </summary>
        [Fact]
        public void StraightFlushTestWithGaps()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Three);
            Card card3 = new Card(Suit.Spades, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Four);
            Card card5 = new Card(Suit.Diamonds, Value.Four);
            Card card6 = new Card(Suit.Clubs, Value.Five);
            Card card7 = new Card(Suit.Clubs, Value.Six);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[0]);
        }

        /// <summary>
        /// Tests for FourOfAKind with a FullHouse
        /// </summary>
        [Fact]
        public void FourOfAKindFullHouse()
        {
            Card card1 = new Card(Suit.Clubs, Value.Four);
            Card card2 = new Card(Suit.Diamonds, Value.Four);
            Card card3 = new Card(Suit.Hearts, Value.Four);
            Card card4 = new Card(Suit.Spades, Value.Four);
            Card card5 = new Card(Suit.Clubs, Value.Seven);
            Card card6 = new Card(Suit.Diamonds, Value.Seven);
            Card card7 = new Card(Suit.Hearts, Value.Seven);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[1]);
        }

        /// <summary>
        /// Tests for FourOfAKind with a Flush
        /// </summary>
        [Fact]
        public void FourOfAKindFlush()
        {
            Card card1 = new Card(Suit.Clubs, Value.Four);
            Card card2 = new Card(Suit.Clubs, Value.Four);
            Card card3 = new Card(Suit.Spades, Value.Four);
            Card card4 = new Card(Suit.Clubs, Value.Four);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Clubs, Value.Seven);
            Card card7 = new Card(Suit.Clubs, Value.Seven);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[1]);
        }
               
        /// <summary>
        /// Tests for FourOfAKind with a Pair
        /// </summary>
        [Fact]
        public void FourOfAKindPair()
        {
            Card card1 = new Card(Suit.Clubs, Value.Four);
            Card card2 = new Card(Suit.Diamonds, Value.Four);
            Card card3 = new Card(Suit.Hearts, Value.Four);
            Card card4 = new Card(Suit.Spades, Value.Four);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Clubs, Value.Seven);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[1]);
        }

        /// <summary>
        /// Tests for FullHouse with Flush
        /// </summary>
        [Fact]
        public void FullHouseWithFlush()
        {
            Card card1 = new Card(Suit.Clubs, Value.Four);
            Card card2 = new Card(Suit.Clubs, Value.Four);
            Card card3 = new Card(Suit.Spades, Value.Four);
            Card card4 = new Card(Suit.Clubs, Value.Seven);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Clubs, Value.Queen);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[2]);
        }

        /// <summary>
        /// Tests for FullHouse with TwoPair
        /// </summary>
        [Fact]
        public void FullHouseWithTwoPair()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Clubs, Value.King);
            Card card4 = new Card(Suit.Diamonds, Value.King);
            Card card5 = new Card(Suit.Hearts, Value.Ace);
            Card card6 = new Card(Suit.Diamonds, Value.Ace);
            Card card7 = new Card(Suit.Spades, Value.Ace);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[2]);
        }

        /// <summary>
        /// Tests for FullHouse with 2 ThreeOfAKinds
        /// </summary>
        [Fact]
        public void FullHouseWithThreeOfAKinds()
        {
            Card card1 = new Card(Suit.Clubs, Value.Four);
            Card card2 = new Card(Suit.Diamonds, Value.Four);
            Card card3 = new Card(Suit.Hearts, Value.Four);
            Card card4 = new Card(Suit.Clubs, Value.Seven);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Hearts, Value.Seven);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[2]);
        }

        /// <summary>
        /// Tests for Flush with ThreeOfAKind
        /// </summary>
        [Fact]
        public void FlushWithThreOfAKind()
        {
            Card card1 = new Card(Suit.Clubs, Value.Three);
            Card card2 = new Card(Suit.Spades, Value.Three);
            Card card3 = new Card(Suit.Diamonds, Value.Three);
            Card card4 = new Card(Suit.Diamonds, Value.Seven);
            Card card5 = new Card(Suit.Diamonds, Value.Ten);
            Card card6 = new Card(Suit.Diamonds, Value.Jack);
            Card card7 = new Card(Suit.Diamonds, Value.Queen);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[3]);
        }

        /// <summary>
        /// Tests for Flush with TwoPair
        /// </summary>
        [Fact]
        public void FlushWithTwoPair()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Clubs, Value.Three);
            Card card4 = new Card(Suit.Diamonds, Value.Three);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Diamonds, Value.Eight);
            Card card7 = new Card(Suit.Diamonds, Value.Ten);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[3]);
        }

        /// <summary>
        /// Tests for Flush with Pair
        /// </summary>
        [Fact]
        public void FlushWithPair()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Diamonds, Value.Seven);
            Card card4 = new Card(Suit.Diamonds, Value.Eight);
            Card card5 = new Card(Suit.Diamonds, Value.Jack);
            Card card6 = new Card(Suit.Diamonds, Value.Queen);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[3]);
        }

        /// <summary>
        /// Tests for Straight with ThreeOfAKind
        /// </summary>
        [Fact]
        public void StraightWithThreeOfAKind()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Spades, Value.Two);
            Card card4 = new Card(Suit.Clubs, Value.Three);
            Card card5 = new Card(Suit.Diamonds, Value.Four);
            Card card6 = new Card(Suit.Clubs, Value.Five);
            Card card7 = new Card(Suit.Clubs, Value.Six);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[4]);
        }

        /// <summary>
        /// Tests for Straight with TwoPair
        /// </summary>
        [Fact]
        public void StraightWithTwoPair()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Spades, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Three);
            Card card5 = new Card(Suit.Diamonds, Value.Four);
            Card card6 = new Card(Suit.Clubs, Value.Five);
            Card card7 = new Card(Suit.Clubs, Value.Six);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[4]);
        }

        /// <summary>
        /// Tests for Straight with Pair
        /// </summary>
        [Fact]
        public void StraightWithPair()
        {
            Card card1 = new Card(Suit.Diamonds, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Two);
            Card card3 = new Card(Suit.Spades, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Four);
            Card card5 = new Card(Suit.Diamonds, Value.Five);
            Card card6 = new Card(Suit.Clubs, Value.Six);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[4]);
        }

        /// <summary>
        /// Tests for ThreeOfAKind
        /// </summary>
        [Fact]
        public void ThreeOfAKindWith1()
        {
            Card card1 = new Card(Suit.Clubs, Value.Three);
            Card card2 = new Card(Suit.Diamonds, Value.Three);
            Card card3 = new Card(Suit.Spades, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Four);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Clubs, Value.Eight);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[5]);
        }

        /// <summary>
        /// Tests for ThreeOfAKind
        /// </summary>
        [Fact]
        public void ThreeOfAKind2()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Three);
            Card card3 = new Card(Suit.Spades, Value.Four);
            Card card4 = new Card(Suit.Clubs, Value.Four);
            Card card5 = new Card(Suit.Diamonds, Value.Four);
            Card card6 = new Card(Suit.Clubs, Value.Seven);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[5]);
        }

        /// <summary>
        /// Tests for ThreeOfAKind
        /// </summary>
        [Fact]
        public void ThreeOfAKind3()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Three);
            Card card3 = new Card(Suit.Spades, Value.Five);
            Card card4 = new Card(Suit.Clubs, Value.Ten);
            Card card5 = new Card(Suit.Diamonds, Value.King);
            Card card6 = new Card(Suit.Hearts, Value.King);
            Card card7 = new Card(Suit.Spades, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[5]);
        }

        /// <summary>
        /// Tests for TwoPair with gap between pairs
        /// </summary>
        [Fact]
        public void TwoPairWithGap()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Hearts, Value.Two);
            Card card3 = new Card(Suit.Spades, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Five);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Clubs, Value.King);
            Card card7 = new Card(Suit.Hearts, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[6]);
        }

        /// <summary>
        /// Tests for TwoPair with no gap between pairs
        /// </summary>
        [Fact]
        public void TwoPairWithNoGap()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Spades, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Three);
            Card card5 = new Card(Suit.Diamonds, Value.Eight);
            Card card6 = new Card(Suit.Clubs, Value.Ten);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[6]);
        }

        /// <summary>
        /// Tests for TwoPair with Ace High
        /// </summary>
        [Fact]
        public void TwoPairWithAceHigh()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Spades, Value.Three);
            Card card4 = new Card(Suit.Clubs, Value.Four);
            Card card5 = new Card(Suit.Diamonds, Value.King);
            Card card6 = new Card(Suit.Clubs, Value.King);
            Card card7 = new Card(Suit.Clubs, Value.Ace);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[6]);
        }

        /// <summary>
        /// Tests for Pair
        /// </summary>
        [Fact]
        public void PairTest1()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Two);
            Card card3 = new Card(Suit.Spades, Value.Four);
            Card card4 = new Card(Suit.Clubs, Value.Seven);
            Card card5 = new Card(Suit.Diamonds, Value.Eight);
            Card card6 = new Card(Suit.Spades, Value.Ten);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[7]);
        }

        /// <summary>
        /// Tests for Pair
        /// </summary>
        [Fact]
        public void PairTest2()
        {
            Card card1 = new Card(Suit.Spades, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Three);
            Card card3 = new Card(Suit.Spades, Value.Five);
            Card card4 = new Card(Suit.Clubs, Value.Seven);
            Card card5 = new Card(Suit.Diamonds, Value.Ten);
            Card card6 = new Card(Suit.Clubs, Value.Ace);
            Card card7 = new Card(Suit.Diamonds, Value.Ace);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[7]);
        }

        /// <summary>
        /// Tests for Pair
        /// </summary>
        [Fact]
        public void PairTest3()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Hearts, Value.Four);
            Card card3 = new Card(Suit.Spades, Value.Five);
            Card card4 = new Card(Suit.Clubs, Value.Seven);
            Card card5 = new Card(Suit.Diamonds, Value.Seven);
            Card card6 = new Card(Suit.Clubs, Value.King);
            Card card7 = new Card(Suit.Diamonds, Value.Ace);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[7]);
        }

        /// <summary>
        /// Tests for HighCard
        /// </summary>
        [Fact]
        public void HighCardTest1()
        {
            Card card1 = new Card(Suit.Diamonds, Value.Two);
            Card card2 = new Card(Suit.Hearts, Value.Five);
            Card card3 = new Card(Suit.Spades, Value.Seven);
            Card card4 = new Card(Suit.Clubs, Value.Jack);
            Card card5 = new Card(Suit.Clubs, Value.Queen);
            Card card6 = new Card(Suit.Clubs, Value.King);
            Card card7 = new Card(Suit.Clubs, Value.Ace);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[8]);
        }

        /// <summary>
        /// Tests for High Card
        /// </summary>
        [Fact]
        public void HighCardTest2()
        {
            Card card1 = new Card(Suit.Spades, Value.Two);
            Card card2 = new Card(Suit.Clubs, Value.Three);
            Card card3 = new Card(Suit.Diamonds, Value.Four);
            Card card4 = new Card(Suit.Hearts, Value.Five);
            Card card5 = new Card(Suit.Diamonds, Value.Ten);
            Card card6 = new Card(Suit.Clubs, Value.Jack);
            Card card7 = new Card(Suit.Clubs, Value.King);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[8]);
        }

        /// <summary>
        /// Tests for HighCard
        /// </summary>
        [Fact]
        public void HighCardTest3()
        {
            Card card1 = new Card(Suit.Clubs, Value.Two);
            Card card2 = new Card(Suit.Diamonds, Value.Four);
            Card card3 = new Card(Suit.Hearts, Value.Six);
            Card card4 = new Card(Suit.Spades, Value.Eight);
            Card card5 = new Card(Suit.Clubs, Value.Ten);
            Card card6 = new Card(Suit.Diamonds, Value.Queen);
            Card card7 = new Card(Suit.Hearts, Value.Ace);

            Deck<Card> hand = new Deck<Card>();
            hand.Add(card1);
            hand.Add(card2);
            hand.Add(card3);
            hand.Add(card4);
            hand.Add(card5);
            hand.Add(card6);
            hand.Add(card7);

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

            CheckHand(hand, results);

            Assert.Equal(1, results[8]);
        }
    }
}
