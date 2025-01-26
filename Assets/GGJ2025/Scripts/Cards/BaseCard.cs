using UnityEngine;
using TMPro;

public class BaseCard : MonoBehaviour, ICard
{
    [SerializeField]
    protected int m_defaultFizz = 1;
    [SerializeField]
    protected int m_defaultBuzz = 1;

    [SerializeField]
    protected int m_fizzModifier = 0;
    [SerializeField]
    protected int m_buzzModifier = 0;

    [SerializeField]
    protected CardState m_state = CardState.DECK;

    [SerializeField]
    protected SuitType m_suit = SuitType.None;

    [SerializeField] protected TextMeshProUGUI m_fizzCostTMP;

    protected CardManager m_manager;

    protected void Awake()
    {
        m_fizzCostTMP.text = m_defaultFizz.ToString();
    }

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
            m_fizzModifier = value;

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

    public SuitType Suit
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

    public virtual void OnPlay()
    {
        m_manager.PlayCard(this);

        m_state = CardState.PLAY;

        m_manager.Player.Buzz += m_buzzModifier + m_defaultBuzz;
        m_manager.Player.Fizz += m_defaultFizz + m_fizzModifier;

        m_manager.DiscardCard(this);

    }

    public virtual void OnEnterHand()
    {
        m_state = CardState.HAND;
    }

    public virtual void OnDiscard()
    {
        m_state = CardState.DISCARD;
    }
}
