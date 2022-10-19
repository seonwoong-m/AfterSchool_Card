using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSize : MonoBehaviour
{
    float timer = 0f;

    public bool isLarge = false;

    public GameObject cardCover;
    SameCard same;
    
    RectTransform card;

    void Awake()
    {
        card = GetComponent<RectTransform>();
    }

    void Start()
    {
        same = FindObjectOfType<SameCard>();
    }

    void Update()
    {
        if(isLarge)
        {
            card.localScale = new Vector3(1.3f, 1.3f, 1f);

            timer += Time.deltaTime;

            if(timer > 0.3f)
            {
                CardLarge();

                timer = 0f;
            }
        }
        else
        {
            card.localScale = new Vector3(1f, 1f, 1f);
        }   
    }

    public void CardLarge()
    {
        if(!isLarge)
        {
            isLarge = true;
            cardCover.SetActive(false);
        }
        else
        {
            isLarge = false;
            cardCover.SetActive(true);
        }

        same.cards.Add(gameObject.GetComponent<CardHandler>());
    }
}
