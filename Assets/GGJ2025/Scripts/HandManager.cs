using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_hand;

    [SerializeField]
    private float m_handStartX = -100;

    [SerializeField]
    private float m_handStartY = -100;

    [SerializeField]
    private float m_handIncrement = 100;

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
        card.SetActive(true);
        m_hand.Add(card);
        UpdateCardPositions();
        card.GetComponent<ICard>().Manager = m_manager;
    }

    public void UpdateCardPositions()
    {
        RectTransform parentTransform = gameObject.GetComponent<RectTransform>();
        float width = parentTransform.rect.width;
        float height = parentTransform.rect.height;
        float cardCount = (float)m_hand.Count;

        int cardsPlaced = 0;
        foreach (GameObject card in m_hand)
        {
            card.transform.position = new Vector3(m_handStartX + cardsPlaced * m_handIncrement, m_handStartY, 0);
            cardsPlaced++;
        }
    }

    public void RemoveFromHand(GameObject card)
    {
        m_hand.Remove(card);
        card.SetActive(false);
    }
}
