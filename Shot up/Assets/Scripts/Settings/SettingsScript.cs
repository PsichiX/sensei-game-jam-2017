using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour {
	public AudioMixer audioMixer;
	public void MainMenu(){
		SceneManager.LoadScene("Start_Scene");
	}
	public void SetVolume(float volume){
		audioMixer.SetFloat("Volume", volume);

	}

}
