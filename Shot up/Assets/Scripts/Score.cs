using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
	public TextMeshProUGUI winScoreText;

	// Use this for initialization
	void Start () {
		setScore();
	}
	
	// Update is called once per frame
	public void setScore(){
    	var score = DoorScript.score;
    	winScoreText.SetText("Score: {0}", score);
    }
}
