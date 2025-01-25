using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Object Hookups")]
    [SerializeField] private SodaManager m_sodaManager;

    private Dictionary<UIControllerTypes, BaseUIController> m_dictUIControllers;

    public SodaManager SodaManager { get { return m_sodaManager; } }

    public void RegisterUIController(UIControllerTypes a_type, BaseUIController a_controller)
    {
        if (m_dictUIControllers == null)
        {
            m_dictUIControllers = new Dictionary<UIControllerTypes, BaseUIController>();
        }

        m_dictUIControllers.Add(a_type, a_controller);
    }

    private void Start()
    {
        DisableAllUIControllers();
        m_dictUIControllers[UIControllerTypes.Main].gameObject.SetActive(true);
    }

    public void StartNewGame()
    {
        DisableAllUIControllers();
        m_dictUIControllers[UIControllerTypes.SelectDate].gameObject.SetActive(true);
    }

    private void DisableAllUIControllers()
    {
        foreach(BaseUIController controller in m_dictUIControllers.Values)
        {
            controller.gameObject.SetActive(false);
        }
    }
}
