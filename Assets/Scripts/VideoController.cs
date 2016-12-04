using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
	private VoiceRec.VoiceClass obj;
	private string word;

	public Text text;

	void Start () {
		obj = new VoiceRec.VoiceClass();
		//set of commands : replace with set of commands to be recognized
		string[] str = { "to the left", "to the right", "down", "up", "direita", "hello", "oh my gosh" };
		obj.initRecog(str);
	}

	void Update () {
		word = obj.getWord();

		if (word != null && word != "")
		{
			puts(word);
		}
	}

	void puts (string message) {
		text.text = message;
	}
}
