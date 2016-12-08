using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BombScript : MonoBehaviour
{
	public AudioClip beep;
	public AudioClip found;
	private bool foundBomb = false;
	private bool canDefuse;

	void Update ()
	{
		float time = Time.deltaTime;

		if (canDefuse && Input.GetKey (KeyCode.E)) {
//			AudioSource.PlayClipAtPoint(beep, transform.position);

			SceneManager.LoadScene ("YouWin");
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			if(!foundBomb) AudioSource.PlayClipAtPoint(found, transform.position);

			foundBomb = true;
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
