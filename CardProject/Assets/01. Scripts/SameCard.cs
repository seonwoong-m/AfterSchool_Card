using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SameCard : MonoBehaviour
{
    public List<CardHandler> cards = new List<CardHandler>();

    public int maxHP;
    public int currentHP;
    public Text hp;

    void Start()
    {
        currentHP = maxHP;
        hp.text = $"{currentHP}";
    }

    public void Update()
    {
        if (cards[1] != null)
        {
            if (cards[0].card.id == cards[1].card.id)
            {
                if (cards[0].card.tagString == cards[1].card.tagString)
                {
                    currentHP -= int.Parse(cards[0].card.id) * 2;
                    hp.text = $"{currentHP}";
                }
                else
                {
                    currentHP -= int.Parse(cards[0].card.id);
                    hp.text = $"{currentHP}";
                }

                cards.Clear();
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
}
