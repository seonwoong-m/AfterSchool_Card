using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public CardDeck initialDeck;
    private CardDeck playerDeck;

    public List<CardHandler> cardsInHand;

    public Transform hand;

    float drawTime = 0f;

    void Start()
    {
        // Initial Deck 에서 player Deck으로 Clone
        playerDeck = initialDeck.Clone();
    }

    public void Draw()
    {
        // Draw 호출되면 IOnstantiateCardObject 실행
        if(cardsInHand.Count < 9)
        {
            Card card = playerDeck.Draw();
            InstantiateCardObjec(card);
        }
    }

    public void InstantiateCardObjec(Card cardData)
    {
        var cardObject = Instantiate(cardPrefab, hand.transform);
        // cardsInHand에 넣고, CardHandler에서 initialize 진행
        cardObject.GetComponent<CardHandler>().Init(cardData);
        cardsInHand.Add(cardObject.GetComponent<CardHandler>());
    }
}
