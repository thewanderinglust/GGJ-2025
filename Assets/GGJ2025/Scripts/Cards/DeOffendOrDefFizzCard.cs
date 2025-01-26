using UnityEngine;

public class DeOffendOrDefFizzCard : BaseCard
{
    public override void OnPlay()
    {
        m_manager.PlayCard(this);

        m_state = CardState.PLAY;

        if(m_manager.Soda.CurrentCondition == DateConditionType.Offended)
        {
            m_manager.Soda.CurrentCondition = DateConditionType.None;
        }
        m_manager.Player.Fizz += m_defaultFizz + m_fizzModifier;

        m_manager.DiscardCard(this);

    }
}
