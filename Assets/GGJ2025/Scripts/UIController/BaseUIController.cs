using UnityEngine;

public class BaseUIController : MonoBehaviour
{
    [SerializeField] protected GameManager m_gameManager;
    [SerializeField] protected UIControllerTypes m_controllerType;

    protected virtual void Awake()
    {
        m_gameManager.RegisterUIController(m_controllerType, this);
    }

    public virtual void OnQuitContext()
    {
        m_gameManager.BackToMain();
        Reset();
    }

    protected virtual void Reset()
    {
        Debug.LogWarning(gameObject.name + " called Reset, but it is not implemented!");
    }
}
