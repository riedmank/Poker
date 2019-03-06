using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Classes
{
    public class Deck<T> : IEnumerable
    {
        T[] deck = new T[5];
        int counter = 0;

        /// <summary>
        /// Creates an indexer
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>returns value at index</returns>
        public T this[int i]
        {
            get { return deck[i]; }
            set { deck[i] = value; }
        }

        /// <summary>
        /// Add a card to the deck collection
        /// </summary>
        /// <param name="card">Takes in the card to be added</param>
        public void Add(T card)
        {
            if (counter == deck.Length)
                Array.Resize(ref deck, deck.Length * 2);
            deck[counter++] = card;
        }

        /// <summary>
        /// Removes a card from the deck
        /// </summary>
        /// <param name="card">The card to be removed</param>
        public void Remove(T card)
        {
            bool check = deck[0].Equals(card);
            for (int i = 0; i < counter; i++)
            {
                if (!check)
                {
                    deck[i] = deck[i];
                    if (i + 1 == counter)
                        return;
                    else
                        check = deck[i + 1].Equals(card);
                }
                else
                    deck[i] = deck[i + 1];
            }
            counter--;
        }

        /// <summary>
        /// Finds a card in the deck at a specific index
        /// </summary>
        /// <param name="index">Integer index in deck</param>
        /// <returns>Returns card at index in deck</returns>
        public T FindCardInDeck(int index)
        {
            if (index > counter)
                return default(T);
            else
                return deck[index];
        }

        /// <summary>
        /// Creates a foreach method for use by the deck collection
        /// </summary>
        /// <returns>Returns every element in the deck</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < counter; i++)
            {
                yield return deck[i];
            }
        }

        /// <summary>
        /// Required code from IEnumerable interface
        /// </summary>
        /// <returns>Returns GetEnumerator method</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
