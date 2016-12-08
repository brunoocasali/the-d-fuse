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

		if (canDefuse && Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
			StartCoroutine(Defusing());
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

	IEnumerator Defusing()
	{
		AudioSource.PlayClipAtPoint(beep, transform.position);

		yield return new WaitForSeconds (5);

		SceneManager.LoadScene ("YouWin");
	}
}
