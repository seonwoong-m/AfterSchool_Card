using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDeck", menuName = "AfterSchool/CardGame/Deck")]
public class CardDeck : ScriptableObject
{
    public List<Card> deck;

    public void Init()
    {
        deck = new List<Card>();
    }

    public void Put(Card _card)
    {
        Debug.Assert(_card != null);
        deck.Add(_card);
    }

    public void Put(CardDeck _deck)
    {
        var cards = _deck.DrawAll();
        deck.AddRange(cards);
    }

    public Card Draw(int a)
    {
        

        if(deck.Count == 0)
        {
            return null;
        }
        Card card = deck[a];
        deck.Remove(card);
        return card;
    }

    public List<Card> DrawAll()
    {
        var cards = new List<Card>(deck);
        deck.Clear();
        return cards;
    }

    public void Shuffle()
    {
        var randomRange = new System.Random();
        int n = deck.Count;

        while(n > 0)
        {
            n--;
            int k = randomRange.Next(n + 1);
            var value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }

    public CardDeck Clone()
    {
        CardDeck newDeck = CreateInstance<CardDeck>();
        newDeck.Init();
        
        foreach (var card in deck)
        {
            newDeck.Put(card.Clone()); 
        }

        return newDeck;
    }
}
