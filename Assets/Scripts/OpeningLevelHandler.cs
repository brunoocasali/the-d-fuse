using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpeningLevelHandler : MonoBehaviour {

	public MovieTexture movie;

	void Start(){
		movie.Play();
	}

	void Update() {
		if (!movie.isPlaying || (Input.GetKeyUp (KeyCode.Escape) || Input.GetKeyUp (KeyCode.KeypadEnter))) {
			SceneManager.LoadScene ("InitialMenu");
		}
	}

	void OnGUI() {
		var rect = new Rect (0, 0, Screen.width, Screen.height);

		GUI.DrawTexture(rect, movie, ScaleMode.StretchToFill, false, 0.0f);
	}
}
