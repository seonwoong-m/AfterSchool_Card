using UnityEngine;

[CreateAssetMenu(fileName = "NewCardPower", menuName = "AfterSchool/CardGame/CardPower")]
public class CardPower : ScriptableObject
{
    public Sprite illust;
    public string cardName;
    public string cardDescription;

    public string seqOnUse;
    public string seqOnDraw;
    public string seqOnDrop;
    public string seqTurnEnd;

    public void Init(Sprite _illust, string _name, string _description, string _seqOnUse, string _seqOnDraw, string _seqOnDrop, string _seqTurnEnd)
    {
        illust = _illust;
        cardName = _name;
        cardDescription = _description;

        seqOnUse = _seqOnUse;
        seqOnDraw = _seqOnDraw;
        seqOnDrop = _seqOnDrop;
        seqTurnEnd = _seqTurnEnd;
    }
}
