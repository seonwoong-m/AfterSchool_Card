using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDeckManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public CardDeck initialDeck;
    private CardDeck playerDeck;

    public List<CardHandler> cardsInHand;

    int[] cardNum = new int[52];
    int count = 52;

    public Transform hand;

    void Start()
    {
        // Initial Deck 에서 player Deck으로 Clone
        playerDeck = initialDeck.Clone();

        for(int i = 0; i < cardNum.Length; i++)
        {
            cardNum[i] = -1;
        }
    }

    public void Draw()
    {
        int a = Random.Range(0, count);

        // if(cardNum[a] != a)
        // {
        //     cardNum[a] = a;

            if(cardsInHand.Count < 9)
            {
                Card card = playerDeck.Draw(a);
                InstantiateCardObjec(card);
                count--;
            }
        //}
        // else
        // {
        //     Draw();
        // }
        // Draw 호출되면 IOnstantiateCardObject 실행
    }

    public void CardSizeCtrl()
    {
        for(int i = 0; i < cardsInHand.Count; i++)
        {
            cardsInHand[i].GetComponent<CardSize>().isLarge = false;
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
