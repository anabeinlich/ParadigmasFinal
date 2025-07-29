using TMPro;
using UnityEngine;

public class FinalBoss : MonoBehaviour, IInteractable
{
    [SerializeField] private int auraRequired = 20;
    [SerializeField] private TextMeshProUGUI worldText;
    [SerializeField] private GameController gameManager;

    private bool defeated = false;

    public void Interact(Player player)
    {
        if (defeated) return;

        int currentAura = player.CurrentAuras;

        if (currentAura >= auraRequired)
        {
            defeated = true;
            worldText.text = "Derrotaste al boss!!";
            gameManager.MostrarVictoria();
        }
        else
        {
            int faltan = auraRequired - currentAura;
            worldText.text = $"Necesitas {faltan} auras más para derrotarlo...";
        }
    }
}
