using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsFlyin : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private Vector3 m_offsetToApply;

    [Min(0f)]
    [SerializeField] private float m_delayBetweenButtons = 0.0f;

    [Header("UI Hookups")]
    [SerializeField] private List<Button> m_menuButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sequence buttonSequence = DOTween.Sequence();
        foreach (var button in m_menuButtons)
        {
            buttonSequence.Append(button.transform.DOMove(transform.position + new Vector3(), 5.0f));
            buttonSequence.AppendInterval(m_delayBetweenButtons);
        }
    }
}
