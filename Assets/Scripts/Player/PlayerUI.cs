using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Text auraText;

    private void Start()
    {
        player.OnHealthChanged += UpdateHealth;
        player.OnAuraChanged += UpdateAura;

        UpdateHealth(player.CurrentHealth);
        UpdateAura(player.CurrentAuras);
    }

    private void UpdateHealth(int currentHealth)
    {
        float fillAmount = (float)currentHealth / player.MaxHealth;
        Debug.Log($"[PlayerUI] Vida actual: {currentHealth}/{player.MaxHealth} - fillAmount = {fillAmount}");
        healthBarImage.fillAmount = fillAmount;
    }

    private void UpdateAura(int auraCount)
    {
        auraText.text = $"Auras: {auraCount}";
    }

    private void OnDestroy()
    {
        player.OnHealthChanged -= UpdateHealth;
        player.OnAuraChanged -= UpdateAura;
    }
}
