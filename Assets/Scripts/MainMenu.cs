using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
   
        SceneManager.LoadScene("MiniGame"); 
    }

    public void QuitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit(); 
    }
}