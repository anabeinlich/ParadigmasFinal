using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;

    private void Start()
    {
        player.OnHealthChanged += RevisarDerrota;
    }

    private void RevisarDerrota(int vidaActual)
    {
        if (!player.IsAlive())
        {
            MostrarDerrota();
        }
    }

    public void MostrarDerrota()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void MostrarVictoria()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        player.OnHealthChanged -= RevisarDerrota;
    }
}
