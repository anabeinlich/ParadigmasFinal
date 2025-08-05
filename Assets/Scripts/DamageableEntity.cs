using UnityEngine;
using System.Collections;

public abstract class DamageableEntity : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Color damageColor = Color.red;
    [SerializeField] protected float flashDuration = 0.2f;

    private Coroutine flashCoroutine;

    protected void FlashOnDamage()
    {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashDamage());
    }

    private IEnumerator FlashDamage()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = damageColor;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.color = originalColor;
    }
}
