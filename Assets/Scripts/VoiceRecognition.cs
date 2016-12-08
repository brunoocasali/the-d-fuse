using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class VoiceRecognition
{
	private VoiceRec.VoiceClass recognizer;
	private string word;
	private string[] left = { "left", "esquerda", "esquerdo" };
	private string[] right = { "direita", "direito", "right" };
	private string[] down = { "down", "trás", "baixo" };
	private string[] up = { "up",  "frente",  "cima" };

	public VoiceRecognition() 
	{
		this.recognizer = new VoiceRec.VoiceClass();
		string[] str = left.Concat(right).Concat(down).Concat(up).ToArray();

		this.recognizer.initRecog(str);
	}

	public Vector2 VoiceMove()
	{
		word = this.recognizer.getWord();

		if (word != null && word != "")
			if (createPattern (up).IsMatch (word))
				return Vector2.up;
			else if (createPattern (down).IsMatch (word))
				return Vector2.down;
			else if (createPattern (right).IsMatch (word))
				return Vector2.right;
			else if (createPattern (left).IsMatch (word))
				return Vector2.left;
			else
				return Vector2.zero;
		else
			return Vector2.zero;
	}

	private Regex createPattern(string[] words)
	{
		string[] escapedWords = words.Select(w => @"\b" + Regex.Escape(w) + @"\b").ToArray();
		return new Regex("(" + string.Join(")|(", escapedWords) + ")");
	}
}
