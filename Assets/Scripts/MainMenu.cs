using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {

        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}