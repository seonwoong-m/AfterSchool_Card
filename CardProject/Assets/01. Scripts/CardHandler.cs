using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    public Image image;
    public Card card;

    public void Init(Card card)
    {
        this.card = card;
        card.Init(card.id, card.tagString, card.power, card.disposable, card.usable);
        image.sprite = card.power.illust;
    }
}
