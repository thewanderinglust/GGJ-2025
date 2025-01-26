using UnityEngine;

public class DeOffendOrDefFizzCard : BaseCard
{
    public override void OnPlay()
    {
        m_manager.PlayCard(this);

        m_state = CardState.PLAY;

        if(m_manager.Soda.ConditionCurrent == DateConditionType.Offended)
        {
            m_manager.Soda.ConditionCurrent = DateConditionType.None;
        }
        else
        {
            m_manager.Player.Fizz += DefaultFizz;

        }

        m_manager.DiscardCard(this);

    }
}
