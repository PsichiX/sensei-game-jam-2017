using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    public GameObject gameStart;
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
