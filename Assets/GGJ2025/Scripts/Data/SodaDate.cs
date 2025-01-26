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
    private DateConditionType CurrentCondition { get {return m_currentCondition; } set { m_currentCondition = value; } }

    private DateConditionType m_currentCondition = DateConditionType.None;

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
}
