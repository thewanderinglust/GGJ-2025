using UnityEngine;
using UnityEngine.UI;

public class VendingSelectButton : MonoBehaviour
{
    [Header("Object Hookups")]
    [SerializeField] private Button m_buttonComponent;

    public Button ButtonComponent { get { return m_buttonComponent; } }
}
