using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardManager", menuName = "Scriptable Objects/CardManager")]
public class CardManager : ScriptableObject
{
    Deck m_deck;
    List<ICard> m_hand = new List<ICard>();
    List<ICard> m_discard = new List<ICard>();
    List<ICard> m_deadCards = new List<ICard>();

    TurnManager m_turnManager;

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

    public List<ICard> Hand
    {
        get
        {
            return m_hand;
        }
    }

    public List<ICard> DiscardPile
    {
        get
        {
            return m_discard;
        }
    }

    public List<ICard> DeadCards
    {
        get
        {
            return m_deadCards;
        }
    }

    public void DrawCard()
    {
        if (m_deck.Cards.Count == 0)
        {
            m_deck.Cards = m_discard;

            m_deck.Shuffle();
        }

        
        ICard drawnCard = m_deck.DrawCard();

        if (drawnCard != null)
        {
            m_hand.Add(drawnCard);
            drawnCard.OnEnterHand();
        }

        TurnManager.UpdateHand();
        
    }

    public void DrawCard(int cardsToDraw)
    {
        for (int i = 0; i < cardsToDraw; i++)
        {
            DrawCard();
        }

        TurnManager.UpdateHand();
    }

    public void PlayCard(ICard card)
    {
        m_hand.Remove(card);

        TurnManager.UpdateHand();

    }

    public void DiscardCard(ICard card)
    {
        m_discard.Add(card);
        card.OnDiscard();

        TurnManager.UpdateHand();
    }

    
}
