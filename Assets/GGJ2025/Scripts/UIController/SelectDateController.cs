using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectDateController : BaseUIController
{
    [Header("Object Hookups")]
    [SerializeField] private List<VendingSelectButton> m_vendingButtons;

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
                Destroy(vendButton);
            }

        }

        // Nullify the list to avoid getting references to deleted objects
        m_vendingButtons = null;
        Debug.Log(sodaList.Count + "Sodas available to select");
    }

    public void OnSodaSelect(SodaType a_selectedType)
    {
        Debug.Log("Selected: " + a_selectedType);
    }
}
