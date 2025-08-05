using UnityEngine;
using System.Collections;

public abstract class Enemy : DamageableEntity, IDamageable
{
    [SerializeField] protected int maxHealth = 3;
    [SerializeField] protected int auraReward = 1; // Cuántas auras da al morir

    [SerializeField] protected Player player; //referencia al jgador 

    protected int currentHealth;


    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        FlashOnDamage();
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

}
