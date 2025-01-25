using UnityEngine;

public class BaseUIController : MonoBehaviour
{
    [SerializeField] protected GameManager m_gameManager;
    [SerializeField] protected UIControllerTypes m_controllerType;

    protected virtual void Awake()
    {
        m_gameManager.RegisterUIController(m_controllerType, this);
    }
}
