using UnityEngine;

public abstract class CollectibleBase : MonoBehaviour, ICollectible
{
    public abstract void Collect(Player player);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<Player>(out var player))
        {
            Collect(player);
            Destroy(gameObject); // Desaparece al recolectarse
        }
    }
}
