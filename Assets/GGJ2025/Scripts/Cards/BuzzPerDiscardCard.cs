using UnityEngine;

public class BuzzPerDiscardCard : BaseCard
{
   public override void OnPlay()
    {
        int buzzToGain = m_manager.DiscardPile.Count;

        BuzzModifier = buzzToGain;

        base.OnPlay();
    }
}
