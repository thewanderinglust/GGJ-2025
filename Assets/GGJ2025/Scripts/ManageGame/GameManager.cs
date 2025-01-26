using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Object Hookups")]
    [SerializeField] private SodaManager m_sodaManager;
    [SerializeField] private GameObject m_veronicasCanvas;
    [SerializeField] private TurnManager m_turnManager;

    private Dictionary<UIControllerTypes, BaseUIController> m_dictUIControllers;

    public SodaManager SodaManager { get { return m_sodaManager; } }

    private void Start()
    {
        DisableAllUIControllers();
        m_veronicasCanvas.SetActive(false);
        m_dictUIControllers[UIControllerTypes.Main].gameObject.SetActive(true);
    }

    public void RegisterUIController(UIControllerTypes a_type, BaseUIController a_controller)
    {
        if (m_dictUIControllers == null)
        {
            m_dictUIControllers = new Dictionary<UIControllerTypes, BaseUIController>();
        }

        m_dictUIControllers.Add(a_type, a_controller);
    }

    public void StartNewGame()
    {
        DisableAllUIControllers();
        m_dictUIControllers[UIControllerTypes.SelectDate].gameObject.SetActive(true);
    }

    public void StartNewDate(SodaDate a_selectedDate)
    {
        DisableAllUIControllers();
        m_turnManager.StartDate(a_selectedDate);
        m_dictUIControllers[UIControllerTypes.PlayDate].gameObject.SetActive(true);
    }

    public void BackToMain()
    {
        DisableAllUIControllers();
        m_dictUIControllers[UIControllerTypes.Main].gameObject.SetActive(true);
    }

    private void DisableAllUIControllers()
    {
        foreach(BaseUIController controller in m_dictUIControllers.Values)
        {
            controller.gameObject.SetActive(false);
        }
    }
}
