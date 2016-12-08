using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {
	private enum ControllerKind {
		VoiceRecognition,
		ArrowKeys
	};

	private static ControllerKind kind = ControllerKind.ArrowKeys;
	// private static VoiceRecognition recognition = new VoiceRecognition();

	public static Vector2 TranslateMove() 
	{
		if (kind == ControllerKind.ArrowKeys)
			return ArrowsMove ();
		else
			return Vector2.zero; //recognition.VoiceMove ();
	}

	private static Vector2 ArrowsMove()
	{
		Vector2 input = Vector2.up;

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			input = Vector2.up;
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			input = Vector2.down;
		} else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			input = Vector2.left;
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			input = Vector2.right;
		}

		return input;
	}
}
