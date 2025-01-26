using UnityEngine;

[CreateAssetMenu(fileName = "DateState", menuName = "Scriptable Objects/DateState")]
public class DateState : ScriptableObject
{
    [SerializeField] private StateEffectType m_effectType;
    [SerializeField] private SuitType m_suit1;
    [SerializeField] private SuitType m_suit2;

    public StateEffectType EffectType { get {return m_effectType; } }
    public SuitType Suit1 { get { return m_suit1; } }
    public SuitType Suit2 { get { return m_suit2; } }
}
