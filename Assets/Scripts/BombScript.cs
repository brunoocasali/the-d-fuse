using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BombScript : MonoBehaviour
{
	public AudioSource beep;
	private bool canDefuse;

	void Start ()
	{
		beep = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		float time = Time.deltaTime;

		if (canDefuse && Input.GetKeyDown (KeyCode.E)) {
			//beep.Play ();
			SceneManager.LoadScene ("MenuWin");
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			canDefuse = defuseBomb (true);
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			canDefuse = defuseBomb (false);
		}
	}

	private bool defuseBomb (bool trigger)
	{
		return trigger;
	}
}
