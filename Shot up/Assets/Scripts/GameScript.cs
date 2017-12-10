using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public float timeLeft = 60;
    public TextMeshProUGUI timeText;

    void Update()
    {
        if (timeLeft <= 0 || FindObjectsOfType<Agent>().Length == 0)
        {
            // TODO: open results view.
            SceneManager.LoadScene("Start_Scene");
            return;
        }

        timeLeft -= Time.deltaTime;
        timeText.SetText("Time left: {0} sec", timeLeft);
    }
}
