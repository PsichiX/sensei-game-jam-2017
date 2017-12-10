using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour {
	public static int score;
	public TextMeshProUGUI  text;
	void Start(){
		score = 0;
	}
	 void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Crowd")
		{
			
			score +=1;
			var agent = other.gameObject;
			Destroy(agent);
			text.SetText("Score: {0}", score);
		}
	}
}
