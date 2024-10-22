﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameMenu : MonoBehaviour {

	public AudioClip[] KeyboardAudioList;

	private AudioSource source;
	private bool canContinue = false;

	void Start()
	{
		source = Camera.main.GetComponent<AudioSource> ();
		StartCoroutine(WaitCoroutine.Do(1.9f, FirstMessage));
	}

	void Update ()
	{
		if (Input.GetButtonDown("Fire1") ||
			Input.GetKeyDown (KeyCode.R) ||
			Input.GetKey(KeyCode.KeypadEnter)) {

			StopsAudio ();
		}

		// verify if audio has been stopped and go to next scene
		if (canContinue && !source.isPlaying) Initialize();
	}

	public void Initialize()
	{
		SceneManager.LoadScene ("InitialMenu");
	}

	private void StopsAudio()
	{
		source.Stop();
		canContinue = true;
	}

	private void FirstMessage()
	{
		var clip = KeyboardAudioList [0];

		if (clip != null)
			SendToAudioSource(clip);
	}

	private void SendToAudioSource(AudioClip clip)
	{
		source.clip = clip;
		source.PlayOneShot(clip);
	}
}