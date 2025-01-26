using System.Collections.Generic;
using UnityEngine;
public class CardManager : MonoBehaviour
{
    Deck m_deck;
    HandManager m_hand;
    List<GameObject> m_discard = new List<GameObject>();
    List<GameObject> m_deadCards = new List<GameObject>();

    TurnManager m_turnManager;

    public bool PlayedNoCards { get { return m_playedNoCards; } set{ m_playedNoCards = value; } }

    private bool m_playedNoCards = false;

    public void Clear()
    {
        m_discard = new List<GameObject>();
        m_deadCards = new List<GameObject>();
    }

    public IPlayer Player
    {
        get
        {
            return m_turnManager.Player;
        }
    }

    public SodaDate Soda
    {
        get
        {
            return m_turnManager.Soda;
        }
    }

    public TurnManager TurnManager
    {
        get
        {
            return m_turnManager;
        }
        set
        {
            m_turnManager = value;
        }
    }

    public Deck Deck
    {
        get
        {
            return m_deck;
        }
        set
        {
            m_deck = value;
        }
    }

    public HandManager Hand
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

    public List<GameObject> DiscardPile
    {
        get
        {
            return m_discard;
        }
    }

    public List<GameObject> DeadCards
    {
        get
        {
            return m_deadCards;
        }
    }

    public void DrawCard()
    {
        GameObject drawnCard = m_deck.DrawCard();

        if (m_deck.Cards.Count == 0)
        {
            m_deck.gameObject.SetActive(false);
        }

        if (drawnCard != null)
        {
            m_hand.AddToHand(drawnCard);
            drawnCard.GetComponent<ICard>().OnEnterHand();
        }  
    }

    public void DrawCard(int cardsToDraw)
    {
        for (int i = 0; i < cardsToDraw; i++)
        {
            DrawCard();
        }

    }

    public void PlayCard(ICard card)
    {
        m_turnManager.CheckSuitTriggers(card.Suit);
        m_hand.RemoveFromHand((card as MonoBehaviour).gameObject);
        PlayedNoCards = false;
        m_turnManager.CheckGameEndConditions();
        RemoveConfused();
    }

    public void DiscardCard(ICard card)
    {
        m_discard.Add((card as MonoBehaviour).gameObject);
        card.OnDiscard();
    }

    public void RemoveConfused()
    {
        if (Soda.ConditionCurrent == DateConditionType.Confused)
        {
            Soda.ConditionCurrent = DateConditionType.None;
        }
    }
    
}
