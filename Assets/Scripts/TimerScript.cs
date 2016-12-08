using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	public Text mostrador;
	public AudioClip clip10;
	public AudioClip clip5;
	public AudioClip clip3;
	public AudioClip clip1;
	public AudioClip clipEnding;
	public GameObject player;
	public AudioClip[] progressMessages;
	public float timeRemaining = 600f;

	private bool alreadyPlayed = false;
	private int lastTimePlayed = 0;

	void Start () {
		InvokeRepeating ("decreaseTimeRemaining", 1.0f, 1.0f);
	}
	
	void Update ()
	{
		if (timeRemaining == 0.0f)
			SceneManager.LoadScene ("Menu");

		updateTimer ();
	}

	void updateTimer ()
	{
		int minutes = Mathf.RoundToInt(Mathf.Floor(timeRemaining / 60)); 
		float seconds = Mathf.RoundToInt(timeRemaining % 60);

		if (comparison(10, minutes))
			callAudioMessage (clip10);
		else if (comparison(5, minutes))
			callAudioMessage (clip5);
		else if (comparison(3, minutes))
			callAudioMessage (clip3);
		else if (comparison(1, minutes))
			callAudioMessage (clip1);
		else if (comparison(2, minutes) || comparison(6, minutes) || comparison(7, minutes) || comparison(8, minutes))
			callAudioMessage (progressMessages[Random.Range(0, progressMessages.Length)]);
		else if (comparison(0, minutes))
			callAudioMessage (clipEnding);

		mostrador.text = minutes.ToString("00':'") + Mathf.RoundToInt(seconds).ToString("00");	
	}

	void callAudioMessage(AudioClip clip)
	{
		var radio = GameObject.FindGameObjectWithTag ("Radio");
		AudioSource.PlayClipAtPoint (clip, radio.transform.position);
	}

	bool comparison(int current, int minutes)
	{
		if (current == minutes)
			if (!alreadyPlayed && lastTimePlayed != minutes) {
				alreadyPlayed = true;
				lastTimePlayed = minutes;

				return true;
			} else if (alreadyPlayed && lastTimePlayed != minutes){
				alreadyPlayed = false;
				lastTimePlayed = minutes;
				
				return true;
			}

		return false;
	}

	void decreaseTimeRemaining ()
	{
		timeRemaining --;
	}
}
