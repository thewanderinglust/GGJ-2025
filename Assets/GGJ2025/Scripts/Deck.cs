using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private List<ScriptableObject> m_startingCards;
    private List<ICard> m_cards;

    public void SetUpDeck()
    {
        m_cards = new List<ICard>();

        foreach (ScriptableObject card in m_startingCards)
        {
           ICard cardScript = card as ICard;
            m_cards.Add(cardScript);
        }

        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<ICard> Cards
    {
        get
        {
            return m_cards;
        }
        set
        {
            m_cards = value;
        }
    }

    /// <summary>
    /// Draws 1 card
    /// </summary>
    /// <returns></returns>
    public ICard DrawCard()
    {
        ICard retVal = null;

        if (m_cards.Count > 0)
        {
            retVal = m_cards[0];

            m_cards.RemoveAt(0);
        }

        return retVal;
    }

    /// <summary>
    /// Draws amount of cards given
    /// </summary>
    /// <param name="drawAmount"></param>
    /// <returns></returns>
    public List<ICard> DrawMultiple(int drawAmount)
    {
        List<ICard> retVal = new List<ICard>();

        for (int i = 0; i < drawAmount; i++)
        {
            retVal.Add(DrawCard());
        }

        return retVal;
    }

    /// <summary>
    /// Shuffles deck
    /// </summary>
    public void Shuffle()
    {
        List<ICard> tempDeck = new List<ICard>();

        while (m_cards.Count > 0)
        {
            System.Random rand = new System.Random();
            int cardToRemove = rand.Next(m_cards.Count);
            tempDeck.Add(m_cards[cardToRemove]);
            m_cards.RemoveAt(cardToRemove);
        }

        m_cards = tempDeck;
    }
}
