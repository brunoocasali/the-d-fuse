using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpeningLevelHandler : MonoBehaviour {

	public MovieTexture movie;

	void Start(){
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.Escape) || Input.GetKeyUp (KeyCode.KeypadEnter) && movie.isPlaying) {
			SceneManager.LoadScene("Menu");
		}
	}

	void OnGUI() {
		movie.Play();
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movie, ScaleMode.StretchToFill, false, 0.0f);
	}
}
