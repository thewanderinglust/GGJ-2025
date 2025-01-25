using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_hand;

    [SerializeField]
    private float m_handStart = -50;

    [SerializeField]
    private float m_handIncrement = 50;

    private CardManager m_manager;

    public List<GameObject> Hand
    {
        get
        {
            return m_hand;
        }
        set
        {
            m_hand = value;
        }
    }

    public CardManager Manager
    {
        set
        {
            m_manager = value;
        }
    }

    public void AddToHand(GameObject card)
    {
        float numCards = (float)m_hand.Count;
        GameObject cardObj = GameObject.Instantiate(card, new Vector3(this.gameObject.transform.position.x + m_handStart + m_handIncrement * numCards, this.gameObject.transform.position.y, 0),
            Quaternion.identity, this.gameObject.transform);
        m_hand.Add(cardObj);
        cardObj.GetComponent<ICard>().Manager = m_manager;
    }

    public void RemoveFromHand(GameObject card)
    {
        m_hand.Remove(card);
        Destroy(card);
    }
}
