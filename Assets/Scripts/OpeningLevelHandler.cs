using UnityEngine;
using System.Collections;

public class OpeningLevelHandler : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource audioSource;

	void Start(){
		Screen.fullScreen = true;
		Cursor.visible = false;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movie, ScaleMode.StretchToFill);
		movie.Play();
	}

	void Update () {
		// Exit the cutscene.
		if (Input.GetKeyUp (KeyCode.Escape) || Input.GetKeyUp (KeyCode.KeypadEnter) && movie.isPlaying) {
			Screen.fullScreen = false;
			Cursor.visible = true;

			movie.Stop ();
			audioSource.Stop ();
		}
	}
}
