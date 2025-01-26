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

    [SerializeField] private Player m_player;

    private SodaDate m_soda;

    private bool m_dateEnd = false;

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

    private void Awake()
    {

    }

    public void StartDate(SodaDate a_yourDate)
    {
        m_soda = a_yourDate;
        m_cardManager.TurnManager = this;
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
    }

    public void EndTurn()
    {
        ResolveConditions();

        /// EMILY TODO
        /// THINK LONG AND HARD ABOUT 
        /// THE DATE ENDING WHEN YOU GAIN ENOUGH BUZZ OR ACCUMULATE TOO MUCH FIZZ
        /// CONSIDER WHERE/HOW THAT SHOULD BE HANDLED
        /// MAYBE THE EVALUATIONS SHOULD BE PUBLIC FUNCTIONS THAT GET CALLED?
        // Move to next turn or end the game
        if (!m_dateEnd)
        {
            StartTurn();
        }
        else
        {
            Debug.LogWarning("Date FAILED but not handled");
        }

        m_handManager.UpdateCardPositions();
    }

    public void StartTurn()
    {
        m_cardManager.PlayedNoCards = false;
        m_cardManager.DrawCard();
    }

    private void ResolveConditions()
    {
        // Become confused if has not played cards and is in neutral state
        if (m_cardManager.PlayedNoCards && Soda.CurrentCondition == DateConditionType.None)
        {
            Soda.CurrentCondition = DateConditionType.Confused;
            Debug.Log("No cards played, date confused");
        }
        else if (Soda.CurrentCondition == DateConditionType.Offended)
        {
            m_player.Fizz++;
            Debug.Log("+1 Fizz because date offended");
        }
    }

}
