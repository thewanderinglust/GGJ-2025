using UnityEngine;
using UnityEngine.UI;

public class VendingSelectButton : MonoBehaviour
{
    [Header("Object Hookups")]
    [SerializeField] private Button m_buttonComponent;
    [SerializeField] private Image m_imageComponent;

    // Getters for UI components
    public Button ButtonComponent { get { return m_buttonComponent; } }
    public Image ImageComponent { get { return m_imageComponent; } }

    // Tracks the soda type this button corresponds to
    [HideInInspector]
    public SodaType AssignedSodaType;
}
