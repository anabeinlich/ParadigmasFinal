using UnityEngine;

public class HealthItem : CollectibleBase
{
    [SerializeField] private int healAmount = 10;

    public override void Collect(Player player)
    {
        player.Heal(healAmount);
        Debug.Log($"Curación +{healAmount}");
    }
}
