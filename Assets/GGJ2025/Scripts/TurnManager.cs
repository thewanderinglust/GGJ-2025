using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private CardManager m_cardManager;

    [SerializeField]
    private GameObject m_deck;

    [SerializeField]
    private HandManager m_handManager;

    [SerializeField]
    private int m_handStartSize;
    [SerializeField] private GameManager m_gameManager;

    [SerializeField] private Player m_player;

    [SerializeField] private SodaDate m_soda;

    [SerializeField] private PlayDateController m_dateUI;

    public IPlayer Player
    {
        get { return m_player; }
    }

    public SodaDate Soda
    {
        get
        {
            return m_soda;
        }
    }

    public void StartDate(SodaDate a_yourDate)
    {
        m_soda = a_yourDate;
        m_cardManager.TurnManager = this;
        m_cardManager.Clear();
        m_cardManager.Deck = m_deck.GetComponent<Deck>();
        m_cardManager.Deck.SetUpDeck();
        foreach(GameObject card in m_cardManager.Deck.Cards)
        {
            card.GetComponent<ICard>().Manager = m_cardManager;
        }

        m_cardManager.Hand = m_handManager.GetComponent<HandManager>();
        m_handManager.GetComponent<HandManager>().Manager = m_cardManager;

        FirstTurn();
    }

    public void FirstTurn()
    {
        m_cardManager.DrawCard(m_handStartSize);
        m_soda.SetNextState();
        m_dateUI.OnStateUpdate(Soda.StateCurrent);
    }

    public void EndTurn()
    {
        ResolveConditions();

        // Set a new state if there is not a condition
        if (Soda.ConditionCurrent == DateConditionType.None)
        {
            m_soda.SetNextState();
            m_dateUI.OnStateUpdate(Soda.StateCurrent);
        }

        CheckGameEndConditions();

        // Update the card positions
        m_handManager.UpdateCardPositions();

        // Start a new turn
        StartTurn();
    }

    public void CheckGameEndConditions()
    {
        Debug.Log("CHECKING END CONDITIONS");
        Debug.Log("Fizz: " + m_player.Fizz);
        Debug.Log("Buzz: " + m_player.Buzz);
        if (m_player.Fizz >= m_player.FizzToLose)
        {
            m_gameManager.FailDate();
        }
        else if (m_player.Buzz >= m_player.BuzzToWin)
        {
            m_gameManager.WinDate();
        }
        else if (m_deck.GetComponent<Deck>().Cards.Count == 0 && m_handManager.Hand.Count == 0)
        {
            m_gameManager.FailDate();
        }
    }

    public void StartTurn()
    {
        m_cardManager.PlayedNoCards = false;
        m_cardManager.DrawCard();
    }

    private void ResolveConditions()
    {
        // Become confused if has not played cards and is in neutral state
        if (m_cardManager.PlayedNoCards && Soda.ConditionCurrent == DateConditionType.None)
        {
            Soda.ConditionCurrent = DateConditionType.Confused;
            m_player.Fizz++;
            Debug.Log("No cards played, date now confused");
        }
        else if (Soda.ConditionCurrent == DateConditionType.Offended)
        {
            m_player.Fizz++;
            Debug.Log("+1 Fizz because date offended");
        }

        m_dateUI.OnConditionUpdate(Soda.ConditionCurrent);
    }

    private void ResolveSuitTrigger(StateEffectType a_effect)
    {
        if (a_effect == StateEffectType.Offended)
        {
            Debug.Log("NOW OFFENDED");
            Soda.ConditionCurrent = DateConditionType.Offended;
            m_player.Fizz++;
            m_dateUI.OnConditionUpdate(Soda.ConditionCurrent);
        }
        else if (a_effect == StateEffectType.Bonus)
        {
            m_player.Buzz++;
        }
    }

    public void CheckSuitTriggers(SuitType a_suit)
    {
        Debug.Log("CHECK SUIT TRIGGERS " + a_suit);
        DateState state = Soda.StateCurrent;

        if (a_suit != SuitType.None)
        {
            if (a_suit == state.Suit1 || a_suit == state.Suit2)
            {
                Debug.Log("SUIT TRIGGER");
                ResolveSuitTrigger(state.EffectType);
            }
        }
    }

    public void UpdateCondition(DateConditionType a_newCondition)
    {
        m_dateUI.OnConditionUpdate(a_newCondition);
    }

}
