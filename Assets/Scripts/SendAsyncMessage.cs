using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendAsyncMessage {
	
	public static void Send (Vector2 vector) {
		var speaker = getRadioSpeaker();
		Radio radio = getRadio().GetComponent<Radio> ();

		AudioClip[] list = radio.right;

		if (Vector2.up == vector) {
			list = radio.up;
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			list = radio.down;
		} else if (Input.GetKeyDown(KeyCode.LeftArrow))
			list = radio.left;

		run (speaker, list);
	}

	private static GameObject getRadio(){
		return GameObject.FindGameObjectWithTag ("Radio");
	}

	private static AudioSource getRadioSpeaker() {
		return getRadio().GetComponent<AudioSource>(); 
	}

	private static void run(AudioSource radio, AudioClip[] list) {
		if (radio.isPlaying) return;

		radio.clip = list[Random.Range(0, list.Length)];
		radio.PlayOneShot(radio.clip);
	}
}
