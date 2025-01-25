using UnityEngine;

[CreateAssetMenu(fileName = "SodaDate", menuName = "Scriptable Objects/SodaDate")]
public class SodaDate : ScriptableObject
{
    [Header("Identifying Info")]
    [SerializeField] private string m_name;
    [SerializeField] private SodaType m_type;

    [Header("Sprites")]
    [SerializeField] private Sprite m_selectionSprite;
    [SerializeField] private Sprite m_fullbodySprite;
    [SerializeField] private Sprite m_portraitSprite;

    [Header("Other Aesthetics")]
    [SerializeField] private Color m_color;

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
}
