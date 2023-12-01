using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckManager : MonoBehaviour
{
    private List<RuntimeCard> cardDeck;

    private const int DeckCapacity = 30;

    public CardDisplayManager cardDisplayManager;

    private void Awake()
    {
        cardDeck = new List<RuntimeCard>(DeckCapacity);
    }

    public int LoadDeck(List<CardTemplate> deck)
    {
        var deckSize = 0;
        foreach (var template in deck)
        {
            if(template == null)
                continue;

            var card = new RuntimeCard
            {
                Template = template
            };

            cardDeck.Add(card);
            ++deckSize;
        }

        return deckSize;
    }

    public void ShuffleDeck()
    {
        cardDeck.Shuffle();
    }

    public void DrawCardFromDeck(int amount)
    {
        var deckSize = cardDeck.Count;

        if(deckSize >= amount )
        {
            var previousDeckSize = deckSize;

            var drawnCards = new List<RuntimeCard>(amount);

            for(var i = 0; i < amount; i++)
            {
                var card = cardDeck[0];
                cardDeck.RemoveAt(0);

                drawnCards.Add(card);
            }

            cardDisplayManager.CreateHandCards(drawnCards);
        }

    }
}
