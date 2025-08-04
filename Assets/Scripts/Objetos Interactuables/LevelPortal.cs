using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour, IInteractable
{
    [SerializeField] private string nombreNivel = "Level1"; 

    public void Interact(Player player)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}
