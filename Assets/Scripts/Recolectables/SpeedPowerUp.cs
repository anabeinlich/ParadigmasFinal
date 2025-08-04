using UnityEngine;

public class SpeedPowerUp : CollectibleBase
{
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float duration = 5f;

    public override void Collect(Player player)
    {
        player.ApplySpeedBoost(speedMultiplier, duration);
        Debug.Log("PowerUp de velocidaddddd");
    }
}
