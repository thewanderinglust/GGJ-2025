using UnityEngine;

public class DrawCardCard : BaseCard
{
    [SerializeField]
    protected int m_cardsToDraw;

    public int CardsToDraw
    {
        get
        {
            return m_cardsToDraw;
        }
        set
        {
            m_cardsToDraw = value;
        }
    }
    public override void OnPlay()
    {
        Debug.Log("OnPlay called");
        m_manager.DrawCard(m_cardsToDraw);
        base.OnPlay();
    }
}
