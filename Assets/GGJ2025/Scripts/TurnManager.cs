using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private CardManager m_cardManager;

    [SerializeField]
    private GameObject m_deck;

    [SerializeField]
    private GameObject m_hand;

    [SerializeField]
    private int m_handStartSize;

    [SerializeField]
    IPlayer m_player;
    
    SodaDate m_soda;

    private bool m_dateEnd = false;

    public IPlayer Player
    {
        get
        {
            return m_player;
        }
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
        m_cardManager.Deck = m_deck.GetComponent<Deck>();
        m_cardManager.Deck.SetUpDeck();
        foreach(GameObject card in m_cardManager.Deck.Cards)
        {
            card.GetComponent<ICard>().Manager = m_cardManager;
        }

        m_cardManager.Hand = m_hand.GetComponent<HandManager>();
        m_hand.GetComponent<HandManager>().Manager = m_cardManager;

        FirstTurn();
    }

    public void FirstTurn()
    {
        m_cardManager.DrawCard(m_handStartSize);
    }

    public void EndTurn()
    {
        // EMILY TODO: Emily will handle state tracking and changes and cool fun stuff yay with the date/status/conditions

        // IF THE CURRENT CONDITION IS OFFENDED, GAIN A FIZZ
        // IF THE CURRENT CONDITION IS NONE, EVALUATE THE 
        //check if date ended
        if (!m_dateEnd)
        {
            StartTurn();
        }
    }

    public void StartTurn()
    {
        m_cardManager.DrawCard();
    }

}
