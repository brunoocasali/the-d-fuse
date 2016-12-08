using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class NarrativeHandler : MonoBehaviour {

	public AudioClip[] AudioClipList;
	private AudioSource source;
	private int IndexCount = 0;

	void Start()
	{
		source = Camera.main.GetComponent<AudioSource>();

//		StartCoroutine(WaitCoroutine.Do(1.0f, playMessage));
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.R))
		{
			playMessage ();
		} 
		else if (!source.isPlaying)
		{
			playMessage();
		}
	}

	void playMessage()
	{
		var first = AudioClipList.FirstOrDefault(item => item != null);
		var hasMore = AudioClipList.Any(item => item != null);

		if (first != null) {
			AudioClipList[IndexCount] = null;

			IndexCount ++;
			source.Stop ();
			SendToAudioSource (first);
		}

		if (!hasMore){
			Initialize ();
		}
	}

	void Initialize()
	{
		SceneManager.LoadScene ("Game");
	}

	private void SendToAudioSource(AudioClip clip)
	{
		source.clip = clip;
		source.PlayOneShot(clip);
	}
}
