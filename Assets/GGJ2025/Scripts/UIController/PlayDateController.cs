using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class PlayDateController : BaseUIController
{
    [Header("Data Hookups")]
    [SerializeField] private Sprite m_offendedSprite;
    [SerializeField] private Sprite m_bonusSprite;

    [SerializeField] private Sprite m_diamondSprite;
    [SerializeField] private Sprite m_heartSprite;
    [SerializeField] private Sprite m_spadeSprite;
    [SerializeField] private Sprite m_clubSprite;

    [Header("Object Hookups")]
    [SerializeField] private Image m_datePortrait;
    [SerializeField] private ConditionOverlay m_conditionOverlay;
    [SerializeField] private Image m_effectImage;
    [SerializeField] private Image m_suit1Image;
    [SerializeField] private Image m_suit2Image;

    protected override void Awake()
    {
        base.Awake();

        m_conditionOverlay.gameObject.SetActive(false);

        m_effectImage.gameObject.SetActive(false);
        m_suit1Image.gameObject.SetActive(false);
        m_suit2Image.gameObject.SetActive(false);
    }

    public void OnConditionUpdate(DateConditionType a_newCondition)
    {
        m_conditionOverlay.SetCondition(a_newCondition);
    }

    public void OnStateUpdate(DateState a_newState)
    {
        if (a_newState.EffectType == StateEffectType.Bonus)
        {
            m_effectImage.sprite = m_bonusSprite;
        }
        else if (a_newState.EffectType == StateEffectType.Offended)
        {
            m_effectImage.sprite = m_offendedSprite;
        }

        m_suit1Image.sprite = GetSuitSprite(a_newState.Suit1);
        m_suit2Image.sprite = GetSuitSprite(a_newState.Suit2);
    }

    private Sprite GetSuitSprite(SuitType a_suit)
    {
        if (a_suit == SuitType.Club)
        {
            return m_clubSprite;
        }
        else if (a_suit == SuitType.Spade)
        {
            return m_spadeSprite;
        }
        else if (a_suit == SuitType.Heart)
        {
            return m_heartSprite;
        }
        else if (a_suit == SuitType.Diamond)
        {
            return m_diamondSprite;
        }
        else
        {
            return null;
        }
    }
}
