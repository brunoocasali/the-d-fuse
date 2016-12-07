using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class NarrativeHandler : MonoBehaviour {

	public AudioClip[] AudioClipList;
	private AudioSource source;
	private bool initialized = false;
	private int IndexCount = 0;

	void Start()
	{
		source = Camera.main.GetComponent<AudioSource>();

		StartCoroutine(WaitCoroutine.Do(1.0f, FirstMessage));

		initialized = true;
	}
	
	void Update()
	{
		if (initialized && Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.R))
		{
			var first = AudioClipList.FirstOrDefault(item => item != null);
			var hasMore = AudioClipList.Any(item => item != null);
			Debug.Log (hasMore);

			if (first != null) {
				IndexCount += 1;

				source.Stop ();
				AudioClipList[IndexCount] = null;

				SendToAudioSource (first);
			}

			if (!hasMore){
				Initialize ();
			}
		}
	}

	void FirstMessage()
	{
		var clip = AudioClipList [IndexCount];
		SendToAudioSource (clip);
		AudioClipList[IndexCount] = null;
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
