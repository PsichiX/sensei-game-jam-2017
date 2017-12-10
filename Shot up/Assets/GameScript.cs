using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {
	float timeLeft = 10;
	public GameObject gameOver;
	public TextMeshProUGUI  timeText;

	void Start(){
		gameOver.SetActive(false);
	}
	void Update(){
		if (timeLeft <=0)
		{
			gameOver.SetActive(true);
			return;
		}
		timeLeft -= Time.deltaTime;
		timeText.SetText("Time left: {0} sec", timeLeft);
	}
	public void StartGame(){
		SceneManager.LoadScene("Main");
		gameOver.SetActive(false);		
	}
	public void QuitGame(){
		Application.Quit();
	}
	public void MainMenu(){
		SceneManager.LoadScene("Start_Scene");
	}
}
