using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int maxHealth = 3;
    [SerializeField] protected int auraReward = 1; // Cuántas auras da al morir

    [SerializeField] protected Player player; //referencia al jgador 

    protected int currentHealth;

    [Header("Visual Feedback")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float flashDuration = 0.2f;

    private Coroutine flashCoroutine;


    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        flashCoroutine = StartCoroutine(FlashDamage());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"[Enemy] Murio y otorga {auraReward} auras");
        player.AddAura(auraReward);
       
        Destroy(gameObject);
    }

    private IEnumerator FlashDamage()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = damageColor;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.color = originalColor;
    }
}
