using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    float timeLeft = 10;
    public TextMeshProUGUI timeText;

    void Update()
    {
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("Start_Scene");
            return;
        }

        timeLeft -= Time.deltaTime;
        timeText.SetText("Time left: {0} sec", timeLeft);
    }
}
