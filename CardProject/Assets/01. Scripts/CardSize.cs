using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSize : MonoBehaviour
{
    public bool isLarge = false;

    RectTransform card;

    void Awake()
    {
        card = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(isLarge)
        {
            card.localScale = new Vector3(1.3f, 1.3f, 1f);
        }
        else
        {
            card.localScale = new Vector3(1f, 1f, 1f);
        }   
    }

    public void CardLarge()
    {
        if(!isLarge)
            isLarge = true;
        else
            isLarge = false;
    }
}
