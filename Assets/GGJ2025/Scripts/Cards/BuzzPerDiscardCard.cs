using UnityEngine;

public class BuzzPerDiscardCard : BaseCard
{
   public override void OnPlay()
    {
        int buzzToGain = m_manager.DiscardPile.Count;
        m_manager.Player.Buzz += buzzToGain;

        base.OnPlay();
    }
}
