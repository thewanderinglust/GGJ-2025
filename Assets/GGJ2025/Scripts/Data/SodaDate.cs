using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SodaDate", menuName = "Scriptable Objects/SodaDate")]
public class SodaDate : ScriptableObject
{
    [Header("Identifying Info")]
    [SerializeField] private string m_name;
    [SerializeField] private SodaType m_type;

    [Header("Game Data")]
    [SerializeField] private List<DateState> m_listDateStates;

    [Header("Sprites")]
    [SerializeField] private Sprite m_selectionSprite;
    [SerializeField] private Sprite m_fullbodySprite;
    [SerializeField] private Sprite m_portraitSprite;

    [Header("Other Aesthetics")]
    [SerializeField] private Color m_color;

    /// <summary>
    /// Internal state tracking for gameplay
    /// </summary>
    public DateConditionType ConditionCurrent { get {return m_currentCondition; } set { m_currentCondition = value; } }

    public DateState StateCurrent { get; private set; }

    private DateConditionType m_currentCondition = DateConditionType.None;

    private int m_stateIndex = -1;

    public string Name
    {
        get { return m_name; }
    }

    public SodaType Type
    {
        get { return m_type; }
    }

    public Color Color
    {
        get { return m_color; }
    }

    public Sprite FullBodySprite
    {
        get { return m_fullbodySprite; }
    }

    public void SetNextState()
    {
        m_stateIndex++;
        if (m_stateIndex >= m_listDateStates.Count)
        {
            m_stateIndex = 0;
        }
        StateCurrent = m_listDateStates[m_stateIndex];
    }
}
