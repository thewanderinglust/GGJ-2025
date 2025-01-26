using UnityEngine;
using TMPro;

public class ConditionOverlay : MonoBehaviour
{
    [Header("Data Settings")]
    [SerializeField] private string m_offendedString;
    [SerializeField] private string m_confusedString;
    [SerializeField] private Color m_offendedColor;
    [SerializeField] private Color m_confusedColor;

    [Header("Object Hookups")]
    [SerializeField] private TextMeshProUGUI m_statusTMP;

    public void SetCondition(DateConditionType a_newCondition)
    {
        switch (a_newCondition)
        {
            case DateConditionType.None:
                gameObject.SetActive(false);
                break;
            case DateConditionType.Confused:
                m_statusTMP.color = m_confusedColor;
                m_statusTMP.text = m_confusedString;
                gameObject.SetActive(true);
                break;
            case DateConditionType.Offended:
                m_statusTMP.color = m_offendedColor;
                m_statusTMP.text = m_offendedString;
                gameObject.SetActive(true);
                break;
        }
    }
}
