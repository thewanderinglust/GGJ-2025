using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDateController : BaseUIController
{
    [Header("Object Hookups")]
    [SerializeField] private List<VendingSelectButton> m_vendingButtons;
    [SerializeField] private GameObject m_confirmButton;
    [SerializeField] private GameObject m_datePortrait;
    [SerializeField] private GameObject m_profileBackdrop;
    [SerializeField] private GameObject m_profileText;

    private SodaDate m_dateSelection;

    protected override void Awake()
    {
        base.Awake();
        m_dateSelection = null;
        m_confirmButton.SetActive(false);
        m_datePortrait.SetActive(false);
        m_profileBackdrop.SetActive(false);
        m_profileText.SetActive(false);
    }

    private void Start()
    {
        // Create a selection button for each soda that exists
        var sodaList = m_gameManager.SodaManager.GetAllSodas();
        for (int i = 0; i < m_vendingButtons.Count; i++)
        {
            var vendButton = m_vendingButtons[i];
            if (i < sodaList.Count)
            {
                vendButton.AssignedSodaType = sodaList[i].Type;
                vendButton.ImageComponent.color = sodaList[i].Color;
                vendButton.ButtonComponent.onClick.AddListener(delegate{OnSodaSelect(vendButton.AssignedSodaType);});
            }
            else
            {
                vendButton.gameObject.SetActive(false);
            }

        }

        // Nullify the list to avoid getting references to deleted objects
        m_vendingButtons = null;
        Debug.Log(sodaList.Count + "Sodas available to select");
    }

    public void OnSodaSelect(SodaType a_selectedType)
    {
        Debug.Log("Selected: " + a_selectedType);
        m_dateSelection = m_gameManager.SodaManager.GetSodaByType(a_selectedType);
        m_datePortrait.GetComponent<Image>().sprite = m_dateSelection.FullBodySprite;
        m_datePortrait.SetActive(true);
        m_confirmButton.SetActive(true);
        m_profileBackdrop.SetActive(true);
        m_profileText.SetActive(true);
    }

    public void OnSelectionConfirmed()
    {
        Debug.Log("Selection confirmed");
        m_gameManager.StartNewDate(m_dateSelection);
    }
}
