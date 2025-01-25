using UnityEngine;

public class BaseCard : MonoBehaviour, ICard
{
    [SerializeField]
    private int m_defaultFizz = 1;
    [SerializeField]
    private int m_defaultBuzz = 1;

    [SerializeField]
    private int m_fizzModifier = 0;
    [SerializeField]
    private int m_buzzModifier = 0;

    [SerializeField]
    private CardState m_state = CardState.DECK;

    [SerializeField]
    private CardSuit m_suit = CardSuit.NONE;

    private CardManager m_manager;

    public CardManager Manager
    {
        set
        {
            m_manager = value;
        }
    }

    public int DefaultFizz
    {
        get
        {
            return m_defaultFizz;
        }
    }

    public int DefaultBuzz
    {
        get
        {
            return m_defaultBuzz;
        }
    }

    /// <summary>
    /// Fizz to be added
    /// setting this value increments the current value by the set amount
    /// </summary>
    public int FizzModifier
    {
        get
        {
            return m_fizzModifier;
        }
        set
        {
            m_fizzModifier += value;

            if (m_fizzModifier > m_defaultFizz)
            {
                m_fizzModifier = m_defaultFizz;
            }
        }
    }

    /// <summary>
    /// Buzz to be added
    /// setting this value increments the current value by the set amount
    /// </summary>
    public int BuzzModifier
    {
        get
        {
            return m_buzzModifier;
        }
        set
        {
            m_buzzModifier = value;

            if (m_buzzModifier > m_defaultBuzz)
            {
                m_buzzModifier = m_defaultBuzz;
            }
        }
    }

    public CardState State
    {
        get
        {
            return m_state;
        }
        set
        {
            m_state = value;
        }
    }

    public CardSuit Suit
    {
        get
        {
            return m_suit;
        }
        set
        {
            m_suit = value;
        }
    }

    public void OnPlay()
    {
        m_manager.PlayCard(this);

        m_state = CardState.PLAY;

        m_manager.Player.Buzz += m_buzzModifier + m_defaultBuzz;
        m_manager.Player.Fizz += m_defaultFizz + m_fizzModifier;

        m_manager.DiscardCard(this);

    }

    public void OnEnterHand()
    {
        m_state = CardState.HAND;
    }

    public void OnDiscard()
    {
        m_state = CardState.DISCARD;
    }
}
