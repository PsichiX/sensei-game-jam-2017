using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public float timeLeft = 60;
    public TextMeshProUGUI timeText;
    private int crowdNumber = 0;
    public double difficulty = 0.8;

    void Start()
    {
        crowdNumber = FindObjectsOfType<Agent>().Length;
    }

    void Update()
    {
        if (timeLeft <= 0 || FindObjectsOfType<Agent>().Length == 0)
        {
            var score = DoorScript.score;
            if (score <= difficulty * crowdNumber)
            {
                SceneManager.LoadScene("Game Over");
            }
            else if(score > difficulty * crowdNumber){
                SceneManager.LoadScene("Win");
            }
            Debug.Log("Score = " + score);
            Debug.Log(" crowdnumber =" + crowdNumber);


            return;
        }

        timeLeft -= Time.deltaTime;
        timeText.SetText("Time left: {0} sec", timeLeft);
    }
}
