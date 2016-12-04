using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class DictationScript : MonoBehaviour
{
//	[SerializeField]
//	private Text m_Hypotheses;

	[SerializeField]
	private Text m_Recognitions;

	private DictationRecognizer m_DictationRecognizer;

	void Start()
	{
		m_DictationRecognizer = new DictationRecognizer();

		m_DictationRecognizer.DictationResult += (text, confidence) =>
		{
			Debug.LogFormat("Dictation result: {0}", text);
			m_Recognitions.text = text;
		};

		m_DictationRecognizer.DictationHypothesis += (text) =>
		{
			Debug.LogFormat("Dictation hypothesis: {0}", text);
			// m_Hypotheses.text += text;
		};

		m_DictationRecognizer.DictationComplete += (completionCause) =>
		{
			if (completionCause != DictationCompletionCause.Complete)
				Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
		};

		m_DictationRecognizer.DictationError += (error, hresult) =>
		{
			Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
		};

		m_DictationRecognizer.Start();
	}
}