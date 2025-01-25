using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectDateController : BaseUIController
{
    [Header("Prefab Hookups")]
    [SerializeField] private GameObject m_vendingButtonPrefab;

    private List<VendingSelectButton> m_selectionButtons;

    protected override void Awake()
    {
        base.Awake();
        m_selectionButtons = new List<VendingSelectButton>();
    }

    private void Start()
    {
        // Create a selection button for each soda that exists
        var sodaList = m_gameManager.SodaManager.GetAllSodas();
        foreach (SodaDate soda in sodaList)
        {
            var buttonObject = Instantiate(m_vendingButtonPrefab, transform);
            m_selectionButtons.Add(buttonObject.GetComponent<VendingSelectButton>());
        }
    }

    public void OnSodaSelect(SodaType a_selectedType)
    {

    }
}
