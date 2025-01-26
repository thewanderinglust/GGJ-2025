using UnityEngine;
using UnityEngine.UI;

public class PlayDateController : BaseUIController
{
    [Header("Object Hookups")]
    [SerializeField] private Image m_datePortrait;
    [SerializeField] private ConditionOverlay m_conditionOverlay;

    protected override void Awake()
    {
        base.Awake();
        m_conditionOverlay.gameObject.SetActive(false);
    }

    public void OnConditionUpdate(DateConditionType a_newCondition)
    {
        m_conditionOverlay.SetCondition(a_newCondition);
    }
}
