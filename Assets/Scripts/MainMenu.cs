using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string nombreEscenaTutorial = "Tutorial"; 

    public void StartGame()
    {
        SceneManager.LoadScene(nombreEscenaTutorial);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
