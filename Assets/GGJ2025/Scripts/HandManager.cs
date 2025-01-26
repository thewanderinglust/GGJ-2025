using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_hand;

    [SerializeField]
    private float m_handIncrement = 100;

    [SerializeField]
    private RectTransform m_handContainer;

    [SerializeField] private AudioClip m_sfxCardDeal;
    [SerializeField] private AudioSource m_sfxPlayer;

    private CardManager m_manager;

    private float HandStartX { get { return m_handContainer.transform.position.x; } }
    private float HandStartY { get { return m_handContainer.transform.position.y; } }

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
        card.transform.SetParent(m_handContainer);
        m_hand.Add(card);
        card.GetComponent<ICard>().Manager = m_manager;
        UpdateCardPositions();
        m_sfxPlayer.PlayOneShot(m_sfxCardDeal);
    }

    public void RemoveFromHand(GameObject card)
    {
        m_hand.Remove(card);
        card.SetActive(false);
        UpdateCardPositions();
    }

    public void UpdateCardPositions()
    {
        int cardsPlaced = 0;
        foreach (GameObject card in m_hand)
        {
            card.transform.position = new Vector3(HandStartX + cardsPlaced * m_handIncrement, HandStartY, 0);
            cardsPlaced++;
        }
    }
}
