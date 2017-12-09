using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {
	public static int score;
	public Text scoreText;
	 void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Crowd")
		{
			score +=1;
			var agent = other.gameObject;
			Destroy(agent);
			scoreText.GetComponent<Text>().text = "Score: " + score;
			
		}
	}
}
