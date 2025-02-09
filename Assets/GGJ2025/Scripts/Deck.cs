using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_originalDeck;

    [SerializeField] private TextMeshProUGUI m_countTMP;

    private List<GameObject> m_cards;

    public void SetUpDeck()
    {
        m_cards = new List<GameObject>();

        foreach(GameObject obj in m_originalDeck)
        {
            GameObject cardObj = Instantiate(obj, gameObject.transform.parent);
            m_cards.Add(cardObj);
            cardObj.SetActive(false);
            
        }
        Shuffle();
        UpdateDeckCountDisplay();
    }

    public List<GameObject> Cards
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
    public GameObject DrawCard()
    {
        GameObject retVal = null;

        if (m_cards.Count > 0)
        {
            retVal = m_cards[0];

            m_cards.RemoveAt(0);
        }
        UpdateDeckCountDisplay();
        return retVal;
    }

    /// <summary>
    /// Draws amount of cards given
    /// </summary>
    /// <param name="drawAmount"></param>
    /// <returns></returns>
    public List<GameObject> DrawMultiple(int drawAmount)
    {
        List<GameObject> retVal = new List<GameObject>();

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
        List<GameObject> tempDeck = new List<GameObject>();

        while (m_cards.Count > 0)
        {
            System.Random rand = new System.Random();
            int cardToRemove = rand.Next(m_cards.Count);
            tempDeck.Add(m_cards[cardToRemove]);
            m_cards.RemoveAt(cardToRemove);
        }

        m_cards = tempDeck;
    }

    private void UpdateDeckCountDisplay()
    {
        m_countTMP.text = m_cards.Count.ToString();
    }
}
