using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "AfterSchool/CardGame/Card")]
public class Card : ScriptableObject
{
    public string id;
    public string tagString;

    public bool usable;
    public bool disposable; // 1회성 카드

    public CardPower power;

    public void Init(string _id, string _tagString, CardPower _defaultCP, bool _dispose = false, bool _usable = true)
    {
            id = _id;
            tagString = _tagString;
            disposable = _dispose;

            power = _defaultCP;
    }

    public Card Clone(bool _setDispose = false)
    {
        var card = CreateInstance<Card>();
        bool dispose = _setDispose || disposable;
        card.Init(id, tagString, power, dispose);
        return card;
    }

    public void OnUse()
    {
        Debug.Log("Card Use : " + power.cardName);
    }
    public void OnDraw()
    {
        Debug.Log("Card Draw : " + power.cardName);
    }
    public void OnDrop()
    {
        Debug.Log("Card Drop : " + power.cardName);
    }
    public void OnTurnEnd()
    {
        Debug.Log("TurnEnd : " + power.cardName);
    }
}
