using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Start_Menu : MonoBehaviour
{
    public GameObject gameStart;
    public void Start(){
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        gameStart.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
 
}
