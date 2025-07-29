using UnityEngine;

public class AuraCollectible : CollectibleBase
{
    [SerializeField] private int auraAmount = 5;

    public override void Collect(Player player)
    {
        player.AddAura(auraAmount);
    }
}
