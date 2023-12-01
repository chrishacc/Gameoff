using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDriver : MonoBehaviour
{
    public CardBank startingDeck;
    
    [Header("Manager")]
    [SerializeField]private CardManager cardManager;

    [SerializeField]private CardDeckManager cardDeckManager;

    [SerializeField]private CardDisplayManager cardDisplayManager;

    private List<CardTemplate> playerDeck = new List<CardTemplate>();

    private void Start()
    {
        cardManager.Initialize();

        CreatPlayer();
        
    }

    private void CreatPlayer()
    {
        foreach (var item in startingDeck.Items)
        {
            for (int i = 0; i < item.Amount; i++)
            {
                playerDeck.Add(item.Card);
            }
        }

        Initialize();
        //cardManager.CreatePlayer(playerDeck);
    }

    public void Initialize()
    {
        cardDeckManager.LoadDeck(playerDeck);
        cardDeckManager.ShuffleDeck();

        cardDisplayManager.Initialize(cardManager);

        cardDeckManager.DrawCardFromDeck(5);
    }
}
