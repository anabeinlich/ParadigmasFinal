using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image fillImage;

    private void Start()
    {
        player.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(player.CurrentHealth);
    }

    private void UpdateHealthBar(int currentHealth)
    {
        fillImage.fillAmount = (float)currentHealth / player.MaxHealth;
        Debug.Log($"Actualizando barra de vida con: {currentHealth}/{player.MaxHealth}");
    }

    private void OnDestroy()
    {
        player.OnHealthChanged -= UpdateHealthBar;
    }
}
