using UnityEngine;

public class BuzzPerDiscardCard : BaseCard
{
   public override void OnPlay()
    {
        int buzzToGain = m_manager.DiscardPile.Count;

        BuzzModifier = BuzzModifier * -1;
        BuzzModifier = buzzToGain;

        base.OnPlay();
    }
}
